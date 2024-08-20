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
    public partial class CorredorFase4 : Form
    {
        bool tocar = true;
        public CorredorFase4()
        {
            InitializeComponent(); 
            /*string audioFilePath = "Jogo.wav";
            AudioManager.Instance.SetlLoop(true);

            AudioManager.Instance.Play(audioFilePath);*/
            //PlayMusic("Jogo.wav");
        }
        #region teladeinformacao
        public static void PlaySFX(string filepath)
        {
            SoundPlayer music = new SoundPlayer();
            music.SoundLocation = filepath;
            music.Play();
        }
        public static void StopSFX(string filepath)
        {
            SoundPlayer music = new SoundPlayer();
            music.SoundLocation = filepath;
            music.Stop();
        }
        private void som_Click(object sender, EventArgs e)
        {
            if (tocar == true)
            {
                AudioManager.Instance.Stop();
                //StopMusic("Jogo.wav");
                som.Image = Properties.Resources.naosonzinho;
                tocar = false;
            }
            else if (tocar == false)
            {
                string audioFilePath = "Jogo.wav";
                AudioManager.Instance.SetlLoop(true);

                AudioManager.Instance.Play(audioFilePath);
                //PlayMusic("Jogo.wav");
                som.Image = Properties.Resources.sonzinho;
                tocar = true;
            }
        }
        private void continuarnojogo_Click(object sender, EventArgs e)
        {
            telaparavoltar.Visible = false;
            menuvoltar.Visible = false;
            continuarnojogo.Visible = false;
            deixarenabled.Visible = false;
        }
        private void menu_Click(object sender, EventArgs e)
        {
            telaparavoltar.Visible = true;
            menuvoltar.Visible = true;
            continuarnojogo.Visible = true;
            deixarenabled.Visible = true;
        }
        private void menuvoltar_Click(object sender, EventArgs e)
        {
            Menu menu = new Menu();
            menu.Show();
            this.Hide();
        }
        #endregion teladeinformacao
        private void AbrirDialogo(string texto)
        {
            timer1.Enabled = true;
            dialogo.Text = texto.ToString();
            dialogo.Visible = true;
            caixadetexto.Visible = true;
            senhorluiz.Visible = true;
            deixarenabled.Visible = true;
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            dialogo.Visible = false;
            caixadetexto.Visible = false;
            senhorluiz.Visible = false;
            deixarenabled.Visible = false;
        }

        private void EventClick(object sender, MouseEventArgs e)
        {
            if (sender == quarto)
            {
                PlaySFX("abrir_armario.wav");
                QuartodoPresidente quarto1 = new QuartodoPresidente();
                quarto1.Show();
                this.Hide(); 
            }
            else if (sender == quarto2)
            {
                PlaySFX("porta.wav");
                AbrirDialogo("Eu já passei por essa sala!");
            }
            else if (sender == quarto3)
            {
                PlaySFX("porta.wav");
                AbrirDialogo("Eu já passei por essa sala!");
            }
            else if (sender == quarto4)
            {
                PlaySFX("porta.wav");
                AbrirDialogo("Eu já passei por essa sala!");
            }
        }

    }
}
