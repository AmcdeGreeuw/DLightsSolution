namespace WindowsUdpPacket
{
    partial class WindowsUdp
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblreceivedAddres = new System.Windows.Forms.Label();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.txtToSend = new System.Windows.Forms.TextBox();
            this.txtSendToPort = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtSendAddress = new System.Windows.Forms.TextBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.btnStop = new System.Windows.Forms.Button();
            this.txtReceived = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtUrl = new System.Windows.Forms.TextBox();
            this.btnListen = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblreceivedAddres
            // 
            this.lblreceivedAddres.AutoSize = true;
            this.lblreceivedAddres.Location = new System.Drawing.Point(44, 39);
            this.lblreceivedAddres.Name = "lblreceivedAddres";
            this.lblreceivedAddres.Size = new System.Drawing.Size(91, 13);
            this.lblreceivedAddres.TabIndex = 27;
            this.lblreceivedAddres.Text = "lblreceivedAddres";
            // 
            // checkBox2
            // 
            this.checkBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(497, 226);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(67, 17);
            this.checkBox2.TabIndex = 26;
            this.checkBox2.Text = "use TCP";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // txtToSend
            // 
            this.txtToSend.AcceptsReturn = true;
            this.txtToSend.AcceptsTab = true;
            this.txtToSend.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtToSend.Location = new System.Drawing.Point(47, 263);
            this.txtToSend.Multiline = true;
            this.txtToSend.Name = "txtToSend";
            this.txtToSend.Size = new System.Drawing.Size(613, 110);
            this.txtToSend.TabIndex = 25;
            // 
            // txtSendToPort
            // 
            this.txtSendToPort.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtSendToPort.Location = new System.Drawing.Point(251, 224);
            this.txtSendToPort.Name = "txtSendToPort";
            this.txtSendToPort.Size = new System.Drawing.Size(37, 20);
            this.txtSendToPort.TabIndex = 24;
            this.txtSendToPort.Text = "6060";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(44, 227);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(18, 13);
            this.label2.TabIndex = 23;
            this.label2.Text = "ip:";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // txtSendAddress
            // 
            this.txtSendAddress.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtSendAddress.Location = new System.Drawing.Point(68, 224);
            this.txtSendAddress.Name = "txtSendAddress";
            this.txtSendAddress.Size = new System.Drawing.Size(178, 20);
            this.txtSendAddress.TabIndex = 22;
            this.txtSendAddress.Text = "127.0.0.1";
            // 
            // btnSend
            // 
            this.btnSend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSend.Location = new System.Drawing.Point(294, 222);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(75, 23);
            this.btnSend.TabIndex = 21;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // txtPort
            // 
            this.txtPort.Location = new System.Drawing.Point(251, 16);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(37, 20);
            this.txtPort.TabIndex = 20;
            this.txtPort.Text = "4546";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(497, 19);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(67, 17);
            this.checkBox1.TabIndex = 19;
            this.checkBox1.Text = "use TCP";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(375, 14);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(75, 23);
            this.btnStop.TabIndex = 18;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // txtReceived
            // 
            this.txtReceived.AcceptsReturn = true;
            this.txtReceived.AcceptsTab = true;
            this.txtReceived.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtReceived.Location = new System.Drawing.Point(47, 71);
            this.txtReceived.Multiline = true;
            this.txtReceived.Name = "txtReceived";
            this.txtReceived.Size = new System.Drawing.Size(613, 136);
            this.txtReceived.TabIndex = 17;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(44, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(18, 13);
            this.label1.TabIndex = 16;
            this.label1.Text = "ip:";
            // 
            // txtUrl
            // 
            this.txtUrl.Location = new System.Drawing.Point(68, 16);
            this.txtUrl.Name = "txtUrl";
            this.txtUrl.Size = new System.Drawing.Size(178, 20);
            this.txtUrl.TabIndex = 15;
            this.txtUrl.Text = "127.0.0.1";
            // 
            // btnListen
            // 
            this.btnListen.Location = new System.Drawing.Point(294, 14);
            this.btnListen.Name = "btnListen";
            this.btnListen.Size = new System.Drawing.Size(75, 23);
            this.btnListen.TabIndex = 14;
            this.btnListen.Text = "Listen";
            this.btnListen.UseVisualStyleBackColor = true;
            this.btnListen.Click += new System.EventHandler(this.btnListen_Click);
            // 
            // WindowsUdp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(701, 387);
            this.Controls.Add(this.lblreceivedAddres);
            this.Controls.Add(this.checkBox2);
            this.Controls.Add(this.txtToSend);
            this.Controls.Add(this.txtSendToPort);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtSendAddress);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.txtPort);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.txtReceived);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtUrl);
            this.Controls.Add(this.btnListen);
            this.Name = "WindowsUdp";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblreceivedAddres;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.TextBox txtToSend;
        private System.Windows.Forms.TextBox txtSendToPort;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtSendAddress;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.TextBox txtReceived;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtUrl;
        private System.Windows.Forms.Button btnListen;
    }
}

