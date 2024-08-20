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
using System.Runtime.InteropServices.WindowsRuntime;

namespace misterio_do_catete
{
    public partial class Menu : Form
    {
        bool tocar = true; 
       // Menu menu = new Menu();
        public Menu()
        {
            InitializeComponent();
                string audioFilePath = "Interface.wav";
                AudioManager.Instance.SetlLoop(true);

                AudioManager.Instance.Play(audioFilePath);
        }
        #region musica
        //Tocar efeitos sonoros
        public static void PlaySFX(string filepath)
        {
            SoundPlayer music = new SoundPlayer();
            music.SoundLocation = filepath;
            music.Play();
        }
        //botao de som do formulario, para parar de tocar e/ou continuar a musica
        private void somclick(object sender, EventArgs e)
        {
            if (tocar == true)
            {
                AudioManager.Instance.Stop();

                som.Image = Properties.Resources.naosonzinho;
                tocar = false;
            }
            else if (tocar == false)
            {
                string audioFilePath = "Interface.wav";
                AudioManager.Instance.SetlLoop(true);

                AudioManager.Instance.Play(audioFilePath);

                som.Image = Properties.Resources.sonzinho;
                tocar = true;
            }
        }
        #endregion musica
        //botao para levar ao tutorial
        private void botaotutorial_Click(object sender, EventArgs e)
        {
            PlaySFX("botao.wav");

            Tutorial tutorial = new Tutorial();
            tutorial.Show();
            this.Hide();
        }
        //botao para perguntar se leva ao tutorial ou ao jogo
        private void jogar_Click(object sender, EventArgs e)
        {
            PlaySFX("botao.wav");

            telaparavoltar.Visible = true;
            menuvoltar.Visible = true;
            continuarnojogo.Visible = true;
        }
        //botao para levar ao jogo

        private void menuvoltar_Click(object sender, EventArgs e)
        {
            PlaySFX("papel.wav");
            Cutscene cutscene = new Cutscene();
            cutscene.Show();
            this.Hide();
        }
        //botao para levar ao tutorial
        private void continuarnojogo_Click(object sender, EventArgs e)
        {
            PlaySFX("papel.wav");

            Tutorial tutorial = new Tutorial();
            tutorial.Show();
            this.Hide();
        }
        //botao para levar ao creditos
        private void botaocreditos_Click(object sender, EventArgs e)
        {
            PlaySFX("botao.wav");

            Creditos creditos = new Creditos();
            creditos.Show();
            this.Hide();
        }
        //botao para fechar jogo
        private void sair_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
