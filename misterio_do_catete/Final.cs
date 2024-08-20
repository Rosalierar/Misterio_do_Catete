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
    public partial class Cutscene : Form
    {
        int mostrarimagens1 = 0;
        int mostrarimagens2 = 0;
        bool pagina = false;
        public Cutscene()
        {
            InitializeComponent();
            string audioFilePath = "Cutscene.wav";
            AudioManager.Instance.SetlLoop(true);

            AudioManager.Instance.Play(audioFilePath);

            timer1.Enabled = true;
        }
        //Tocar efeitos sonoros
        public static void PlaySFX(string filepath)
        {
            SoundPlayer music = new SoundPlayer();
            music.SoundLocation = filepath;
            music.Play();
        }
        public static void StopMusic(string filepath)
        {
            SoundPlayer music = new SoundPlayer();
            music.SoundLocation = filepath;
            music.Stop();
        }
        //botao para passar as imagens
        private void EventClick(object sender, EventArgs e)
        {
            PlaySFX("botao.wav");
            if (pagina == false)
            {
                cuts1.Visible = false;
                cuts3.Visible = false;
                confirmar.Visible = false;
                pagina = true;
                timer1.Enabled = true;
            }
            else if (pagina == true)
            {
                StopMusic("Cutscene.wav");
                CorredorFase1 fase1 = new CorredorFase1();
                fase1.Show();
                this.Hide();
            }
        }

        private void EventTimer(object sender, EventArgs e)
        {
            if (pagina == false)
            {
                if (mostrarimagens1 == 0)
                {
                    cuts1.Visible = true;
                    mostrarimagens1++;
                    timer1.Interval = 2000;
                    timer1.Enabled = true;
                }
                else if (mostrarimagens1 == 1)
                {
                    cuts1.Image = Properties.Resources.parte1a;
                    mostrarimagens1++;
                    timer1.Interval = 2500;
                    timer1.Enabled = true;
                }
                else if (mostrarimagens1 == 2)
                {
                    cuts3.Visible = true;
                    mostrarimagens1++;
                    timer1.Interval = 2000;
                    timer1.Enabled = true;
                }
                else if (mostrarimagens1 == 3)
                {
                    cuts3.Image = Properties.Resources.parte2a;
                    mostrarimagens1++;
                    timer1.Interval = 2500;
                    timer1.Enabled = true;
                }
                else if (mostrarimagens1 == 4)
                {
                    confirmar.Visible = true;
                }

            }
            if (pagina == true)
            {
                if (mostrarimagens2 == 0)
                {
                    cuts4.Visible = true;
                    mostrarimagens2++;
                    timer1.Interval = 2000;
                    timer1.Enabled = true;
                }
                else if (mostrarimagens2 == 1)
                {
                    cuts4.Image = Properties.Resources.parte3a;
                    mostrarimagens2++;
                    timer1.Interval = 2500;
                    timer1.Enabled = true;
                }
                else if (mostrarimagens2 == 2)
                {
                    cuts5.Visible = true;
                    mostrarimagens2++;
                    timer1.Interval = 2000;
                    timer1.Enabled = true;
                }
                else if (mostrarimagens2 == 3)
                {
                    cuts5.Image = Properties.Resources.parte4a;
                    mostrarimagens2++;
                    timer1.Interval = 2500;
                    timer1.Enabled = true;
                }
                else if (mostrarimagens2 == 4)
                {
                    confirmar.Visible = true;
                }
            }
        }

        private void pular_Click(object sender, EventArgs e)
        {
            StopMusic("Cutscene.wav");
            CorredorFase1 corredor = new CorredorFase1();
            corredor.Show();
            this.Hide();
        }
    }
}
