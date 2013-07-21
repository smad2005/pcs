namespace GuiConfig
{
    partial class Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.label1 = new System.Windows.Forms.Label();
            this.t_cookie = new System.Windows.Forms.TextBox();
            this.b_ok = new System.Windows.Forms.Button();
            this.b_cancel = new System.Windows.Forms.Button();
            this.c_format = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.ch_public = new System.Windows.Forms.CheckBox();
            this.llEnterInAcoount = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Cookie";
            // 
            // t_cookie
            // 
            this.t_cookie.Location = new System.Drawing.Point(21, 31);
            this.t_cookie.Name = "t_cookie";
            this.t_cookie.Size = new System.Drawing.Size(201, 20);
            this.t_cookie.TabIndex = 1;
            this.t_cookie.TextChanged += new System.EventHandler(this.t_cookie_TextChanged);
            // 
            // b_ok
            // 
            this.b_ok.Location = new System.Drawing.Point(66, 181);
            this.b_ok.Name = "b_ok";
            this.b_ok.Size = new System.Drawing.Size(75, 23);
            this.b_ok.TabIndex = 2;
            this.b_ok.Text = "Ок";
            this.b_ok.UseVisualStyleBackColor = true;
            this.b_ok.Click += new System.EventHandler(this.b_ok_Click);
            // 
            // b_cancel
            // 
            this.b_cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.b_cancel.Location = new System.Drawing.Point(147, 181);
            this.b_cancel.Name = "b_cancel";
            this.b_cancel.Size = new System.Drawing.Size(75, 23);
            this.b_cancel.TabIndex = 3;
            this.b_cancel.Text = "Отмена";
            this.b_cancel.UseVisualStyleBackColor = true;
            this.b_cancel.Click += new System.EventHandler(this.b_cancel_Click);
            // 
            // c_format
            // 
            this.c_format.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.c_format.FormattingEnabled = true;
            this.c_format.Location = new System.Drawing.Point(21, 75);
            this.c_format.Name = "c_format";
            this.c_format.Size = new System.Drawing.Size(201, 21);
            this.c_format.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(111, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Формат сохранения";
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(18, 131);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(163, 13);
            this.linkLabel1.TabIndex = 6;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Удалить из контексного меню";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // ch_public
            // 
            this.ch_public.AutoSize = true;
            this.ch_public.Location = new System.Drawing.Point(21, 111);
            this.ch_public.Name = "ch_public";
            this.ch_public.Size = new System.Drawing.Size(206, 17);
            this.ch_public.TabIndex = 7;
            this.ch_public.Text = "Публиковать для всех посетителей";
            this.ch_public.UseVisualStyleBackColor = true;
            // 
            // llEnterInAcoount
            // 
            this.llEnterInAcoount.AutoSize = true;
            this.llEnterInAcoount.Location = new System.Drawing.Point(18, 154);
            this.llEnterInAcoount.Name = "llEnterInAcoount";
            this.llEnterInAcoount.Size = new System.Drawing.Size(89, 13);
            this.llEnterInAcoount.TabIndex = 8;
            this.llEnterInAcoount.TabStop = true;
            this.llEnterInAcoount.Text = "Войти в аккаунт";
            this.llEnterInAcoount.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llEnterInAcount_LinkClicked);
            // 
            // Main
            // 
            this.AcceptButton = this.b_ok;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.b_cancel;
            this.ClientSize = new System.Drawing.Size(236, 213);
            this.Controls.Add(this.llEnterInAcoount);
            this.Controls.Add(this.ch_public);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.c_format);
            this.Controls.Add(this.b_cancel);
            this.Controls.Add(this.b_ok);
            this.Controls.Add(this.t_cookie);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Main";
            this.Text = "GuiConfig";
            this.Load += new System.EventHandler(this.Main_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox t_cookie;
        private System.Windows.Forms.Button b_ok;
        private System.Windows.Forms.Button b_cancel;
        private System.Windows.Forms.ComboBox c_format;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.CheckBox ch_public;
        private System.Windows.Forms.LinkLabel llEnterInAcoount;
    }
}

