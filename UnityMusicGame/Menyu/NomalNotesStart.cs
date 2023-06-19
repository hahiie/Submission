using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NomalNotesStart : MonoBehaviour
{
    public int lane;
    public float GoalTime;
    NotesMoveStart notesMoveStart;
    // Start is called before the first frame update
    void Start()
    {
        notesMoveStart = this.GetComponent<NotesMoveStart>();
    }

    // Update is called once per frame
    void Update()
    {
        float Time = GoalTime - (SongControalStart.NowTime + SongControalStart.HanteiTyousei2);
        if (Time < 0)
        {
            SongControalStart.NotesSound(2);
            GoalTime += SongControalStart.SongLength;
            notesMoveStart.GoalTimeSet(GoalTime);
        }

    }
}
