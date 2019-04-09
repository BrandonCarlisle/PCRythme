using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace PCRhythm
{
    public class SongLevel
    {
        public string LevelName { get; set; }
        public List<SingleNote> LevelNotes { get; set; }
        public string AudioPath { get; set; }
        public float LevelLength { get; set; }
        public float SongDelay { get; set; }

        public SongLevel(string levelName, string songPath, string audioPath, float levelLength, float songdelay = 3.2f)
        {      
            var levelRecording = new SongRecording(levelName);
            this.LevelName = levelName;

            TextAsset songAsset = (TextAsset)Resources.Load("SongNotes/" + songPath);
            levelRecording.SetRawSongText(songAsset.text);

            this.LevelNotes = levelRecording.readSong();
            this.AudioPath = audioPath;

            if (levelLength < 1)
                this.LevelLength = 1f;
            else
                this.LevelLength = levelLength;

            if (songdelay < 0)
                this.SongDelay = 0f;
            else
                this.SongDelay = songdelay;
        }
    }
}
