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
    public partial class Salao : Form
    {
        int[] analisarobj = new int[2];
        //int analisarquadro = 0;

        bool tocar = true;
        int interacoes = 0;
        bool ganhar;
        bool ganhar2;
        bool voltaraocorredor;
        int tager;
        int add = 0;
        bool responder = false;
        bool responder2 = false;
        int respondeu = 0;
        int respondeu2 = 0;
        string quiz1 = null;
        string quiz2 = null;
        bool visualizar = false;
        int pagina = 0;
        int inf = 0;
        int qual=0;

        bool[] mensagens = new bool[7];

        bool concluirquizz = false;
        bool viudepois = false;
        bool click = false;

        private const int MaxWidth = 580;
        public Salao()
        {
            InitializeComponent(); 
            /*string audioFilePath = "Jogo.wav";
            AudioManager.Instance.SetlLoop(true);

            AudioManager.Instance.Play(audioFilePath);
            // PlayMusic("Jogo.wav");*/

            AbrirDialogocomFechar("Esta sala deve ter sido usado para reuniões, pelo tamanho dessa mesa. Ela também está lotada de pastas, checá-las pode ser um boa ideia.");
            for (int i = 0; i < 7; i++)
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

        private void Comodo(int num)
        {
            if (num == 0)
            {
                Escritorio escritorio = new Escritorio();
                escritorio.Show();
                this.Hide();
                timer2.Enabled = false;
            }
            if (num == 1)
            {
                CorredorFase3 corredor = new CorredorFase3();
                corredor.Show();
                this.Hide();
                timer3.Enabled = false;
            }
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
            avancar.Visible = false;
            fechar.Visible = false;
            dialogo.Visible = false;
            rolagem.Visible = false;
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
            caixadetexto.Enabled = true;
            senhorluiz.Visible = false;
            deixarenabled.Visible = false;

            /*if (interacoes == 6 && responder == false && timer1.Enabled == false)
            {
                quizz.Image = Properties.Resources.fichanormal;
                AbrirDialogocomFechar("Houveram inúmeros conflitos e críticas em seu mandato, por mais que tenha tido realizações significativas no país");
                responder = true;
            }*/
            if (click == true && quiz1 != null && quiz2 != null && (quiz1 == "errado" || quiz2 == "errado"))
            {
                timer2.Enabled = true;
            }
        }
        private void voltar_Click(object sender, EventArgs e)
        {
            PlaySFX("botao.wav");
            if (voltaraocorredor == true && ganhar == true)
            {
                CorredorFase3 corredor = new CorredorFase3();
                corredor.Show();
                this.Hide(); 
            }
            else if (voltaraocorredor == false && ganhar == true)
            {
                AbrirDialogo("Ainda preciso pegar algo!");
            }
            else if (interacoes == 6 && responder == false)
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
         /*   else if (interacoes == 0)
            {
                CorredorFase3 corredor = new CorredorFase3();
                corredor.Show();
                this.Hide();
            }
            // */

            else
            {
                AbrirDialogo("Ainda não olhei toda a sala!");
            }
            
        }
        private void fechar_Click(object sender, EventArgs e)
        {
            PlaySFX("botao.wav");
            FecharDialogo();

            if (analisarobj[0] == 5 && analisarobj[1] == 0 && mensagens[1] == false && mensagens[6] != true)
            {
                AbrirDialogocomFechar("Há um quadro grande bem chamativo, o que posso ver sobre ele?");
                mensagens[1] = true;
            }

            if (interacoes == 6 && responder == false && mensagens[1] == true)
            {
                quizz.Image = Properties.Resources.fichanormal;
                AbrirDialogocomFechar("Houveram inúmeros conflitos e críticas em seu mandato, por mais que tenha tido realizações significativas no país.");
                responder = true;
            }


            if (ganhar == false && interacoes == 6 && mensagens[2] == false && mensagens[1] == true)
            {
                AbrirDialogocomFechar("Agora o que me resta fazer nessa sala é anotar as informações no meu fichário!");
                mensagens[2] = true;
            }
            if (voltaraocorredor == true && quiz1 == "correto" && quiz2 == "correto" && viudepois == true)
            {
                timer3.Enabled = true;
            }
            if (qual == 4 && mensagens[3] == false)
            {
                timer4.Enabled = true;
                mensagens[3] = true;
            }
            if (qual == 5 && mensagens[5] == false)
            {
                timer4.Enabled = true;
                mensagens[5] = true;
            }

            if (analisarobj[0] == 5 && analisarobj[1] == 0 && mensagens[1] == false && mensagens[6] == true)
            {
                AbrirDialogocomFechar("Há um quadro grande bem chamativo, o que posso ver sobre ele?");
                mensagens[1] = true;
                mensagens[6] = false;
            }
            if (viudepois == false && concluirquizz == true && mensagens[4] == false)
            {
                AbrirDialogo("Hum, o que seria isso no chão?");
                mensagens[4] = true;
            }
            if (analisarobj[0] == 5 && mensagens[6] == false)
                mensagens[6] = true;
        }
        private void avancar_Click(object sender, EventArgs e)
        {
            if (qual == 1)
            {
                PlaySFX("papelpassar.wav");
                inf += 60;
                if (inf == 0)
                {
                    jornalcrise.Image = Properties.Resources.jornalcrise;
                }
                else if (inf == 60)
                {
                    jornalcrise.Image = Properties.Resources.jornalMC;
                }
                else if (inf == 120)
                {
                    tager = Convert.ToInt32(jornalcrise.Tag);
                    if (tager == 0)
                    {
                        jornalcrise.Tag = 1;
                    }
                    jornalcrise.Image = Properties.Resources.jornalRenuncia;
                    fecharjornal.Visible = true;
                }
                else if (inf >= 180)
                {
                    jornalcrise.Image = Properties.Resources.jornalcrise;
                    fecharjornal.Visible = true;
                    inf = 0;
                }
            }
            if (qual == 2)
            {
                PlaySFX("papelpassar.wav");
                inf += 60;
                if (inf == 0)
                {
                    cartaestadonovo.Image = Properties.Resources.papel1sm;
                }
                else if (inf == 60)
                {
                    tager = Convert.ToInt32(papelada.Tag);
                    if (tager == 0)
                    {
                        papelada.Tag = 1;
                    }
                    cartaestadonovo.Image = Properties.Resources.papel2sm;
                    fecharjornal.Visible = true;
                }
                else if (inf >= 120)
                {
                    cartaestadonovo.Image = Properties.Resources.papel1sm;
                    fecharjornal.Visible = true;
                    inf = 0;
                }
            }
            if (qual == 3 )
            {
                PlaySFX("botao.wav");

                inf += 60;
                if (inf == 0)
                {
                    dialogo.Text = "No papel está escrito:\r\nNa fase constitucional, o governo de Vargas, em teoria, estender-se-ia até 1938, pois o presidente não poderia concorrer à reeleição. No entanto, a política brasileira como um todo – o próprio Vargas, inclusive – caminhava para a radicalização. Assim, surgiram grupos que expressavam essa radicalização do nosso país: Ação Integralista Brasileiro (AIB) e Aliança Libertadora Nacional (ANL).".ToString();
                    avancar.Visible = true;
                    dialogo.MaximumSize = new Size(MaxWidth, 0);
                    dialogo.Visible = true;
                    rolagem.Visible = true;
                    rolagem.Controls.Add(dialogo);
                    caixadetexto.Visible = true;
                    senhorluiz.Visible = true;
                    deixarenabled.Visible = true;
                }
                if (inf >= 60)
                {
                    dialogo.Text = "...Essa fase constitucional da Era Vargas estendeu-se até novembro de 1937, quando Getúlio Vargas realizou um autogolpe, cancelou a eleição de 1938 e instalou um regime ditatorial no país. O golpe do Estado Novo teve como pretexto a divulgação de um documento falso conhecido como Plano Cohen. Esse documento falava sobre uma conspiração comunista que estava em curso no país. Acesse também: Intentona Integralista, outra rebelião organizada durante a Era Vargas Estado Novo (1937-1945).".ToString();
                    avancar.Visible = false;
                    fechar.Visible = true;
                    dialogo.MaximumSize = new Size(MaxWidth, 0);
                    dialogo.Visible = true;
                    rolagem.Visible = true;
                    rolagem.Controls.Add(dialogo);
                    caixadetexto.Visible = true;
                    senhorluiz.Visible = true;
                    deixarenabled.Visible = true;
                    inf = 0;
                }
            }
            if (qual == 4)
            {
                PlaySFX("botao.wav");

                inf += 60;
                if (inf == 0)
                {
                    dialogo.Text = "No papel está escrito:\r\n\r\nO governo provisório de Vargas, deveria ter sido uma fase de transição em que Vargas rapidamente organizaria uma Assembleia Constituinte para elaborar uma nova Constituição para o Brasil. Getúlio Vargas, porém, nesse momento, já deu mostras da sua habilidade de se sustentar no poder, pois adiou o quanto foi possível a realização da Constituinte".ToString();
                    avancar.Visible = true;
                    dialogo.MaximumSize = new Size(MaxWidth, 0);
                    dialogo.Visible = true;
                    rolagem.Visible = true;
                    rolagem.Controls.Add(dialogo);
                    caixadetexto.Visible = true;
                    senhorluiz.Visible = true;
                    deixarenabled.Visible = true;
                }
                if (inf == 120)
                {
                    dialogo.Text = "...Nessa fase, Vargas já realizou as primeiras medidas de centralização do poder e, assim, dissolveu o Congresso Nacional, por exemplo.A demora de Vargas em realizar eleições e convocar uma Constituinte teve impactos em alguns locais do país, como São Paulo, que se rebelou contra o governo em 1932 no que ficou conhecido como Revolução Constitucionalista de 1932...".ToString();
                    avancar.Visible = true;
                    dialogo.MaximumSize = new Size(MaxWidth, 0);
                    dialogo.Visible = true;
                    rolagem.Visible = true;
                    rolagem.Controls.Add(dialogo);
                    caixadetexto.Visible = true;
                    senhorluiz.Visible = true;
                    deixarenabled.Visible = true;
                }           
                if (inf >= 180)
                {
                    dialogo.Text = "...O movimento da Revolução Constitucionalista foi um fracasso e, após a sua derrota, Getúlio Vargas atendeu as demandas dos paulistas, nomeando para o estado um interventor(governador) civil e nascido em São Paulo, além de garantir a realização de uma eleição em 1933 para compor a Constituinte. Dessa Constituinte, foi promulgada a Constituição de 1934.".ToString();
                    avancar.Visible = false;
                    fechar.Visible = true;
                    dialogo.MaximumSize = new Size(MaxWidth, 0);
                    dialogo.Visible = true;
                    rolagem.Visible = true;
                    rolagem.Controls.Add(dialogo);
                    caixadetexto.Visible = true;
                    senhorluiz.Visible = true;
                    deixarenabled.Visible = true;
                    inf = 0;
                }
            }
            if (qual == 5)
            {
                PlaySFX("botao.wav");

                inf += 60;
                if (inf == 0)
                {
                    dialogo.Text = "No papel está escrito:\r\n\r\nA nova Constituição de 1934 foi considerada bastante moderna para a época e trouxe novidades, como o sufrágio universal feminino (confirmando o que já havia sido estipulado pelo Código Eleitoral de 1932). Junto da promulgação da nova Constituição, Vargas foi reeleito indiretamente para ser presidente brasileiro entre 1934 e 1938. Após isso, um novo presidente deveria ser eleito.".ToString();
                    avancar.Visible = true;
                    dialogo.MaximumSize = new Size(MaxWidth, 0);
                    dialogo.Visible = true;
                    rolagem.Visible = true;
                    rolagem.Controls.Add(dialogo);
                    caixadetexto.Visible = true;
                    senhorluiz.Visible = true;
                    deixarenabled.Visible = true;
                }
                if (inf >= 60)
                {
                    dialogo.Text = "...Nessa fase, a política econômica de Vargas concentrou - se em combater os efeitos da Crise de 1929 no Brasil. Para isso, agiu comprando milhares de sacas de café e incendiando-as como forma de valorizar o principal produto da nossa economia.Nas questões trabalhistas, autorizou a criação do Ministério do Trabalho em 1930 e começou a intervir diretamente na atuação dos sindicatos.Governo Constitucional(1934 - 1937).".ToString();
                    avancar.Visible = false;
                    fechar.Visible = true;
                    dialogo.MaximumSize = new Size(MaxWidth, 0);
                    dialogo.Visible = true;
                    rolagem.Visible = true;
                    rolagem.Controls.Add(dialogo);
                    caixadetexto.Visible = true;
                    senhorluiz.Visible = true;
                    deixarenabled.Visible = true;
                    inf = 0;
                }
            }
        }
        private void fecharjornal_Click(object sender, EventArgs e)
        {
            PlaySFX("botao.wav");
            jornalcrise.Visible = false;
            avancar.Visible = false;
            fecharjornal.Visible = false;
            deixarenabled.Visible = false;
            cartaestadonovo.Visible = false;

            if (qual == 2)
            {
                timer4.Enabled = true;
            }
            if (interacoes == 5 && analisarobj[1] == 0 && mensagens[0] == false)
            {
                AbrirDialogocomFechar("Há um quadro grande bem chamativo, o que posso ver sobre ele?");
                mensagens[0] = true;
            }
        }
        private void chavefase2_Click(object sender, EventArgs e)
        {
            PlaySFX("chaves.wav");
            voltaraocorredor = true;
            chavefase2.Visible = false;
            AbrirDialogocomFechar("Essa é a chave da Porta Arquivos do Governo!");
        }

        #region mensagens
        private void mensagem(object sender, EventArgs e)
        {
            if (sender == quadro)
            {
                tager = Convert.ToInt32(quadro.Tag);
                if (tager == 0)
                {
                    interacoes++;
                    quadro.Tag = 1;
                    analisarobj[1]++;
                    AbrirDialogocomFechar("Uma foto do manisfesto dos Coronéis, lá havia 42 Coronéis e 39 Tenentes-Coronéis!");
                }
                if (tager == 1)
                {
                    AbrirDialogo("Eu não preciso mais ver o que tem aqui!");
                }
            }
            if (sender == papelada)
            {
                PlaySFX("papel.wav");
                tager = Convert.ToInt32(papelada.Tag);
                if (tager == 0)
                {
                    qual = 2;
                    cartaestadonovo.Image = Properties.Resources.papel1sm;
                    cartaestadonovo.Visible = true;
                    avancar.Visible = true;
                    papelada.Tag = 1;
                    interacoes++;
                    analisarobj[0]++;
                }
                if (tager == 1)
                {
                    AbrirDialogo("Eu não preciso mais ver o que tem aqui!");
                }
            }
            if (sender == pasta)
            {
                PlaySFX("papeladas.wav");
                tager = Convert.ToInt32(pasta.Tag);
                if (tager == 0)
                {
                    interacoes++;
                    pasta.Tag = 1;
                    analisarobj[0]++;
                    qual = 5;
                    fechar.Visible = true;
                    dialogo.Text = "No papel está escrito:\r\nA nova Constituição de 1934 foi considerada bastante moderna para a época e trouxe novidades, como o sufrágio universal feminino (confirmando o que já havia sido estipulado pelo Código Eleitoral de 1932). Junto da promulgação da nova Constituição, Vargas foi reeleito indiretamente para ser presidente brasileiro entre 1934 e 1938. Após isso, um novo presidente deveria ser eleito."/*\r\n\r\nNessa fase, a política econômica de Vargas concentrou - se em combater os efeitos da Crise de 1929 no Brasil. Para isso, agiu comprando milhares de sacas de café e incendiando-as como forma de valorizar o principal produto da nossa economia.Nas questões trabalhistas, autorizou a criação do Ministério do Trabalho em 1930 e começou a intervir diretamente na atuação dos sindicatos.Governo Constitucional"*/.ToString();
                    dialogo.MaximumSize = new Size(MaxWidth, 0);
                    dialogo.Visible = true;
                    rolagem.Visible = true;
                    rolagem.Controls.Add(dialogo);
                    caixadetexto.Visible = true;
                    senhorluiz.Visible = true;
                }
                if (tager == 1)
                {
                    AbrirDialogo("Eu não preciso mais ver o que tem aqui!");
                }
            }
            if (sender == pastacheia)
            {
                PlaySFX("papeladas.wav");
                tager = Convert.ToInt32(pastacheia.Tag);
                if (tager == 0)
                {
                    interacoes++;
                    pastacheia.Tag = 1;
                    analisarobj[0]++;
                    qual = 4;
                    fechar.Visible = true;
                    dialogo.Text = "No papel está escrito:\r\nO governo provisório de Vargas, deveria ter sido uma fase de transição em que Vargas rapidamente organizaria uma Assembleia Constituinte para elaborar uma nova Constituição para o Brasil. Getúlio Vargas, porém, nesse momento, já deu mostras da sua habilidade de se sustentar no poder, pois adiou o quanto foi possível a realização da Constituinte."/*\r\n\r\nNessa fase, Vargas já realizou as primeiras medidas de centralização do poder e, assim, dissolveu o Congresso Nacional, por exemplo.A demora de Vargas em realizar eleições e convocar uma Constituinte teve impactos em alguns locais do país, como São Paulo, que se rebelou contra o governo em 1932 no que ficou conhecido como Revolução Constitucionalista de 1932.\\r\\n\\r\\nO movimento da Revolução Constitucionalista foi um fracasso e, após a sua derrota, Getúlio Vargas atendeu as demandas dos paulistas, nomeando para o estado um interventor(governador) civil e nascido em São Paulo, além de garantir a realização de uma eleição em 1933 para compor a Constituinte. Dessa Constituinte, foi promulgada a Constituição de 1934."*/.ToString();
                    dialogo.MaximumSize = new Size(MaxWidth, 0);
                    dialogo.Visible = true;
                    rolagem.Visible = true;
                    rolagem.Controls.Add(dialogo);
                    caixadetexto.Visible = true;
                    senhorluiz.Visible = true;
                }
                if (tager == 1)
                {
                    AbrirDialogo("Eu não preciso mais ver o que tem aqui!");
                }
            }
            if (sender == pastavazia)
            {
                PlaySFX("papeladas.wav");
                tager = Convert.ToInt32(pastavazia.Tag);
                if (tager == 0)
                {
                    interacoes++;
                    pastavazia.Tag = 1;
                    analisarobj[0]++;
                    qual = 3;
                    avancar.Visible = true;
                    dialogo.Text = "No papel está escrito:\r\nNa fase constitucional, o governo de Vargas, em teoria, estender-se-ia até 1938, pois o presidente não poderia concorrer à reeleição. No entanto, a política brasileira como um todo – o próprio Vargas, inclusive – caminhava para a radicalização. Assim, surgiram grupos que expressavam essa radicalização do nosso país: Ação Integralista Brasileiro (AIB) e Aliança Libertadora Nacional (ANL)."/*\r\n\r\nEssa fase constitucional da Era Vargas estendeu-se até novembro de 1937, quando Getúlio Vargas realizou um autogolpe, cancelou a eleição de 1938 e instalou um regime ditatorial no país. O golpe do Estado Novo teve como pretexto a divulgação de um documento falso conhecido como Plano Cohen. Esse documento falava sobre uma conspiração comunista que estava em curso no país. Acesse também: Intentona Integralista, outra rebelião organizada durante a Era Vargas Estado Novo."*/.ToString();
                    dialogo.MaximumSize = new Size(MaxWidth, 0);
                    dialogo.Visible = true;
                    rolagem.Visible = true;
                    rolagem.Controls.Add(dialogo);
                    caixadetexto.Visible = true;
                    senhorluiz.Visible = true;
                }
                if (tager == 1)
                {
                    AbrirDialogo("Eu não preciso mais ver o que tem aqui!");
                }
            }
            ////////////////////
            if (sender == jornal)
            {
                PlaySFX("papel.wav");
                tager = Convert.ToInt32(jornal.Tag);
                if (tager == 0)
                {
                    interacoes++;
                    qual = 1;
                    jornalcrise.Visible = true;
                    avancar.Visible = true;
                    jornal.Tag = 1;
                    analisarobj[0]++;
                }
                if (tager == 1)
                {
                    AbrirDialogo("Eu não preciso mais ver o que tem aqui!");
                }
            }
            if (interacoes == 6)
            {
                quizz.Image = Properties.Resources.fichanormal;
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
        }
        private void AmostrarSelecionada()
        {
            if (respondeu == 1 || respondeu2 == 1)
            {
                alternativa1.Image = Properties.Resources.btnfechar;
                alternativa2.Image = Properties.Resources.btn;
                alternativa3.Image = Properties.Resources.btn;
                alternativa4.Image = Properties.Resources.btn;
            }
            else if (respondeu == 2 || respondeu2 == 2)
            {
                alternativa1.Image = Properties.Resources.btn;
                alternativa3.Image = Properties.Resources.btn;
                alternativa4.Image = Properties.Resources.btn;
                alternativa2.Image = Properties.Resources.btnfechar;
            }
            else if (respondeu == 3 || respondeu2 == 3)
            {
                alternativa3.Image = Properties.Resources.btnfechar;
                alternativa1.Image = Properties.Resources.btn;
                alternativa2.Image = Properties.Resources.btn;
                alternativa4.Image = Properties.Resources.btn;
            }
            else if (respondeu == 4 || respondeu2 == 4)
            {
                alternativa4.Image = Properties.Resources.btnfechar;
                alternativa1.Image = Properties.Resources.btn;
                alternativa2.Image = Properties.Resources.btn;
                alternativa3.Image = Properties.Resources.btn;
            }
            else
            {
                alternativa1.Image = Properties.Resources.btn;
                alternativa2.Image = Properties.Resources.btn;
                alternativa3.Image = Properties.Resources.btn;
                alternativa4.Image = Properties.Resources.btn;
            }
        }
        private void EventoQuiz(object sender, EventArgs e)
        {
            if (sender == fichario)
            {
                if (interacoes == 6)
                {
                    responder = true;
                    click = true;
                    quizz.Image = Properties.Resources.fichanormal;
                }
                AumentarFicha();
            }
            if (sender == fecharficha)
            {
                DiminuirFicha();
                voltar.Visible = true;
                pagina = 0;
            }
        }
        private void ResponderPergunta(object sender, EventArgs e)
        {
            if (responder == true)
            {
                //AmostrarSelecionada();
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
                if (pagina == 240)
                {
                    if (sender == alternativa1)
                    {
                        respondeu2 = 1;
                        alternativa1.Image = Properties.Resources.btnfechar;
                        alternativa2.Image = Properties.Resources.btn;
                        alternativa3.Image = Properties.Resources.btn;
                        alternativa4.Image = Properties.Resources.btn;
                       
                            quiz2 = "errado";
                      
                    }
                    if (sender == alternativa2)
                    {
                        respondeu2 = 2;
                        alternativa2.Image = Properties.Resources.btnfechar;
                        alternativa3.Image = Properties.Resources.btn;
                        alternativa4.Image = Properties.Resources.btn;
                        alternativa1.Image = Properties.Resources.btn;
                       
                            quiz2 = "correto";
                      
                    }
                    if (sender == alternativa3)
                    {
                        respondeu2 = 3;
                        alternativa3.Image = Properties.Resources.btnfechar;
                        alternativa4.Image = Properties.Resources.btn;
                        alternativa1.Image = Properties.Resources.btn;
                        alternativa2.Image = Properties.Resources.btn;
                      
                            quiz2 = "errado";
                        
                    }
                    if (sender == alternativa4)
                    {
                        respondeu2 = 4;
                        alternativa4.Image = Properties.Resources.btnfechar;
                        alternativa1.Image = Properties.Resources.btn;
                        alternativa2.Image = Properties.Resources.btn;
                        alternativa3.Image = Properties.Resources.btn;
                      
                            quiz2 = "errado";
                       
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
                   // ConclusaodaPergunta();
                   // ConclusaodaPergunta2();

                    if (quiz1 == "correto" && quiz2 == "correto")
                    {
                        if (viudepois == true)
                        {
                            chavefase2.Visible = true;
                            ganhar = true;
                            AbrirDialogocomFechar("Esse cômodo trouxe informações, muito interessantes!");
                        }
                        else if (viudepois == false)
                        {
                            DiminuirFicha();
                            AbrirDialogocomFechar("Esse cômodo trouxe informações, muito interessantes!");
                            chavefase2.Visible = true;
                            ganhar = true;
                            dica.Visible = true;
                            concluirquizz = true;
                        }
                    }
                    else if (quiz2 == null || quiz1 == null)
                    {
                        AbrirDialogocomsemluiz("Falto responder a Questão!");
                    }
                    else if ((quiz1 == "correto" && quiz2 == "errado") || (quiz1 == "errado" && quiz2 == "correto"))
                    {
                        DiminuirFicha();
                        AbrirDialogo("Eu não devo ter Analizado Corretamente, é melhor verificar novamente o outro cômodo!");
                    }
                    else if (quiz1 == "errado" && quiz2 == "errado")
                    {
                        DiminuirFicha();
                        AbrirDialogo("Eu não devo ter Analizado Corretamente, é melhor verificar novamente o outro cômodo!");
                    }
                    break;

                case false:
                    AbrirDialogocomsemluiz("Eu não vou responder agora!");
                    break;
            }
        }
        private void Passarpagina(object sender, EventArgs e)
        {
            PlaySFX("papelpassar.wav");
            switch (responder)
            {
                case true:
                    if (sender == passarpaginafrente)
                    {
                        AmostrarSelecionada();
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
                            if (respondeu == 1)
                            {
                                alternativa1.Image = Properties.Resources.btnfechar;
                                alternativa2.Image = Properties.Resources.btn;
                                alternativa3.Image = Properties.Resources.btn;
                                alternativa4.Image = Properties.Resources.btn;
                            }
                            else if (respondeu == 2 )
                            {
                                alternativa1.Image = Properties.Resources.btn;
                                alternativa3.Image = Properties.Resources.btn;
                                alternativa4.Image = Properties.Resources.btn;
                                alternativa2.Image = Properties.Resources.btnfechar;
                            }
                            else if (respondeu == 3 )
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
                            quizz.Image = Properties.Resources.quizz2P1;
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
                            if (respondeu2 == 1)
                            {
                                alternativa1.Image = Properties.Resources.btnfechar;
                                alternativa2.Image = Properties.Resources.btn;
                                alternativa3.Image = Properties.Resources.btn;
                                alternativa4.Image = Properties.Resources.btn;
                            }
                            else if (respondeu2 == 2)
                            {
                                alternativa1.Image = Properties.Resources.btn;
                                alternativa3.Image = Properties.Resources.btn;
                                alternativa4.Image = Properties.Resources.btn;
                                alternativa2.Image = Properties.Resources.btnfechar;
                            }
                            else if (respondeu2 == 3)
                            {
                                alternativa3.Image = Properties.Resources.btnfechar;
                                alternativa1.Image = Properties.Resources.btn;
                                alternativa2.Image = Properties.Resources.btn;
                                alternativa4.Image = Properties.Resources.btn;
                            }
                            else if ( respondeu2 == 4)
                            {
                                alternativa4.Image = Properties.Resources.btnfechar;
                                alternativa1.Image = Properties.Resources.btn;
                                alternativa2.Image = Properties.Resources.btn;
                                alternativa3.Image = Properties.Resources.btn;
                            }
                            else
                            {
                                alternativa1.Image = Properties.Resources.btn;
                                alternativa2.Image = Properties.Resources.btn;
                                alternativa3.Image = Properties.Resources.btn;
                                alternativa4.Image = Properties.Resources.btn;
                            }
                            quizz.Image = Properties.Resources.quizz2P2;
                            alternativa1.Location = new Point(415, 256);
                            alternativa1.Visible = true;
                            alternativa2.Location = new Point(415, 212);
                            alternativa2.Visible = true;
                            alternativa3.Location = new Point(415, 297);
                            alternativa3.Visible = true;
                            alternativa4.Location = new Point(415, 337);
                            alternativa4.Visible = true;
                        }
                        else
                        {
                            fecharficha.Parent = quizz;
                            fecharficha.Location = new Point(20, 40);
                            pagina = 240;
                            quizz.Image = Properties.Resources.quizz2P2;
                            alternativa1.Location = new Point(415, 256);
                            alternativa1.Visible = true;
                            alternativa2.Location = new Point(415, 212);
                            alternativa2.Visible = true;
                            alternativa3.Location = new Point(415, 297);
                            alternativa3.Visible = true;
                            alternativa4.Location = new Point(415, 337);
                            alternativa4.Visible = true;

                            AbrirDialogocomsemluiz("Eu não vou passar para a proxima página!");
                        }
                    }
                    if (sender == passarpaginaatras)
                    {
                        AmostrarSelecionada();
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
                            quizz.Image = Properties.Resources.quizz2P1;
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
                            if (respondeu2 == 1)
                            {
                                alternativa1.Image = Properties.Resources.btnfechar;
                                alternativa2.Image = Properties.Resources.btn;
                                alternativa3.Image = Properties.Resources.btn;
                                alternativa4.Image = Properties.Resources.btn;
                            }
                            else if (respondeu2 == 2)
                            {
                                alternativa1.Image = Properties.Resources.btn;
                                alternativa3.Image = Properties.Resources.btn;
                                alternativa4.Image = Properties.Resources.btn;
                                alternativa2.Image = Properties.Resources.btnfechar;
                            }
                            else if (respondeu2 == 3)
                            {
                                alternativa3.Image = Properties.Resources.btnfechar;
                                alternativa1.Image = Properties.Resources.btn;
                                alternativa2.Image = Properties.Resources.btn;
                                alternativa4.Image = Properties.Resources.btn;
                            }
                            else if (respondeu2 == 4)
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
                            quizz.Image = Properties.Resources.quizz2P2;
                            alternativa1.Location = new Point(415, 256);
                            alternativa1.Visible = true;
                            alternativa2.Location = new Point(415, 212);
                            alternativa2.Visible = true;
                            alternativa3.Location = new Point(415, 297);
                            alternativa3.Visible = true;
                            alternativa4.Location = new Point(415, 337);
                            alternativa4.Visible = true;
                        }
                        else
                        {
                            fecharficha.Parent = quizz;
                            fecharficha.Location = new Point(210, 40);
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
                    confirmarresposta.Visible = true;
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
                            alternativa1.Image = Properties.Resources.btn;
                            alternativa2.Image = Properties.Resources.btnfechar;
                            alternativa3.Image = Properties.Resources.btn;
                            alternativa4.Image = Properties.Resources.btn;


                            quizz.Image = Properties.Resources.quizz1;
                            alternativa1.Location = new Point(418, 171);
                            alternativa1.Visible = true;
                            alternativa2.Location = new Point(418, 244);
                            alternativa2.Visible = true;
                            alternativa3.Location = new Point(418, 304);
                            alternativa3.Visible = true;
                            alternativa4.Location = new Point(418, 365);
                            alternativa4.Visible = true;
                            fecharficha.Location = new Point(31, 40);
                            fecharficha.Parent = quizz;
                            fecharficha.BackColor = Color.Transparent;
                        }
                        else if (pagina == 180)
                        {
                            alternativa1.Image = Properties.Resources.btn;
                            alternativa2.Image = Properties.Resources.btn;
                            alternativa3.Image = Properties.Resources.btn;
                            alternativa4.Image = Properties.Resources.btn;
                            quizz.Image = Properties.Resources.quizz2P1;
                            alternativa1.Location = new Point(415, 179);
                            alternativa1.Visible = true;
                            alternativa2.Location = new Point(415, 239);
                            alternativa2.Visible = true;
                            alternativa3.Location = new Point(415, 318);
                            alternativa3.Visible = true;
                            alternativa4.Location = new Point(415, 379);
                            alternativa4.Visible = true;
                            fecharficha.Location = new Point(31, 40);
                            fecharficha.Parent = quizz;
                            fecharficha.BackColor = Color.Transparent;
                        }
                        else if (pagina == 240)
                        {
                            alternativa1.Image = Properties.Resources.btn;
                            alternativa2.Image = Properties.Resources.btn;
                            alternativa3.Image = Properties.Resources.btn;
                            alternativa4.Image = Properties.Resources.btn;
                            quizz.Image = Properties.Resources.quizz2P2;
                            alternativa1.Location = new Point(415, 256);
                            alternativa1.Visible = true;
                            alternativa2.Location = new Point(415, 212);
                            alternativa2.Visible = true;
                            alternativa3.Location = new Point(415, 297);
                            alternativa3.Visible = true;
                            alternativa4.Location = new Point(415, 337);
                            alternativa4.Visible = true;
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
                            alternativa1.Image = Properties.Resources.btn;
                            alternativa2.Image = Properties.Resources.btnfechar;
                            alternativa3.Image = Properties.Resources.btn;
                            alternativa4.Image = Properties.Resources.btn;


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
                            alternativa1.Image = Properties.Resources.btn;
                            alternativa2.Image = Properties.Resources.btn;
                            alternativa3.Image = Properties.Resources.btn;
                            alternativa4.Image = Properties.Resources.btn;
                            quizz.Image = Properties.Resources.quizz2P1;
                            alternativa1.Location = new Point(415, 179);
                            alternativa1.Visible = true;
                            alternativa2.Location = new Point(415, 239);
                            alternativa2.Visible = true;
                            alternativa3.Location = new Point(415, 318);
                            alternativa3.Visible = true;
                            alternativa4.Location = new Point(415, 379);
                            alternativa4.Visible = true;
                            fecharficha.Location = new Point(31, 40);
                            fecharficha.Parent = quizz;
                            fecharficha.BackColor = Color.Transparent;
                        }
                        else if (pagina == 240)
                        {
                            alternativa1.Image = Properties.Resources.btn;
                            alternativa2.Image = Properties.Resources.btn;
                            alternativa3.Image = Properties.Resources.btn;
                            alternativa4.Image = Properties.Resources.btn;
                            quizz.Image = Properties.Resources.quizz2P2;
                            alternativa1.Location = new Point(415, 256);
                            alternativa1.Visible = true;
                            alternativa2.Location = new Point(415, 212);
                            alternativa2.Visible = true;
                            alternativa3.Location = new Point(415, 297);
                            alternativa3.Visible = true;
                            alternativa4.Location = new Point(415, 337);
                            alternativa4.Visible = true;
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
            if (analisarobj[0] != 5)
            {
                AbrirDialogocomFechar("Esses papeis em cima da mesa, deve haver várias informações!");
            }
            if (analisarobj[0] == 5 && analisarobj[1] == 0)
            { 
                AbrirDialogocomFechar("Há um quadro grande bem chamativo, o que posso ver sobre ele?");
            }
            if (interacoes == 6 && click == false)
            {
                AbrirDialogo("Eu devo anotar as informações no meu fichário! Ele se encontra no canto superior direito.");
            }
            if (interacoes == 6 && click == true && voltaraocorredor == false)
            {
                AbrirDialogo("Hum, o que seria isso no chão?");
            }
            if (interacoes == 6 && voltaraocorredor == true)
            {
                AbrirDialogo("Eu tenho que retornar ao corredor de onde eu vim");
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

        private void timer4_Tick(object sender, EventArgs e)
        {
            timer4.Enabled = false;
            if (timer4.Enabled == false && qual == 5)
            {
                AbrirDialogocomFechar("Vargas foi eleito presidente indiretamente sob a nova Constituição de 1934.\r\n\r\nSurgiram movimentos políticos extremistas como a Ação Integralista Brasileira (AIB) de Plínio Salgado e a Aliança Nacional Libertadora (ANL) liderada por Luís Carlos Prestes.\r\n\r\nA Intentona Comunista de 1935, liderada pela ANL, foi reprimida por Vargas, que intensificou medidas centralizadoras.");
            }
            if (timer4.Enabled == false && qual == 4)
            {
                AbrirDialogocomFechar("Vargas assumiu o poder após a Revolução de 1930 e iniciou uma fase de centralização do poder.\r\n\r\nAdiou a convocação de uma Assembleia Constituinte, gerando tensões como a Revolução Constitucionalista de 1932 em São Paulo.\r\n\r\nNomeou um interventor civil para São Paulo após a derrota do movimento, comprometendo-se a convocar eleições para uma Constituinte.\r\n\r\nA Constituição de 1934 foi promulgada, introduzindo o sufrágio feminino e garantindo uma base jurídica para o governo de Vargas.");
            }
            if (timer4.Enabled == false && qual == 2)
            {
                AbrirDialogocomFechar("Então Vargas deu um autogolpe em 1937, cancelando eleições e instaurando o Estado Novo com base em um suposto Plano Cohen, que descrevia uma conspiração comunista.\r\nO Estado Novo foi um regime ditatorial marcado por controle rigoroso da imprensa, supressão de liberdades civis e censura.\r\n\r\nPromoveu políticas trabalhistas significativas como a criação do salário mínimo e a CLT.\r\n\r\nParticipação do Brasil na Segunda Guerra Mundial (1942-1945) fortaleceu a posição de Vargas no cenário internacional, mas enfraqueceu o regime internamente devido ao desgaste econômico e social.\r\n\r\nPressionado pela oposição interna e militar, Vargas convocou eleições em 1945 e foi deposto pelos militares após sua derrota eleitoral.");
            }
        }

        private void dialogo_Click(object sender, EventArgs e)
        {

        }


        private void senhorluiz_Click(object sender, EventArgs e)
        {

        }

        private void telaparavoltar_Click(object sender, EventArgs e)
        {

        }

        private void quizz_Click(object sender, EventArgs e)
        {

        }

        private void deixarenabled_Click(object sender, EventArgs e)
        {

        }

        private void cartaestadonovo_Click(object sender, EventArgs e)
        {

        }

        private void jornalcrise_Click(object sender, EventArgs e)
        {

        }
    }
}
