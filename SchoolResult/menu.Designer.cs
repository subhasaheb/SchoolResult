namespace SchoolResult
{
    partial class menu
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
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.btnResult9to10 = new System.Windows.Forms.Button();
            this.btnResult5to8 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button5
            // 
            this.button5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button5.Location = new System.Drawing.Point(197, 263);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(230, 37);
            this.button5.TabIndex = 10;
            this.button5.Text = "Extract Result of V to VIII";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button4
            // 
            this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.Location = new System.Drawing.Point(197, 203);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(230, 34);
            this.button4.TabIndex = 9;
            this.button4.Text = "Enter Result Of - V to VIII";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Location = new System.Drawing.Point(197, 143);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(230, 36);
            this.button3.TabIndex = 8;
            this.button3.Text = "Enter Result Of - IX and X";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // btnResult9to10
            // 
            this.btnResult9to10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnResult9to10.Location = new System.Drawing.Point(197, 83);
            this.btnResult9to10.Name = "btnResult9to10";
            this.btnResult9to10.Size = new System.Drawing.Size(230, 35);
            this.btnResult9to10.TabIndex = 7;
            this.btnResult9to10.Text = "Generate query for insert result";
            this.btnResult9to10.UseVisualStyleBackColor = true;
            this.btnResult9to10.Click += new System.EventHandler(this.btnResult9to10_Click);
            // 
            // btnResult5to8
            // 
            this.btnResult5to8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnResult5to8.Location = new System.Drawing.Point(197, 23);
            this.btnResult5to8.Name = "btnResult5to8";
            this.btnResult5to8.Size = new System.Drawing.Size(230, 33);
            this.btnResult5to8.TabIndex = 6;
            this.btnResult5to8.Text = "Add Student";
            this.btnResult5to8.UseVisualStyleBackColor = true;
            this.btnResult5to8.Click += new System.EventHandler(this.btnResult5to8_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(197, 388);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(230, 37);
            this.button1.TabIndex = 11;
            this.button1.Text = "Exit Application";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(197, 326);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(230, 37);
            this.button2.TabIndex = 12;
            this.button2.Text = "Extract Result of  IX and X";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(630, 472);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.btnResult9to10);
            this.Controls.Add(this.btnResult5to8);
            this.MaximizeBox = false;
            this.Name = "menu";
            this.Text = "Menu";
            this.Load += new System.EventHandler(this.menu_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button btnResult9to10;
        private System.Windows.Forms.Button btnResult5to8;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}