using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCRhythm
{
    public class SingleNote
    {
        public float Timing { get; set; }
        public NoteCategory NoteType { get; set; }

        public SingleNote(float timing, NoteCategory noteType)
        {
            this.Timing = timing;
            this.NoteType = noteType;
        }
    }
}
