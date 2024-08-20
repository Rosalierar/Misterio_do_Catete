namespace misterio_do_catete
{
    partial class Fim
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
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.fechar = new System.Windows.Forms.PictureBox();
            this.caixadetexto = new System.Windows.Forms.PictureBox();
            this.confirmar = new System.Windows.Forms.PictureBox();
            this.jornall = new System.Windows.Forms.PictureBox();
            this.finall2 = new System.Windows.Forms.PictureBox();
            this.finall1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.fechar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.caixadetexto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.confirmar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.jornall)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.finall2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.finall1)).BeginInit();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Interval = 2500;
            this.timer1.Tick += new System.EventHandler(this.EventTimer);
            // 
            // timer2
            // 
            this.timer2.Interval = 3500;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // fechar
            // 
            this.fechar.BackColor = System.Drawing.Color.Transparent;
            this.fechar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.fechar.Location = new System.Drawing.Point(471, 113);
            this.fechar.Name = "fechar";
            this.fechar.Size = new System.Drawing.Size(239, 52);
            this.fechar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.fechar.TabIndex = 72;
            this.fechar.TabStop = false;
            this.fechar.Tag = "0";
            this.fechar.Visible = false;
            this.fechar.Click += new System.EventHandler(this.fechar_Click);
            // 
            // caixadetexto
            // 
            this.caixadetexto.BackColor = System.Drawing.Color.Transparent;
            this.caixadetexto.Enabled = false;
            this.caixadetexto.Image = global::misterio_do_catete.Properties.Resources.obg;
            this.caixadetexto.Location = new System.Drawing.Point(8, 32);
            this.caixadetexto.Name = "caixadetexto";
            this.caixadetexto.Size = new System.Drawing.Size(799, 516);
            this.caixadetexto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.caixadetexto.TabIndex = 71;
            this.caixadetexto.TabStop = false;
            this.caixadetexto.Tag = "0";
            this.caixadetexto.Visible = false;
            // 
            // confirmar
            // 
            this.confirmar.BackColor = System.Drawing.Color.Transparent;
            this.confirmar.Image = global::misterio_do_catete.Properties.Resources.btnconfirmar;
            this.confirmar.Location = new System.Drawing.Point(722, 499);
            this.confirmar.Name = "confirmar";
            this.confirmar.Size = new System.Drawing.Size(100, 50);
            this.confirmar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.confirmar.TabIndex = 9;
            this.confirmar.TabStop = false;
            this.confirmar.Visible = false;
            this.confirmar.Click += new System.EventHandler(this.EventClick);
            // 
            // jornall
            // 
            this.jornall.BackColor = System.Drawing.Color.Transparent;
            this.jornall.Enabled = false;
            this.jornall.Image = global::misterio_do_catete.Properties.Resources.jornal;
            this.jornall.Location = new System.Drawing.Point(95, 9);
            this.jornall.Name = "jornall";
            this.jornall.Size = new System.Drawing.Size(670, 537);
            this.jornall.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.jornall.TabIndex = 10;
            this.jornall.TabStop = false;
            this.jornall.Visible = false;
            // 
            // finall2
            // 
            this.finall2.Enabled = false;
            this.finall2.Image = global::misterio_do_catete.Properties.Resources.final2;
            this.finall2.Location = new System.Drawing.Point(-16, -24);
            this.finall2.Name = "finall2";
            this.finall2.Size = new System.Drawing.Size(850, 600);
            this.finall2.TabIndex = 1;
            this.finall2.TabStop = false;
            this.finall2.Visible = false;
            // 
            // finall1
            // 
            this.finall1.Enabled = false;
            this.finall1.Image = global::misterio_do_catete.Properties.Resources.final1;
            this.finall1.Location = new System.Drawing.Point(-16, -24);
            this.finall1.Name = "finall1";
            this.finall1.Size = new System.Drawing.Size(850, 600);
            this.finall1.TabIndex = 0;
            this.finall1.TabStop = false;
            this.finall1.Visible = false;
            // 
            // Fim
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.BackgroundImage = global::misterio_do_catete.Properties.Resources.finalzin;
            this.ClientSize = new System.Drawing.Size(834, 561);
            this.Controls.Add(this.caixadetexto);
            this.Controls.Add(this.fechar);
            this.Controls.Add(this.confirmar);
            this.Controls.Add(this.jornall);
            this.Controls.Add(this.finall2);
            this.Controls.Add(this.finall1);
            this.ForeColor = System.Drawing.Color.Black;
            this.Name = "Fim";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Final";
            ((System.ComponentModel.ISupportInitialize)(this.fechar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.caixadetexto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.confirmar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.jornall)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.finall2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.finall1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox finall1;
        private System.Windows.Forms.PictureBox finall2;
        private System.Windows.Forms.PictureBox confirmar;
        private System.Windows.Forms.PictureBox jornall;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.PictureBox fechar;
        private System.Windows.Forms.PictureBox caixadetexto;
        private System.Windows.Forms.Timer timer2;
    }
}