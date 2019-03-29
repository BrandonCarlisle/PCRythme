using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PCRhythm;
using UnityEngine.UI;

//obj inst source 
//https://www.youtube.com/watch?v=4rZAAHevq1s


public class RecordingControllerScript : MonoBehaviour
{
    // Start is called before the first frame update
    public float songSpeed = 1.0f;
    public GameClock gameClock;
    public AudioController audioControl;
    public float songStart = 0.0f;

    public GameObject singleNotePurple;
    public GameObject singleNoteOrange;
    public GameObject singleNoteCyan;
    public GameObject singleNoteGreen;
    public GameObject singleNoteYellow;
    public GameObject singleNoteRed;
    public GameObject singleNotePink;
    public InputField inputSongName;
    public InputField inputSongTrack;
    public Text statusLabel;
    public Text countdownLabel;
    

    private SongRecording recording = new SongRecording("");
    private float recordingTimer = 0f;
    private bool isRecording = false;
    private bool countdownRecord = false;
    private float countdownTimer = 3.4f;

    void Start()
    {
        InputManager.onPurplePressed += purplePress;
        InputManager.onOrangePressed += orangePress;
        InputManager.onCyanPressed += cyanPress;
        InputManager.onGreenPressed += greenPress;
        InputManager.onYellowPressed += yellowPress;
        InputManager.onRedPressed += redPress;
        InputManager.onPinkPressed += pinkPress;

        statusLabel.text = "Ready";
    }

    void OnDisable()
    {
        InputManager.onPurplePressed -= purplePress;
        InputManager.onOrangePressed -= orangePress;
        InputManager.onCyanPressed -= cyanPress;
        InputManager.onGreenPressed -= greenPress;
        InputManager.onYellowPressed -= yellowPress;
        InputManager.onRedPressed -= redPress;
        InputManager.onPinkPressed -= pinkPress;
    }

    // Update is called once per frame
    void Update()
    {
        recordingTimer += Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            checkToRecord();
        }

        if (Input.GetKeyDown(KeyCode.Equals))
        {
            saveRecording();
        }

        if (Input.GetKeyDown(KeyCode.Delete))
            deleteRecording();

        if (countdownRecord)
        {
            RecordCountdown();
            countdownTimer -= Time.deltaTime;          
        }          
    }

    void checkToRecord()
    {
        if (isRecording)
            return;

        if (inputSongTrack.text == "")
        {
            statusLabel.text = "Song File Required. Ready.";
            return;
        }

        if (inputSongName.text == "")
        {
            statusLabel.text = "Song Name Required. Ready.";
            return;
        }

        if (FileManagement.CheckExistingFile("Songs/" + inputSongName.text))
        {
            statusLabel.text = "Song Name Already Exists. Ready.";
            return;
        }

        countdownRecord = true;
    }

    void RecordCountdown()
    {     
        if (countdownTimer < 0.51f)
        {
            countdownLabel.text = "";
            countdownTimer = 3.4f;
            countdownRecord = false;
            startRecording();
        }
        else
        {
            countdownLabel.text = (countdownTimer).ToString("F0");
        }    
    }

    void startRecording()
    {
         gameClock.ActivateDebugTimer();
         gameClock.debugTimer = songStart;

         recordingTimer = songStart;
         recording = new SongRecording(inputSongName.text);
         isRecording = true;
         audioControl.LoadClip(inputSongTrack.text, songStart);
         statusLabel.text = "Recording...";        
    }

    void saveRecording()
    {
        if (!isRecording || recording == null)
            return;

        string status = recording.SaveRecording();
        statusLabel.text = status + ". Ready.";

        isRecording = false;
        audioControl.StopClip();

        gameClock.DisableDebugTimer();
    }

    void deleteRecording()
    {
        if (!isRecording || recording == null)
            return;

        recording.DeleteRecording();
        statusLabel.text = "Recording Deleted. Ready";

        isRecording = false;
        audioControl.StopClip();

        gameClock.DisableDebugTimer();
    }

    void purplePress()
    {
        NotePress(NoteCategory.purple);
    }

    void orangePress()
    {
        NotePress(NoteCategory.orange);
    }

    void cyanPress()
    {
        NotePress(NoteCategory.cyan);
    }

    void greenPress()
    {
        NotePress(NoteCategory.green);
    }

    void yellowPress()
    {
        NotePress(NoteCategory.yellow);
    }

    void redPress()
    {
        NotePress(NoteCategory.red);
    }

    void pinkPress()
    {
        NotePress(NoteCategory.pink);
    }


    void RecordNote(NoteCategory type)
    {
        var note = new SingleNote(recordingTimer, type);
        recording.InsertNote(note);
    }

    void NotePress(NoteCategory type)
    {
        GameObject note;
        switch (type)
        {
            case NoteCategory.purple:
                note = singleNotePurple;
                break;
            case NoteCategory.orange:
                note = singleNoteOrange;
                break;
            case NoteCategory.cyan:
                note = singleNoteCyan;
                break;
            case NoteCategory.green:
                note = singleNoteGreen;
                break;
            case NoteCategory.yellow:
                note = singleNoteYellow;
                break;
            case NoteCategory.red:
                note = singleNoteRed;
                break;
            case NoteCategory.pink:
                note = singleNotePink;
                break;
            default:
                note = singleNotePurple;
                break;          
        }
        note = Instantiate(note, note.transform.position, note.transform.rotation);
        NoteControl noteSpeed = note.GetComponent(typeof(NoteControl)) as NoteControl;
        noteSpeed.speed = 7 * songSpeed;

        if (isRecording)
            RecordNote(type);
    }

}
