using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace PomodoroTimer.Services
{
    internal class Player
    {
        string sound;
        System.Media.SoundPlayer player;
        public Player() {
            // default sound
            sound = "C:\\Users\\Kyrpa Vladislav\\source\\repos\\PomodoroTimer\\PomodoroTimer\\Sounds\\Default.wav";
            player = new System.Media.SoundPlayer();
        }

        public void play()
        {
            player.SoundLocation = sound;
            player.Play();
        }
    }
}
