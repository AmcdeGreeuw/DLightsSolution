using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace WindowsUdpPacket
{
    public class HttpHandler
    {
        TcpClient _tcpClient = null;
        ServerListener _listener = null;

        private Stream inputStream;
        public StreamWriter outputStream;

        public string http_method;
        public string http_url;
        public string http_protocol_versionstring;
        public Hashtable httpHeaders = new Hashtable();
        public string body { get; set; }


        private static int MAX_POST_SIZE = 10 * 1024 * 1024; // 10MB

        public ReceivedText OnReceived { get; set; }

        public HttpHandler(TcpClient tcpClient, ServerListener listener)
        {
            _tcpClient = tcpClient; _listener = listener;
        }

        public void Process()
        {
            // we can't use a StreamReader for input, because it buffers up extra data on us inside it's
            // "processed" view of the world, and we want the data raw after the headers
            inputStream = new BufferedStream(_tcpClient.GetStream());

            // we probably shouldn't be using a streamwriter for all output from handlers either
            outputStream = new StreamWriter(new BufferedStream(_tcpClient.GetStream()));
            try
            {
                parseRequest();
                readHeaders();
                if (http_method.Equals("GET"))
                {
                   // handleGETRequest();
                }
                else if (http_method.Equals("POST"))
                {
                   // handlePOSTRequest();
                }
                writeSuccess();
                outputStream.WriteLine(body);  
            }
            catch (Exception ex)
            {                
                writeFailure(ex);
            }
            outputStream.Flush();
            // bs.Flush(); // flush any remaining output
            inputStream = null; outputStream = null; // bs = null;            
            _tcpClient.Close(); 
        }
        private string streamReadLine(Stream inputStream)
        {
            int next_char;
            string data = "";
            while (true)
            {
                next_char = inputStream.ReadByte();
                if (next_char == '\n') { break; }
                if (next_char == '\r') { continue; }
                if (next_char == -1) { Thread.Sleep(1); continue; };
                data += Convert.ToChar(next_char);
            }
            return data;
        }
        public void parseRequest()
        {
            String request = streamReadLine(inputStream);
            string[] tokens = request.Split(' ');
            if (tokens.Length != 3)
            {
                throw new Exception("invalid http request line");
            }
            http_method = tokens[0].ToUpper();
            http_url = tokens[1];
            http_protocol_versionstring = tokens[2];

            verbose("starting: " + request);
        }
        public void readHeaders()
        {
            verbose("readHeaders()");
            string line;
            while ((line = streamReadLine(inputStream)) != null)
            {
                if (line.Equals(""))
                {
                    verbose("got headers");
                    return;
                }

                int separator = line.IndexOf(':');
                if (separator == -1)
                {
                    throw new Exception("invalid http header line: " + line);
                }
                string name = line.Substring(0, separator);
                int pos = separator + 1;
                while ((pos < line.Length) && (line[pos] == ' '))
                {
                    pos++; // strip any spaces
                }

                string value = line.Substring(pos, line.Length - pos);
                verbose("header: {0}:{1}", name, value);
                httpHeaders[name] = value;
            }
        }

        public void writeSuccess(string content_type = "text/html")
        {
            // this is the successful HTTP response line
            outputStream.WriteLine("HTTP/1.0 200 OK");
            // these are the HTTP headers...          
            outputStream.WriteLine("Content-Type: " + content_type);
            outputStream.WriteLine("Connection: close");
            // ..add your own headers here if you like

            outputStream.WriteLine(""); // this terminates the HTTP headers.. everything after this is HTTP body..
        }

        public void writeFailure()
        {
            // this is an http 404 failure response
            outputStream.WriteLine("HTTP/1.0 404 File not found");
            // these are the HTTP headers
            outputStream.WriteLine("Connection: close");
            // ..add your own headers here

            outputStream.WriteLine(""); // this terminates the HTTP headers.
        }

        void writeFailure(Exception ex)
        {
            OnReceivedHandler(ex.Message);
            writeFailure();
        }
        void verbose(string msg)
        {
            OnReceivedHandler(msg);
        }
        void verbose(string frmt, params object[] args)
        {
            OnReceivedHandler(string.Format(frmt, args));
        }

        void OnReceivedHandler(string msg)
        {
            if (this.OnReceived != null)
                OnReceived(msg);
        }
    }
}
