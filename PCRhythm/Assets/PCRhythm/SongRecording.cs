using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Globalization;

namespace PCRhythm
{
    public class SongRecording
    {
        public string SongName { get; set; }
        private string SongText { get; set; }

        public SongRecording(string songname)
        {
            this.SongName = songname;
            this.SongText = "";
        }


        public void InsertNote(SingleNote note)
        {
            string noteText = string.Format("{{S:{0}:{1}}}", NoteCategoryParse(note), note.Timing);
            SongText += noteText;
            SongText += Environment.NewLine;
        }

        private string NoteCategoryParse(SingleNote note)
        {
            switch (note.NoteType)
            {
                case NoteCategory.purple:
                    return "P";
                case NoteCategory.orange:
                    return "O";
                case NoteCategory.cyan:
                    return "C";
                case NoteCategory.green:
                    return "G";
                case NoteCategory.yellow:
                    return "Y";
                case NoteCategory.red:
                    return "R";
                case NoteCategory.pink:
                    return "PN";
                default:
                    return "P";
            }
        }

        private NoteCategory RawToCategory(string raw)
        {
            switch (raw)
            {
                case "P":
                    return NoteCategory.purple;
                case "O":
                    return NoteCategory.orange;
                case "C":
                    return NoteCategory.cyan;
                case "G":
                    return NoteCategory.green;
                case "Y":
                    return NoteCategory.yellow;
                case "R":
                    return NoteCategory.red;
                case "PN":
                    return NoteCategory.pink;
                default:
                    return NoteCategory.purple;
            }
        }


        public List<SingleNote> readSong()
        {
            var songNotes = new List<SingleNote>();

            MatchCollection matchList = Regex.Matches(this.SongText, @"\{[a-zA-z:0-9.]*\}");
            var notesRaw = matchList.Cast<Match>().Select(match => match.Value).ToList();

            foreach (var noteRaw in notesRaw)
            {
                songNotes.Add(readNextNote(noteRaw.ToString()));
            }
            return songNotes;
        }

        private SingleNote readNextNote(string rawNote)
        {
            var note = new SingleNote(0, NoteCategory.purple);

            try
            {
                rawNote = rawNote.Replace('{', ' ').Replace('}', ' ');
                var noteSections = rawNote.Split(':');
                if (noteSections.Length > 2)
                {
                    var noteType = noteSections[0];
                    var noteCategory = noteSections[1];
                    float noteTiming = float.Parse(noteSections[2], CultureInfo.InvariantCulture.NumberFormat);

                    note.NoteType = RawToCategory(noteCategory);
                    note.Timing = noteTiming;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return note;
        }

        public void SetRawSongText(string songText)
        {
            this.SongText = songText;
        }

        public void DeleteRecording()
        {
            this.SongText = "";
        }

        public string SaveRecording()
        {
            return FileManagement.CreateText(this.SongText, "Songs/" + this.SongName);
        }
    }
}
