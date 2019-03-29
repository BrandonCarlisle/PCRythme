using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.PCRhythm
{
    //parse, all notes get loaded into place before start
    //go through lists and place objects
    //timing 1 = -15, timing 2 = -15.5, etc

    //min interval for between notes = .5
    //1.0 scale = .25sec = 1 interval

    //zone for 4 main notes
    //rpad  12.1
    //lpad  12.7
    //center    12.36
    //destroy at 14
    //private List<SingleNote> getSongNotes() {
    //    var singleNotes = new List<SingleNote>();
    //    int[] purpleSingle = {1,3,5,7};
    //    int[] orangeSingle = {1,2,8};
    //    int[] cyanSingle = {3,5,8};
    //    int[] greenSingle = {4,5,8};

    //    foreach (var noteTime in purpleSingle)
    //    {
    //        singleNotes.Add(new SingleNote(noteTime, NoteCategory.purple));
    //    }
    //    foreach (var noteTime in orangeSingle)
    //    {
    //        singleNotes.Add(new SingleNote(noteTime, NoteCategory.orange));
    //    }
    //    foreach (var noteTime in cyanSingle)
    //    {
    //        singleNotes.Add(new SingleNote(noteTime, NoteCategory.cyan));
    //    }
    //    foreach (var noteTime in greenSingle)
    //    {
    //        singleNotes.Add(new SingleNote(noteTime, NoteCategory.green));
    //    }

    //    singleNotes.Add(new SingleNote(1, NoteCategory.green));
    //    return singleNotes;
    //}


    //var singleNotes = getSongNotes();
    //foreach (var singleNote in singleNotes)
    //{
    //    Vector3 newPos = new Vector3(-(timingOffset * singleNote.Timing), 0, 0);
    //    GameObject note = singleNotePurple;
    //    switch (singleNote.NoteType)
    //    {      
    //        case NoteCategory.purple:
    //            note = Instantiate(singleNotePurple, singleNotePurple.transform.position + newPos, singleNotePurple.transform.rotation);
    //            break;
    //        case NoteCategory.orange:                
    //            note = Instantiate(singleNoteOrange, singleNoteOrange.transform.position + newPos, singleNoteOrange.transform.rotation);
    //            break;
    //        case NoteCategory.cyan:
    //            note = Instantiate(singleNoteCyan, singleNoteCyan.transform.position + newPos, singleNoteCyan.transform.rotation);
    //            break;
    //        case NoteCategory.green:
    //            note = Instantiate(singleNoteGreen, singleNoteGreen.transform.position + newPos, singleNoteGreen.transform.rotation);
    //            break;
    //        default:
    //            break;
    //    }
    //    NoteControl noteSpeed = note.GetComponent(typeof(NoteControl)) as NoteControl;
    //    noteSpeed.speed = 7 * songSpeed;
    //}


    //void PurpleHold()
    //{
    //    if (purpleHoldNote == null)
    //    {
    //        GameObject note = singleNotePurple;
    //        note = Instantiate(singleNotePurple, singleNotePurple.transform.position, singleNotePurple.transform.rotation);
    //        NoteControl noteSpeed = note.GetComponent(typeof(NoteControl)) as NoteControl;
    //        noteSpeed.speed = 7 * songSpeed;
    //        purpleHoldNote = note;
    //    }
    //    else
    //    {
    //        purpleHoldNote.transform.localScale += new Vector3(.2f * songSpeed, 0, 0);
    //    }     
    //}
}
