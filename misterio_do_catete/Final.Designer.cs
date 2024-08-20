namespace misterio_do_catete
{
    partial class Cutscene
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
            this.cuts1 = new System.Windows.Forms.PictureBox();
            this.confirmar = new System.Windows.Forms.PictureBox();
            this.cuts3 = new System.Windows.Forms.PictureBox();
            this.cuts5 = new System.Windows.Forms.PictureBox();
            this.cuts4 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.cuts1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.confirmar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cuts3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cuts5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cuts4)).BeginInit();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Interval = 1500;
            this.timer1.Tick += new System.EventHandler(this.EventTimer);
            // 
            // cuts1
            // 
            this.cuts1.BackColor = System.Drawing.Color.Transparent;
            this.cuts1.Enabled = false;
            this.cuts1.Image = global::misterio_do_catete.Properties.Resources.parte1;
            this.cuts1.Location = new System.Drawing.Point(13, 14);
            this.cuts1.Name = "cuts1";
            this.cuts1.Size = new System.Drawing.Size(385, 368);
            this.cuts1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.cuts1.TabIndex = 13;
            this.cuts1.TabStop = false;
            this.cuts1.Visible = false;
            // 
            // confirmar
            // 
            this.confirmar.BackColor = System.Drawing.Color.Transparent;
            this.confirmar.Image = global::misterio_do_catete.Properties.Resources.btnconfirmar;
            this.confirmar.Location = new System.Drawing.Point(714, 512);
            this.confirmar.Name = "confirmar";
            this.confirmar.Size = new System.Drawing.Size(100, 50);
            this.confirmar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.confirmar.TabIndex = 8;
            this.confirmar.TabStop = false;
            this.confirmar.Visible = false;
            this.confirmar.Click += new System.EventHandler(this.EventClick);
            // 
            // cuts3
            // 
            this.cuts3.BackColor = System.Drawing.Color.Transparent;
            this.cuts3.Enabled = false;
            this.cuts3.Image = global::misterio_do_catete.Properties.Resources.parte2;
            this.cuts3.Location = new System.Drawing.Point(395, 126);
            this.cuts3.Name = "cuts3";
            this.cuts3.Size = new System.Drawing.Size(441, 389);
            this.cuts3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.cuts3.TabIndex = 11;
            this.cuts3.TabStop = false;
            this.cuts3.Visible = false;
            // 
            // cuts5
            // 
            this.cuts5.BackColor = System.Drawing.Color.Transparent;
            this.cuts5.Enabled = false;
            this.cuts5.Image = global::misterio_do_catete.Properties.Resources.parte4;
            this.cuts5.Location = new System.Drawing.Point(403, 13);
            this.cuts5.Name = "cuts5";
            this.cuts5.Size = new System.Drawing.Size(427, 507);
            this.cuts5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.cuts5.TabIndex = 9;
            this.cuts5.TabStop = false;
            this.cuts5.Visible = false;
            // 
            // cuts4
            // 
            this.cuts4.BackColor = System.Drawing.Color.Transparent;
            this.cuts4.Enabled = false;
            this.cuts4.Image = global::misterio_do_catete.Properties.Resources.parte3;
            this.cuts4.Location = new System.Drawing.Point(3, 70);
            this.cuts4.Name = "cuts4";
            this.cuts4.Size = new System.Drawing.Size(406, 419);
            this.cuts4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.cuts4.TabIndex = 10;
            this.cuts4.TabStop = false;
            this.cuts4.Visible = false;
            // 
            // Cutscene
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Bisque;
            this.ClientSize = new System.Drawing.Size(834, 561);
            this.Controls.Add(this.cuts5);
            this.Controls.Add(this.cuts1);
            this.Controls.Add(this.confirmar);
            this.Controls.Add(this.cuts3);
            this.Controls.Add(this.cuts4);
            this.ForeColor = System.Drawing.Color.SaddleBrown;
            this.Name = "Cutscene";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cutscene";
            ((System.ComponentModel.ISupportInitialize)(this.cuts1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.confirmar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cuts3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cuts5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cuts4)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PictureBox confirmar;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.PictureBox cuts5;
        private System.Windows.Forms.PictureBox cuts4;
        private System.Windows.Forms.PictureBox cuts3;
        private System.Windows.Forms.PictureBox cuts1;
    }
}