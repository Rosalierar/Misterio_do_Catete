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
    public partial class Creditos : Form
    {
        bool tocar = true;
        public Creditos()
        {
            InitializeComponent(); 
           /* string audioFilePath = "Interface.wav";
            AudioManager.Instance.SetlLoop(true);

            AudioManager.Instance.Play(audioFilePath);
            //  PlayMusic("Interface.wav");
        }
      /*  public static void PlayMusic(string filepath)
        {
            SoundPlayer music = new SoundPlayer();
            music.SoundLocation = filepath;
            Task.Run(() => { music.PlayLooping(); });
        }
        public static void StopMusic(string filepath)
        {
            SoundPlayer music = new SoundPlayer();
            music.SoundLocation = filepath;
            music.Stop();*/
        }
        public static void PlaySFX(string filepath)
        {
            SoundPlayer music = new SoundPlayer();
            music.SoundLocation = filepath;
            music.Play();
        }
        private void som_Click(object sender, EventArgs e)
        {
            if (tocar == true)
            {
                AudioManager.Instance.Stop();
            //    StopMusic("Interface.wav");
                som.Image = Properties.Resources.naosonzinho;
                tocar = false;
            }
            else if (tocar == false)
            {
                string audioFilePath = "Interface.wav";
                AudioManager.Instance.SetlLoop(true);

                AudioManager.Instance.Play(audioFilePath);
               // PlayMusic("Interface.wav");
                som.Image = Properties.Resources.sonzinho;
                tocar = true;
            }
        }
        private void voltar_Click(object sender, EventArgs e)
        {
            PlaySFX("botao.wav");

            Menu menu = new Menu();
            menu.Show();
            this.Hide();
        }
    }
}
