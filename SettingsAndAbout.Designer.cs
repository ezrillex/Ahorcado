namespace Ahorcado
{
    partial class SettingsAndAbout
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
            this.fileSystemWatcher1 = new System.IO.FileSystemWatcher();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.linkLabel_donos = new System.Windows.Forms.LinkLabel();
            this.checkBox_darkmode = new System.Windows.Forms.CheckBox();
            this.button_cerrar = new System.Windows.Forms.Button();
            this.checkBox_antialiasing = new System.Windows.Forms.CheckBox();
            this.button_ReportWord = new System.Windows.Forms.Button();
            this.button_ResetScore = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).BeginInit();
            this.SuspendLayout();
            // 
            // fileSystemWatcher1
            // 
            this.fileSystemWatcher1.EnableRaisingEvents = true;
            this.fileSystemWatcher1.SynchronizingObject = this;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 339);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(178, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Juego desarrollado por: Ezra Abarca";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(263, 339);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Version:";
            // 
            // linkLabel_donos
            // 
            this.linkLabel_donos.AutoSize = true;
            this.linkLabel_donos.Location = new System.Drawing.Point(193, 339);
            this.linkLabel_donos.Name = "linkLabel_donos";
            this.linkLabel_donos.Size = new System.Drawing.Size(64, 13);
            this.linkLabel_donos.TabIndex = 2;
            this.linkLabel_donos.TabStop = true;
            this.linkLabel_donos.Text = "Donaciones";
            this.linkLabel_donos.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel_donos_LinkClicked);
            // 
            // checkBox_darkmode
            // 
            this.checkBox_darkmode.AutoSize = true;
            this.checkBox_darkmode.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBox_darkmode.Enabled = false;
            this.checkBox_darkmode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkBox_darkmode.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox_darkmode.Location = new System.Drawing.Point(63, 151);
            this.checkBox_darkmode.Name = "checkBox_darkmode";
            this.checkBox_darkmode.Size = new System.Drawing.Size(197, 35);
            this.checkBox_darkmode.TabIndex = 3;
            this.checkBox_darkmode.Text = "Modo oscuro";
            this.checkBox_darkmode.UseVisualStyleBackColor = true;
            // 
            // button_cerrar
            // 
            this.button_cerrar.BackColor = System.Drawing.Color.White;
            this.button_cerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_cerrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_cerrar.Location = new System.Drawing.Point(120, 252);
            this.button_cerrar.Name = "button_cerrar";
            this.button_cerrar.Size = new System.Drawing.Size(100, 40);
            this.button_cerrar.TabIndex = 4;
            this.button_cerrar.Text = "Atrás";
            this.button_cerrar.UseVisualStyleBackColor = false;
            this.button_cerrar.Click += new System.EventHandler(this.button1_Click);
            // 
            // checkBox_antialiasing
            // 
            this.checkBox_antialiasing.AutoSize = true;
            this.checkBox_antialiasing.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBox_antialiasing.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkBox_antialiasing.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox_antialiasing.Location = new System.Drawing.Point(80, 192);
            this.checkBox_antialiasing.Name = "checkBox_antialiasing";
            this.checkBox_antialiasing.Size = new System.Drawing.Size(181, 35);
            this.checkBox_antialiasing.TabIndex = 5;
            this.checkBox_antialiasing.Text = "Antialiasing";
            this.checkBox_antialiasing.UseVisualStyleBackColor = true;
            this.checkBox_antialiasing.CheckedChanged += new System.EventHandler(this.checkBox_antialiasing_CheckedChanged);
            // 
            // button_ReportWord
            // 
            this.button_ReportWord.BackColor = System.Drawing.Color.White;
            this.button_ReportWord.Enabled = false;
            this.button_ReportWord.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_ReportWord.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_ReportWord.Location = new System.Drawing.Point(12, 12);
            this.button_ReportWord.Name = "button_ReportWord";
            this.button_ReportWord.Size = new System.Drawing.Size(317, 40);
            this.button_ReportWord.TabIndex = 6;
            this.button_ReportWord.Text = "Reportar un problema";
            this.button_ReportWord.UseVisualStyleBackColor = false;
            // 
            // button_ResetScore
            // 
            this.button_ResetScore.BackColor = System.Drawing.Color.White;
            this.button_ResetScore.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_ResetScore.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_ResetScore.Location = new System.Drawing.Point(12, 58);
            this.button_ResetScore.Name = "button_ResetScore";
            this.button_ResetScore.Size = new System.Drawing.Size(316, 40);
            this.button_ResetScore.TabIndex = 7;
            this.button_ResetScore.Text = "Borrar Puntaje";
            this.button_ResetScore.UseVisualStyleBackColor = false;
            this.button_ResetScore.Click += new System.EventHandler(this.button_ResetScore_Click);
            // 
            // SettingsAndAbout
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(340, 361);
            this.Controls.Add(this.button_ResetScore);
            this.Controls.Add(this.button_ReportWord);
            this.Controls.Add(this.checkBox_antialiasing);
            this.Controls.Add(this.button_cerrar);
            this.Controls.Add(this.checkBox_darkmode);
            this.Controls.Add(this.linkLabel_donos);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.MaximumSize = new System.Drawing.Size(356, 400);
            this.MinimumSize = new System.Drawing.Size(356, 400);
            this.Name = "SettingsAndAbout";
            this.Text = "Settings And About";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SettingsAndAbout_FormClosing);
            this.Load += new System.EventHandler(this.SettingsAndAbout_Load);
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.IO.FileSystemWatcher fileSystemWatcher1;
        private System.Windows.Forms.LinkLabel linkLabel_donos;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox checkBox_darkmode;
        private System.Windows.Forms.Button button_cerrar;
        private System.Windows.Forms.CheckBox checkBox_antialiasing;
        private System.Windows.Forms.Button button_ResetScore;
        private System.Windows.Forms.Button button_ReportWord;
    }
}