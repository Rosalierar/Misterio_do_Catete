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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace misterio_do_catete
{
    public partial class Arquivos : Form
    {
        bool tocar = true;
        int interacoes = 0;
        bool ganhar = false;
        bool voltaraocorredor;
        int contador = 0;
        int add = 0;
        bool responder = false;
        int respondeu = 0;
        int respondeu2 = 0;
        string quiz1 = null;
        string quiz2 = null;
        bool desaparecer = false;
        int pagina = 0;

        bool[] mensagens = new bool[3];
        bool concluirquizz = false;
        bool viudepois = false;
        bool click = false;

        private const int MaxWidth = 580;
        public Arquivos()
        {
            InitializeComponent();
            /*string audioFilePath = "Jogo.wav";
            AudioManager.Instance.SetlLoop(true);

            AudioManager.Instance.Play(audioFilePath);
            //PlayMusic("Jogo.wav");*/

            AbrirDialogocomFechar("Aqui tem muitas gavetas lotadas de papéis, mas algumas estão entreabertas. Estranho, melhor averiguar esses papéis, podem ter informações importantes.");

            for (int i = 0; i < 3; i++)
            {
                mensagens[i] = false;
            }
            rolagem.Controls.Add(dialogo);
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
               // PlayMusic("Jogo.wav");
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
        private void voltar_Click(object sender, EventArgs e)
        {
            PlaySFX("botao.wav");
            if (voltaraocorredor == true && ganhar == true)
            {
                CorredorFase4 corredor = new CorredorFase4();
                corredor.Show();
                this.Hide();
            }
            else if (voltaraocorredor == false && ganhar == true)
            {
                AbrirDialogocomFechar("Ainda preciso pegar algo!");
            }
            else if (interacoes == 7 && ganhar == false)
            {
                viudepois = true;
                click = true;
                dica.Visible = false;
                menu.Visible = false;
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

            //apenas para testar as proximas fases
           /* else if (interacoes == 0)
            {
                CorredorFase4 corredor = new CorredorFase4();
                corredor.Show();
                this.Hide();
            }
            //*/

            else
            {
                AbrirDialogo("Ainda não olhei toda a sala!");
            }
        }
        private void Comodo(int num)
        {
            if (num == 0)
            {
                Salao salao = new Salao();
                salao.Show();
                this.Hide();
                timer2.Enabled = false;
            }
            else if (num == 1)
            {
                CorredorFase4 corredor = new CorredorFase4();
                corredor.Show();
                this.Hide();
                timer3.Enabled = false;
            }
        }
        private void AbrirDialogocomsemluiz(string texto)
        {
            caixadetexto.Enabled = false;
            timer1.Enabled = true;
            dialogo.Text = texto.ToString();
            dialogo.Visible = true; 
            rolagem.Visible = true;
            dialogo.MaximumSize = new Size(MaxWidth, 0);
            rolagem.Controls.Add(dialogo);
            caixadetexto.Visible = true;
            deixarenabled.Visible = true;
        }
        private void AbrirDialogo(string texto)
        {
            caixadetexto.Enabled = false;
            timer1.Enabled = true;
            dialogo.Text = texto.ToString();
            dialogo.Visible = true; 
            rolagem.Visible = true;
            dialogo.MaximumSize = new Size(MaxWidth, 0);
            rolagem.Controls.Add(dialogo);
            caixadetexto.Visible = true;
            senhorluiz.Visible = true;
            deixarenabled.Visible = true;
        }
        private void AbrirDialogocomFechar(string texto)
        {
            caixadetexto.Enabled = true;
            dialogo.Text = texto.ToString();
            dialogo.Visible = true;
            rolagem.Visible = true;
            dialogo.MaximumSize = new Size(MaxWidth, 0);
            rolagem.Controls.Add(dialogo);
            fechar.Visible = true;
            caixadetexto.Visible = true;
            senhorluiz.Visible = true;
            deixarenabled.Visible = true;
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
        }
        private void FecharDialogo()
        {
            fechar.Visible = false;
            dialogo.Visible = false;
            rolagem.Visible = false;
            caixadetexto.Visible = false;
            senhorluiz.Visible = false;
            deixarenabled.Visible = false;
        }
        private void fechar_Click(object sender, EventArgs e)
        {
            PlaySFX("botao.wav");
            FecharDialogo();
            if (add == 6 && mensagens[0]== false)
            {
                quizz.Image = Properties.Resources.fichanormal;
                AbrirDialogocomFechar("Esse atentado com certeza trouxe dificuldades para Getúlio Vargas!");
                mensagens[0] = true;
            }
            else if (interacoes == 7 && mensagens[1] == false && mensagens[0] == true)
            {
                AbrirDialogocomFechar("Agora o que me resta fazer nessa sala é anotar as informações no meu fichário!");
                mensagens[1] = true;
            }
            if ((viudepois == false || viudepois == true) && concluirquizz == true && mensagens[2] == false)
            {
                AbrirDialogocomFechar("Há algo em cima desse armário de aço!");
                mensagens[2] = true;
            }
            if (voltaraocorredor == true && quiz1 == "correto" && viudepois == true)
            {
                timer3.Enabled = true;
            }
        }
        private void chavefase4_Click(object sender, EventArgs e)
        {
            PlaySFX("chaves.wav");
            chavefase4.Visible = false;
            voltaraocorredor = true;
            AbrirDialogocomFechar("Outra chave, essa deve abrir a última porta restante do corredor, o Quarto do Presidente!");
        }

        #region mensagens

        private void mensagem(object sender, EventArgs e)
        {
            int tager;
           
            if (sender == quadro1)
            {
                PlaySFX("papeladas.wav");
                tager = Convert.ToInt32(quadro1.Tag);
                if (tager == 0)
                {
                    interacoes++;
                    add++;
                    quadro1.Tag = 1;
                    AbrirDialogocomFechar("No papel está escrito:\r\n\r\nNa madrugada de 5 de agosto de 1954, um atentado a tiros de revólver, em frente ao edifício onde residia Carlos Lacerda, em Copacabana, no Rio de Janeiro, mata o major Rubens Florentino Vaz, da Força Aérea Brasileira (FAB), e fere, no pé, Carlos Lacerda, jornalista e o futuro deputado federal e governador da Guanabara e membro da UDN, que fazia forte oposição a Getúlio.");
                }
                if (tager == 1)
                {
                    AbrirDialogo("Eu não preciso mais ver o que tem aqui!");
                }
            }
            if (sender == quadro1_2)
            {
                PlaySFX("papeladas.wav");
                tager = Convert.ToInt32(quadro1_2.Tag);
                if (tager == 0)
                {
                    interacoes++;
                    add++;
                    quadro1_2.Tag = 1;
                    AbrirDialogocomFechar("No papel está escrito:\r\n\r\nOs jornais e as rádios davam em manchetes, todos os dias, a perseguição aos suspeitos. Alcino foi capturado no dia 13 de agosto. Climério foi finalmente capturado, no dia 17 de agosto, pelo coronel da Aeronáutica Délio Jardim de Matos que, posteriormente, chegaria a ser ministro da Aeronáutica. Na caçada aos suspeitos, chegou-se a utilizar uma novidade para a época, o helicóptero.");
                }
                if (tager == 1)
                {
                    AbrirDialogo("Eu não preciso mais ver o que tem aqui!");
                }
            }
            if (sender == quadro2)
            {
                PlaySFX("papeladas.wav");
                tager = Convert.ToInt32(quadro2.Tag);
                if (tager == 0)
                {
                    interacoes++;
                    add++;
                    quadro2.Tag = 1;
                    AbrirDialogocomFechar("No papel está escrito:\r\n\r\nGregório Fortunato, chefe da guarda pessoal do presidente Getúlio Vargas, chamado pelo povo simplesmente de Gregório, foi acusado de ser o mandante do atentado contra Lacerda. Gregório admitiria mais tarde perante à justiça ter sido o mandante. Em 1956, os acusados do crime foram levados a um primeiro julgamento: Gregório Fortunato foi condenado a 25 anos de prisão como mandante, pena reduzida a vinte anos por Juscelino Kubitschek e a quinze anos por João Goulart. Gregório foi assassinado em 1962, no Rio de Janeiro, dentro da penitenciária do Complexo Lemos de Brito, pelo também detento Feliciano Emiliano Damas.");
                }
                if (tager == 1)
                {
                    AbrirDialogo("Eu não preciso mais ver o que tem aqui!");
                }
            }
            if (sender == quadro2_2)
            {
                PlaySFX("papeladas.wav");
                tager = Convert.ToInt32(quadro2_2.Tag);
                if (tager == 0)
                {
                    interacoes++;
                    add++;
                    quadro2_2.Tag = 1;
                    AbrirDialogocomFechar("No papel está escrito:\r\n\r\nO atentado da rua tonelero foi atribuído a Alcino João do Nascimento e o auxiliar Climério Euribes de Almeida, membros da guarda pessoal de Getúlio, chamada pelo povo de \"Guarda Negra\". Esta guarda foi criada para a segurança de Getúlio, em maio de 1938, logo após um ataque de partidários do integralismo ao Palácio do Catete. Ao tomar conhecimento do atentado contra Carlos Lacerda na rua Tonelero, Getúlio disse: \"Carlos Lacerda levou um tiro no pé. Eu levei dois tiros nas costas!\"");
                }
                if (tager == 1)
                {
                    AbrirDialogo("Eu não preciso mais ver o que tem aqui!");
                }
            }
            if (sender == quadro3)
            {
                PlaySFX("papeladas.wav");
                tager = Convert.ToInt32(quadro3.Tag);
                if (tager == 0)
                {
                    interacoes++;
                    add++;
                    quadro3.Tag = 1;
                    AbrirDialogocomFechar("No papel está escrito:\r\n\r\nExistem várias versões para o crime do Atentado da Rua Tonelero. Há versões que divergem daquela que foi dada por Carlos Lacerda: O Jornal do Brasil entrevistou o pistoleiro Alcino João do Nascimento, aos 82 anos em 2004, o qual garantiu que o primeiro tiro que atingiu o major Rubens Vaz partiu do revólver de Carlos Lacerda. Existe também um depoimento de um morador da rua Tonelero, dado à TV Record, em 24 de agosto de 2004, que garante que Carlos Lacerda não foi ferido a bala. Os documentos, laudos e exames médicos de Carlos Lacerda, no Hospital Miguel Couto, onde ele foi levado para ser medicado, simplesmente desapareceram.");
                }
                if (tager == 1)
                {
                    AbrirDialogo("Eu não preciso mais ver o que tem aqui!");
                }
            }
            if (sender == quadro3_2)
            {
                PlaySFX("papeladas.wav");
                tager = Convert.ToInt32(quadro3_2.Tag);
                if (tager == 0)
                {
                    interacoes++;
                    add++;
                    quadro3_2.Tag = 1;
                    AbrirDialogocomFechar("No papel está escrito:\r\n\r\nA crise política que se instalou por causa do Atentado da Rua Tonelero, foi muito grave porque, além da importância de Carlos Lacerda, a FAB, à qual o major Vaz pertencia, tinha como grande heroi o brigadeiro Eduardo Gomes, da UDN, que Getúlio derrotara nas eleições de 1950. A FAB criou uma investigação paralela do crime que recebeu o apelido de \"República do Galeão\". No dia 8 de agosto, foi extinta a \"Guarda Negra\".");
                }
                if (tager == 1)
                {
                    AbrirDialogo("Eu não preciso mais ver o que tem aqui!");
                }
            }
            if (sender == quadro4)
            {
                PlaySFX("papel.wav");
                tager = Convert.ToInt32(quadro4.Tag);
                if (tager == 0)
                {
                    interacoes++;
                    quadro4.Tag = 1;
                    AbrirDialogocomFechar("Há uma lista escrita à mão dizendo: \r\n\r\n“Contribuí durante meu mandato: Na Industrialialização, Leis trabalhistas, Grandes estatais, Política nacionalista, Educação e Cultura, Política de inclusão Social, Expansão da Infraestrutura, Política Externa Independente, Criação do Ministério do Trabalho Indústria e Comércio, Política de Valorização do Café, Reforma da Previdência Social, Promoção naciona–”\r\n\r\nA lista não está completa.");
                }
                if (tager == 1)
                {
                    AbrirDialogo("Eu não preciso mais ver o que tem aqui!");
                }
            }
         
            if (interacoes == 7 && responder == false)
            {
                quizz.Image = Properties.Resources.fichanormal;
                responder = true;
            }
        }

        #endregion mensagens
        #region Quiz
        private void DiminuirFicha()
        {
            som.Visible = true;
            menu.Visible = true;
            dica.Visible = true;
            voltar.Visible = true;
            quizz.Image = Properties.Resources.fichafechada;
            quizz.Enabled = false;
            quizz.Location = new Point(662, 72);
            quizz.Size = new Size(176, 143);
            passarpaginaatras.Visible = false;
            passarpaginafrente.Visible = false;
            fecharficha.Visible = false;
            alternativa1.Visible = false;
            alternativa2.Visible = false;
            alternativa3.Visible = false;
            alternativa4.Visible = false;
            confirmarresposta.Visible = false;
            barra1.Visible = false;
            barra2.Visible = false;
            dia.Visible = false;
            mes.Visible = false;
            ano.Visible = false;
        }
        private void AumentarFicha()
        {
            som.Visible = false;
            menu.Visible = false;
            dica.Visible = false;
            confirmarresposta.Visible = true;
            confirmarresposta.Parent = quizz;
            // confirmarresposta.BackColor = Color.Transparent;
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
            barra1.Visible = false;
            barra2.Visible = false;
            dia.Visible = false;
            mes.Visible = false;
            ano.Visible = false;
        }
       
        private void EventoQuiz(object sender, EventArgs e)
        {
            if (sender == fichario)
            {
                if (interacoes == 7)
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
                if (pagina == 120)
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
                    string respostadia = Convert.ToString(dia.Text);
                    string respostames = Convert.ToString(mes.Text);
                    string respostaano = Convert.ToString(ano.Text);
                    if ((respostadia == "05" || respostadia == "5") && (respostames == "08" || respostames == "8") && respostaano == "1954")
                    {
                        respondeu2 = 1;
                        quiz2 = "correto";
                    }
                    else if (respostadia == "" || respostames == "" || respostaano == "")
                    {
                        respondeu2 = 0;
                        quiz2 = null;
                    }
                    else if ((respostadia != "05" && respostadia != "") || (respostames != "08" && respostames != "") || (respostaano != "1954" && respostaano != ""))
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
                    else if (sender == alternativa2)
                    {
                        respondeu = 2;
                        alternativa2.Image = Properties.Resources.btnfechar;
                        alternativa3.Image = Properties.Resources.btn;
                        alternativa4.Image = Properties.Resources.btn;
                        alternativa1.Image = Properties.Resources.btn;
                        quiz1 = "correto";
                    }
                    else if (sender == alternativa3)
                    {
                        respondeu = 3;
                        alternativa3.Image = Properties.Resources.btnfechar;
                        alternativa4.Image = Properties.Resources.btn;
                        alternativa1.Image = Properties.Resources.btn;
                        alternativa2.Image = Properties.Resources.btn;
                        quiz1 = "errado";
                    }
                    else if (sender == alternativa4)
                    {
                        respondeu = 4;
                        alternativa4.Image = Properties.Resources.btnfechar;
                        alternativa1.Image = Properties.Resources.btn;
                        alternativa2.Image = Properties.Resources.btn;
                        alternativa3.Image = Properties.Resources.btn;
                        quiz1 = "errado";
                    }
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
                    if ((respostadia == "05" || respostadia == "5") && (respostames == "08" || respostames == "8") && respostaano == "1954")
                    {
                        respondeu2 = 1;
                        quiz2 = "correto";
                    }
                    else if (respostadia == "" || respostames == "" || respostaano == "")
                    {
                        respondeu2 = 0;
                        quiz2 = null;
                    }
                    else if ((respostadia != "05" && respostadia != "") || (respostames != "08" && respostames != "") || (respostaano != "1954" && respostaano != ""))
                    {
                        respondeu2 = -1;
                        quiz2 = "errado";
                    }
                    if (quiz1 == "correto" && quiz2 == "correto")
                    {
                        concluirquizz = true;
                        if (viudepois == true)
                        {
                            DiminuirFicha();
                            chavefase4.Visible = true;
                            ganhar = true;
                            AbrirDialogocomFechar("Agora que eu já sei isso posso prosseguir com a minha investigação!");
                        }
                        else if (viudepois == false)
                        {
                            DiminuirFicha();
                            //quizz.Enabled = true;
                            AbrirDialogocomFechar("Agora que eu já sei isso posso prosseguir com a minha investigação!");
                            chavefase4.Visible = true;
                            ganhar = true;
                            dica.Visible = true;
                        }
                    }
                    else if (quiz2 == null || quiz1 == null)
                    {
                        AbrirDialogocomsemluiz("Falto responder a outra Questão!");
                    }
                    else if ((quiz1 == "correto" && quiz2 == "errado") || (quiz2 == "correto" && quiz1 == "errado"))
                    {
                        DiminuirFicha();
                        AbrirDialogocomsemluiz("Eu posso ter deixado algo passar no outro cômodo, é melhor conferir!");

                        timer2.Enabled = true;
                    }
                    else if (quiz1 == "errado" && quiz2 == "errado")
                    {
                        DiminuirFicha();
                        AbrirDialogocomsemluiz("Eu posso ter deixado algo passar no outro cômodo, é melhor conferir!");

                        timer2.Enabled = true;
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
                            alternativa1.Visible = false;
                            alternativa2.Visible = false;
                            alternativa3.Visible = false;
                            alternativa4.Visible = false;

                        }
                        else if (pagina == 60)
                        {
                            fecharficha.Parent = quizz;
                            fecharficha.Location = new Point(50, 40);
                            quizz.Image = Properties.Resources.fichaaberta;
                            alternativa1.Visible = false;
                            alternativa2.Visible = false;
                            alternativa3.Visible = false;
                            alternativa4.Visible = false;
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
                            alternativa1.Visible = true;
                            alternativa2.Location = new Point(418, 244);
                            alternativa2.Visible = true;
                            alternativa3.Location = new Point(418, 304);
                            alternativa3.Visible = true;
                            alternativa4.Location = new Point(418, 365);
                            alternativa4.Visible = true;
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
                            alternativa1.Visible = true;
                            alternativa2.Location = new Point(415, 239);
                            alternativa2.Visible = true;
                            alternativa3.Location = new Point(415, 318);
                            alternativa3.Visible = true;
                            alternativa4.Location = new Point(415, 379);
                            alternativa4.Visible = true;
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
                            alternativa1.Visible = true;
                            alternativa2.Location = new Point(415, 212);
                            alternativa2.Visible = true;
                            alternativa3.Location = new Point(415, 297);
                            alternativa3.Visible = true;
                            alternativa4.Location = new Point(415, 337);
                            alternativa4.Visible = true;
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
                            quizz.Image = Properties.Resources.quizz3;
                            alternativa1.Location = new Point(418, 303);
                            alternativa1.Visible = true;
                            alternativa2.Location = new Point(418, 391);
                            alternativa2.Visible = true;
                            alternativa3.Location = new Point(418, 362);
                            alternativa3.Visible = true;
                            alternativa4.Location = new Point(418, 331);
                            alternativa4.Visible = true;
                           
                        }
                        else
                        {
                            fecharficha.Parent = quizz;
                            fecharficha.Location = new Point(20, 40);
                            pagina = 300;
                            quizz.Image = Properties.Resources.quizz3;
                            alternativa1.Visible = true;
                            alternativa2.Visible = true;
                            alternativa3.Visible = true;
                            alternativa4.Visible = true;

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
                            alternativa1.Visible = false;
                            alternativa2.Visible = false;
                            alternativa3.Visible = false;
                            alternativa4.Visible = false;
                        }
                        else if (pagina == 60)
                        {
                            fecharficha.Parent = quizz;
                            fecharficha.Location = new Point(50, 40);
                            quizz.Image = Properties.Resources.fichaaberta;
                            alternativa1.Visible = false;
                            alternativa2.Visible = false;
                            alternativa3.Visible = false;
                            alternativa4.Visible = false;
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
                            alternativa1.Visible = true;
                            alternativa2.Visible = true;
                            alternativa3.Visible = true;
                            alternativa4.Visible = true;
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
                            alternativa1.Visible = true;
                            alternativa2.Location = new Point(418, 244);
                            alternativa2.Visible = true;
                            alternativa3.Location = new Point(418, 304);
                            alternativa3.Visible = true;
                            alternativa4.Location = new Point(418, 365);
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
                            alternativa1.Visible = true;
                            alternativa2.Location = new Point(415, 239);
                            alternativa2.Visible = true;
                            alternativa3.Location = new Point(415, 318);
                            alternativa3.Visible = true;
                            alternativa4.Location = new Point(415, 379);
                            alternativa4.Visible = true;
                           
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
                            alternativa1.Visible = true;
                            alternativa2.Location = new Point(415, 212);
                            alternativa2.Visible = true;
                            alternativa3.Location = new Point(415, 297);
                            alternativa3.Visible = true;
                            alternativa4.Location = new Point(415, 337);
                            alternativa4.Visible = true;
                           
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
                            quizz.Image = Properties.Resources.quizz3;
                            alternativa1.Location = new Point(418, 303);
                            alternativa1.Visible = true;
                            alternativa2.Location = new Point(418, 391);
                            alternativa2.Visible = true;
                            alternativa3.Location = new Point(418, 362);
                            alternativa3.Visible = true;
                            alternativa4.Location = new Point(418, 331);
                            alternativa4.Visible = true;
                            
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
                            alternativa1.Visible = false;
                            alternativa2.Visible = false;
                            alternativa3.Visible = false;
                            alternativa4.Visible = false;

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
                            alternativa1.Visible = false;
                            alternativa2.Visible = false;
                            alternativa3.Visible = false;
                            alternativa4.Visible = false;
                            fecharficha.Location = new Point(250, 40);
                            fecharficha.Parent = quizz;
                            fecharficha.BackColor = Color.Transparent;
                        }
                        else if (pagina == 60)
                        {
                            quizz.Image = Properties.Resources.fichaaberta;
                            alternativa1.Visible = false;
                            alternativa2.Visible = false;
                            alternativa3.Visible = false;
                            alternativa4.Visible = false;
                            fecharficha.Location = new Point(55, 40);
                            fecharficha.Parent = quizz;
                            fecharficha.BackColor = Color.Transparent;
                        }
                        else if (pagina == 120)
                        {

                            quizz.Image = Properties.Resources.quizz1;
                            alternativa1.Visible = true;
                            alternativa2.Visible = true;
                            alternativa3.Visible = true;
                            alternativa4.Visible = true;
                            fecharficha.Location = new Point(31, 40);
                            fecharficha.Parent = quizz;
                            fecharficha.BackColor = Color.Transparent;
                        }
                        else if (pagina == 180)
                        {
                            quizz.Image = Properties.Resources.quizz2P1;
                            alternativa1.Visible = false;
                            alternativa2.Visible = false;
                            alternativa3.Visible = false;
                            alternativa4.Visible = false;
                            fecharficha.Location = new Point(31, 40);
                            fecharficha.Parent = quizz;
                            fecharficha.BackColor = Color.Transparent;
                        }
                        else if (pagina == 240)
                        {
                            quizz.Image = Properties.Resources.quizz2P2;
                            alternativa1.Visible = false;
                            alternativa2.Visible = false;
                            alternativa3.Visible = false;
                            alternativa4.Visible = false;
                            fecharficha.Location = new Point(31, 40);
                            fecharficha.Parent = quizz;
                            fecharficha.BackColor = Color.Transparent;
                        }
                        else if (pagina == 300)
                        {
                            quizz.Image = Properties.Resources.quizz3;
                            alternativa1.Visible = false;
                            alternativa2.Visible = false;
                            alternativa3.Visible = false;
                            alternativa4.Visible = false;
                            fecharficha.Location = new Point(31, 40);
                            fecharficha.Parent = quizz;
                            fecharficha.BackColor = Color.Transparent;
                        }
                        else if (pagina == 360)
                        {
                            quizz.Image = Properties.Resources.quizz4;
                            alternativa1.Visible = false;
                            alternativa2.Visible = false;
                            alternativa3.Visible = false;
                            alternativa4.Visible = false;
                            fecharficha.Location = new Point(31, 40);
                            fecharficha.Parent = quizz;
                            fecharficha.BackColor = Color.Transparent;
                        }
                        else
                        {
                            pagina = 360;
                            quizz.Image = Properties.Resources.quizz4;
                            alternativa1.Visible = false;
                            alternativa2.Visible = false;
                            alternativa3.Visible = false;
                            alternativa4.Visible = false;
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
                            alternativa1.Visible = false;
                            alternativa2.Visible = false;
                            alternativa3.Visible = false;
                            alternativa4.Visible = false;
                            fecharficha.Location = new Point(250, 40);
                            fecharficha.Parent = quizz;
                            fecharficha.BackColor = Color.Transparent;
                        }
                        else if (pagina == 60)
                        {
                            quizz.Image = Properties.Resources.fichaaberta;
                            alternativa1.Visible = false;
                            alternativa2.Visible = false;
                            alternativa3.Visible = false;
                            alternativa4.Visible = false;
                            fecharficha.Location = new Point(55, 40);
                            fecharficha.Parent = quizz;
                            fecharficha.BackColor = Color.Transparent;
                        }
                        else if (pagina == 120)
                        {
                            quizz.Image = Properties.Resources.quizz1;
                            alternativa1.Visible = true;
                            alternativa2.Visible = true;
                            alternativa3.Visible = true;
                            alternativa4.Visible = true;
                            fecharficha.Location = new Point(31, 40);
                            fecharficha.Parent = quizz;
                            fecharficha.BackColor = Color.Transparent;

                        }
                        else if (pagina == 180)
                        {
                            quizz.Image = Properties.Resources.quizz2P1;
                            alternativa1.Visible = false;
                            alternativa2.Visible = false;
                            alternativa3.Visible = false;
                            alternativa4.Visible = false;
                            fecharficha.Location = new Point(31, 40);
                            fecharficha.Parent = quizz;
                            fecharficha.BackColor = Color.Transparent;
                        }
                        else if (pagina == 240)
                        {
                            quizz.Image = Properties.Resources.quizz2P2;
                            alternativa1.Visible = false;
                            alternativa2.Visible = false;
                            alternativa3.Visible = false;
                            alternativa4.Visible = false;
                            fecharficha.Location = new Point(31, 40);
                            fecharficha.Parent = quizz;
                            fecharficha.BackColor = Color.Transparent;
                        }
                        else if (pagina == 300)
                        {
                            quizz.Image = Properties.Resources.quizz3;
                            alternativa1.Visible = false;
                            alternativa2.Visible = false;
                            alternativa3.Visible = false;
                            alternativa4.Visible = false;
                            fecharficha.Location = new Point(31, 40);
                            fecharficha.Parent = quizz;
                            fecharficha.BackColor = Color.Transparent;
                        }
                        else if (pagina == 360)
                        {
                            quizz.Image = Properties.Resources.quizz4;
                            alternativa1.Visible = false;
                            alternativa2.Visible = false;
                            alternativa3.Visible = false;
                            alternativa4.Visible = false;
                            fecharficha.Location = new Point(31, 40);
                            fecharficha.Parent = quizz;
                            fecharficha.BackColor = Color.Transparent;
                        }
                        else
                        {
                            pagina = 0;
                            quizz.Image = Properties.Resources.fichafechada;
                            alternativa1.Visible = false;
                            alternativa2.Visible = false;
                            alternativa3.Visible = false;
                            alternativa4.Visible = false;
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
            if (interacoes != 7)
            {
                AbrirDialogo("Eu devo checar essas gavetas entreabertas");
            }
            if (interacoes == 7 && click == false)
            {
                AbrirDialogo("Eu devo anotar as informações no meu fichário! Ele se encontra no canto superior direito.");
            }
            if (ganhar == true && voltaraocorredor == false)
            {
                AbrirDialogo("Há algo em cima desse armário de aço!");
            }
            if (voltaraocorredor == true && ganhar == true)
            {
                AbrirDialogo("Eu tenho que retornar ao corredor de onde eu vim!");
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            Comodo(0);
            timer2.Enabled = false;
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            Comodo(1);
            timer3.Enabled = false;
        }

    }
}
