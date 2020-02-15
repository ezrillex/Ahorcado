using System.Media;

namespace Ahorcado
{
    static class Sonido
    {
        private static SoundPlayer sound_Correct;
        private static SoundPlayer sound_Wrong;
        private static SoundPlayer sound_Lose;
        private static SoundPlayer sound_Win;
        private static SoundPlayer sound_Click;

        public static void Init()
        {
            sound_Correct = new SoundPlayer("Correct.wav");
            sound_Wrong = new SoundPlayer("Wrong.wav");
            sound_Lose = new SoundPlayer("Lose.wav");
            sound_Win = new SoundPlayer("Win.wav");
            sound_Click = new SoundPlayer("Click.wav");
        }

        public static void Click()
        {
            // encapsulate in a try catch to initialize if it ever gets called without initializing first
            sound_Click.Play();
        }

        public static void Correct()
        {
            sound_Correct.Play();
        }

        public static void Win()
        {
            sound_Win.Play();
        }

        public static void Wrong()
        {
            sound_Wrong.Play();
        }

        public static void Lose()
        {
            sound_Lose.Play();
        }

        public static void Dispose()
        {
            sound_Correct.Dispose();
            sound_Wrong.Dispose();
            sound_Lose.Dispose();
            sound_Win.Dispose();
            sound_Click.Dispose();
        }
    }
}
