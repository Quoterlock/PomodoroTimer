namespace PomodoroTimer.Services
{
    /// <summary>
    /// Player for sounds if wave format
    /// </summary>
    internal class Player
    {
        string soundPath; 
        private System.Media.SoundPlayer player;
        private const string DEFAULT_SOUND_PATH = "C:\\Users\\Kyrpa Vladislav\\source\\repos\\PomodoroTimer\\PomodoroTimer\\Sounds\\Default.wav";
        
        public Player() {
            soundPath = DEFAULT_SOUND_PATH;
            player = new System.Media.SoundPlayer();
        }

        public void PlaySelected()
        {
            player.SoundLocation = soundPath;
            player.Play();
        }
        public void SetSoundPath(string soundPath)
        {
            this.soundPath = soundPath;
        }
    }
}
