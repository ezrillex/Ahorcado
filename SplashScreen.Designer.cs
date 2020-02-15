namespace Ahorcado
{
    partial class SplashScreen
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
            this.label_titulo = new System.Windows.Forms.Label();
            this.label_loading = new System.Windows.Forms.Label();
            this.label_version = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label_titulo
            // 
            this.label_titulo.AutoSize = true;
            this.label_titulo.Font = new System.Drawing.Font("Century", 60F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_titulo.Location = new System.Drawing.Point(134, 178);
            this.label_titulo.Name = "label_titulo";
            this.label_titulo.Size = new System.Drawing.Size(533, 95);
            this.label_titulo.TabIndex = 1;
            this.label_titulo.Text = "AHORCADO";
            // 
            // label_loading
            // 
            this.label_loading.AutoSize = true;
            this.label_loading.Font = new System.Drawing.Font("Century", 20F, System.Drawing.FontStyle.Bold);
            this.label_loading.Location = new System.Drawing.Point(313, 273);
            this.label_loading.Name = "label_loading";
            this.label_loading.Size = new System.Drawing.Size(174, 33);
            this.label_loading.TabIndex = 2;
            this.label_loading.Text = "Cargando...";
            // 
            // label_version
            // 
            this.label_version.AutoSize = true;
            this.label_version.Location = new System.Drawing.Point(673, 245);
            this.label_version.Name = "label_version";
            this.label_version.Size = new System.Drawing.Size(32, 13);
            this.label_version.TabIndex = 3;
            this.label_version.Text = "V000";
            // 
            // SplashScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.ControlBox = false;
            this.Controls.Add(this.label_version);
            this.Controls.Add(this.label_loading);
            this.Controls.Add(this.label_titulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(800, 450);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(800, 450);
            this.Name = "SplashScreen";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SplashScreen";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_titulo;
        private System.Windows.Forms.Label label_loading;
        private System.Windows.Forms.Label label_version;
    }
}