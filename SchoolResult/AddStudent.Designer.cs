namespace SchoolResult
{
    partial class AddStudent
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
            this.grpAddStudent = new System.Windows.Forms.GroupBox();
            this.btnMenu = new System.Windows.Forms.Button();
            this.txtRoll = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.cmbSess = new System.Windows.Forms.ComboBox();
            this.lblSession = new System.Windows.Forms.Label();
            this.cmbSec = new System.Windows.Forms.ComboBox();
            this.lblSection = new System.Windows.Forms.Label();
            this.cmbClass = new System.Windows.Forms.ComboBox();
            this.lblClass = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.grpUpdateStudent = new System.Windows.Forms.GroupBox();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.cmbSessUp = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbSecUp = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbClassUp = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.rstGrid = new System.Windows.Forms.DataGridView();
            this.grpAddStudent.SuspendLayout();
            this.grpUpdateStudent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rstGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // grpAddStudent
            // 
            this.grpAddStudent.Controls.Add(this.btnMenu);
            this.grpAddStudent.Controls.Add(this.txtRoll);
            this.grpAddStudent.Controls.Add(this.label1);
            this.grpAddStudent.Controls.Add(this.btnAdd);
            this.grpAddStudent.Controls.Add(this.cmbSess);
            this.grpAddStudent.Controls.Add(this.lblSession);
            this.grpAddStudent.Controls.Add(this.cmbSec);
            this.grpAddStudent.Controls.Add(this.lblSection);
            this.grpAddStudent.Controls.Add(this.cmbClass);
            this.grpAddStudent.Controls.Add(this.lblClass);
            this.grpAddStudent.Controls.Add(this.txtName);
            this.grpAddStudent.Controls.Add(this.lblName);
            this.grpAddStudent.Location = new System.Drawing.Point(12, 12);
            this.grpAddStudent.Name = "grpAddStudent";
            this.grpAddStudent.Size = new System.Drawing.Size(711, 117);
            this.grpAddStudent.TabIndex = 0;
            this.grpAddStudent.TabStop = false;
            this.grpAddStudent.Text = "Add Student";
            // 
            // btnMenu
            // 
            this.btnMenu.Location = new System.Drawing.Point(531, 77);
            this.btnMenu.Name = "btnMenu";
            this.btnMenu.Size = new System.Drawing.Size(138, 23);
            this.btnMenu.TabIndex = 11;
            this.btnMenu.Text = "Menu";
            this.btnMenu.UseVisualStyleBackColor = true;
            this.btnMenu.Click += new System.EventHandler(this.btnMenu_Click);
            // 
            // txtRoll
            // 
            this.txtRoll.Location = new System.Drawing.Point(521, 36);
            this.txtRoll.Name = "txtRoll";
            this.txtRoll.Size = new System.Drawing.Size(49, 20);
            this.txtRoll.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(490, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(28, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Roll:";
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(254, 77);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(138, 23);
            this.btnAdd.TabIndex = 8;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // cmbSess
            // 
            this.cmbSess.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSess.FormattingEnabled = true;
            this.cmbSess.Location = new System.Drawing.Point(628, 37);
            this.cmbSess.Name = "cmbSess";
            this.cmbSess.Size = new System.Drawing.Size(64, 21);
            this.cmbSess.TabIndex = 7;
            // 
            // lblSession
            // 
            this.lblSession.AutoSize = true;
            this.lblSession.Location = new System.Drawing.Point(576, 40);
            this.lblSession.Name = "lblSession";
            this.lblSession.Size = new System.Drawing.Size(47, 13);
            this.lblSession.TabIndex = 6;
            this.lblSession.Text = "Session:";
            // 
            // cmbSec
            // 
            this.cmbSec.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSec.FormattingEnabled = true;
            this.cmbSec.Location = new System.Drawing.Point(436, 36);
            this.cmbSec.Name = "cmbSec";
            this.cmbSec.Size = new System.Drawing.Size(48, 21);
            this.cmbSec.TabIndex = 5;
            // 
            // lblSection
            // 
            this.lblSection.AutoSize = true;
            this.lblSection.Location = new System.Drawing.Point(384, 40);
            this.lblSection.Name = "lblSection";
            this.lblSection.Size = new System.Drawing.Size(46, 13);
            this.lblSection.TabIndex = 4;
            this.lblSection.Text = "Section:";
            // 
            // cmbClass
            // 
            this.cmbClass.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbClass.FormattingEnabled = true;
            this.cmbClass.Location = new System.Drawing.Point(333, 37);
            this.cmbClass.Name = "cmbClass";
            this.cmbClass.Size = new System.Drawing.Size(45, 21);
            this.cmbClass.TabIndex = 3;
            // 
            // lblClass
            // 
            this.lblClass.AutoSize = true;
            this.lblClass.Location = new System.Drawing.Point(292, 40);
            this.lblClass.Name = "lblClass";
            this.lblClass.Size = new System.Drawing.Size(35, 13);
            this.lblClass.TabIndex = 2;
            this.lblClass.Text = "Class:";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(50, 37);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(236, 20);
            this.txtName.TabIndex = 1;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(6, 40);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(38, 13);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "Name:";
            // 
            // grpUpdateStudent
            // 
            this.grpUpdateStudent.Controls.Add(this.btnGenerate);
            this.grpUpdateStudent.Controls.Add(this.btnUpdate);
            this.grpUpdateStudent.Controls.Add(this.cmbSessUp);
            this.grpUpdateStudent.Controls.Add(this.label2);
            this.grpUpdateStudent.Controls.Add(this.cmbSecUp);
            this.grpUpdateStudent.Controls.Add(this.label3);
            this.grpUpdateStudent.Controls.Add(this.cmbClassUp);
            this.grpUpdateStudent.Controls.Add(this.label4);
            this.grpUpdateStudent.Controls.Add(this.rstGrid);
            this.grpUpdateStudent.Location = new System.Drawing.Point(12, 149);
            this.grpUpdateStudent.Name = "grpUpdateStudent";
            this.grpUpdateStudent.Size = new System.Drawing.Size(711, 318);
            this.grpUpdateStudent.TabIndex = 1;
            this.grpUpdateStudent.TabStop = false;
            this.grpUpdateStudent.Text = "Update Student";
            // 
            // btnGenerate
            // 
            this.btnGenerate.Location = new System.Drawing.Point(563, 22);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(75, 23);
            this.btnGenerate.TabIndex = 15;
            this.btnGenerate.Text = "Generate";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(270, 284);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(147, 23);
            this.btnUpdate.TabIndex = 14;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Visible = false;
            // 
            // cmbSessUp
            // 
            this.cmbSessUp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSessUp.FormattingEnabled = true;
            this.cmbSessUp.Location = new System.Drawing.Point(434, 22);
            this.cmbSessUp.Name = "cmbSessUp";
            this.cmbSessUp.Size = new System.Drawing.Size(64, 21);
            this.cmbSessUp.TabIndex = 13;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(382, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Session:";
            // 
            // cmbSecUp
            // 
            this.cmbSecUp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSecUp.FormattingEnabled = true;
            this.cmbSecUp.Location = new System.Drawing.Point(292, 21);
            this.cmbSecUp.Name = "cmbSecUp";
            this.cmbSecUp.Size = new System.Drawing.Size(48, 21);
            this.cmbSecUp.TabIndex = 11;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(240, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Section:";
            // 
            // cmbClassUp
            // 
            this.cmbClassUp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbClassUp.FormattingEnabled = true;
            this.cmbClassUp.Location = new System.Drawing.Point(139, 22);
            this.cmbClassUp.Name = "cmbClassUp";
            this.cmbClassUp.Size = new System.Drawing.Size(45, 21);
            this.cmbClassUp.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(98, 25);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Class:";
            // 
            // rstGrid
            // 
            this.rstGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.rstGrid.Location = new System.Drawing.Point(9, 69);
            this.rstGrid.Name = "rstGrid";
            this.rstGrid.Size = new System.Drawing.Size(696, 209);
            this.rstGrid.TabIndex = 0;
            // 
            // AddStudent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(735, 479);
            this.Controls.Add(this.grpUpdateStudent);
            this.Controls.Add(this.grpAddStudent);
            this.MaximizeBox = false;
            this.Name = "AddStudent";
            this.Text = "Add Student";
            this.Load += new System.EventHandler(this.AddStudent_Load);
            this.grpAddStudent.ResumeLayout(false);
            this.grpAddStudent.PerformLayout();
            this.grpUpdateStudent.ResumeLayout(false);
            this.grpUpdateStudent.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rstGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpAddStudent;
        private System.Windows.Forms.GroupBox grpUpdateStudent;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.ComboBox cmbSess;
        private System.Windows.Forms.Label lblSession;
        private System.Windows.Forms.ComboBox cmbSec;
        private System.Windows.Forms.Label lblSection;
        private System.Windows.Forms.ComboBox cmbClass;
        private System.Windows.Forms.Label lblClass;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtRoll;
        private System.Windows.Forms.Button btnMenu;
        private System.Windows.Forms.DataGridView rstGrid;
        private System.Windows.Forms.ComboBox cmbSessUp;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbSecUp;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbClassUp;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnGenerate;
    }
}