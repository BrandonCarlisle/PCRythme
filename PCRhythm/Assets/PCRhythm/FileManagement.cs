using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

namespace PCRhythm
{
    public class FileManagement
    {
        public static string CreateText(string text, string subPath)
        {
            string path = Application.dataPath + "/" + subPath;

            if (!File.Exists(path))
            {
                File.WriteAllText(path, text);
                return "Song Saved: " + path;
            }
            else
            {
                return "Error";
            }
        }

        public static string ReadText(string subPath)
        {
            string text = System.IO.File.ReadAllText(Application.dataPath + "/" + subPath);
            return text;
        }

        public static bool CheckExistingFile(string subPath)
        {
            string path = Application.dataPath + "/" + subPath;

            if (File.Exists(path))
                return true;
            return false;
        }
    } 
}
