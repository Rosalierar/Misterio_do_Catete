namespace misterio_do_catete
{
    partial class Menu
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.tutorial = new System.Windows.Forms.PictureBox();
            this.jogar = new System.Windows.Forms.PictureBox();
            this.credito = new System.Windows.Forms.PictureBox();
            this.sair = new System.Windows.Forms.PictureBox();
            this.som = new System.Windows.Forms.PictureBox();
            this.continuarnojogo = new System.Windows.Forms.PictureBox();
            this.menuvoltar = new System.Windows.Forms.PictureBox();
            this.telaparavoltar = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.tutorial)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.jogar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.credito)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sair)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.som)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.continuarnojogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.menuvoltar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.telaparavoltar)).BeginInit();
            this.SuspendLayout();
            // 
            // tutorial
            // 
            this.tutorial.BackColor = System.Drawing.Color.Transparent;
            this.tutorial.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.tutorial.Location = new System.Drawing.Point(359, 335);
            this.tutorial.Name = "tutorial";
            this.tutorial.Size = new System.Drawing.Size(111, 32);
            this.tutorial.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.tutorial.TabIndex = 98;
            this.tutorial.TabStop = false;
            this.tutorial.Tag = "0";
            this.tutorial.Click += new System.EventHandler(this.botaotutorial_Click);
            // 
            // jogar
            // 
            this.jogar.BackColor = System.Drawing.Color.Transparent;
            this.jogar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.jogar.Location = new System.Drawing.Point(359, 370);
            this.jogar.Name = "jogar";
            this.jogar.Size = new System.Drawing.Size(111, 32);
            this.jogar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.jogar.TabIndex = 99;
            this.jogar.TabStop = false;
            this.jogar.Tag = "0";
            this.jogar.Click += new System.EventHandler(this.jogar_Click);
            // 
            // credito
            // 
            this.credito.BackColor = System.Drawing.Color.Transparent;
            this.credito.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.credito.Location = new System.Drawing.Point(359, 405);
            this.credito.Name = "credito";
            this.credito.Size = new System.Drawing.Size(111, 32);
            this.credito.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.credito.TabIndex = 100;
            this.credito.TabStop = false;
            this.credito.Tag = "0";
            this.credito.Click += new System.EventHandler(this.botaocreditos_Click);
            // 
            // sair
            // 
            this.sair.BackColor = System.Drawing.Color.Transparent;
            this.sair.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.sair.Location = new System.Drawing.Point(359, 439);
            this.sair.Name = "sair";
            this.sair.Size = new System.Drawing.Size(111, 26);
            this.sair.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.sair.TabIndex = 101;
            this.sair.TabStop = false;
            this.sair.Tag = "0";
            this.sair.Click += new System.EventHandler(this.sair_Click);
            // 
            // som
            // 
            this.som.BackColor = System.Drawing.Color.Transparent;
            this.som.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.som.Image = global::misterio_do_catete.Properties.Resources.sonzinho;
            this.som.Location = new System.Drawing.Point(767, 12);
            this.som.Name = "som";
            this.som.Size = new System.Drawing.Size(55, 55);
            this.som.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.som.TabIndex = 102;
            this.som.TabStop = false;
            this.som.Tag = "0";
            this.som.Click += new System.EventHandler(this.somclick);
            // 
            // continuarnojogo
            // 
            this.continuarnojogo.BackColor = System.Drawing.Color.Transparent;
            this.continuarnojogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.continuarnojogo.Location = new System.Drawing.Point(420, 376);
            this.continuarnojogo.Name = "continuarnojogo";
            this.continuarnojogo.Size = new System.Drawing.Size(266, 66);
            this.continuarnojogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.continuarnojogo.TabIndex = 121;
            this.continuarnojogo.TabStop = false;
            this.continuarnojogo.Tag = "0";
            this.continuarnojogo.Visible = false;
            this.continuarnojogo.Click += new System.EventHandler(this.continuarnojogo_Click);
            // 
            // menuvoltar
            // 
            this.menuvoltar.BackColor = System.Drawing.Color.Transparent;
            this.menuvoltar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.menuvoltar.Location = new System.Drawing.Point(148, 376);
            this.menuvoltar.Name = "menuvoltar";
            this.menuvoltar.Size = new System.Drawing.Size(266, 66);
            this.menuvoltar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.menuvoltar.TabIndex = 120;
            this.menuvoltar.TabStop = false;
            this.menuvoltar.Tag = "0";
            this.menuvoltar.Visible = false;
            this.menuvoltar.Click += new System.EventHandler(this.menuvoltar_Click);
            // 
            // telaparavoltar
            // 
            this.telaparavoltar.BackColor = System.Drawing.Color.Transparent;
            this.telaparavoltar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.telaparavoltar.Enabled = false;
            this.telaparavoltar.Image = global::misterio_do_catete.Properties.Resources.certeza2;
            this.telaparavoltar.Location = new System.Drawing.Point(-40, 14);
            this.telaparavoltar.Name = "telaparavoltar";
            this.telaparavoltar.Size = new System.Drawing.Size(891, 525);
            this.telaparavoltar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.telaparavoltar.TabIndex = 119;
            this.telaparavoltar.TabStop = false;
            this.telaparavoltar.Tag = "0";
            this.telaparavoltar.Visible = false;
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::misterio_do_catete.Properties.Resources.menu;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(834, 561);
            this.Controls.Add(this.som);
            this.Controls.Add(this.telaparavoltar);
            this.Controls.Add(this.continuarnojogo);
            this.Controls.Add(this.menuvoltar);
            this.Controls.Add(this.sair);
            this.Controls.Add(this.credito);
            this.Controls.Add(this.jogar);
            this.Controls.Add(this.tutorial);
            this.DoubleBuffered = true;
            this.Name = "Menu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Menu";
            ((System.ComponentModel.ISupportInitialize)(this.tutorial)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.jogar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.credito)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sair)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.som)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.continuarnojogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.menuvoltar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.telaparavoltar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PictureBox tutorial;
        private System.Windows.Forms.PictureBox jogar;
        private System.Windows.Forms.PictureBox credito;
        private System.Windows.Forms.PictureBox sair;
        private System.Windows.Forms.PictureBox som;
        private System.Windows.Forms.PictureBox continuarnojogo;
        private System.Windows.Forms.PictureBox menuvoltar;
        private System.Windows.Forms.PictureBox telaparavoltar;
    }
}

