using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;
using System.Security;
using System.Media;
using System.Security.Cryptography;
using System.Windows.Forms.VisualStyles;

namespace misterio_do_catete
{
    public partial class Escritorio : Form
    {
        PictureBox[] cartas = new PictureBox[12];
        PictureBox[] cartaClicada = new PictureBox[2];

        Image[] imagens = new Image[6];
        PictureBox pic;

        int[] verificacao = new int[2];

        bool tocar = true;
        int interacoes = 0;
        int contador = 0;
        int add = 0;

        bool ganhar = false;        bool voltaraocorredor;

        bool viudepois = false;
        bool responder = false;
        bool respondeu = false;
        string quiz1 = null;
        bool concluirquizz = false;
        int pagina = 0;
        int inf = 0 ;
        int qual = 0;
        bool[] mensagens = new bool[7];
        int[] analisarobj = new int [3];
        //int analisarlivros = 0;
        bool click = false;

        private const int MaxWidth = 580;
        public Escritorio()
        {
            InitializeComponent(); 
           /* string audioFilePath = "Jogo.wav";
            AudioManager.Instance.SetlLoop(true);

            AudioManager.Instance.Play(audioFilePath);*/
            //PlayMusic("Jogo.wav");

            AbrirDialogocomFechar("Um escritório, provavelmente era aqui onde o presidente exercia seus trabalhos. Tem algumas coisas em sua mesa, vou dar uma olhada em algumas delas.");

            cartas[0] = cartar0;
            cartas[1] = cartar1;
            cartas[2] = cartar2;
            cartas[3] = cartar3;
            cartas[4] = cartar4;
            cartas[5] = cartar5;
            cartas[6] = cartar6;
            cartas[7] = cartar7;
            cartas[8] = cartar8;
            cartas[9] = cartar9;
            cartas[10] = cartar10;
            cartas[11] = cartar11;

            imagens[0] = Properties.Resources.cart1;
            imagens[1] = Properties.Resources.cart2;
            imagens[2] = Properties.Resources.cart3;
            imagens[3] = Properties.Resources.cart4;
            imagens[4] = Properties.Resources.cart5;
            imagens[5] = Properties.Resources.cart6;

            for (int i = 0; i < 7; i++)
            {
                mensagens[i] = false;
            }
        }
        #region teladeinformacao
       /* public static void PlayMusic(CorredorFase1 instance, string filepath)
        {
            instance.music = new MediaPlayer();
            instance.music.Open(new Uri(filepath, UriKind.Relative));
            instance.music.MediaEnded += (sender, e) => {
                instance.music.Position = TimeSpan.Zero;
                instance.music.Play();
            };
            instance.music.Play();
        }
        public static void StopMusic(CorredorFase1 instance, string filepath)
        {
            instance.music.Stop();
        }
        public static void PlayMusic(string filepath)
        {
            SoundPlayer music = new SoundPlayer();
            music.SoundLocation = filepath;
            music.PlayLooping();
        }
        public static void StopMusic(string filepath)
        {
            SoundPlayer music = new SoundPlayer();
            music.SoundLocation = filepath;
            music.Stop();
        }*/
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
             //   StopMusic("Jogo.wav");
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
        private void continuar(object sender, EventArgs e)
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
        private void voltarmenu(object sender, EventArgs e)
        {
            PlaySFX("papelpassar.wav");
            Menu menu = new Menu();
            menu.Show();
            this.Hide();
        }
        #endregion teladeinformacao
       
        private void AbrirDialogo(string texto)
        {
            caixadetexto.Enabled = false;
            dialogo.Text = texto.ToString();
            dialogo.MaximumSize = new Size(MaxWidth, 0);
            dialogo.Visible = true;
            rolagem.Visible = true;
            rolagem.Controls.Add(dialogo);
            caixadetexto.Visible = true;
            if (interacoes == 9 && click == true && ganhar == false)
            {
                senhorluiz.Visible = false;
                deixarenabled.Visible = false;
            }
            else
            {
                senhorluiz.Visible = true;
                deixarenabled.Visible = true;
            }
            timer1.Enabled = true;
        }
        private void AbrDialogocomsemluiz(string texto)
        {
            caixadetexto.Enabled = false;
            dialogo.Text = texto.ToString();
            dialogo.MaximumSize = new Size(MaxWidth,0);
            dialogo.Visible = true;
            rolagem.Visible = true;
            rolagem.Controls.Add(dialogo);
            caixadetexto.Visible = true;
            deixarenabled.Visible = true;
            timer1.Enabled = true;
        }
        private void AbrirDialogocomFechar(string texto)
        {
            caixadetexto.Enabled = true;
            dialogo.Text = texto.ToString();
            dialogo.MaximumSize = new Size(MaxWidth, 0);
            fechar.Visible = true;
            dialogo.Visible = true;
            rolagem.Visible = true;
            rolagem.Controls.Add(dialogo);
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

            /*if (interacoes == 9 && ganhar == false && click == false)
            {
                //amostrar jogo da memoria
                timer2.Enabled = true;
            }*/
            if (ganhar == true && quiz1 == "errado")
            {
                timer3.Enabled = true;
            }
        }

        private void FecharDialogo()
        {
            dialogo.Visible = false;
            rolagem.Visible = false;
            caixadetexto.Visible = false;
            fechar.Visible = false;
            senhorluiz.Visible = false;
            deixarenabled.Visible = false;
            avancar.Visible = false;
        }
        private void chavefase2_Click(object sender, EventArgs e)
        {
            PlaySFX("chaves.wav");
            voltaraocorredor = true;
            chavefase2.Visible = false;
            AbrirDialogocomFechar("Essa é a chave da Porta Salão Ministerial!");
        }
        private void voltar_Click(object sender, EventArgs e)
        {
            PlaySFX("botao.wav");
            if (voltaraocorredor == true && ganhar == true && concluirquizz == false)
            {
                viudepois = true;
                dica.Visible = false;
                menu.Visible = false;
                som.Visible = false;
                confresposta.Visible = true;
                confresposta.Parent = quizz;
                confresposta.BringToFront();
                confresposta.Location = new Point(639, 484);
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
            }
            else if (voltaraocorredor == false && ganhar == true)
            {
                AbrirDialogo("Há alguma coisa em cima da mesa, o que pode ser?");
            }
            else if (interacoes == 9 && ganhar == false)
            {
                click = true;
                voltar.Visible = false;
                quizz.Visible = false;
                VirarCarta();
                Embaralhar();
                VisibleT();
            }
            else if (concluirquizz == true)
            {
                CorredorFase2 corredor = new CorredorFase2();
                corredor.Show();
                this.Hide();
            }
            //apenas para testar as proximas fases
           /* else if (interacoes == 0)
            {
                CorredorFase2 corredor = new CorredorFase2();
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
                Cutscene cutscene = new Cutscene();
                cutscene.Show();
                this.Hide();
                timer3.Enabled = false;
            }
            else if (num == 1)
            {
                CorredorFase2 corredor = new CorredorFase2();
                corredor.Show();
                this.Hide();
            }
        }
        private void avancar_Click(object sender, EventArgs e)
        {
            PlaySFX("botao.wav");

            if (qual == 1)
            {
                inf += 60;
                if (inf == 0)
                {
                    dialogo.Text = "Há um papel escrito:\r\n\r\nA UDN, durante todo o segundo governo de Vargas, manteve-se atuante na oposição às propostas do governo varguista. Sua atuação ganhou repercussão à medida que a população se tornava mais insatisfeita com o aumento no custo de vida.A insatisfação popular reforçou-se especialmente a partir de 1953, quando manifestações populares de grande repercussão aconteceram.".ToString();
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
                    dialogo.Text = "...Primeiramente, pode ser destacada a Marcha das Panelas Vazias, quando cerca de 60 mil pessoas manifestaram - se na cidade de São Paulo.Pouco tempo depois, houve a Greve dos 300 mil, quando cinco sindicatos convocaram uma greve que paralisou trabalhadores em São Paulo durante quase um mês. A mobilização dos trabalhadores chamou a atenção do governo, que, em resposta, nomeou João Goulart para o posto de Ministro do Trabalho.".ToString(); avancar.Visible = true;
                    fechar.Visible = true;
                    avancar.Visible = false;
                    dialogo.MaximumSize = new Size(MaxWidth, 0);
                    dialogo.Visible = true;
                    rolagem.Visible = true;
                    rolagem.Controls.Add(dialogo);
                    caixadetexto.Visible = true;
                    senhorluiz.Visible = true;
                    deixarenabled.Visible = true;
                }
            }
            if (qual == 2)
            {
                inf += 60;
                if (inf == 0)
                {
                    dialogo.Text = "Nos papéis está escrito:\r\n\r\nA permanência de João Goulart no Ministério do Trabalho foi curta – oito meses. Além de controlar os ânimos dos trabalhadores, Jango propôs algo que foi polêmico na época: aumento de 100 % no salário - mínimo dos trabalhadores. A proposta de Jango era uma forma de compensar o desgaste na renda do trabalhador causado pela inflação.".ToString();
                    avancar.Visible = true;
                    dialogo.MaximumSize = new Size(MaxWidth, 0);
                    dialogo.Visible = true;
                    rolagem.Visible = true;
                    rolagem.Controls.Add(dialogo);
                    caixadetexto.Visible = true;
                    senhorluiz.Visible = true;
                    deixarenabled.Visible = true;
                }
                if (inf == 60)
                {
                    dialogo.Text = "...A proposta de aumento do salário - mínimo em 100 % enfureceu diferentes grupos do Brasil, como representantes das elites econômicas, membros da UDN, além do exército brasileiro. A insatisfação do exército com a medida foi tamanha que 82 coroneis e tenentes - coroneis publicaram o “Manifesto dos Coroneis” em fevereiro de 1954, tecendo duras críticas ao governo e à medida de aumento salarial...".ToString();
                    avancar.Visible = true;
                    dialogo.MaximumSize = new Size(MaxWidth, 0);
                    dialogo.Visible = true;
                    rolagem.Visible = true;
                    rolagem.Controls.Add(dialogo);
                    caixadetexto.Visible = true;
                    senhorluiz.Visible = true;
                    deixarenabled.Visible = true;
                }
                if (inf >= 120)
                {
                    dialogo.Text = "...A postura dos coroneis é vista pelos historiadores como uma demonstração de insubordinação clara da corporação, que já manifestava uma tendência para o golpismo.É importante lembrar que muitos dos coroneis envolvidos com o manifesto de 1954 envolveram - se com o golpe que deu início à Ditadura civil - militar em 1964.".ToString();
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
            if (qual == 3)
            {
                inf += 60;
                if (inf == 0)
                {
                    dialogo.Text = "Há um papel escrito:\r\n\r\nA nomeação de Jango, como era conhecido João Goulart, foi estratégica, pois ele tinha uma boa relação com os trabalhadores e com as lideranças sindicais.A atuação de Jango no Ministério do Trabalho logo acalmou o ânimo dos movimentos trabalhistas, no entanto, por outro lado, acirrou os dos opositores de Vargas.".ToString();
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
                    dialogo.Text = "...A nomeação de Jango fez com que a oposição udenista acusasse o governo de Getúlio Vargas de querer implantar uma “República sindicalista” no Brasil (espécie de ditadura dos trabalhadores), uma vez que João Goulart era visto pelos conservadores como um comunista. A denúncia da oposição, naturalmente, era falsa, pois não havia sombra disso no governo varguista.".ToString();
                    fechar.Visible = true;
                    avancar.Visible = false;
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
                inf += 60;
                if (inf == 0)
                {
                    dialogo.Text = "No papel está escrito:\r\n\r\n O projeto de energia elétrica, do governo de Vargas para a criação de uma empresa estatal não teve tanto sucesso, e a criação da Eletrobrás só aconteceu em 1962. Ambos projetos de criação de empresas estatais desagradaram profundamente à UDN, defensora ardorosa de que o desenvolvimento econômico e industrial do Brasil deveria acontecer a partir de capital estrangeiro e sem a interferência do Estado.".ToString();
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
                    dialogo.Text = "...Esse projeto político - econômico de Vargas, portanto, entrou em choque com o interesse de grupos internos que estavam alinhados com o capital internacional, tais como da Standard Oil, Light and Power Co. e American &Foreign Power Co. Além disso, havia muitos grupos econômicos poderosos do Brasil que não viam com bons olhos a postura interventora do Estado nos assuntos da economia.".ToString();
                    fechar.Visible = true;
                    avancar.Visible = false;
                    dialogo.MaximumSize = new Size(MaxWidth, 0);
                    dialogo.Visible = true;
                    rolagem.Visible = true;
                    rolagem.Controls.Add(dialogo); ;
                    caixadetexto.Visible = true;
                    senhorluiz.Visible = true;
                    deixarenabled.Visible = true;
                  
                    inf = 0;
                }
            }
        }
        private void fechar_Click(object sender, EventArgs e)
        {
            PlaySFX("botao.wav");
            FecharDialogo();
            StopSFX("locutor.wav");
            StopSFX("radioestatico.wav");

            if (analisarobj[0] == 2 && analisarobj[1] != 5 && mensagens[0] == false)
            {
               AbrirDialogocomFechar("A lixeira está bem cheia, deve ter algo em todas essas folhas.");
                mensagens[0] = true;
            }
            if (analisarobj[1] == 5 && analisarobj[2] < 2 && mensagens[1] == false)
            {
                AbrirDialogocomFechar("Algum livro da primeira fileira e da última, se destacam entre os outros, será que podem ser importantes?");
                mensagens[1] = true;
            }
            if (analisarobj[0] != 2  && analisarobj[1] == 5 && analisarobj[2] == 2 && mensagens[5] == false)
            {
                AbrirDialogocomFechar("É melhor eu verificar a mesa, com certeza ainda tem informações nela!");
                mensagens[5] = true;
            }
            if (interacoes == 9 && ganhar == false && mensagens[2] == false)
            {
                AbrirDialogocomFechar("O Governo de Getúlio Vargas, de fato, foi repleto de várias participações!");
                mensagens[2] = true;
            }
            else if (interacoes == 9 && ganhar == false && mensagens[2] == true)
            {
                //amostrar jogo da memoria
                timer2.Enabled = true;
            }
            if (ganhar == true && concluirquizz == false && mensagens[3] == false)
            {
                AbrirDialogocomFechar("Agora o que me resta fazer nessa sala é anotar as informações no meu fichário!");
                mensagens[3] = true;
            }
            if (voltaraocorredor == true && quiz1 == "correto" && viudepois == true)
            {
                timer4.Enabled = true;
            }
            if (voltaraocorredor == false && concluirquizz == true && mensagens[4] == false)
            {
                AbrirDialogo("Há alguma coisa em cima da mesa, o que pode ser?");
                mensagens[4] = true;
            }
        }
        //Testo mostrados quando clicar nos objetos
        #region mensagens
        private void mensagem(object sender, EventArgs e)
        {
            int tager;
           
            if (sender == quadro2)
            {
                PlaySFX("livro.wav");
                tager = Convert.ToInt32(quadro2.Tag);
                if (tager == 0)
                {
                    interacoes++; quadro2.Tag = 1;
                    analisarobj[2]++;
                    qual = 1;
                    inf = 0;
                    dialogo.Text = "Há um papel escrito:\r\n\r\nA UDN, durante todo o segundo governo de Vargas, manteve-se atuante na oposição às propostas do governo varguista. Sua atuação ganhou repercussão à medida que a população se tornava mais insatisfeita com o aumento no custo de vida. A insatisfação popular reforçou-se especialmente a partir de 1953, quando manifestações populares de grande repercussão aconteceram."/*\r\n\r\nPrimeiramente, pode ser destacada a Marcha das Panelas Vazias, quando cerca de 60 mil pessoas manifestaram - se na cidade de São Paulo.Pouco tempo depois, houve a Greve dos 300 mil, quando cinco sindicatos convocaram uma greve que paralisou trabalhadores em São Paulo durante quase um mês. A mobilização dos trabalhadores chamou a atenção do governo, que, em resposta, nomeou João Goulart para o posto de Ministro do Trabalho."*/.ToString();
                    avancar.Visible = true;
                    dialogo.MaximumSize = new Size(MaxWidth, 0);
                    dialogo.Visible = true;
                    rolagem.Visible = true;
                    rolagem.Controls.Add(dialogo);
                    caixadetexto.Visible = true;
                    senhorluiz.Visible = true;
                    deixarenabled.Visible = true;
                }
                if (tager == 1)
                {
                    AbrirDialogo("Eu não preciso mais ver o que tem aqui!");
                }
            }
            if (sender == quadro7_2)
            {
                PlaySFX("livro.wav");
                tager = Convert.ToInt32(quadro7_2.Tag);
                if (tager == 0)
                {
                    interacoes++; quadro7_2.Tag = 1;
                    analisarobj[2]++;
                    inf = 0;
                    AbrirDialogocomFechar("Há um papel escrito:\r\n\r\nUm forte debate sobre o desenvolvimento do Brasil dividiu o país ao longo da década de 1950 entre aqueles que defendiam uma postura que priorizasse o desenvolvimento do país a partir de empresas e capital nacional e com grande intervenção do Estado na economia (nacional-desenvolvimentismo) e aqueles que defendiam a priorização do capital e empresas estrangeiras com predominância do livre mercado.");
                }
                if (tager == 1)
                {
                    AbrirDialogo("Eu não preciso mais ver o que tem aqui!");
                }
            }
          
            if (sender == quadrolixeira)
            {
                PlaySFX("papel.wav");
                tager = Convert.ToInt32(quadrolixeira.Tag);
                if (tager == 0)
                {
                    interacoes++; quadrolixeira.Tag = 1;
                    analisarobj[1]++;
                    inf = 0;
                    qual = 3;
                    avancar.Visible = true;
                    dialogo.Text = "Há um papel escrito:\r\n\r\nA nomeação de Jango, como era conhecido João Goulart, foi estratégica, pois ele tinha uma boa relação com os trabalhadores e com as lideranças sindicais. A atuação de Jango no Ministério do Trabalho logo acalmou o ânimo dos movimentos trabalhistas, no entanto, por outro lado, acirrou os dos opositores de Vargas."/*\r\n\r\nA nomeação de Jango fez com que a oposição udenista acusasse o governo de Getúlio Vargas de querer implantar uma “República sindicalista” no Brasil (espécie de ditadura dos trabalhadores), uma vez que João Goulart era visto pelos conservadores como um comunista. A denúncia da oposição, naturalmente, era falsa, pois não havia sombra disso no governo varguista."*/.ToString();
                    dialogo.MaximumSize = new Size(MaxWidth, 0);
                    dialogo.Visible = true;
                    rolagem.Visible = true;
                    rolagem.Controls.Add(dialogo);
                    caixadetexto.Visible = true;
                    senhorluiz.Visible = true;
                    deixarenabled.Visible = true;
                }
                if (tager == 1)
                {
                    AbrirDialogo("Eu não preciso mais ver o que tem aqui!");
                }
            }
            if (sender == quadrolixeira1)
            {
                PlaySFX("papel.wav");
                tager = Convert.ToInt32(quadrolixeira1.Tag);
                if (tager == 0)
                {
                    interacoes++; quadrolixeira1.Tag = 1;
                    analisarobj[1]++;
                    inf = 0;
                    fechar.Visible = true;
                    dialogo.Text = "No papel está escrito:\r\n\r\nDesde a sua campanha eleitoral de Getúlio Vargas, o seu discurso defendia uma maior priorização para a opção nacionalista do desenvolvimentismo. Essa postura de Vargas refletiu-se em duas importantes áreas da economia brasileira: a exploração do petróleo e a produção de energia elétrica.".ToString();
                    dialogo.MaximumSize = new Size(MaxWidth, 0);
                    dialogo.Visible = true;
                    rolagem.Visible = true;
                    rolagem.Controls.Add(dialogo);
                    caixadetexto.Visible = true;
                    senhorluiz.Visible = true;
                    deixarenabled.Visible = true;   
                }
                if (tager == 1)
                {
                    AbrirDialogo("Eu não preciso mais ver o que tem aqui!");
                }
            }
            if (sender == quadrolixeira2)
            {
                PlaySFX("papel.wav");

                tager = Convert.ToInt32(quadrolixeira2.Tag);
                if (tager == 0)
                {
                    interacoes++; quadrolixeira2.Tag = 1;
                    analisarobj[1]++;
                    inf = 0;
                    fechar.Visible = true;
                    dialogo.Text = "No papel está escrito:\r\n\r\nSurgiu durante o segundo governo de Vargas a Campanha do Petróleo, na qual se defendia que a exploração do petróleo brasileiro deveria ser realizada por empresas nacionais. Essa campanha teve adesão de diferentes grupos da sociedade brasileira sob o lema de “o petróleo é nosso”. Essa campanha resultou na criação da Petrobras a partir de 1953, que passou a ser a detentora do monopólio de exploração do petróleo no Brasil a partir de 1954.".ToString();
                    dialogo.MaximumSize = new Size(MaxWidth, 0);
                    dialogo.Visible = true;
                    rolagem.Visible = true;
                    rolagem.Controls.Add(dialogo);
                    caixadetexto.Visible = true;
                    senhorluiz.Visible = true;
                    deixarenabled.Visible = true;
                }
                if (tager == 1)
                {
                    AbrirDialogo("Eu não preciso mais ver o que tem aqui!");
                }
            }
            if (sender == quadrolixeira3)
            {
                PlaySFX("papel.wav");

                tager = Convert.ToInt32(quadrolixeira3.Tag);
                if (tager == 0)
                {
                    interacoes++; quadrolixeira3.Tag = 1;
                    analisarobj[1]++;
                    inf = 0;
                    qual = 4;
                    avancar.Visible = true;
                    dialogo.Text = "No papel está escrito:\r\n\r\n O projeto de energia elétrica, do governo de Vargas para a criação de uma empresa estatal não teve tanto sucesso, e a criação da Eletrobrás só aconteceu em 1962. Ambos projetos de criação de empresas estatais desagradaram profundamente à UDN, defensora ardorosa de que o desenvolvimento econômico e industrial do Brasil deveria acontecer a partir de capital estrangeiro e sem a interferência do Estado."/*\r\n\r\nEsse projeto político - econômico de Vargas, portanto, entrou em choque com o interesse de grupos internos que estavam alinhados com o capital internacional, tais como da Standard Oil, Light and Power Co. e American &Foreign Power Co. Além disso, havia muitos grupos econômicos poderosos do Brasil que não viam com bons olhos a postura interventora do Estado nos assuntos da economia.*/.ToString();
                    dialogo.MaximumSize = new Size(MaxWidth, 0);
                    dialogo.Visible = true;
                    rolagem.Visible = true;
                    rolagem.Controls.Add(dialogo);
                    caixadetexto.Visible = true;
                    senhorluiz.Visible = true;
                    deixarenabled.Visible = true;
                }
                if (tager == 1)
                {
                    AbrirDialogo("Eu não preciso mais ver o que tem aqui!");
                }
            }
            if (sender == quadrolixeira4)
            {
                PlaySFX("papel.wav");

                tager = Convert.ToInt32(quadrolixeira4.Tag);
                if (tager == 0)
                {
                    analisarobj[1]++;
                    inf = 0;
                    fechar.Visible = true;
                    if (inf == 0)
                    {
                        dialogo.Text = "No papel está escrito:\r\n\r\nComo forma de contornar toda a situação acontecendo no período, Getúlio Vargas tomou medidas para agradar aos diferentes lados: para acalmar a oposição, demitiu Jango; para acalmar a população, ratificou o aumento salarial; para manter o exército sob controle, substituiu o posto de Ministro do Trabalho nomeando Zenóbio da Costa.".ToString();
                    }
                    dialogo.MaximumSize = new Size(MaxWidth, 0);
                    dialogo.Visible = true;
                    rolagem.Visible = true;
                    rolagem.Controls.Add(dialogo);
                    caixadetexto.Visible = true;
                    senhorluiz.Visible = true;
                    deixarenabled.Visible = true;
                    interacoes++; quadrolixeira4.Tag = 1;
                }
                if (tager == 1)
                {
                    AbrirDialogo("Eu não preciso mais ver o que tem aqui!");
                }
            }
            if (sender == quadropapelada)
            {
                PlaySFX("papeladas.wav");

                qual = 2;
                tager = Convert.ToInt32(quadropapelada.Tag);
                if (tager == 0)
                {
                    interacoes++;
                    analisarobj[0]++;
                    inf = 0;
                    dialogo.Text = "Nos papéis está escrito:\r\n\r\nA permanência de João Goulart no Ministério do Trabalho foi curta – oito meses. Além de controlar os ânimos dos trabalhadores, Jango propôs algo que foi polêmico na época: aumento de 100 % no salário - mínimo dos trabalhadores. A proposta de Jango era uma forma de compensar o desgaste na renda do trabalhador causado pela inflação."/*\r\n\r\nA proposta de aumento do salário - mínimo em 100 % enfureceu diferentes grupos do Brasil, como representantes das elites econômicas, membros da UDN, além do exército brasileiro. A insatisfação do exército com a medida foi tamanha que 82 coroneis e tenentes - coroneis publicaram o “Manifesto dos Coroneis” em fevereiro de 1954, tecendo duras críticas ao governo e à medida de aumento salarial.\r\n\r\nA postura dos coroneis é vista pelos historiadores como uma demonstração de insubordinação clara da corporação, que já manifestava uma tendência para o golpismo.É importante lembrar que muitos dos coroneis envolvidos com o manifesto de 1954 envolveram - se com o golpe que deu início à Ditadura civil - militar em 1964.*/.ToString();
                    avancar.Visible = true;
                    dialogo.MaximumSize = new Size(MaxWidth, 0);
                    dialogo.Visible = true;
                    rolagem.Visible = true;
                    rolagem.Controls.Add(dialogo);
                    caixadetexto.Visible = true;
                    senhorluiz.Visible = true;
                    deixarenabled.Visible = true;
                    quadropapelada.Tag = 1;
                }
                if (tager == 1)
                {
                    AbrirDialogo("Eu não preciso mais ver o que tem aqui!");
                }
            }
            
            if (sender == quadroradio)
            {
                tager = Convert.ToInt32(quadroradio.Tag);
                if (tager == 0)
                {
                    PlaySFX("locutor.wav");

                    interacoes++;
                    quadroradio.Tag = 1;
                    analisarobj[0]++;
                AbrirDialogocomFechar("Um rádio ligado em uma frequência dizendo: \r\n\r\nInterrompemos nossa programação para um notícia urgente. O presidente, Getúlio Vargas, faleceu nesta manhã, 24 de agosto, em sua residência, no Palacio do Catete! Pedimos a todos que mantenham a calma e aguardem mais informações. Reiteramos nosso compromisso de trazer as últimas notícias sobre este triste acontecimento. Que Deus abençoe o Brasil.");
                }
                if (tager == 1)
                {
                    PlaySFX("radioestatico.wav");
                    AbrirDialogo("Eu não preciso mais ver o que tem aqui!");
                }
            }
            if (interacoes == 9)
            {
                quizz.Image = Properties.Resources.fichanormal;
            }  
        }
        #endregion mensagens
        #region Quizz
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
            if (responder == true)
            {
                som.Visible = false;
                menu.Visible = false;
                dica.Visible = false;
                confresposta.Visible = true;
                confresposta.Parent = quizz;
                confresposta.BringToFront();
                //confresposta.BackColor = Color.Transparent;
                confresposta.Location = new Point(639, 484);
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
            else if (responder == false)
            {
                AbrDialogocomsemluiz("Ainda não juntei informações suficientes para anotar!");
            }
        }
        private void ConclusaodaPergunta()
        {
            if (respondeu == false)
            {
                AbrDialogocomsemluiz("Eu tenho que reponder essa pergunta!");
            }
            if (respondeu == true)
            {
                if (quiz1 == "correto")
                {
                    if (viudepois == true)
                    {
                        DiminuirFicha();
                        AbrirDialogocomFechar("Agora que eu já sei isso posso prosseguir com a minha investigação!");
                    }
                    else if (viudepois == false)
                    {
                        DiminuirFicha();
                        quizz.Enabled = true;
                        AbrirDialogocomFechar("Agora que eu já sei isso posso prosseguir com a minha investigação!");

                        concluirquizz = true;
                    }
                }
                else if (quiz1 == "errado")
                {
                    DiminuirFicha();
                    AbrirDialogo("Eu não devo ter Analizado Corretamente!");
                }
            }
        } 
        
        private void EventoQuiz(object sender, EventArgs e)
        {
            if (sender == fichario)
            {
                if (interacoes == 9 && ganhar == true)
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
                respondeu = true;
                if (sender == alternativa1)
                {
                    alternativa1.Image = Properties.Resources.btnfechar;
                    alternativa2.Image = Properties.Resources.btn;
                    alternativa3.Image = Properties.Resources.btn;
                    alternativa4.Image = Properties.Resources.btn;
                    quiz1 = "errado";
                }
                if (sender == alternativa2)
                {
                    alternativa2.Image = Properties.Resources.btnfechar;
                    alternativa3.Image = Properties.Resources.btn;
                    alternativa4.Image = Properties.Resources.btn;
                    alternativa1.Image = Properties.Resources.btn;
                    quiz1 = "correto";
                }
                if (sender == alternativa3)
                {
                    alternativa3.Image = Properties.Resources.btnfechar;
                    alternativa4.Image = Properties.Resources.btn;
                    alternativa1.Image = Properties.Resources.btn;
                    alternativa2.Image = Properties.Resources.btn;
                    quiz1 = "errado";
                }
                if (sender == alternativa4)
                {
                    alternativa4.Image = Properties.Resources.btnfechar;
                    alternativa1.Image = Properties.Resources.btn;
                    alternativa2.Image = Properties.Resources.btn;
                    alternativa3.Image = Properties.Resources.btn;
                    quiz1 = "errado";
                }
            }
            else if ( responder == false)
            {
                AbrirDialogo("Eu não vou responder agora!");
            }
        }
        private void confirmarresposta_Click(object sender, EventArgs e)
        {
            PlaySFX("papeladas.wav");
            switch (responder)
            {
                case true:
                    ConclusaodaPergunta();
                    break;

                case false:
                    AbrirDialogo("Eu não vou responder agora!");
                    break;
            }
        }

        private void PassarPagina(object sender, EventArgs e)
        {
            switch (responder)
            {
                case true:
                    if (sender == passarpaginafrente)
                    {
                        PlaySFX("papelpassar.wav");
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
                            fecharficha.Location = new Point(20, 40);
                            fecharficha.Parent = quizz;
                            quizz.Image = Properties.Resources.quizz1;
                            alternativa1.Visible = true;
                            alternativa2.Visible = true;
                            alternativa3.Visible = true;
                            alternativa4.Visible = true;
                        }
                        else
                        {
                            fecharficha.Parent = quizz;
                            fecharficha.Location = new Point(20, 40);
                            pagina = 120;
                            quizz.Image = Properties.Resources.quizz1;
                            alternativa1.Visible = true;
                            alternativa2.Visible = true;
                            alternativa3.Visible = true;
                            alternativa4.Visible = true;

                            AbrDialogocomsemluiz("Eu tenho que reponder essa pergunta!");
                        }
                    }
                    if (sender == passarpaginaatras)
                    {
                        PlaySFX("papelpassar.wav");
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
                            quizz.Image = Properties.Resources.quizz1;
                            alternativa1.Visible = true;
                            alternativa2.Visible = true;
                            alternativa3.Visible = true;
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

                            AbrDialogocomsemluiz("Não tem mais páginas!");
                        }
                    }
                    break;

                case false:

                    if (sender == passarpaginafrente)
                    {
                        PlaySFX("papelpassar.wav");
                        pagina += 60;
                        if (pagina == 0)
                        {
                            quizz.Image = Properties.Resources.fichafechada;
                            alternativa1.Visible = false;
                            alternativa2.Visible = false;
                            alternativa3.Visible = false;
                            alternativa4.Visible = false;
                            fecharficha.Location = new Point(250, 40) ;
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

                            AbrDialogocomsemluiz("Não tem mais páginas!");
                        }
                    }
                    if (sender == passarpaginaatras)
                    {
                        PlaySFX("papelpassar.wav");
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

                            AbrDialogocomsemluiz("Não tem mais páginas!");
                        }
                    }
                break;
            }
        }
        #endregion Quizz
        #region JogodaMemoria
        private void Embaralhar()
        {
            Random rnd = new Random();
            cartas = cartas.OrderBy(x => rnd.Next()).ToArray();

            int[] xL = { 95, 269, 445, 610, 95, 269, 445, 610, 95, 269, 445, 610 };
            int[] yL = { 35, 35, 35, 35, 221, 221, 221, 221, 410, 410, 410, 410 };

            for (int i = 0; i < 12; i++)
            {
                cartas[i].Location = new Point(xL[i], yL[i]);
            }
        }
        private void VirarCarta()
        {
            for (int i = 0; i < 12; i++)
            {
                if (cartas[i].Enabled == true)
                {
                    cartas[i].Image = Properties.Resources.vers;
                }
            }
        }
        private void Verificar()
        {
            if (verificacao[0] == verificacao[1])
            {
                add++;
                for (int i = 0; i < 2; i++)
                {
                    cartaClicada[i].Enabled = false;
                }
                if (add == 6)
                {
                    ganhar = true;
                    VisibleF();
                    dica.Location = new Point(671, 12);
                    som.Location = new Point(722, 12);
                    if (ganhar == true && concluirquizz == false && mensagens[3] == false)
                    {
                        AbrirDialogocomFechar("Agora o que me resta fazer nessa sala é anotar as informações no meu fichário!");
                        mensagens[3] = true;
                    }
                    chavefase2.Visible = true;
                    voltar.Visible = true;
                    quizz.Visible = true;
                }
            }
        }
        private void EventClick(object sender, EventArgs e)
        {
            pic = sender as PictureBox;

            if (contador == 0)
            {
                int tag = Convert.ToInt32(pic.Tag);
                pic.Image = imagens[tag];
                verificacao[0] = tag;
                cartaClicada[0] = pic;

                contador++;
            }
            else if (cartaClicada[0] != pic)
            {
                if (contador == 1)
                {
                    int tag = Convert.ToInt32(pic.Tag);
                    pic.Image = imagens[tag];
                    verificacao[1] = tag;
                    cartaClicada[1] = pic;
                    pic.Refresh();

                    Thread.Sleep(1000);
                    Verificar();
                    VirarCarta();

                    contador = 0;
                }
            }
        }

        private void VisibleT()
        {
            cartar0.Visible = true;
            cartar1.Visible = true;
            cartar2.Visible = true;
            cartar3.Visible = true;
            cartar4.Visible = true;
            cartar5.Visible = true;
            cartar6.Visible = true;
            cartar7.Visible = true;
            cartar8.Visible = true;
            cartar9.Visible = true;
            cartar10.Visible = true;
            cartar11.Visible = true;
            dica.Location = new Point(773, 114);
            som.Location = new Point(774, 63);
            fundo.Visible = true;
            fundo.Location = new Point(0, 0);
        }
        private void VisibleF()
        {
            cartar0.Visible = false;
            cartar1.Visible = false;
            cartar2.Visible = false;
            cartar3.Visible = false;
            cartar4.Visible = false;
            cartar5.Visible = false;
            cartar6.Visible = false;
            cartar7.Visible = false;
            cartar8.Visible = false;
            cartar9.Visible = false;
            cartar10.Visible = false;
            cartar11.Visible = false;
            fundo.Visible = false;
        }
        #endregion JogodaMemoria

        private void dica_Click(object sender, EventArgs e)
        {
            PlaySFX("botao.wav");
            if (analisarobj[0] != 2)
            {
                AbrirDialogocomFechar("Por que eu não dou uma olhada em cima da mesa?");
            }
            if (analisarobj[1] != 5 && analisarobj[0] == 2)
            {
                AbrirDialogocomFechar("A lixeira, e as quatro folhas no chão deve conter algo.");
            }
            if (analisarobj[1] == 5 && analisarobj[2] < 2)
            {
                AbrirDialogocomFechar("Alguns desses livros na estante podem ser importantes. Que tal eu verificar a primeira fileira e a última?");
            }
            if (interacoes == 9 && click == true && ganhar == false)
            {
                dialogo.MaximumSize = new Size(MaxWidth, 0);
                dialogo.Text = "Eu devo achar as duas cartas idênticas!".ToString();
                timer1.Enabled = true;
                dialogo.Visible = true;
                rolagem.Visible = true;
                rolagem.Controls.Add(dialogo);
                caixadetexto.Visible = true;
            }
            if (quiz1 == null && ganhar == true)
            {
                AbrirDialogo("Eu devo anotar as informações no meu fichário! Ele se encontra no canto superior direito.");
            }
            if (ganhar == true && quiz1 == "correto" && voltaraocorredor == false)
            {
                AbrirDialogo("Há alguma coisa em cima da mesa, o que pode ser?!");
            }
            if (quiz1 == "correto" && voltaraocorredor == true)
            {
                AbrirDialogo("Eu tenho que retornar ao corredor de onde eu vim!");
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            Embaralhar();
            VirarCarta();
            VisibleT();
            click = true;
            voltar.Visible = false;
            quizz.Visible = false;
            timer2.Enabled = false;
            quizz.Image = Properties.Resources.fichanormal;
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            Comodo(0);
            timer3.Enabled = false;
        }

        private void timer4_Tick(object sender, EventArgs e)
        {
            Comodo(1);
            timer4.Enabled = false;
        }

    }
}
