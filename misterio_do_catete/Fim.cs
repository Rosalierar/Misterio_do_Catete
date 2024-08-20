using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace misterio_do_catete
{
    public partial class Fim : Form
    {
        int pagina = 0;
        int mostrar = 0;
        public Fim()
        {
            InitializeComponent(); 
            string audioFilePath = "Cutscene.wav";
            AudioManager.Instance.SetlLoop(true);

            AudioManager.Instance.Play(audioFilePath);
            //PlayMusic("Cutscene.wav");
            timer1.Enabled = true;
        }
        public static void PlayMusic(string filepath)
        {
            SoundPlayer music = new SoundPlayer();
            music.SoundLocation = filepath;
            music.PlayLooping();
        }

        private void EventClick(object sender, EventArgs e)
        {
            pagina++;
            if (pagina == 1)
            {
                confirmar.Visible = false;
                finall1.Visible = false;
                finall2.Visible = false;
                jornall.Visible = true;
                timer2.Enabled = true;
            }
            else if (pagina == 2)
            {
                confirmar.Visible = false;
                jornall.Visible = false;
                finall1.Visible = false;
                finall2.Visible = true;
                timer2.Enabled = true;
            }
            if (pagina == 3)
            {
                confirmar.Visible = false;
                finall2.Visible = false;
                finall1.Visible = false;
                jornall.Visible = false;
                caixadetexto.Visible = true;
                fechar.Visible = true;
            }
        }

        private void EventTimer(object sender, EventArgs e)
        {
            if (mostrar == 0)
            {
                finall1.Visible = true;
                timer2.Enabled = true;
                mostrar++;
            }
        }

        private void fechar_Click(object sender, EventArgs e)
        {
            Menu menu = new Menu();
            menu.Show();
            this.Hide();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (pagina != 3)
            confirmar.Visible = true;
        }
    }
}
