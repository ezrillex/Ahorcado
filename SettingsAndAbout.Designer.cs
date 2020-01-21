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
            this.label1.Location = new System.Drawing.Point(12, 339);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(178, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Juego desarrollado por: Ezra Abarca";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(266, 339);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Version: 1.0";
            // 
            // linkLabel_donos
            // 
            this.linkLabel_donos.AutoSize = true;
            this.linkLabel_donos.Location = new System.Drawing.Point(196, 339);
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
            this.checkBox_darkmode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkBox_darkmode.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox_darkmode.Location = new System.Drawing.Point(72, 163);
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
            // SettingsAndAbout
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(340, 361);
            this.Controls.Add(this.button_cerrar);
            this.Controls.Add(this.checkBox_darkmode);
            this.Controls.Add(this.linkLabel_donos);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "SettingsAndAbout";
            this.Text = "Settings And About";
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
    }
}