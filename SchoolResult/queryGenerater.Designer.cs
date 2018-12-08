namespace SchoolResult
{
    partial class queryGenerater
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
            this.btnGenerate = new System.Windows.Forms.Button();
            this.txtQuery = new System.Windows.Forms.TextBox();
            this.btnUpdateDB = new System.Windows.Forms.Button();
            this.rd5to8Formative = new System.Windows.Forms.RadioButton();
            this.rd5to8Summative = new System.Windows.Forms.RadioButton();
            this.rdResult9to10 = new System.Windows.Forms.RadioButton();
            this.btnMenu = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnGenerate
            // 
            this.btnGenerate.Location = new System.Drawing.Point(142, 55);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(107, 23);
            this.btnGenerate.TabIndex = 0;
            this.btnGenerate.Text = "Generate";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // txtQuery
            // 
            this.txtQuery.Location = new System.Drawing.Point(12, 84);
            this.txtQuery.Multiline = true;
            this.txtQuery.Name = "txtQuery";
            this.txtQuery.ReadOnly = true;
            this.txtQuery.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtQuery.Size = new System.Drawing.Size(616, 245);
            this.txtQuery.TabIndex = 1;
            // 
            // btnUpdateDB
            // 
            this.btnUpdateDB.Location = new System.Drawing.Point(217, 349);
            this.btnUpdateDB.Name = "btnUpdateDB";
            this.btnUpdateDB.Size = new System.Drawing.Size(159, 23);
            this.btnUpdateDB.TabIndex = 2;
            this.btnUpdateDB.Text = "Update DB";
            this.btnUpdateDB.UseVisualStyleBackColor = true;
            this.btnUpdateDB.Visible = false;
            this.btnUpdateDB.Click += new System.EventHandler(this.btnUpdateDB_Click);
            // 
            // rd5to8Formative
            // 
            this.rd5to8Formative.AutoSize = true;
            this.rd5to8Formative.Location = new System.Drawing.Point(61, 13);
            this.rd5to8Formative.Name = "rd5to8Formative";
            this.rd5to8Formative.Size = new System.Drawing.Size(136, 17);
            this.rd5to8Formative.TabIndex = 3;
            this.rd5to8Formative.TabStop = true;
            this.rd5to8Formative.Text = "Result Formative(V-VIII)";
            this.rd5to8Formative.UseVisualStyleBackColor = true;
            this.rd5to8Formative.CheckedChanged += new System.EventHandler(this.rd5to8Summative_CheckedChanged);
            // 
            // rd5to8Summative
            // 
            this.rd5to8Summative.AutoSize = true;
            this.rd5to8Summative.Location = new System.Drawing.Point(252, 12);
            this.rd5to8Summative.Name = "rd5to8Summative";
            this.rd5to8Summative.Size = new System.Drawing.Size(142, 17);
            this.rd5to8Summative.TabIndex = 4;
            this.rd5to8Summative.TabStop = true;
            this.rd5to8Summative.Text = "Result Summative(V-VIII)";
            this.rd5to8Summative.UseVisualStyleBackColor = true;
            this.rd5to8Summative.CheckedChanged += new System.EventHandler(this.rd5to8Summative_CheckedChanged);
            // 
            // rdResult9to10
            // 
            this.rdResult9to10.AutoSize = true;
            this.rdResult9to10.Location = new System.Drawing.Point(453, 12);
            this.rdResult9to10.Name = "rdResult9to10";
            this.rdResult9to10.Size = new System.Drawing.Size(81, 17);
            this.rdResult9to10.TabIndex = 5;
            this.rdResult9to10.TabStop = true;
            this.rdResult9to10.Text = "Result(IX-X)";
            this.rdResult9to10.UseVisualStyleBackColor = true;
            this.rdResult9to10.CheckedChanged += new System.EventHandler(this.rd5to8Summative_CheckedChanged);
            // 
            // btnMenu
            // 
            this.btnMenu.Location = new System.Drawing.Point(486, 55);
            this.btnMenu.Name = "btnMenu";
            this.btnMenu.Size = new System.Drawing.Size(90, 23);
            this.btnMenu.TabIndex = 6;
            this.btnMenu.Text = "Menu";
            this.btnMenu.UseVisualStyleBackColor = true;
            this.btnMenu.Click += new System.EventHandler(this.btnMenu_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(305, 55);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(107, 23);
            this.btnClear.TabIndex = 7;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // queryGenerater
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(640, 399);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnMenu);
            this.Controls.Add(this.rdResult9to10);
            this.Controls.Add(this.rd5to8Summative);
            this.Controls.Add(this.rd5to8Formative);
            this.Controls.Add(this.btnUpdateDB);
            this.Controls.Add(this.txtQuery);
            this.Controls.Add(this.btnGenerate);
            this.MaximizeBox = false;
            this.Name = "queryGenerater";
            this.Text = "Query Generater";
            this.Load += new System.EventHandler(this.queryGenerater_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.TextBox txtQuery;
        private System.Windows.Forms.Button btnUpdateDB;
        private System.Windows.Forms.RadioButton rd5to8Formative;
        private System.Windows.Forms.RadioButton rd5to8Summative;
        private System.Windows.Forms.RadioButton rdResult9to10;
        private System.Windows.Forms.Button btnMenu;
        private System.Windows.Forms.Button btnClear;
    }
}