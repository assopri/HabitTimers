using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
