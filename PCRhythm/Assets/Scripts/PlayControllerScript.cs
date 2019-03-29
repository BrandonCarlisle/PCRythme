using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using PCRhythm;


public class PlayControllerScript : MonoBehaviour
{
    public float songSpeed = 1.0f;

    public GameClock gameClock;
    public bool debugMode = true;
    public float songStart = 0f;

    public GameObject singleNotePurple;
    public GameObject singleNoteOrange;
    public GameObject singleNoteCyan;
    public GameObject singleNoteGreen;
    public GameObject singleNoteYellow;
    public GameObject singleNoteRed;
    public GameObject singleNotePink;
    public AudioController audioControl;
    public Text countdownLabel;

    private bool levelPlaying = false;
    private float levelTimer = 0f;
    private float levelEnd = 0f;
    private bool countdownLevel = false;
    private float countdownTimer = 3.4f;

    // Start is called before the first frame update
    void Start()
    {
        loadLevel1();        
    }

    // Update is called once per frame
    void Update()
    {
        if (countdownLevel)
        {
            levelCountdown();
            countdownTimer -= Time.deltaTime;
        }

        if (levelPlaying)
            levelTimer += Time.deltaTime;

        if (levelTimer >= levelEnd)
            EndLevel();
    }

    void loadLevel1()
    {
        var songLevel1 = new SongLevel("Epic", "Songs/epic1", "epic", 120, 3.2f);
        loadLevel(songLevel1);
    }


    void loadLevel(SongLevel level)
    {
        foreach (var singleNote in level.LevelNotes)
        {
            GameObject note = singleNotePurple;

            if (songStart > singleNote.Timing)
                continue;

            switch (singleNote.NoteType)
            {
                case NoteCategory.purple:
                    note = Instantiate(singleNotePurple, singleNotePurple.transform.position, singleNotePurple.transform.rotation);
                    break;
                case NoteCategory.orange:
                    note = Instantiate(singleNoteOrange, singleNoteOrange.transform.position, singleNoteOrange.transform.rotation);
                    break;
                case NoteCategory.cyan:
                    note = Instantiate(singleNoteCyan, singleNoteCyan.transform.position, singleNoteCyan.transform.rotation);
                    break;
                case NoteCategory.green:
                    note = Instantiate(singleNoteGreen, singleNoteGreen.transform.position, singleNoteGreen.transform.rotation);
                    break;
                case NoteCategory.yellow:
                    note = Instantiate(singleNoteYellow, singleNoteYellow.transform.position, singleNoteYellow.transform.rotation);
                    break;
                case NoteCategory.red:
                    note = Instantiate(singleNoteRed, singleNoteRed.transform.position, singleNoteRed.transform.rotation);
                    break;
                case NoteCategory.pink:
                    note = Instantiate(singleNotePink, singleNotePink.transform.position, singleNotePink.transform.rotation);
                    break;
                default:
                    break;
            }
            NoteControl noteSpeed = note.GetComponent(typeof(NoteControl)) as NoteControl;
            noteSpeed.speed = 7 * songSpeed;
            noteSpeed.noteDelay = singleNote.Timing;
        }

        StartCoroutine(audioControl.LoadClipDelay(level.AudioPath, level.SongDelay, songStart));
        levelEnd = level.LevelLength;
        levelPlaying = true;
        countdownLevel = true;

        if (debugMode)
        {
            gameClock.GameTimer = songStart;
            gameClock.debugTimer = songStart;
            gameClock.ActivateDebugTimer();
        }
            
    }

    void levelCountdown()
    {
        if (countdownTimer < 0.51f)
        {
            countdownLabel.text = "";

            if (countdownTimer < 0f)
            {
                countdownTimer = 3.4f;
                countdownLevel = false;
            }
        }
        else
        {
            //countdownLabel.text = (countdownTimer).ToString("F0");
        }
    }


    void EndLevel()
    {      
        audioControl.StopClip();
        levelPlaying = false;
        levelTimer = 0f;

        if (debugMode)
            gameClock.DisableDebugTimer();

        //switch to score screen


    }
}
