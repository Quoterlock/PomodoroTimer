namespace PomodoroTimer.Services
{
    /// <summary>
    /// Player for sounds if wave format
    /// </summary>
    internal class Player
    {
        string sound; // sound path
        System.Media.SoundPlayer player; // player
        public Player() {
            // default sound
            sound = "C:\\Users\\Kyrpa Vladislav\\source\\repos\\PomodoroTimer\\PomodoroTimer\\Sounds\\Default.wav";
            // new player
            player = new System.Media.SoundPlayer();
        }

        /// <summary>
        /// Play selected sound
        /// </summary>
        public void play()
        {
            player.SoundLocation = sound;
            player.Play();
        }

        /// <summary>
        /// Set new sound path
        /// </summary>
        /// <param name="songPath"></param>
        public void setSong(string songPath)
        {
            sound = songPath;
        }
    }
}
