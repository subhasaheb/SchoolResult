namespace SchoolResult
{
    partial class BulkResult9to10
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnMenu = new System.Windows.Forms.Button();
            this.cmbUnit = new System.Windows.Forms.ComboBox();
            this.lblUnit = new System.Windows.Forms.Label();
            this.cmbSec = new System.Windows.Forms.ComboBox();
            this.lblSec = new System.Windows.Forms.Label();
            this.cmbClass = new System.Windows.Forms.ComboBox();
            this.lblClass = new System.Windows.Forms.Label();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rdComputer = new System.Windows.Forms.RadioButton();
            this.rdWorkEdu = new System.Windows.Forms.RadioButton();
            this.rdGeograph = new System.Windows.Forms.RadioButton();
            this.rdHistory = new System.Windows.Forms.RadioButton();
            this.rdLifeScnc = new System.Windows.Forms.RadioButton();
            this.rdPhyScnc = new System.Windows.Forms.RadioButton();
            this.rdMathematics = new System.Windows.Forms.RadioButton();
            this.rdSecndLan = new System.Windows.Forms.RadioButton();
            this.rdFirstLan = new System.Windows.Forms.RadioButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.rstGrid = new System.Windows.Forms.DataGridView();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rstGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnMenu);
            this.groupBox1.Controls.Add(this.cmbUnit);
            this.groupBox1.Controls.Add(this.lblUnit);
            this.groupBox1.Controls.Add(this.cmbSec);
            this.groupBox1.Controls.Add(this.lblSec);
            this.groupBox1.Controls.Add(this.cmbClass);
            this.groupBox1.Controls.Add(this.lblClass);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(799, 70);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Search Criteria";
            // 
            // btnMenu
            // 
            this.btnMenu.Location = new System.Drawing.Point(659, 20);
            this.btnMenu.Name = "btnMenu";
            this.btnMenu.Size = new System.Drawing.Size(124, 26);
            this.btnMenu.TabIndex = 6;
            this.btnMenu.Text = "Menu";
            this.btnMenu.UseVisualStyleBackColor = true;
            this.btnMenu.Click += new System.EventHandler(this.btnMenu_Click);
            // 
            // cmbUnit
            // 
            this.cmbUnit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbUnit.FormattingEnabled = true;
            this.cmbUnit.Location = new System.Drawing.Point(512, 25);
            this.cmbUnit.Name = "cmbUnit";
            this.cmbUnit.Size = new System.Drawing.Size(59, 21);
            this.cmbUnit.TabIndex = 5;
            this.cmbUnit.SelectedIndexChanged += new System.EventHandler(this.cmbUnit_SelectedIndexChanged);
            // 
            // lblUnit
            // 
            this.lblUnit.AutoSize = true;
            this.lblUnit.Location = new System.Drawing.Point(474, 28);
            this.lblUnit.Name = "lblUnit";
            this.lblUnit.Size = new System.Drawing.Size(29, 13);
            this.lblUnit.TabIndex = 4;
            this.lblUnit.Text = "Unit:";
            // 
            // cmbSec
            // 
            this.cmbSec.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSec.FormattingEnabled = true;
            this.cmbSec.Location = new System.Drawing.Point(371, 25);
            this.cmbSec.Name = "cmbSec";
            this.cmbSec.Size = new System.Drawing.Size(59, 21);
            this.cmbSec.TabIndex = 3;
            this.cmbSec.SelectedIndexChanged += new System.EventHandler(this.cmbSec_SelectedIndexChanged);
            // 
            // lblSec
            // 
            this.lblSec.AutoSize = true;
            this.lblSec.Location = new System.Drawing.Point(333, 28);
            this.lblSec.Name = "lblSec";
            this.lblSec.Size = new System.Drawing.Size(29, 13);
            this.lblSec.TabIndex = 2;
            this.lblSec.Text = "Sec:";
            // 
            // cmbClass
            // 
            this.cmbClass.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbClass.FormattingEnabled = true;
            this.cmbClass.Location = new System.Drawing.Point(233, 25);
            this.cmbClass.Name = "cmbClass";
            this.cmbClass.Size = new System.Drawing.Size(59, 21);
            this.cmbClass.TabIndex = 1;
            this.cmbClass.SelectedIndexChanged += new System.EventHandler(this.cmbClass_SelectedIndexChanged);
            // 
            // lblClass
            // 
            this.lblClass.AutoSize = true;
            this.lblClass.Location = new System.Drawing.Point(195, 28);
            this.lblClass.Name = "lblClass";
            this.lblClass.Size = new System.Drawing.Size(35, 13);
            this.lblClass.TabIndex = 0;
            this.lblClass.Text = "Class:";
            // 
            // btnGenerate
            // 
            this.btnGenerate.Location = new System.Drawing.Point(604, 65);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(155, 23);
            this.btnGenerate.TabIndex = 6;
            this.btnGenerate.Text = "Generate";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rdComputer);
            this.groupBox2.Controls.Add(this.rdWorkEdu);
            this.groupBox2.Controls.Add(this.btnGenerate);
            this.groupBox2.Controls.Add(this.rdGeograph);
            this.groupBox2.Controls.Add(this.rdHistory);
            this.groupBox2.Controls.Add(this.rdLifeScnc);
            this.groupBox2.Controls.Add(this.rdPhyScnc);
            this.groupBox2.Controls.Add(this.rdMathematics);
            this.groupBox2.Controls.Add(this.rdSecndLan);
            this.groupBox2.Controls.Add(this.rdFirstLan);
            this.groupBox2.Location = new System.Drawing.Point(12, 88);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(799, 100);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Select Subject";
            // 
            // rdComputer
            // 
            this.rdComputer.AutoSize = true;
            this.rdComputer.Location = new System.Drawing.Point(436, 68);
            this.rdComputer.Name = "rdComputer";
            this.rdComputer.Size = new System.Drawing.Size(70, 17);
            this.rdComputer.TabIndex = 8;
            this.rdComputer.TabStop = true;
            this.rdComputer.Text = "Computer";
            this.rdComputer.UseVisualStyleBackColor = true;
            // 
            // rdWorkEdu
            // 
            this.rdWorkEdu.AutoSize = true;
            this.rdWorkEdu.Location = new System.Drawing.Point(297, 68);
            this.rdWorkEdu.Name = "rdWorkEdu";
            this.rdWorkEdu.Size = new System.Drawing.Size(102, 17);
            this.rdWorkEdu.TabIndex = 7;
            this.rdWorkEdu.TabStop = true;
            this.rdWorkEdu.Text = "Work Education";
            this.rdWorkEdu.UseVisualStyleBackColor = true;
            // 
            // rdGeograph
            // 
            this.rdGeograph.AutoSize = true;
            this.rdGeograph.Location = new System.Drawing.Point(137, 68);
            this.rdGeograph.Name = "rdGeograph";
            this.rdGeograph.Size = new System.Drawing.Size(77, 17);
            this.rdGeograph.TabIndex = 6;
            this.rdGeograph.TabStop = true;
            this.rdGeograph.Text = "Geography";
            this.rdGeograph.UseVisualStyleBackColor = true;
            this.rdGeograph.CheckedChanged += new System.EventHandler(this.rdGeograph_CheckedChanged);
            // 
            // rdHistory
            // 
            this.rdHistory.AutoSize = true;
            this.rdHistory.Location = new System.Drawing.Point(6, 68);
            this.rdHistory.Name = "rdHistory";
            this.rdHistory.Size = new System.Drawing.Size(57, 17);
            this.rdHistory.TabIndex = 5;
            this.rdHistory.TabStop = true;
            this.rdHistory.Text = "History";
            this.rdHistory.UseVisualStyleBackColor = true;
            this.rdHistory.CheckedChanged += new System.EventHandler(this.rdGeograph_CheckedChanged);
            // 
            // rdLifeScnc
            // 
            this.rdLifeScnc.AutoSize = true;
            this.rdLifeScnc.Location = new System.Drawing.Point(604, 32);
            this.rdLifeScnc.Name = "rdLifeScnc";
            this.rdLifeScnc.Size = new System.Drawing.Size(84, 17);
            this.rdLifeScnc.TabIndex = 4;
            this.rdLifeScnc.TabStop = true;
            this.rdLifeScnc.Text = "Life Science";
            this.rdLifeScnc.UseVisualStyleBackColor = true;
            this.rdLifeScnc.CheckedChanged += new System.EventHandler(this.rdGeograph_CheckedChanged);
            // 
            // rdPhyScnc
            // 
            this.rdPhyScnc.AutoSize = true;
            this.rdPhyScnc.Location = new System.Drawing.Point(436, 32);
            this.rdPhyScnc.Name = "rdPhyScnc";
            this.rdPhyScnc.Size = new System.Drawing.Size(106, 17);
            this.rdPhyScnc.TabIndex = 3;
            this.rdPhyScnc.TabStop = true;
            this.rdPhyScnc.Text = "Physical Science";
            this.rdPhyScnc.UseVisualStyleBackColor = true;
            this.rdPhyScnc.CheckedChanged += new System.EventHandler(this.rdGeograph_CheckedChanged);
            // 
            // rdMathematics
            // 
            this.rdMathematics.AutoSize = true;
            this.rdMathematics.Location = new System.Drawing.Point(297, 32);
            this.rdMathematics.Name = "rdMathematics";
            this.rdMathematics.Size = new System.Drawing.Size(85, 17);
            this.rdMathematics.TabIndex = 2;
            this.rdMathematics.TabStop = true;
            this.rdMathematics.Text = "Mathematics";
            this.rdMathematics.UseVisualStyleBackColor = true;
            this.rdMathematics.CheckedChanged += new System.EventHandler(this.rdGeograph_CheckedChanged);
            // 
            // rdSecndLan
            // 
            this.rdSecndLan.AutoSize = true;
            this.rdSecndLan.Location = new System.Drawing.Point(137, 32);
            this.rdSecndLan.Name = "rdSecndLan";
            this.rdSecndLan.Size = new System.Drawing.Size(113, 17);
            this.rdSecndLan.TabIndex = 1;
            this.rdSecndLan.TabStop = true;
            this.rdSecndLan.Text = "Second Language";
            this.rdSecndLan.UseVisualStyleBackColor = true;
            this.rdSecndLan.CheckedChanged += new System.EventHandler(this.rdGeograph_CheckedChanged);
            // 
            // rdFirstLan
            // 
            this.rdFirstLan.AutoSize = true;
            this.rdFirstLan.Location = new System.Drawing.Point(6, 32);
            this.rdFirstLan.Name = "rdFirstLan";
            this.rdFirstLan.Size = new System.Drawing.Size(95, 17);
            this.rdFirstLan.TabIndex = 0;
            this.rdFirstLan.TabStop = true;
            this.rdFirstLan.Text = "First Language";
            this.rdFirstLan.UseVisualStyleBackColor = true;
            this.rdFirstLan.CheckedChanged += new System.EventHandler(this.rdGeograph_CheckedChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.rstGrid);
            this.groupBox3.Location = new System.Drawing.Point(12, 194);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(799, 397);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Update Result";
            // 
            // rstGrid
            // 
            this.rstGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.rstGrid.Location = new System.Drawing.Point(18, 19);
            this.rstGrid.Name = "rstGrid";
            this.rstGrid.Size = new System.Drawing.Size(765, 378);
            this.rstGrid.TabIndex = 0;
            this.rstGrid.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.rstGrid_CellEndEdit);
            this.rstGrid.CellLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.rstGrid_CellLeave);
            this.rstGrid.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.rstGrid_DataBindingComplete);
            this.rstGrid.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.rstGrid_DataError);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(319, 597);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(155, 23);
            this.btnUpdate.TabIndex = 3;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // BulkResult9to10
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(823, 636);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.Name = "BulkResult9to10";
            this.Text = "Enter Result IX - X";
            this.Load += new System.EventHandler(this.BulkResult5to8_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.rstGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cmbUnit;
        private System.Windows.Forms.Label lblUnit;
        private System.Windows.Forms.ComboBox cmbSec;
        private System.Windows.Forms.Label lblSec;
        private System.Windows.Forms.ComboBox cmbClass;
        private System.Windows.Forms.Label lblClass;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rdSecndLan;
        private System.Windows.Forms.RadioButton rdFirstLan;
        private System.Windows.Forms.RadioButton rdMathematics;
        private System.Windows.Forms.RadioButton rdPhyScnc;
        private System.Windows.Forms.RadioButton rdLifeScnc;
        private System.Windows.Forms.RadioButton rdGeograph;
        private System.Windows.Forms.RadioButton rdHistory;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView rstGrid;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.RadioButton rdComputer;
        private System.Windows.Forms.RadioButton rdWorkEdu;
        private System.Windows.Forms.Button btnMenu;
    }
}