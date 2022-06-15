namespace pharmacie_logecial
{
    partial class Form1
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.BaredeProgression = new Guna.UI2.WinForms.Guna2CircleProgressBar();
            this.l = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // BaredeProgression
            // 
            this.BaredeProgression.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(213)))), ((int)(((byte)(218)))), ((int)(((byte)(223)))));
            this.BaredeProgression.FillThickness = 10;
            this.BaredeProgression.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.BaredeProgression.ForeColor = System.Drawing.Color.White;
            this.BaredeProgression.Location = new System.Drawing.Point(139, 129);
            this.BaredeProgression.Minimum = 0;
            this.BaredeProgression.Name = "BaredeProgression";
            this.BaredeProgression.ProgressColor = System.Drawing.Color.DeepSkyBlue;
            this.BaredeProgression.ProgressColor2 = System.Drawing.Color.SteelBlue;
            this.BaredeProgression.ProgressThickness = 10;
            this.BaredeProgression.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.BaredeProgression.Size = new System.Drawing.Size(154, 154);
            this.BaredeProgression.TabIndex = 0;
            this.BaredeProgression.Text = "guna2CircleProgressBar1";
            this.BaredeProgression.ValueChanged += new System.EventHandler(this.BaredeProgression_ValueChanged);
            // 
            // l
            // 
            this.l.AutoSize = true;
            this.l.Font = new System.Drawing.Font("Microsoft Tai Le", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.l.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.l.Location = new System.Drawing.Point(92, 47);
            this.l.Name = "l";
            this.l.Size = new System.Drawing.Size(269, 31);
            this.l.TabIndex = 1;
            this.l.Text = "Gestion de Pharmacie ";
            this.l.Click += new System.EventHandler(this.label1_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MediumTurquoise;
            this.ClientSize = new System.Drawing.Size(450, 403);
            this.Controls.Add(this.l);
            this.Controls.Add(this.BaredeProgression);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2CircleProgressBar BaredeProgression;
        private System.Windows.Forms.Label l;
        private System.Windows.Forms.Timer timer1;
    }
}

