
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
            this.SetMainButton = new System.Windows.Forms.Button();
            this.MainSaveButton = new System.Windows.Forms.Button();
            this.LoadButton = new System.Windows.Forms.Button();
            this.SaveBox = new System.Windows.Forms.ListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.downButton = new System.Windows.Forms.Button();
            this.upButton = new System.Windows.Forms.Button();
            this.RenameButton = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.slot1Button = new System.Windows.Forms.Button();
            this.slot3Button = new System.Windows.Forms.Button();
            this.slot2Button = new System.Windows.Forms.Button();
            this.topBar = new System.Windows.Forms.Panel();
            this.closeButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.topBar.SuspendLayout();
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
            this.DeleteButton.Enabled = false;
            this.DeleteButton.Location = new System.Drawing.Point(129, 190);
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.Size = new System.Drawing.Size(110, 39);
            this.DeleteButton.TabIndex = 17;
            this.DeleteButton.Text = "Delete Selected Save";
            this.DeleteButton.UseVisualStyleBackColor = true;
            this.DeleteButton.Click += new System.EventHandler(this.DeleteButton_Click);
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
            this.MainSaveButton.Location = new System.Drawing.Point(257, 333);
            this.MainSaveButton.Name = "MainSaveButton";
            this.MainSaveButton.Size = new System.Drawing.Size(103, 39);
            this.MainSaveButton.TabIndex = 15;
            this.MainSaveButton.Text = "Load Main Saves";
            this.MainSaveButton.UseVisualStyleBackColor = true;
            this.MainSaveButton.Click += new System.EventHandler(this.MainSaveButton_Click);
            // 
            // LoadButton
            // 
            this.LoadButton.Enabled = false;
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
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.SaveCurrentSave);
            this.groupBox1.Controls.Add(this.SetMainButton);
            this.groupBox1.Location = new System.Drawing.Point(137, 56);
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
            this.groupBox2.Location = new System.Drawing.Point(445, 56);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(245, 237);
            this.groupBox2.TabIndex = 22;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Backups";
            // 
            // downButton
            // 
            this.downButton.Enabled = false;
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
            this.upButton.Enabled = false;
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
            this.RenameButton.Enabled = false;
            this.RenameButton.Location = new System.Drawing.Point(129, 145);
            this.RenameButton.Name = "RenameButton";
            this.RenameButton.Size = new System.Drawing.Size(110, 39);
            this.RenameButton.TabIndex = 18;
            this.RenameButton.Text = "Rename Selected Save";
            this.RenameButton.UseVisualStyleBackColor = true;
            this.RenameButton.Click += new System.EventHandler(this.RenameButton_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.slot1Button);
            this.panel1.Controls.Add(this.slot3Button);
            this.panel1.Controls.Add(this.slot2Button);
            this.panel1.Location = new System.Drawing.Point(0, 33);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(131, 385);
            this.panel1.TabIndex = 23;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(25, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "Using Slot";
            // 
            // slot1Button
            // 
            this.slot1Button.FlatAppearance.BorderSize = 0;
            this.slot1Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.slot1Button.ForeColor = System.Drawing.Color.White;
            this.slot1Button.Location = new System.Drawing.Point(0, 58);
            this.slot1Button.Name = "slot1Button";
            this.slot1Button.Size = new System.Drawing.Size(131, 53);
            this.slot1Button.TabIndex = 3;
            this.slot1Button.Text = "Save Slot 1";
            this.slot1Button.UseVisualStyleBackColor = true;
            this.slot1Button.Click += new System.EventHandler(this.slot1Button_Click);
            // 
            // slot3Button
            // 
            this.slot3Button.FlatAppearance.BorderSize = 0;
            this.slot3Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.slot3Button.ForeColor = System.Drawing.Color.White;
            this.slot3Button.Location = new System.Drawing.Point(0, 161);
            this.slot3Button.Name = "slot3Button";
            this.slot3Button.Size = new System.Drawing.Size(131, 53);
            this.slot3Button.TabIndex = 2;
            this.slot3Button.Text = "Save Slot 3";
            this.slot3Button.UseVisualStyleBackColor = true;
            this.slot3Button.Click += new System.EventHandler(this.slot3Button_Click);
            // 
            // slot2Button
            // 
            this.slot2Button.FlatAppearance.BorderSize = 0;
            this.slot2Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.slot2Button.ForeColor = System.Drawing.Color.White;
            this.slot2Button.Location = new System.Drawing.Point(0, 109);
            this.slot2Button.Name = "slot2Button";
            this.slot2Button.Size = new System.Drawing.Size(131, 53);
            this.slot2Button.TabIndex = 1;
            this.slot2Button.Text = "Save Slot 2";
            this.slot2Button.UseVisualStyleBackColor = true;
            this.slot2Button.Click += new System.EventHandler(this.slot2Button_Click);
            // 
            // topBar
            // 
            this.topBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.topBar.Controls.Add(this.closeButton);
            this.topBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.topBar.Location = new System.Drawing.Point(0, 0);
            this.topBar.Name = "topBar";
            this.topBar.Size = new System.Drawing.Size(698, 35);
            this.topBar.TabIndex = 24;
            this.topBar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.topBar_MouseDown);
            this.topBar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.topBar_MouseMove);
            this.topBar.MouseUp += new System.Windows.Forms.MouseEventHandler(this.topBar_MouseUp);
            // 
            // closeButton
            // 
            this.closeButton.FlatAppearance.BorderSize = 0;
            this.closeButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
            this.closeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.closeButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.closeButton.ForeColor = System.Drawing.Color.White;
            this.closeButton.Location = new System.Drawing.Point(656, 0);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(42, 35);
            this.closeButton.TabIndex = 0;
            this.closeButton.Text = "x";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(333, 181);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 25;
            this.label2.Text = "label2";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(698, 417);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.topBar);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.MainSaveButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.Text = "SaveTheWorld";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.topBar.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button SaveCurrentSave;
        private System.Windows.Forms.Button DeleteButton;
        private System.Windows.Forms.Button SetMainButton;
        private System.Windows.Forms.Button MainSaveButton;
        private System.Windows.Forms.Button LoadButton;
        private System.Windows.Forms.ListBox SaveBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button RenameButton;
        private System.Windows.Forms.Button upButton;
        private System.Windows.Forms.Button downButton;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button slot2Button;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button slot1Button;
        private System.Windows.Forms.Button slot3Button;
        private System.Windows.Forms.Panel topBar;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.Label label2;
    }
}

