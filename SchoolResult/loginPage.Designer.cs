namespace SchoolResult
{
    partial class loginPage
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
            this.crtAccButton = new System.Windows.Forms.Button();
            this.usrnmTextBox = new System.Windows.Forms.TextBox();
            this.passwordTextBox = new System.Windows.Forms.TextBox();
            this.delAccButton = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.chngPassbutton = new System.Windows.Forms.Button();
            this.rstAllAccButton = new System.Windows.Forms.Button();
            this.exitButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // crtAccButton
            // 
            this.crtAccButton.Location = new System.Drawing.Point(9, 158);
            this.crtAccButton.Margin = new System.Windows.Forms.Padding(2);
            this.crtAccButton.Name = "crtAccButton";
            this.crtAccButton.Size = new System.Drawing.Size(73, 41);
            this.crtAccButton.TabIndex = 0;
            this.crtAccButton.Text = "Create Account";
            this.crtAccButton.UseVisualStyleBackColor = true;
            this.crtAccButton.Click += new System.EventHandler(this.crtAccButton_Click);
            // 
            // usrnmTextBox
            // 
            this.usrnmTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.usrnmTextBox.Location = new System.Drawing.Point(70, 37);
            this.usrnmTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.usrnmTextBox.Name = "usrnmTextBox";
            this.usrnmTextBox.Size = new System.Drawing.Size(139, 26);
            this.usrnmTextBox.TabIndex = 1;
            this.usrnmTextBox.Text = "User Name";
            this.usrnmTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.usrnmTextBox.Enter += new System.EventHandler(this.usrnmTextBox_Enter);
            // 
            // passwordTextBox
            // 
            this.passwordTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.passwordTextBox.Location = new System.Drawing.Point(70, 94);
            this.passwordTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.passwordTextBox.Name = "passwordTextBox";
            this.passwordTextBox.Size = new System.Drawing.Size(139, 26);
            this.passwordTextBox.TabIndex = 2;
            this.passwordTextBox.Text = "Password";
            this.passwordTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.passwordTextBox.Enter += new System.EventHandler(this.passwordTextBox_Enter);
            // 
            // delAccButton
            // 
            this.delAccButton.Location = new System.Drawing.Point(107, 158);
            this.delAccButton.Margin = new System.Windows.Forms.Padding(2);
            this.delAccButton.Name = "delAccButton";
            this.delAccButton.Size = new System.Drawing.Size(73, 41);
            this.delAccButton.TabIndex = 3;
            this.delAccButton.Text = "Delete Account";
            this.delAccButton.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(205, 158);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(73, 41);
            this.button1.TabIndex = 4;
            this.button1.Text = "Login";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.LoginButton_Click);
            // 
            // chngPassbutton
            // 
            this.chngPassbutton.Location = new System.Drawing.Point(9, 231);
            this.chngPassbutton.Margin = new System.Windows.Forms.Padding(2);
            this.chngPassbutton.Name = "chngPassbutton";
            this.chngPassbutton.Size = new System.Drawing.Size(73, 41);
            this.chngPassbutton.TabIndex = 5;
            this.chngPassbutton.Text = "Change Password";
            this.chngPassbutton.UseVisualStyleBackColor = true;
            this.chngPassbutton.Click += new System.EventHandler(this.chngPassbutton_Click);
            // 
            // rstAllAccButton
            // 
            this.rstAllAccButton.Location = new System.Drawing.Point(107, 231);
            this.rstAllAccButton.Margin = new System.Windows.Forms.Padding(2);
            this.rstAllAccButton.Name = "rstAllAccButton";
            this.rstAllAccButton.Size = new System.Drawing.Size(73, 41);
            this.rstAllAccButton.TabIndex = 6;
            this.rstAllAccButton.Text = "Reset All Accounts";
            this.rstAllAccButton.UseVisualStyleBackColor = true;
            // 
            // exitButton
            // 
            this.exitButton.Location = new System.Drawing.Point(205, 231);
            this.exitButton.Margin = new System.Windows.Forms.Padding(2);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(73, 41);
            this.exitButton.TabIndex = 7;
            this.exitButton.Text = "Exit";
            this.exitButton.UseVisualStyleBackColor = true;
            this.exitButton.Click += new System.EventHandler(this.exitbutton_Click);
            // 
            // loginPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(286, 288);
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.rstAllAccButton);
            this.Controls.Add(this.chngPassbutton);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.delAccButton);
            this.Controls.Add(this.passwordTextBox);
            this.Controls.Add(this.usrnmTextBox);
            this.Controls.Add(this.crtAccButton);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "loginPage";
            this.Text = "Login Page";
            this.Load += new System.EventHandler(this.loginPage_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button crtAccButton;
        private System.Windows.Forms.TextBox passwordTextBox;
        private System.Windows.Forms.Button delAccButton;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button chngPassbutton;
        protected internal System.Windows.Forms.TextBox usrnmTextBox;
        private System.Windows.Forms.Button rstAllAccButton;
        private System.Windows.Forms.Button exitButton;
    }
}