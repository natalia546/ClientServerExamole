
namespace AuthorizationExample.UserControls
{
    partial class AuthorizationControl
    {
        /// <summary> 
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.seepasswordbutton = new System.Windows.Forms.Button();
            this.passwordtextBox = new System.Windows.Forms.TextBox();
            this.logintextBox = new System.Windows.Forms.TextBox();
            this.passwordlabel = new System.Windows.Forms.Label();
            this.loginlabel = new System.Windows.Forms.Label();
            this.sendbutton = new System.Windows.Forms.Button();
            this.langbutton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // seepasswordbutton
            // 
            this.seepasswordbutton.Location = new System.Drawing.Point(208, 59);
            this.seepasswordbutton.Name = "seepasswordbutton";
            this.seepasswordbutton.Size = new System.Drawing.Size(91, 23);
            this.seepasswordbutton.TabIndex = 11;
            this.seepasswordbutton.Text = "Посмотреть";
            this.seepasswordbutton.UseVisualStyleBackColor = true;
            this.seepasswordbutton.Click += new System.EventHandler(this.seepasswordbutton_Click);
            // 
            // passwordtextBox
            // 
            this.passwordtextBox.Location = new System.Drawing.Point(91, 61);
            this.passwordtextBox.Name = "passwordtextBox";
            this.passwordtextBox.Size = new System.Drawing.Size(100, 20);
            this.passwordtextBox.TabIndex = 10;
            this.passwordtextBox.UseSystemPasswordChar = true;
            // 
            // logintextBox
            // 
            this.logintextBox.Location = new System.Drawing.Point(91, 29);
            this.logintextBox.Name = "logintextBox";
            this.logintextBox.Size = new System.Drawing.Size(100, 20);
            this.logintextBox.TabIndex = 9;
            // 
            // passwordlabel
            // 
            this.passwordlabel.AutoSize = true;
            this.passwordlabel.Location = new System.Drawing.Point(24, 61);
            this.passwordlabel.Name = "passwordlabel";
            this.passwordlabel.Size = new System.Drawing.Size(53, 13);
            this.passwordlabel.TabIndex = 8;
            this.passwordlabel.Text = "Password";
            // 
            // loginlabel
            // 
            this.loginlabel.AutoSize = true;
            this.loginlabel.Location = new System.Drawing.Point(21, 29);
            this.loginlabel.Name = "loginlabel";
            this.loginlabel.Size = new System.Drawing.Size(33, 13);
            this.loginlabel.TabIndex = 7;
            this.loginlabel.Text = "Login";
            // 
            // sendbutton
            // 
            this.sendbutton.Location = new System.Drawing.Point(91, 97);
            this.sendbutton.Name = "sendbutton";
            this.sendbutton.Size = new System.Drawing.Size(100, 23);
            this.sendbutton.TabIndex = 6;
            this.sendbutton.Text = "Отправить";
            this.sendbutton.UseVisualStyleBackColor = true;
            this.sendbutton.Click += new System.EventHandler(this.sendbutton_Click);
            // 
            // langbutton
            // 
            this.langbutton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.langbutton.Location = new System.Drawing.Point(271, 97);
            this.langbutton.Name = "langbutton";
            this.langbutton.Size = new System.Drawing.Size(28, 23);
            this.langbutton.TabIndex = 12;
            this.langbutton.Text = "ru";
            this.langbutton.UseVisualStyleBackColor = true;
            this.langbutton.Click += new System.EventHandler(this.langbutton_Click);
            // 
            // AuthorizationControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.langbutton);
            this.Controls.Add(this.seepasswordbutton);
            this.Controls.Add(this.passwordtextBox);
            this.Controls.Add(this.logintextBox);
            this.Controls.Add(this.passwordlabel);
            this.Controls.Add(this.loginlabel);
            this.Controls.Add(this.sendbutton);
            this.Name = "AuthorizationControl";
            this.Size = new System.Drawing.Size(333, 184);
            this.Load += new System.EventHandler(this.AuthorizationControl_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button seepasswordbutton;
        private System.Windows.Forms.TextBox passwordtextBox;
        private System.Windows.Forms.TextBox logintextBox;
        private System.Windows.Forms.Label passwordlabel;
        private System.Windows.Forms.Label loginlabel;
        private System.Windows.Forms.Button sendbutton;
        private System.Windows.Forms.Button langbutton;
    }
}
