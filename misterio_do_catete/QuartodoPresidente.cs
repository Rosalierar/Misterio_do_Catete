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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace misterio_do_catete
{
    public partial class QuartodoPresidente : Form
    {
        bool tocar = true;
        bool ver = false;
        int interacoes = 0;
        bool ganhar = false;
        bool voltaraocorredor;
        int puzzle;
        int[] tager = new int [2];
        int[] analisarobj = new int [4];
        bool responder = false;
        int respondeu = 0;
        int respondeu2 = 0;
        string quiz1 = null;
        string quiz2 = null;
        bool visualizar = false;
        int pagina = 0;
        bool diminuir = false;
        bool viudepois = false;
        bool click = false;

        bool[] mensagens = new bool[4];

        private const int MaxWidth = 580;

        public QuartodoPresidente()
        {
            InitializeComponent(); 
            /*string audioFilePath = "Jogo.wav";
            AudioManager.Instance.SetlLoop(true);

            AudioManager.Instance.Play(audioFilePath);*/

            AbrirDialogocomFechar("Então esses são os aposentos do Presidente. Hum, é melhor eu analisar o que tem em cima da cama.");

            for (int i = 0; i < 4; i++)
            {
                mensagens[i] = false;
            }
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
            PlaySFX("botao.wav");
            if (tocar == true)
            {
                AudioManager.Instance.Stop();
               // StopMusic("Jogo.wav");
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
            PlaySFX("papelpassar.wav");
            telaparavoltar.Visible = false;
            menuvoltar.Visible = false;
            continuarnojogo.Visible = false;
        }
        private void menu_Click(object sender, EventArgs e)
        {
            PlaySFX("botao.wav");
            telaparavoltar.Visible = true;
            menuvoltar.Visible = true;
            continuarnojogo.Visible = true;
        }
        private void menuvoltar_Click(object sender, EventArgs e)
        {
            PlaySFX("papelpassar.wav");
            Menu menu = new Menu();
            menu.Show();
            this.Hide();
        }
        #endregion teladeinformacao
        private void AbrirDialogocomsemluiz(string texto)
        {
            caixadetexto.Enabled = false;
            timer1.Enabled = true;
            dialogo.Text = texto.ToString();
            dialogo.MaximumSize = new Size(MaxWidth, 0);
            dialogo.Visible = true;
            rolagem.Visible = true;
            rolagem.Controls.Add(dialogo);
            caixadetexto.Visible = true;
            deixarenabled.Visible = true;
        }
        private void AbrirDialogo(string texto)
        {
            caixadetexto.Enabled = false;
            timer1.Enabled = true;
            dialogo.Text = texto.ToString();
            dialogo.MaximumSize = new Size(MaxWidth, 0);
            dialogo.Visible = true;
            rolagem.Visible = true;
            rolagem.Controls.Add(dialogo);
            caixadetexto.Visible = true;
            senhorluiz.Visible = true;
            deixarenabled.Visible = true;
        }
        private void AbrirDialogocomFechar(string texto)
        {
            dialogo.Text = texto.ToString();
            fechar.Visible = true;
            dialogo.Visible = true;
            rolagem.Visible = true;
            dialogo.MaximumSize = new Size(MaxWidth, 0);
            rolagem.Controls.Add(dialogo);
            caixadetexto.Visible = true;
            caixadetexto.Enabled = true;
            senhorluiz.Visible = true;
            deixarenabled.Visible = true;

        }
        private void FecharDialogo()
        {
            dialogo.Visible = false;
            rolagem.Visible = false;
            fechar.Visible = false;
            caixadetexto.Visible = false;
            senhorluiz.Visible = false;
            deixarenabled.Visible = false;
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            fechar.Visible = false;
            dialogo.Visible = false;
            rolagem.Visible = false;
            caixadetexto.Visible = false;
            senhorluiz.Visible = false;
            deixarenabled.Visible = false;
            caixadetexto.Enabled = true;

           /* if (analisarobj[0] == 2 && interacoes != 3 && mensagens[0] == false)
            {
                AbrirDialogocomFechar("Aquele Porta Retrato não tem nenhuma foto, que estranho, acho melhor dar uma olhada!");
                timer1.Enabled = false;
                mensagens[0] = true;
            }
            if (ver == true && ganhar == false && mensagens[1] == false)
            {
                AbrirDialogocomFechar("Apareceram alguns pedaços de uma foto, espalhados pelo quarto, acho melhor coletá-los e ver o que forma.");
                mensagens[1] = true;
            }
           
            if (ganhar == true && responder == true && interacoes == 4 && mensagens[2] == false)
            {
                AbrirDialogo("Eu devo anotar as informações no meu fichário!");
                mensagens[2] = true;
            }
            if (interacoes == 4 && puzzle == 10 && responder == false)
            {
                quizz.Image = Properties.Resources.fichanormal;
                responder = true;
                timer1.Enabled = true;
            }*/
        }
        private void fechar_Click(object sender, EventArgs e)
        {
            PlaySFX("botao.wav");

            FecharDialogo();

            if (analisarobj[0] == 2 && interacoes != 3 && mensagens[0] == false)
            {
                AbrirDialogocomFechar("Aquele Porta Retrato não tem nenhuma foto, que estranho, acho melhor dar uma olhada!");
                timer1.Enabled = false;
                mensagens[0] = true;
            }
            if (ver == true && ganhar == false && mensagens[1] == false)
            {
                AbrirDialogocomFechar("Apareceram alguns pedaços de uma foto, espalhados pelo quarto, acho melhor coletá-los e ver o que forma.");
                mensagens[1] = true;
            }

            if (ganhar == true && responder == true && interacoes == 4 && mensagens[2] == false)
            {
                AbrirDialogo("Eu devo anotar as informações no meu fichário!");
                mensagens[2] = true;
            }
            if (interacoes == 4 && puzzle == 10 && responder == false)
            {
                quizz.Image = Properties.Resources.fichanormal;
                responder = true;
                timer1.Enabled = true;
            }
            if (mensagens[1] == true && pic1.Enabled == false)
            {
                pic1.Enabled = true;
                pic2.Enabled = true;
                pic3.Enabled = true;
                pic4.Enabled = true;
                pic5.Enabled = true;
                pic6.Enabled = true;
                pic7.Enabled = true;
                pic8.Enabled = true;
                pic9.Enabled = true;
                pic10.Enabled = true;
            }
        }
        private void voltar_Click(object sender, EventArgs e)
        {
            PlaySFX("botao.wav");

            if (voltaraocorredor == true && ganhar == true && interacoes == 4 && puzzle == 10)
            {
                Fim Final = new Fim();
                Final.Show();
                this.Hide();
            }
            else if (voltaraocorredor == false && ganhar == true && interacoes == 4 && puzzle == 10 && responder == false)
            {
                viudepois = true;
                click = true;
                menu.Visible = false;
                dica.Visible = false;
                som.Visible = false;
                confirmarresposta.Visible = true;
                confirmarresposta.Parent = quizz;
                confirmarresposta.BringToFront();
                confirmarresposta.Location = new Point(639, 484);
                voltar.Visible = false;
                responder = true;
                quizz.Enabled = true;
                fecharficha.Visible = true;
                quizz.Location = new Point(31, -25);
                quizz.Size = new Size(770, 574);
                passarpaginaatras.Visible = true;
                passarpaginafrente.Visible = true;
                fecharficha.Visible = false;
                alternativa1.Visible = false;
                alternativa2.Visible = false;
                alternativa3.Visible = false;
                alternativa4.Visible = false;
                dica.Visible = false;
            }
            /*else if (interacoes == 0)
            {

                Fim Final = new Fim();
                Final.Show();
                this.Hide();
            }*/
            else
            {
                AbrirDialogo("Ainda não olhei toda a sala!");
            }
            
        }

        private void aumentarcarta()
        {
            cartasuicidio.Enabled = true;
            carta.Visible = false;
            cartasuicidio.Size = new Size(395, 485);
            cartasuicidio.Location = new Point(238, 17);
            cartasuicidio.Visible = true;
            cartasuicidio.Enabled = true;
        }
        private void Diminuircarta()
        {
            cartasuicidio.Enabled = false;
            cartasuicidio.Size = new Size(52, 52);
            cartasuicidio.Location = new Point(493, 185);
            carta.Visible = true;
            carta.Size = new Size(52, 52);
            carta.Location = new Point(493, 185);
            cartasuicidio.Visible = true;
        }
        private void amostrartextodacarta()
        {
            textocartadesuicidio.Visible = true;
            textocartadesuicidio.Size = new Size(494, 542);
            textocartadesuicidio.Location = new Point(174, 7);
            textocartadesuicidio.Enabled = true;
        }
        private void EventoLeitura(object sender, EventArgs e)
        {
            if (sender == carta)
            {
                PlaySFX("papeladas.wav");
                aumentarcarta();
                tager[0] = Convert.ToInt32(textocartadesuicidio.Tag);
                if (tager[0] == 0)
                {
                    interacoes++;
                    analisarobj[2]++;
                    visualizar = true;
                    textocartadesuicidio.Tag = 1;
                }
                dialogo.Text = "É uma Carta de Testamento que Getúlio Vargas escreveu!".ToString();
                fechar.Visible = true;
                dialogo.MaximumSize = new Size(MaxWidth, 0);
                dialogo.Visible = true;
                rolagem.Visible = true;
                rolagem.Controls.Add(dialogo);
                caixadetexto.Visible = true;
            }
            if (sender == cartasuicidio)
            {
                amostrartextodacarta();
                cartasuicidio.Visible = false;
            }
            else if (sender == textocartadesuicidio)
            {
                PlaySFX("papeladas.wav");
                textocartadesuicidio.Visible = false;
                Diminuircarta();
                ganhar = true;
                carta.Visible = true;

                if (ganhar == true && responder == true && interacoes == 4 && mensagens[2] == false)
                {
                    AbrirDialogo("Eu devo anotar as informações no meu fichário!");
                    mensagens[2] = true;
                }
            }
        }

        private void aparecerTimer(object sender, EventArgs e)
        {
            if (puzzle == 0 && ganhar == false)
            {
                pic1.Visible = true;
                pic2.Visible = true;
                pic3.Visible = true;
                pic4.Visible = true;
                pic5.Visible = true;
                pic6.Visible = true;
                pic7.Visible = true;
                pic8.Visible = true;
                pic9.Visible = true;
                pic10.Visible = true;
            }
        }

        #region mensagens
        private void mensagem(object sender, EventArgs e)
        {
            timer1.Interval = 2000;
            if (sender == arma)
            {
                PlaySFX("armar.wav");

                tager[0] = Convert.ToInt32(arma.Tag);
                if (tager[0] == 0)
                {
                    interacoes++;
                    analisarobj[0]++;
                    arma.Tag = 1;
                    AbrirDialogocomFechar("Essa é arma que foi disparada no peito de Getúlio Vargas!");
                }
                if (tager[0] == 1)
                {
                    AbrirDialogo("Eu não preciso olhar de novo!");
                }
            }
            if (sender == getulio)
            {
                PlaySFX("tecido.wav");
                tager[0] = Convert.ToInt32(getulio.Tag);
                if (tager[0] == 0)
                {
                    interacoes++;
                    analisarobj[0]++;
                    getulio.Tag = 1;
                    AbrirDialogocomFechar("Esse é o corpo do Getúlio Vargas!");
                }
                if (tager[0] == 1)
                {
                    AbrirDialogo("Eu não preciso olhar de novo!");
                }
            }
            if (sender == portaretrato)
            {
                PlaySFX("portaretrato.wav");

                lu3.Visible = false;
                tager[0] = Convert.ToInt32(portaretrato.Tag);
                if (tager[0] == 0)
                {
                    interacoes++;
                    analisarobj[1]++;
                    portaretrato.Tag = 1;
                    timer2.Enabled = true;
                }
                if (ver == false)
                {
                    AbrirDialogocomFechar("Um Porta-Retrato vazio!");
                    ver = true;
                }
                else if (ver == true && ganhar == true)
                {
                    Diminuircarta();
                    if (diminuir == false)
                    {
                        //diminuir
                        deixarEnabled2.Visible = false;
                        portaretrato.Location = new Point(588, 152);
                        portaretrato.Size = new Size(48,58);
                        diminuir = true;
                        if (ganhar == true && visualizar == false && mensagens[3] == false)
                        {
                            AbrirDialogocomFechar("Eu não reparei antes mas tem uma carta perto do corpo de Getúlio Vargas.");
                            mensagens[3] = true;
                        }
                    }
                    else if (diminuir == true)
                    {
                        //aumentar
                        portaretrato.Location = new Point(238, 17);
                        portaretrato.Size = new Size(395, 485);
                        dialogo.MaximumSize = new Size(MaxWidth, 0);
                        dialogo.Text = "Uma foto de Getúlio Vargas com sua esposa.".ToString();
                        timer1.Enabled = true;
                        dialogo.Visible = true;
                        rolagem.Visible = true;
                        rolagem.Controls.Add(dialogo);
                        caixadetexto.Visible = true;
                        deixarEnabled2.Visible = true;
                        diminuir = false;
                    }
                }
                else 
                {
                    AbrirDialogocomFechar("Tenho que pegar todas as partes da foto!");
                }
            }
            if (interacoes == 4 && puzzle == 10)
            {
                quizz.Image = Properties.Resources.fichanormal;
                responder = true;
                timer1.Enabled = true;
            }
        }
        #endregion mensagens
        #region Puzzle
        private void PassarPuzzle(object sender, EventArgs e)
        {
            PlaySFX("pegarfoto.wav");

            timer1.Interval = 1000;
            if (analisarobj[3] == 0)
            {
                AbrirDialogo("Uma parte de uma Foto!");
                analisarobj[3]++;
            }
            if (sender == pic1)
            {
                tager[1] = Convert.ToInt32(pic1.Tag);
                if (tager[0] == 0)
                {
                    puzzle++;
                    //interacoes++;
                    pic1.Tag = 1;
                }
                pic1.Visible = false;
            }
            if (sender == pic2)
            {
                tager[1] = Convert.ToInt32(pic2.Tag);
                if (tager[1] == 0)
                {
                    puzzle++;
                   // interacoes++;
                    pic2.Tag = 1;
                }
                pic2.Visible = false;
            }
            if (sender == pic3)
            {
                tager[1] = Convert.ToInt32(pic3.Tag);
                if (tager[1] == 0)
                {
                    puzzle++;
                    //interacoes++;
                    pic3.Tag = 1;
                }
                pic3.Visible = false;
            }
            if (sender == pic4)
            {
                tager[1] = Convert.ToInt32(pic4.Tag);
                if (tager[1] == 0)
                {
                    puzzle++;
                   // interacoes++;
                    pic4.Tag = 1;
                }
                pic4.Visible = false;
            }
            if (sender == pic5)
            {
                tager[1] = Convert.ToInt32(pic5.Tag);
                if (tager[1] == 0)
                {
                    puzzle++;
                   // interacoes++;
                    pic5.Tag = 1;
                }
                pic5.Visible = false;
            }
            if (sender == pic6)
            {
                tager[1] = Convert.ToInt32(pic6.Tag);
                if (tager[1] == 0)
                {
                    puzzle++;
                    //interacoes++;
                    pic6.Tag = 1;
                }
                pic6.Visible = false;
            }
            if (sender == pic7)
            {
                tager[1] = Convert.ToInt32(pic7.Tag);
                if (tager[1] == 0)
                {
                    puzzle++;
                   // interacoes++;
                    pic7.Tag = 1;
                }
                pic7.Visible = false;
            }
            if (sender == pic8)
            {
                tager[1] = Convert.ToInt32(pic8.Tag);
                if (tager[1] == 0)
                {
                    puzzle++;
                   // interacoes++;
                    pic8.Tag = 1;
                }
                pic8.Visible = false;
            }
            if (sender == pic9)
            {
                tager[1] = Convert.ToInt32(pic9.Tag);
                if (tager[1] == 0)
                {
                    puzzle++;
                   // interacoes++;
                    pic9.Tag = 1;
                }
                pic9.Visible = false;
            }
            if (sender == pic10)
            {
                tager[1] = Convert.ToInt32(pic10.Tag);
                if (tager[1] == 0)
                {
                    puzzle++;
                  //  interacoes++;
                    pic10.Tag = 1;
                }
                pic10.Visible = false;
            }
            else if (puzzle == 10)
            {
               // timer1.Interval = 2000;
                diminuir = false;
                ganhar = true;
                portaretrato.Image = Properties.Resources.PortaRetratocomfoto;
                portaretrato.Location = new Point(238, 17);
                portaretrato.Size = new Size(395, 485);
                dialogo.MaximumSize = new Size(MaxWidth, 0);
                dialogo.Text = "Uma foto de Getúlio Vargas com sua esposa.".ToString();
                timer1.Enabled = true;
                dialogo.Visible = true;
                rolagem.Visible = true;
                rolagem.Controls.Add(dialogo);
                caixadetexto.Visible = true;
                deixarEnabled2.Visible = true;

                if (interacoes == 4 && puzzle == 10)
                {
                    quizz.Image = Properties.Resources.fichanormal;
                    responder = true;
                    timer1.Enabled = true;
                }
            }
        }
        #endregion Puzzle   
        #region Quiz
        private void DiminuirFicha()
        {
            som.Visible = true;
            menu.Visible = true;
            dica.Visible = true;
            voltar.Visible = true;
            quizz.Image = Properties.Resources.fichafechada;
            quizz.Enabled = false;
            quizz.Location = new Point(662,72);
            dia.Visible = false;
            mes.Visible = false;
            ano.Visible = false;
            barra1.Visible = false;
            barra2.Visible = false;
            quizz.Size = new Size(176, 143);
            passarpaginaatras.Visible = false;
            passarpaginafrente.Visible = false;
            fecharficha.Visible = false;
            alternativa1.Visible = false;
            alternativa2.Visible = false;
            alternativa3.Visible = false;
            alternativa4.Visible = false;
            confirmarresposta.Visible = false;
        }
        private void AumentarFicha()
        {
            dica.Visible = false;
            som.Visible = false;
            menu.Visible = false;
            menu.Visible = false;
            confirmarresposta.Visible = true;
            confirmarresposta.Parent = quizz;
            confirmarresposta.BringToFront();
            confirmarresposta.Location = new Point(639, 484);
            voltar.Visible = false;
            quizz.Image = Properties.Resources.fichafechada;
            fecharficha.Visible = true;
            quizz.Enabled = true;
            quizz.Location = new Point(31, -25);
            quizz.Size = new Size(770, 574);
            passarpaginaatras.Visible = true;
            passarpaginafrente.Visible = true;
            fecharficha.Visible = true;
            alternativa1.Visible = false;
            alternativa2.Visible = false;
            alternativa3.Visible = false;
            alternativa4.Visible = false;
            fecharficha.Location = new Point(210, 40);
            fecharficha.Parent = quizz;
            fecharficha.BackColor = Color.Transparent;
        }
        private void AlternativasF()
        {
            alternativa1.Visible = false;
            alternativa2.Visible = false;
            alternativa3.Visible = false;
            alternativa4.Visible = false;
        }
        private void AlternativasT()
        {
            alternativa1.Visible = true;
            alternativa2.Visible = true;
            alternativa3.Visible = true;
            alternativa4.Visible = true;
        }
        private void EventoQuiz(object sender, EventArgs e)
        {
            if (sender == fichario)
            {
                if (interacoes == 4 && puzzle == 10)
                {
                    responder = true;
                }
                AumentarFicha();
            }
            if (sender == fecharficha)
            {
                DiminuirFicha();
                pagina = 0;
            }
        }
        private void ResponderPergunta(object sender, EventArgs e)
        {
            if (responder == true)
            {
                if(pagina == 120)
                {
                    alternativa1.Image = Properties.Resources.btn;
                    alternativa2.Image = Properties.Resources.btnfechar;
                    alternativa3.Image = Properties.Resources.btn;
                    alternativa4.Image = Properties.Resources.btn;

                    AbrirDialogocomsemluiz("Eu já respondi essa questão!");
                }
                if (pagina == 180)
                {
                    alternativa1.Image = Properties.Resources.btn;
                    alternativa2.Image = Properties.Resources.btnfechar;
                    alternativa3.Image = Properties.Resources.btn;
                    alternativa4.Image = Properties.Resources.btn;

                    AbrirDialogocomsemluiz("Eu já respondi essa questão!");
                }
                if (pagina == 240)
                {
                    alternativa1.Image = Properties.Resources.btn;
                    alternativa2.Image = Properties.Resources.btnfechar;
                    alternativa3.Image = Properties.Resources.btn;
                    alternativa4.Image = Properties.Resources.btn;

                    AbrirDialogocomsemluiz("Eu já respondi essa questão!");
                }
                if (pagina == 300)
                {
                    dia.Text = "05".ToString();
                    mes.Text = "08".ToString();
                    ano.Text = "1954".ToString();

                    alternativa1.Image = Properties.Resources.btn;
                    alternativa2.Image = Properties.Resources.btnfechar;
                    alternativa3.Image = Properties.Resources.btn;
                    alternativa4.Image = Properties.Resources.btn;

                    AbrirDialogocomsemluiz("Eu já respondi essa questão!");
                }
                if (pagina == 360)
                {
                    string respostadia = Convert.ToString(dia.Text);
                    string respostames = Convert.ToString(mes.Text);
                    string respostaano = Convert.ToString(ano.Text);
                    if (respostadia == "24" && (respostames == "08" || respostames == "8") && respostaano == "1954")
                    {
                        respondeu2 = 1;
                        quiz2 = "correto";
                    }
                    else if (respostadia == "" || respostames == "" || respostaano == "")
                    {
                        respondeu2 = 0;
                        quiz2 = null;
                    }
                    else if ((respostadia != "24" && respostadia != "") || (respostames != "08" && respostames != "") || (respostaano != "1954" && respostaano != ""))
                    {
                        respondeu2 = -1;
                        quiz2 = "errado";
                    }
                    if (sender == alternativa1)
                    {
                        respondeu = 1;
                        alternativa1.Image = Properties.Resources.btnfechar;
                        alternativa2.Image = Properties.Resources.btn;
                        alternativa3.Image = Properties.Resources.btn;
                        alternativa4.Image = Properties.Resources.btn;
                        quiz1 = "errado";
                    }
                    if (sender == alternativa2)
                    {
                        respondeu = 2;
                        alternativa2.Image = Properties.Resources.btnfechar;
                        alternativa3.Image = Properties.Resources.btn;
                        alternativa4.Image = Properties.Resources.btn;
                        alternativa1.Image = Properties.Resources.btn;
                        quiz1 = "correto";
                    }
                    if (sender == alternativa3)
                    {
                        respondeu = 3;
                        alternativa3.Image = Properties.Resources.btnfechar;
                        alternativa4.Image = Properties.Resources.btn;
                        alternativa1.Image = Properties.Resources.btn;
                        alternativa2.Image = Properties.Resources.btn;
                        quiz1 = "errado";
                    }
                    if (sender == alternativa4)
                    {
                        respondeu = 4;
                        alternativa4.Image = Properties.Resources.btnfechar;
                        alternativa1.Image = Properties.Resources.btn;
                        alternativa2.Image = Properties.Resources.btn;
                        alternativa3.Image = Properties.Resources.btn;
                        quiz1 = "errado";
                    }
                }
                    else if (pagina == 120)
                    {
                    AbrirDialogocomsemluiz("Eu já respondi essa questão!");
                }
            }
            else if (responder == false)
            {
                AbrirDialogocomsemluiz("Eu não vou responder agora!");
            }
        }
        private void confirmarresposta_Click(object sender, EventArgs e)
        {
            PlaySFX("botao.wav");
            switch (responder)
            {
                case true:
                    string respostadia = Convert.ToString(dia.Text);
                    string respostames = Convert.ToString(mes.Text);
                    string respostaano = Convert.ToString(ano.Text);
                    if (respostadia == "24" && (respostames == "08" || respostames == "8") && respostaano == "1954")
                    {
                        respondeu2 = 1;
                        quiz2 = "correto";
                    }
                    else if (respostadia == "" || respostames == "" || respostaano == "")
                    {
                        respondeu2 = 0;
                        quiz2 = null;
                    }
                    else if ((respostadia != "24" && respostadia != "") || (respostames != "08" && respostames != "") || (respostaano != "1954" && respostaano != ""))
                    {
                        respondeu2 = -1;
                        quiz2 = "errado";
                    }
                    if (quiz1 == "correto" && quiz2 == "correto")
                    {
                        click = true;
                        DiminuirFicha();
                        voltaraocorredor = true;
                       
                        dialogo.Text = "Com isso eu finalizo a minha investigação, A carta de Testamento de Getúlio Vargas, não só fala sobre o seu suicídio, como fala dos ataques que ele havia sofrendo durante seu governo, Essa carta com certeza entrará para a história.\r\n\r\nAgora, o que me resta é retonar, para informar ao policial e ao povo sobre o resultado da minha investigação!".ToString();
                        dialogo.MaximumSize = new Size(MaxWidth, 0);
                        fechar.Visible = true;
                        dialogo.Visible = true;
                        rolagem.Visible = true;
                        rolagem.Controls.Add(dialogo);
                        caixadetexto.Visible = true;
                        senhorluiz.Visible = true;
                        deixarenabled.Visible = true;
                    }
                    else if (quiz2 == null || quiz1 == null)
                    {
                        AbrirDialogocomsemluiz("Falto responder a outra Questão!");
                    }
                    else if ((quiz1 == "correto" && quiz2 == "errado") || quiz2 == "correto")
                    {
                        DiminuirFicha();

                        AbrirDialogocomsemluiz("Devo averiguar novamente o outro comodo, por via das dúvidas!");

                        timer3.Enabled = true;
                    }
                    else if (quiz1 == "errado" && quiz2 == "errado")
                    {
                        DiminuirFicha();

                        AbrirDialogocomsemluiz("Devo averiguar novamente o outro comodo, por via das dúvidas!");

                        timer3.Enabled = true;
                    }
                    break;

                case false:
                    AbrirDialogocomsemluiz("Eu não vou responder agora!");
                    break;
            }
        }

        private void PassarPagina(object sender, EventArgs e)
        {
            PlaySFX("papelpassar.wav");
            object passarfrente = passarpaginafrente;
            object passartras = passarpaginaatras;

            switch (responder)
            {
                case true:
                    if (sender == passarpaginafrente)
                    {
                        pagina += 60;
                        if (pagina == 0)
                        {
                            fecharficha.Parent = quizz;
                            fecharficha.Location = new Point(210, 40);
                            quizz.Image = Properties.Resources.fichafechada;
                            AlternativasF();

                        }
                        else if (pagina == 60)
                        {
                            fecharficha.Parent = quizz;
                            fecharficha.Location = new Point(50, 40);
                            quizz.Image = Properties.Resources.fichaaberta;
                            AlternativasF();
                        }
                        else if (pagina == 120)
                        {
                            fecharficha.Parent = quizz;
                            fecharficha.Location = new Point(20, 40);
                            alternativa1.Image = Properties.Resources.btn;
                            alternativa3.Image = Properties.Resources.btn;
                            alternativa4.Image = Properties.Resources.btn;
                            quizz.Image = Properties.Resources.quizz1carimbada;
                            alternativa2.Image = Properties.Resources.btnfechar;
                            alternativa1.Location = new Point(418, 171);
                            alternativa2.Location = new Point(418, 244);
                            alternativa3.Location = new Point(418, 304);
                            alternativa4.Location = new Point(418, 365);
                            AlternativasT();
                        }
                        else if (pagina == 180)
                        {
                            fecharficha.Parent = quizz;
                            fecharficha.Location = new Point(20, 40);
                            alternativa1.Image = Properties.Resources.btn;
                            alternativa3.Image = Properties.Resources.btn;
                            alternativa4.Image = Properties.Resources.btn;
                            alternativa2.Image = Properties.Resources.btnfechar;
                            quizz.Image = Properties.Resources.quizz2P1carimbada;
                            alternativa1.Location = new Point(415, 179);
                            alternativa2.Location = new Point(415, 239);
                            alternativa3.Location = new Point(415, 318);
                            alternativa4.Location = new Point(415, 379);
                            AlternativasT();

                        }
                        else if (pagina == 240)
                        {
                            fecharficha.Parent = quizz;
                            fecharficha.Location = new Point(20, 40);
                            dia.Visible = false;
                            mes.Visible = false;
                            ano.Visible = false;
                            barra1.Visible = false;
                            barra2.Visible = false;
                            alternativa1.Image = Properties.Resources.btn;
                            alternativa3.Image = Properties.Resources.btn;
                            alternativa4.Image = Properties.Resources.btn;
                            alternativa2.Image = Properties.Resources.btnfechar;
                            quizz.Image = Properties.Resources.quizz2P2carimbada;
                            alternativa1.Location = new Point(415, 256);
                            alternativa2.Location = new Point(415, 212);
                            alternativa3.Location = new Point(415, 297);
                            alternativa4.Location = new Point(415, 337);
                            AlternativasT();

                        }
                        else if (pagina == 300)
                        {
                            fecharficha.Parent = quizz;
                            fecharficha.Location = new Point(20, 40);
                            dia.Visible = true;
                            mes.Visible = true;
                            ano.Visible = true;
                            barra1.Visible = true;
                            barra2.Visible = true;
                            dia.Text = "05".ToString();
                            mes.Text = "08".ToString();
                            ano.Text = "1954".ToString();
                            dia.Enabled = false;
                            mes.Enabled = false;
                            ano.Enabled = false;
                            dia.Location = new Point(427, 208);
                            mes.Location = new Point(482,208);
                            ano.Location = new Point(535, 208);
                            barra1.Location = new Point(464, 202);
                            barra2.Location = new Point(518, 201);
                            alternativa1.Image = Properties.Resources.btn;
                            alternativa3.Image = Properties.Resources.btn;
                            alternativa4.Image = Properties.Resources.btn;
                            alternativa2.Image = Properties.Resources.btnfechar;
                            quizz.Image = Properties.Resources.quizz3carimbada;
                            alternativa1.Location = new Point(418, 303);
                            alternativa2.Location = new Point(418, 391);
                            alternativa3.Location = new Point(418, 362);
                            alternativa4.Location = new Point(418, 331);
                            AlternativasT();
                        }
                        else if (pagina == 360)
                        {
                            fecharficha.Parent = quizz;
                            fecharficha.Location = new Point(20, 40);
                            dia.Enabled = true;
                            mes.Enabled = true;
                            ano.Enabled = true;
                            dia.Visible = true;
                            mes.Visible = true;
                            ano.Visible = true;
                            barra1.Visible = true;
                            dia.Location = new Point(427, 144);
                            mes.Location = new Point(483, 144);
                            ano.Location = new Point(536, 144);
                            barra1.Location = new Point(465, 138);
                            barra2.Location = new Point(519, 138);
                            if (respondeu == 1)
                            {
                                alternativa1.Image = Properties.Resources.btnfechar;
                                alternativa2.Image = Properties.Resources.btn;
                                alternativa3.Image = Properties.Resources.btn;
                                alternativa4.Image = Properties.Resources.btn;
                            }
                            else if (respondeu == 2)
                            {
                                alternativa1.Image = Properties.Resources.btn;
                                alternativa3.Image = Properties.Resources.btn;
                                alternativa4.Image = Properties.Resources.btn;
                                alternativa2.Image = Properties.Resources.btnfechar;
                            }
                            else if (respondeu == 3)
                            {
                                alternativa3.Image = Properties.Resources.btnfechar;
                                alternativa1.Image = Properties.Resources.btn;
                                alternativa2.Image = Properties.Resources.btn;
                                alternativa4.Image = Properties.Resources.btn;
                            }
                            else if (respondeu == 4)
                            {
                                alternativa4.Image = Properties.Resources.btnfechar;
                                alternativa1.Image = Properties.Resources.btn;
                                alternativa2.Image = Properties.Resources.btn;
                                alternativa3.Image = Properties.Resources.btn;
                            }
                            else
                            {
                                alternativa3.Image = Properties.Resources.btn;
                                alternativa1.Image = Properties.Resources.btn;
                                alternativa2.Image = Properties.Resources.btn;
                                alternativa4.Image = Properties.Resources.btn;
                            }
                            if (respondeu2 == 0)
                            {
                                dia.Text = "".ToString();
                                mes.Text = "".ToString();
                                ano.Text = "".ToString();
                            }
                            quizz.Image = Properties.Resources.quizz4;
                            alternativa1.Location = new Point(418, 218);
                            alternativa2.Location = new Point(418, 354);
                            alternativa3.Location = new Point(418, 277);
                            alternativa4.Location = new Point(418, 402);
                            AlternativasT();
                        }
                        else
                        {
                            fecharficha.Parent = quizz;
                            fecharficha.Location = new Point(20, 40);
                            dia.Enabled = true;
                            mes.Enabled = true;
                            ano.Enabled = true;
                            dia.Visible = true;
                            mes.Visible = true;
                            ano.Visible = true;
                            barra1.Visible = true;
                            barra2.Visible = true;
                            dia.Location = new Point(427, 144);
                            mes.Location = new Point(483, 144);
                            ano.Location = new Point(536, 144);
                            barra1.Location = new Point(465, 138);
                            barra2.Location = new Point(519, 138);
                            pagina = 360;
                            quizz.Image = Properties.Resources.quizz4;
                            AlternativasT();

                            AbrirDialogocomsemluiz("Eu tenho que reponder essa pergunta!");
                        }
                    }
                    if (sender == passarpaginaatras)
                    {
                        pagina -= 60;
                        if (pagina == 0)
                        {
                            fecharficha.Parent = quizz;
                            fecharficha.Location = new Point(210, 40);
                            quizz.Image = Properties.Resources.fichafechada;
                            AlternativasF();
                        }
                        else if (pagina == 60)
                        {
                            fecharficha.Parent = quizz;
                            fecharficha.Location = new Point(50, 40);
                            quizz.Image = Properties.Resources.fichaaberta;
                            AlternativasF();
                        }
                        else if (pagina == 120)
                        {
                            fecharficha.Parent = quizz;
                            fecharficha.Location = new Point(20, 40);
                            alternativa1.Image = Properties.Resources.btn;
                            alternativa3.Image = Properties.Resources.btn;
                            alternativa4.Image = Properties.Resources.btn;
                            alternativa2.Image = Properties.Resources.btnfechar;
                            quizz.Image = Properties.Resources.quizz1carimbada;
                            AlternativasT();
                        }
                        else if (pagina == 120)
                        {
                            fecharficha.Parent = quizz;
                            fecharficha.Location = new Point(20, 40);
                            alternativa1.Image = Properties.Resources.btn;
                            alternativa3.Image = Properties.Resources.btn;
                            alternativa4.Image = Properties.Resources.btn;
                            alternativa2.Image = Properties.Resources.btnfechar;
                            quizz.Image = Properties.Resources.quizz1carimbada;
                            alternativa1.Location = new Point(418, 171);
                            alternativa2.Location = new Point(418, 244);
                            alternativa3.Location = new Point(418, 304);
                            alternativa4.Location = new Point(418, 365);
                            AlternativasT();
                        }
                        else if (pagina == 180)
                        {
                            fecharficha.Parent = quizz;
                            fecharficha.Location = new Point(20, 40);
                            alternativa1.Image = Properties.Resources.btn;
                            alternativa3.Image = Properties.Resources.btn;
                            alternativa4.Image = Properties.Resources.btn;
                            alternativa2.Image = Properties.Resources.btnfechar;
                            quizz.Image = Properties.Resources.quizz2P1carimbada;
                            alternativa1.Location = new Point(415, 179);
                            alternativa2.Location = new Point(415, 239);
                            alternativa3.Location = new Point(415, 318);
                            alternativa4.Location = new Point(415, 379);
                            AlternativasT();

                        }
                        else if (pagina == 240)
                        {
                            fecharficha.Parent = quizz;
                            fecharficha.Location = new Point(20, 40);
                            dia.Visible = false;
                            mes.Visible = false;
                            ano.Visible = false;
                            barra1.Visible = false;
                            barra2.Visible = false;
                            alternativa1.Image = Properties.Resources.btn;
                            alternativa3.Image = Properties.Resources.btn;
                            alternativa4.Image = Properties.Resources.btn;
                            alternativa2.Image = Properties.Resources.btnfechar;
                            quizz.Image = Properties.Resources.quizz2P2carimbada;
                            alternativa1.Location = new Point(415, 256);
                            alternativa2.Location = new Point(415, 212);
                            alternativa3.Location = new Point(415, 297);
                            alternativa4.Location = new Point(415, 337);
                            AlternativasT();
                        }
                        else if (pagina == 300)
                        {
                            fecharficha.Parent = quizz;
                            fecharficha.Location = new Point(20, 40);
                            dia.Enabled = false;
                            mes.Enabled = false;
                            ano.Enabled = false;
                            dia.Visible = true;
                            mes.Visible = true;
                            ano.Visible = true;
                            barra1.Visible = true;
                            barra2.Visible = true;
                            dia.Location = new Point(427, 208);
                            mes.Location = new Point(482, 208);
                            ano.Location = new Point(535, 208);
                            barra1.Location = new Point(464, 202);
                            barra2.Location = new Point(518, 201);
                            dia.Text = "05".ToString();
                            mes.Text = "08".ToString();
                            ano.Text = "1954".ToString();

                            alternativa1.Image = Properties.Resources.btn;
                            alternativa3.Image = Properties.Resources.btn;
                            alternativa4.Image = Properties.Resources.btn;
                            alternativa2.Image = Properties.Resources.btnfechar;
                            quizz.Image = Properties.Resources.quizz3carimbada;
                            alternativa1.Location = new Point(418, 303);
                            alternativa2.Location = new Point(418, 391);
                            alternativa3.Location = new Point(418, 362);
                            alternativa4.Location = new Point(418, 331);
                            AlternativasT();

                        }
                        else if (pagina == 360)
                        {
                            fecharficha.Parent = quizz;
                            fecharficha.Location = new Point(20, 40);
                            if (respondeu == 1)
                            {
                                alternativa1.Image = Properties.Resources.btnfechar;
                                alternativa2.Image = Properties.Resources.btn;
                                alternativa3.Image = Properties.Resources.btn;
                                alternativa4.Image = Properties.Resources.btn;
                            }
                            else if (respondeu == 2)
                            {
                                alternativa1.Image = Properties.Resources.btn;
                                alternativa3.Image = Properties.Resources.btn;
                                alternativa4.Image = Properties.Resources.btn;
                                alternativa2.Image = Properties.Resources.btnfechar;
                            }
                            else if (respondeu == 3)
                            {
                                alternativa3.Image = Properties.Resources.btnfechar;
                                alternativa1.Image = Properties.Resources.btn;
                                alternativa2.Image = Properties.Resources.btn;
                                alternativa4.Image = Properties.Resources.btn;
                            }
                            else if (respondeu == 4)
                            {
                                alternativa4.Image = Properties.Resources.btnfechar;
                                alternativa1.Image = Properties.Resources.btn;
                                alternativa2.Image = Properties.Resources.btn;
                                alternativa3.Image = Properties.Resources.btn;
                            }
                            else
                            {
                                alternativa3.Image = Properties.Resources.btn;
                                alternativa1.Image = Properties.Resources.btn;
                                alternativa2.Image = Properties.Resources.btn;
                                alternativa4.Image = Properties.Resources.btn;
                            }
                            if (respondeu2 == 0)
                            {
                                dia.Text = "".ToString();
                                mes.Text = "".ToString();
                                ano.Text = "".ToString();
                            }
                            dia.Enabled = true;
                            mes.Enabled = true;
                            ano.Enabled = true;
                            dia.Visible = true;
                            mes.Visible = true;
                            ano.Visible = true;
                            barra1.Visible = true;
                            barra2.Visible = true;
                            dia.Location = new Point(427, 144);
                            mes.Location = new Point(483, 144);
                            ano.Location = new Point(536, 144);
                            barra1.Location = new Point(465, 138);
                            barra2.Location = new Point(519, 138);
                            quizz.Image = Properties.Resources.quizz4;
                            alternativa1.Location = new Point(418, 218);
                            alternativa2.Location = new Point(418, 354);
                            alternativa3.Location = new Point(418, 277);
                            alternativa4.Location = new Point(418, 402);
                            AlternativasT();

                        }
                        else
                        {
                            fecharficha.Parent = quizz;
                            fecharficha.Location = new Point(210, 40);
                            dia.Visible = false;
                            mes.Visible = false;
                            ano.Visible = false;
                            barra1.Visible = false;
                            barra2.Visible = false;
                            pagina = 0;
                            quizz.Image = Properties.Resources.fichafechada;
                            AlternativasF();

                            AbrirDialogocomsemluiz("Não tem mais páginas!");
                        }
                    }
                    break;

                case false:

                    if (sender == passarpaginafrente)
                    {
                        pagina += 60;
                        if (pagina == 0)
                        {
                            quizz.Image = Properties.Resources.fichafechada;
                            AlternativasF();
                            fecharficha.Location = new Point(250, 40);
                            fecharficha.Parent = quizz;
                            fecharficha.BackColor = Color.Transparent;
                        }
                        else if (pagina == 60)
                        {
                            quizz.Image = Properties.Resources.fichaaberta;
                            AlternativasF();
                            fecharficha.Location = new Point(55, 40);
                            fecharficha.Parent = quizz;
                            fecharficha.BackColor = Color.Transparent;
                        }
                        else if (pagina == 120)
                        {

                            quizz.Image = Properties.Resources.quizz1;
                            AlternativasT();
                            fecharficha.Location = new Point(31, 40);
                            fecharficha.Parent = quizz;
                            fecharficha.BackColor = Color.Transparent;
                        }
                        else if (pagina == 180)
                        {
                            quizz.Image = Properties.Resources.quizz2P1;
                            AlternativasF();
                            fecharficha.Location = new Point(31, 40);
                            fecharficha.Parent = quizz;
                            fecharficha.BackColor = Color.Transparent;
                        }
                        else if (pagina == 240)
                        {
                            quizz.Image = Properties.Resources.quizz2P2;
                            AlternativasF();
                            fecharficha.Location = new Point(31, 40);
                            fecharficha.Parent = quizz;
                            fecharficha.BackColor = Color.Transparent;
                        }
                        else if (pagina == 300)
                        {
                            quizz.Image = Properties.Resources.quizz3;
                            AlternativasF();
                            fecharficha.Location = new Point(31, 40);
                            fecharficha.Parent = quizz;
                            fecharficha.BackColor = Color.Transparent;
                        }
                        else if (pagina == 360)
                        {
                            quizz.Image = Properties.Resources.quizz4;
                            AlternativasF();
                            fecharficha.Location = new Point(31, 40);
                            fecharficha.Parent = quizz;
                            fecharficha.BackColor = Color.Transparent;
                        }
                        else
                        {
                            pagina = 360;
                            quizz.Image = Properties.Resources.quizz4;
                            AlternativasF();
                            fecharficha.Location = new Point(31, 40);
                            fecharficha.Parent = quizz;
                            fecharficha.BackColor = Color.Transparent;

                            AbrirDialogocomsemluiz("Não tem mais páginas!");
                        }
                    }
                    if (sender == passarpaginaatras)
                    {
                        pagina -= 60;
                        if (pagina == 0)
                        {
                            quizz.Image = Properties.Resources.fichafechada;
                            AlternativasF();
                            fecharficha.Location = new Point(250, 40);
                            fecharficha.Parent = quizz;
                            fecharficha.BackColor = Color.Transparent;
                        }
                        else if (pagina == 60)
                        {
                            quizz.Image = Properties.Resources.fichaaberta;
                            AlternativasF();
                            fecharficha.Location = new Point(55, 40);
                            fecharficha.Parent = quizz;
                            fecharficha.BackColor = Color.Transparent;
                        }
                        else if (pagina == 120)
                        {
                            quizz.Image = Properties.Resources.quizz1;
                            AlternativasF();
                            fecharficha.Location = new Point(31, 40);
                            fecharficha.Parent = quizz;
                            fecharficha.BackColor = Color.Transparent;

                        }
                        else if (pagina == 180)
                        {
                            quizz.Image = Properties.Resources.quizz2P1;
                            AlternativasF();
                            fecharficha.Location = new Point(31, 40);
                            fecharficha.Parent = quizz;
                            fecharficha.BackColor = Color.Transparent;
                        }
                        else if (pagina == 240)
                        {
                            quizz.Image = Properties.Resources.quizz2P2;
                            AlternativasF();
                            fecharficha.Location = new Point(31, 40);
                            fecharficha.Parent = quizz;
                            fecharficha.BackColor = Color.Transparent;
                        }
                        else if (pagina == 300)
                        {
                            quizz.Image = Properties.Resources.quizz3;
                            AlternativasF();
                            fecharficha.Location = new Point(31, 40);
                            fecharficha.Parent = quizz;
                            fecharficha.BackColor = Color.Transparent;
                        }
                        else if (pagina == 360)
                        {
                            quizz.Image = Properties.Resources.quizz4;
                            AlternativasF();
                            fecharficha.Location = new Point(31, 40);
                            fecharficha.Parent = quizz;
                            fecharficha.BackColor = Color.Transparent;
                        }
                        else
                        {
                            pagina = 0;
                            quizz.Image = Properties.Resources.fichafechada;
                            AlternativasF();
                            fecharficha.Location = new Point(250, 40);
                            fecharficha.Parent = quizz;
                            fecharficha.BackColor = Color.Transparent;

                            AbrirDialogocomsemluiz("Não tem mais páginas!");
                        }
                    }
                    break;
            }
        }

        #endregion Quiz

        private void dica_Click(object sender, EventArgs e)
        {
            PlaySFX("botao.wav");
            if (analisarobj[0] < 2 && analisarobj[1] == 0)
            {
                AbrirDialogo("Por que eu não verifico a cama?");
            }
            else if (analisarobj[0] == 2 && interacoes != 4)
            {
                AbrirDialogo("Esse porta-Retrato está estranho, é melhor eu dá uma olha nele");
            }
            else if (puzzle != 10 && analisarobj[0] < 2)
            {
                AbrirDialogo("Eu tenho que pegar todas essas fotos e vericar a cama!");
            }
            else if (puzzle != 10 && interacoes == 4)
            {
                AbrirDialogo("Eu tenho que pegar todas as fotos!");
            }
            else if (puzzle == 10 && ganhar == true && visualizar == false && click == false)
            {
                AbrirDialogo("Eu tenho que olhar a carta em cima da cama!");
            }
            else if (interacoes == 4 && puzzle == 10 && click == false)
            {
                AbrirDialogo("Eu devo anotar as informações no meu fichário! Ele se encontra no canto superior direito.");
            }
            else if (voltaraocorredor == true && ganhar == true)
            {
                AbrirDialogo("Eu preciso retornar!");
            }
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            Arquivos arquivos = new Arquivos();
            arquivos.Show();
            this.Hide();
            timer3.Enabled = false;
        }

    }
}
