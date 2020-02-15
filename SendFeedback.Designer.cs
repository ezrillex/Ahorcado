namespace Ahorcado
{
    partial class SendFeedback
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
            this.button_sendfeedback = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_nombre = new System.Windows.Forms.TextBox();
            this.textBox_email = new System.Windows.Forms.TextBox();
            this.textBox_comentario = new System.Windows.Forms.TextBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // button_sendfeedback
            // 
            this.button_sendfeedback.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_sendfeedback.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold);
            this.button_sendfeedback.Location = new System.Drawing.Point(147, 194);
            this.button_sendfeedback.Name = "button_sendfeedback";
            this.button_sendfeedback.Size = new System.Drawing.Size(256, 47);
            this.button_sendfeedback.TabIndex = 0;
            this.button_sendfeedback.Text = "Enviar Comentarios";
            this.button_sendfeedback.UseVisualStyleBackColor = true;
            this.button_sendfeedback.Click += new System.EventHandler(this.button_sendfeedback_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(42, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Nombre:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(65, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 25);
            this.label2.TabIndex = 2;
            this.label2.Text = "Email:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(3, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(139, 25);
            this.label3.TabIndex = 3;
            this.label3.Text = "Comentario:";
            // 
            // textBox_nombre
            // 
            this.textBox_nombre.Location = new System.Drawing.Point(147, 9);
            this.textBox_nombre.Name = "textBox_nombre";
            this.textBox_nombre.Size = new System.Drawing.Size(255, 20);
            this.textBox_nombre.TabIndex = 4;
            // 
            // textBox_email
            // 
            this.textBox_email.Location = new System.Drawing.Point(147, 35);
            this.textBox_email.Name = "textBox_email";
            this.textBox_email.Size = new System.Drawing.Size(255, 20);
            this.textBox_email.TabIndex = 5;
            // 
            // textBox_comentario
            // 
            this.textBox_comentario.Location = new System.Drawing.Point(147, 61);
            this.textBox_comentario.Multiline = true;
            this.textBox_comentario.Name = "textBox_comentario";
            this.textBox_comentario.Size = new System.Drawing.Size(256, 128);
            this.textBox_comentario.TabIndex = 6;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // SendFeedback
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(424, 253);
            this.Controls.Add(this.textBox_comentario);
            this.Controls.Add(this.textBox_email);
            this.Controls.Add(this.textBox_nombre);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_sendfeedback);
            this.MaximumSize = new System.Drawing.Size(440, 292);
            this.MinimumSize = new System.Drawing.Size(440, 292);
            this.Name = "SendFeedback";
            this.Text = "Enviar comentarios";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SendFeedback_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_sendfeedback;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox_nombre;
        private System.Windows.Forms.TextBox textBox_email;
        private System.Windows.Forms.TextBox textBox_comentario;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}