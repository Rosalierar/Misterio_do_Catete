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
using System.Windows.Media;

namespace misterio_do_catete
{
    public partial class CorredorFase1 : Form
    {
        bool tocar = true;
        bool abrirporta = false;
        
        bool pegarachave = false;
        int[] analisarobj = new int [2];

        int[] tags = new int[4];

       // private MediaPlayer music;
        public CorredorFase1()
        {
            InitializeComponent();
            string audioFilePath = "Jogo.wav";
            AudioManager.Instance.SetlLoop(true);

            AudioManager.Instance.Play(audioFilePath);

            AbrirDialogocomFechar("Bom, vou iniciar a investigação vasculhando esse corredor.");

        }
        #region telasdeinformacoes
        public static void StopiMusic(string filepath)
        {
            SoundPlayer efeitos = new SoundPlayer();
            efeitos.SoundLocation = filepath;
            efeitos.Stop();
        }
        public static void PlaySFX(string filepath)
        {
            SoundPlayer efeitos = new SoundPlayer();
            efeitos.SoundLocation = filepath;
            efeitos.Play();
        }
        private void som_Click(object sender, EventArgs e)
        {
            PlaySFX("botao.wav");
            if (tocar == true)
            {
                AudioManager.Instance.Stop();
                som.Image = Properties.Resources.naosonzinho;
                tocar = false;
            }
            else if (tocar == false)
            {
                string audioFilePath = "Jogo.wav";
                AudioManager.Instance.SetlLoop(true);

                AudioManager.Instance.Play(audioFilePath);
                som.Image = Properties.Resources.sonzinho;
                tocar = true;
            }
        }
        private void continuarnojogo_Click(object sender, EventArgs e)
        {
            PlaySFX("papelpassar.wav");
            telaparavoltar.Visible = false;
            menuvoltar.Visible = false;
            continuarnojogo.Visible = false;
            deixarenabled.Visible = false;
        }
        private void menu_Click(object sender, EventArgs e)
        {
            PlaySFX("botao.wav");
            telaparavoltar.Visible = true;
            menuvoltar.Visible = true;
            continuarnojogo.Visible = true;
            deixarenabled.Visible = true;
        }
        private void menuvoltar_Click(object sender, EventArgs e)
        {
            PlaySFX("papelpassar.wav");
            Menu menu = new Menu();
            menu.Show();
            this.Hide();
        }

        #endregion teladeinformacoes
        private void AbrirDialogo(string texto)
        {
            timer1.Enabled = true;
            dialogo.Text = texto.ToString();
            dialogo.Visible = true;
            caixadetexto.Visible = true;
            senhorluiz.Visible = true;
            deixarenabled.Visible = true;
        }
        private void AbrirDialogocomFechar(string texto)
        {
            dialogo.Text = texto.ToString();
            fechar.Visible = true;
            dialogo.Visible = true;
            caixadetexto.Visible = true;
            senhorluiz.Visible = true;
            deixarenabled.Visible = true;
           
        }
        private void FecharDialogo()
        {
            fechar.Visible = false;
            dialogo.Visible = false;
            caixadetexto.Visible = false;
            senhorluiz.Visible = false;
            deixarenabled.Visible = false;
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            dialogo.Visible = false;
            caixadetexto.Visible = false;
            senhorluiz.Visible = false;
            deixarenabled.Visible = false;

            if (timer1.Enabled == false && analisarobj[1] == 4 && pegarachave == false)
            {
                AbrirDialogocomFechar("Há uma chave no canto da sala, deve abrir alguma dessas portas.");
            }
        }
        private void EventClick(object sender, MouseEventArgs e)
        {
            tags[0] = Convert.ToInt32(quarto.Tag);
            tags[1] = Convert.ToInt32(quarto2.Tag);
            tags[2] = Convert.ToInt32(quarto3.Tag);
            tags[3] = Convert.ToInt32(quarto4.Tag);

            if (sender == quarto && abrirporta == true)
            { 
                PlaySFX("porta.wav");
            
                AbrirDialogo("Eu tenho que passar pelas outras salas primeiro!");
            }
            else if (sender == quarto2 && abrirporta == true)
            {
                PlaySFX("abrir_armario.wav");

                Escritorio escritorio = new Escritorio();
                escritorio.Show();
                this.Hide();
            }
            if (sender == quarto2 && abrirporta == false)
            {
                PlaySFX("porta.wav");

                AbrirDialogo("Essa porta está trancada!");

                if (tags[1] == 0)
                    analisarobj[1]++;
            }
            else if (sender == quarto3 && abrirporta == true || sender == quarto4 && abrirporta == true)
            {
                PlaySFX("porta.wav");
                AbrirDialogo("Essa não é a chave para essa porta!");
            }
            else if (abrirporta == false)
            {
                PlaySFX("porta.wav");
                AbrirDialogo("Essa porta está trancada!");
            }

            if (sender == quarto)
            {
                if (tags[0] == 0)
                    analisarobj[1]++;
            }
            if (sender == quarto3)
            {
                if (tags[2] == 0)
                    analisarobj[1]++;
            }
            if (sender == quarto4)
            {
                if (tags[3] == 0)
                    analisarobj[1]++;
            }
        }

        private void fechar_Click(object sender, EventArgs e)
        {
            PlaySFX("botao.wav");
            FecharDialogo();

            if (analisarobj[1] != 4 && pegarachave == false && analisarobj[0] == 0)
            {
                AbrirDialogocomFechar("Tem uma chave no canto da sala, deve ser de alguma dessas portas.");
                analisarobj[0]++;
            }
            if (pegarachave == false)
                chavefase1.Visible = true;
        }

        private void chavefase1_Click(object sender, EventArgs e)
        {
            PlaySFX("chaves.wav");

            pegarachave = true;
            abrirporta = true;
            chavefase1.Visible = false;

            AbrirDialogocomFechar("Essa é a chave do Escritório do Presidente!");
        }

        private void Timer_Effects(object sender, EventArgs e)
        {
        }
    }
}
