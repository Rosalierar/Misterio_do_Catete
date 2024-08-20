using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;
using System.Windows.Media;
using WMPLib;

namespace misterio_do_catete
{
    public class AudioManager
    {
        private static AudioManager _instance;
        private WindowsMediaPlayer _player;

        // Construtor privado para evitar instância externa
        private AudioManager()
        {
            _player = new WindowsMediaPlayer();

            _player.settings.setMode("loop", true); // configura a reproducao em loop como padrao
        }

        // Propriedade para obter a instância única
        public static AudioManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new AudioManager();
                }
                return _instance;
            }
        }

        // Método para tocar a música
        public void Play(string filePath)
        {
            _player.URL = filePath;
            _player.controls.play();
        }
        public void PlayTrack1()
        {
            Play("Interface.wav");
        }
        public void PlayTrack2()
        {
            Play("Cutscene.wav");
        }
        public void PlayTrack3()
        {
            Play("Jogo.wav");
        }
        // Método para parar a música
        public void Stop()
        {
            _player.controls.stop();
        }

        // Método para verificar se a música está tocando
        public bool IsPlaying()
        {
            return _player.playState == WMPPlayState.wmppsPlaying;
        }

        //metodo para configurar a reproducao em loop
        public void SetlLoop(bool enable)
        {
            _player.settings.setMode("loop",enable);
        }
    }
}
