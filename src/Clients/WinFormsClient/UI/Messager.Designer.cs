namespace WinFormsClient;

partial class Messager
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
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
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
            this.btnCreateChat = new System.Windows.Forms.Button();
            this.listChats = new System.Windows.Forms.ListBox();
            this.listMessages = new System.Windows.Forms.ListBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnCreateChat
            // 
            this.btnCreateChat.Location = new System.Drawing.Point(12, 12);
            this.btnCreateChat.Name = "btnCreateChat";
            this.btnCreateChat.Size = new System.Drawing.Size(163, 29);
            this.btnCreateChat.TabIndex = 1;
            this.btnCreateChat.Text = "Create Chat";
            this.btnCreateChat.UseVisualStyleBackColor = true;
            this.btnCreateChat.Click += new System.EventHandler(this.btnCreateChat_Click);
            // 
            // listChats
            // 
            this.listChats.FormattingEnabled = true;
            this.listChats.ItemHeight = 15;
            this.listChats.Location = new System.Drawing.Point(12, 58);
            this.listChats.Name = "listChats";
            this.listChats.Size = new System.Drawing.Size(163, 439);
            this.listChats.TabIndex = 2;
            // 
            // listMessages
            // 
            this.listMessages.FormattingEnabled = true;
            this.listMessages.ItemHeight = 15;
            this.listMessages.Location = new System.Drawing.Point(181, 13);
            this.listMessages.Name = "listMessages";
            this.listMessages.Size = new System.Drawing.Size(344, 409);
            this.listMessages.TabIndex = 3;
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(484, 428);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(41, 69);
            this.btnSend.TabIndex = 9;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // txtMessage
            // 
            this.txtMessage.Location = new System.Drawing.Point(181, 428);
            this.txtMessage.Multiline = true;
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.Size = new System.Drawing.Size(299, 69);
            this.txtMessage.TabIndex = 10;
            // 
            // Messager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(537, 509);
            this.Controls.Add(this.txtMessage);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.listMessages);
            this.Controls.Add(this.listChats);
            this.Controls.Add(this.btnCreateChat);
            this.Name = "Messager";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Messenger";
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    #endregion
    private Button btnCreateChat;
    private ListBox listChats;
    private ListBox listMessages;
    private Button btnSend;
    private TextBox txtMessage;
}
