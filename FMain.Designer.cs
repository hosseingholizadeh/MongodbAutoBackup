namespace MongoDbBackup
{
    partial class FMain
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem("TestDb");
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FMain));
            this.ls_Messages = new System.Windows.Forms.ListBox();
            this.daysCheckbox = new System.Windows.Forms.CheckedListBox();
            this.btnManualBackup = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnApply = new System.Windows.Forms.Button();
            this.lv_Dbs = new System.Windows.Forms.ListView();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtMin = new System.Windows.Forms.TextBox();
            this.txtHour = new System.Windows.Forms.TextBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtDatabase = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtBackupDir = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.txtDatabaseName = new System.Windows.Forms.TextBox();
            this.btnAddDatabase = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // ls_Messages
            // 
            this.ls_Messages.FormattingEnabled = true;
            this.ls_Messages.Location = new System.Drawing.Point(0, 171);
            this.ls_Messages.Name = "ls_Messages";
            this.ls_Messages.Size = new System.Drawing.Size(581, 277);
            this.ls_Messages.TabIndex = 0;
            // 
            // daysCheckbox
            // 
            this.daysCheckbox.FormattingEnabled = true;
            this.daysCheckbox.Items.AddRange(new object[] {
            "SAT",
            "SUN",
            "MON",
            "TUE",
            "WED",
            "THU",
            "FRI"});
            this.daysCheckbox.Location = new System.Drawing.Point(6, 19);
            this.daysCheckbox.Name = "daysCheckbox";
            this.daysCheckbox.Size = new System.Drawing.Size(65, 109);
            this.daysCheckbox.TabIndex = 1;
            // 
            // btnManualBackup
            // 
            this.btnManualBackup.Location = new System.Drawing.Point(12, 95);
            this.btnManualBackup.Name = "btnManualBackup";
            this.btnManualBackup.Size = new System.Drawing.Size(90, 23);
            this.btnManualBackup.TabIndex = 4;
            this.btnManualBackup.Text = "Manual Backup";
            this.btnManualBackup.UseVisualStyleBackColor = true;
            this.btnManualBackup.Click += new System.EventHandler(this.btnManualBackup_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.groupBox1.Controls.Add(this.btnAddDatabase);
            this.groupBox1.Controls.Add(this.txtDatabaseName);
            this.groupBox1.Controls.Add(this.btnApply);
            this.groupBox1.Controls.Add(this.lv_Dbs);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.daysCheckbox);
            this.groupBox1.Controls.Add(this.txtMin);
            this.groupBox1.Controls.Add(this.txtHour);
            this.groupBox1.Controls.Add(this.btnClose);
            this.groupBox1.Location = new System.Drawing.Point(235, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(341, 137);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Auto Backup Service";
            // 
            // btnApply
            // 
            this.btnApply.Location = new System.Drawing.Point(90, 76);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(106, 23);
            this.btnApply.TabIndex = 9;
            this.btnApply.Text = "Apply";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // lv_Dbs
            // 
            this.lv_Dbs.HideSelection = false;
            listViewItem2.Tag = "etraab";
            this.lv_Dbs.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem2});
            this.lv_Dbs.Location = new System.Drawing.Point(215, 10);
            this.lv_Dbs.Name = "lv_Dbs";
            this.lv_Dbs.Size = new System.Drawing.Size(111, 89);
            this.lv_Dbs.TabIndex = 8;
            this.lv_Dbs.UseCompatibleStateImageBehavior = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(82, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "minute";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(87, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "hour";
            // 
            // txtMin
            // 
            this.txtMin.Location = new System.Drawing.Point(132, 43);
            this.txtMin.Name = "txtMin";
            this.txtMin.Size = new System.Drawing.Size(31, 20);
            this.txtMin.TabIndex = 5;
            // 
            // txtHour
            // 
            this.txtHour.Location = new System.Drawing.Point(132, 19);
            this.txtHour.Name = "txtHour";
            this.txtHour.Size = new System.Drawing.Size(31, 20);
            this.txtHour.TabIndex = 4;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(90, 105);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(106, 23);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.groupBox2.Controls.Add(this.txtDatabase);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.btnManualBackup);
            this.groupBox2.Location = new System.Drawing.Point(3, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(226, 137);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Manual Backup";
            // 
            // txtDatabase
            // 
            this.txtDatabase.Location = new System.Drawing.Point(74, 48);
            this.txtDatabase.Name = "txtDatabase";
            this.txtDatabase.Size = new System.Drawing.Size(149, 20);
            this.txtDatabase.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(9, 51);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "database";
            // 
            // txtBackupDir
            // 
            this.txtBackupDir.Location = new System.Drawing.Point(105, 146);
            this.txtBackupDir.Name = "txtBackupDir";
            this.txtBackupDir.Size = new System.Drawing.Size(466, 20);
            this.txtBackupDir.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(3, 149);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(95, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "backup dest dir";
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.BalloonTipText = "MongoDb Backup";
            this.notifyIcon1.BalloonTipTitle = "MongoDb Backup";
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "notifyIcon1";
            this.notifyIcon1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseClick);
            // 
            // txtDatabaseName
            // 
            this.txtDatabaseName.Location = new System.Drawing.Point(245, 105);
            this.txtDatabaseName.Name = "txtDatabaseName";
            this.txtDatabaseName.Size = new System.Drawing.Size(81, 20);
            this.txtDatabaseName.TabIndex = 10;
            // 
            // btnAddDatabase
            // 
            this.btnAddDatabase.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddDatabase.Location = new System.Drawing.Point(215, 102);
            this.btnAddDatabase.Name = "btnAddDatabase";
            this.btnAddDatabase.Size = new System.Drawing.Size(24, 26);
            this.btnAddDatabase.TabIndex = 11;
            this.btnAddDatabase.Text = "+";
            this.btnAddDatabase.UseVisualStyleBackColor = true;
            this.btnAddDatabase.Click += new System.EventHandler(this.btnAddDatabase_Click);
            // 
            // FMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.ClientSize = new System.Drawing.Size(579, 447);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtBackupDir);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.ls_Messages);
            this.Name = "FMain";
            this.Text = "Mongodb Backup";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FMain_FormClosing);
            this.Load += new System.EventHandler(this.FMain_Load);
            this.Resize += new System.EventHandler(this.FMain_Resize);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox ls_Messages;
        private System.Windows.Forms.CheckedListBox daysCheckbox;
        private System.Windows.Forms.Button btnManualBackup;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtMin;
        private System.Windows.Forms.TextBox txtHour;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtBackupDir;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListView lv_Dbs;
        private System.Windows.Forms.TextBox txtDatabase;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.Button btnAddDatabase;
        private System.Windows.Forms.TextBox txtDatabaseName;
    }
}