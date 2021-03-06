using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoLibrary;

namespace HabitTimers.Classes
{
    public static class Utilities
    {
        public static string GetRandomFileFromFolder(string folder)
        {
            var rand = new Random();
            var files = Directory.GetFiles(folder, "*.*");
            if (files.Length == 0) return "";
            return files[rand.Next(files.Length)];
        }

        public static int GetVideoLengthSeconds(string youtubeVideoUrl)
        {
            YouTube youTube = YouTube.Default;
            var video = youTube.GetVideo(youtubeVideoUrl);
            return (int)video.Info.LengthSeconds;
        }
    }
}
