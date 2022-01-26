using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleEngineLib.Audio
{
    public class AudioManager
    {
        protected static List<string> filesToPlay = new List<string>();
        public static void PlaySound(string file)
        {
            lock(filesToPlay)
                filesToPlay.Add(file);
        }
        public static void PlayQueue()
        {
            List<string> queueFiles = new List<string>();

            lock (filesToPlay)
            {
                queueFiles = filesToPlay.ToList();
                filesToPlay.Clear();

            }
            foreach(var item in queueFiles)
            {
                System.Media.SoundPlayer player = new System.Media.SoundPlayer(item);
                player.Play();
            }
        }
    }
}
