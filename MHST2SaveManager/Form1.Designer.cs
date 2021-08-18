
namespace MHST2SaveManager
{
    partial class Form1
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
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.SaveCurrentSave = new System.Windows.Forms.Button();
            this.DeleteButton = new System.Windows.Forms.Button();
            this.CurrentSaveLabel = new System.Windows.Forms.Label();
            this.SetMainButton = new System.Windows.Forms.Button();
            this.MainSaveButton = new System.Windows.Forms.Button();
            this.SetWorldPath = new System.Windows.Forms.Button();
            this.LoadButton = new System.Windows.Forms.Button();
            this.SaveBox = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.downButton = new System.Windows.Forms.Button();
            this.upButton = new System.Windows.Forms.Button();
            this.RenameButton = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // SaveCurrentSave
            // 
            this.SaveCurrentSave.Location = new System.Drawing.Point(27, 93);
            this.SaveCurrentSave.Name = "SaveCurrentSave";
            this.SaveCurrentSave.Size = new System.Drawing.Size(109, 35);
            this.SaveCurrentSave.TabIndex = 19;
            this.SaveCurrentSave.Text = "Backup Current Save";
            this.SaveCurrentSave.UseVisualStyleBackColor = true;
            this.SaveCurrentSave.Click += new System.EventHandler(this.SaveCurrentSave_Click);
            // 
            // DeleteButton
            // 
            this.DeleteButton.Location = new System.Drawing.Point(129, 190);
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.Size = new System.Drawing.Size(110, 39);
            this.DeleteButton.TabIndex = 17;
            this.DeleteButton.Text = "Delete Selected Save";
            this.DeleteButton.UseVisualStyleBackColor = true;
            this.DeleteButton.Click += new System.EventHandler(this.DeleteButton_Click);
            // 
            // CurrentSaveLabel
            // 
            this.CurrentSaveLabel.Location = new System.Drawing.Point(247, 106);
            this.CurrentSaveLabel.Name = "CurrentSaveLabel";
            this.CurrentSaveLabel.Size = new System.Drawing.Size(112, 13);
            this.CurrentSaveLabel.TabIndex = 14;
            this.CurrentSaveLabel.Text = "SaveNameHere";
            this.CurrentSaveLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // SetMainButton
            // 
            this.SetMainButton.Location = new System.Drawing.Point(27, 28);
            this.SetMainButton.Name = "SetMainButton";
            this.SetMainButton.Size = new System.Drawing.Size(109, 23);
            this.SetMainButton.TabIndex = 18;
            this.SetMainButton.Text = "Overwrite Main";
            this.SetMainButton.UseVisualStyleBackColor = true;
            this.SetMainButton.Click += new System.EventHandler(this.SetMainButton_Click);
            // 
            // MainSaveButton
            // 
            this.MainSaveButton.Location = new System.Drawing.Point(256, 289);
            this.MainSaveButton.Name = "MainSaveButton";
            this.MainSaveButton.Size = new System.Drawing.Size(103, 39);
            this.MainSaveButton.TabIndex = 15;
            this.MainSaveButton.Text = "Load Main Save";
            this.MainSaveButton.UseVisualStyleBackColor = true;
            this.MainSaveButton.Click += new System.EventHandler(this.MainSaveButton_Click);
            // 
            // SetWorldPath
            // 
            this.SetWorldPath.Location = new System.Drawing.Point(250, 12);
            this.SetWorldPath.Name = "SetWorldPath";
            this.SetWorldPath.Size = new System.Drawing.Size(109, 23);
            this.SetWorldPath.TabIndex = 20;
            this.SetWorldPath.Text = "Set Save Folder";
            this.SetWorldPath.UseVisualStyleBackColor = true;
            this.SetWorldPath.Click += new System.EventHandler(this.SetWorldPath_Click);
            // 
            // LoadButton
            // 
            this.LoadButton.Location = new System.Drawing.Point(129, 100);
            this.LoadButton.Name = "LoadButton";
            this.LoadButton.Size = new System.Drawing.Size(110, 39);
            this.LoadButton.TabIndex = 16;
            this.LoadButton.Text = "Load Selected Save";
            this.LoadButton.UseVisualStyleBackColor = true;
            this.LoadButton.Click += new System.EventHandler(this.LoadButton_Click);
            // 
            // SaveBox
            // 
            this.SaveBox.FormattingEnabled = true;
            this.SaveBox.Location = new System.Drawing.Point(20, 19);
            this.SaveBox.Name = "SaveBox";
            this.SaveBox.Size = new System.Drawing.Size(103, 212);
            this.SaveBox.TabIndex = 11;
            this.SaveBox.SelectedIndexChanged += new System.EventHandler(this.SaveBox_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(247, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(118, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "Currently Loaded Save:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.SaveCurrentSave);
            this.groupBox1.Controls.Add(this.SetMainButton);
            this.groupBox1.Location = new System.Drawing.Point(12, 92);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(161, 140);
            this.groupBox1.TabIndex = 21;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "New Save";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.downButton);
            this.groupBox2.Controls.Add(this.upButton);
            this.groupBox2.Controls.Add(this.RenameButton);
            this.groupBox2.Controls.Add(this.SaveBox);
            this.groupBox2.Controls.Add(this.LoadButton);
            this.groupBox2.Controls.Add(this.DeleteButton);
            this.groupBox2.Location = new System.Drawing.Point(444, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(245, 237);
            this.groupBox2.TabIndex = 22;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Backups";
            // 
            // downButton
            // 
            this.downButton.Location = new System.Drawing.Point(129, 64);
            this.downButton.Name = "downButton";
            this.downButton.Size = new System.Drawing.Size(110, 24);
            this.downButton.TabIndex = 20;
            this.downButton.Text = "Move Down";
            this.downButton.UseVisualStyleBackColor = true;
            this.downButton.Click += new System.EventHandler(this.downButton_Click);
            // 
            // upButton
            // 
            this.upButton.Location = new System.Drawing.Point(129, 28);
            this.upButton.Name = "upButton";
            this.upButton.Size = new System.Drawing.Size(110, 24);
            this.upButton.TabIndex = 19;
            this.upButton.Text = "Move Up";
            this.upButton.UseVisualStyleBackColor = true;
            this.upButton.Click += new System.EventHandler(this.upButton_Click);
            // 
            // RenameButton
            // 
            this.RenameButton.Location = new System.Drawing.Point(129, 145);
            this.RenameButton.Name = "RenameButton";
            this.RenameButton.Size = new System.Drawing.Size(110, 39);
            this.RenameButton.TabIndex = 18;
            this.RenameButton.Text = "Rename Selected Save";
            this.RenameButton.UseVisualStyleBackColor = true;
            this.RenameButton.Click += new System.EventHandler(this.RenameButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(698, 374);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.SetWorldPath);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.CurrentSaveLabel);
            this.Controls.Add(this.MainSaveButton);
            this.Controls.Add(this.label2);
            this.Name = "Form1";
            this.Text = "SaveTheWorld";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button SaveCurrentSave;
        private System.Windows.Forms.Button DeleteButton;
        private System.Windows.Forms.Label CurrentSaveLabel;
        private System.Windows.Forms.Button SetMainButton;
        private System.Windows.Forms.Button MainSaveButton;
        private System.Windows.Forms.Button SetWorldPath;
        private System.Windows.Forms.Button LoadButton;
        private System.Windows.Forms.ListBox SaveBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button RenameButton;
        private System.Windows.Forms.Button upButton;
        private System.Windows.Forms.Button downButton;
    }
}

