using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class NotesCreateTest : MonoBehaviour
{
    [System.Serializable]
    public class NotesList
    {
        public Notes[] notes;
    }
    [System.Serializable]
    public class Notes
    {
        public int type;
        public int lane;
        public float time;
    }
    // Start is called before the first frame update
    void Start()
    {
        Notes n1 = new Notes();
        Notes n2 = new Notes();
        Notes n3 = new Notes();
        Notes n4 = new Notes();
        Notes n5 = new Notes();
        Notes n6 = new Notes();
        Notes n7 = new Notes();

        Notes n8 = new Notes();
        Notes n9 = new Notes();
        Notes n10 = new Notes();
        NotesCr(n1, 1, 0, 2f);
        NotesCr(n2, 1, 3, 3f);
        NotesCr(n3, 1, 5, 2f);
        NotesCr(n4, 1, 7, 4f);
        NotesCr(n5, 2, 2, 5f);
        NotesCr(n6, 2, 3, 6.5f);
        NotesCr(n7, 2, 2, 7f);
        NotesCr(n8, 3, 5, 4f);
        NotesCr(n9, 3, 6, 5f);
        NotesCr(n10, 3, 3, 2f);
        Notes[] noteslist = { n1, n2, n3, n4, n5, n6, n7,n8,n9,n10};
        NotesList notes = new NotesList();
        notes.notes = noteslist;
        saveNotesData(notes);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void saveNotesData(NotesList player)
    {
        StreamWriter writer;

        string jsonstr = JsonUtility.ToJson(player);

        //writer = new StreamWriter(Application.dataPath + "/song"+SongControal.SongNumber+".json", false);
        writer = new StreamWriter(Application.streamingAssetsPath + "/song" + SongControal.SongNumber + "_difficulty" + SongControal.SongDifficulty + ".json", false);
        writer.Write(jsonstr);
        writer.Flush();
        writer.Close();
    }
    public void NotesCr(Notes notes,int type,int lane,float time)
    {
        notes.type = type;
        notes.lane = lane;
        notes.time = time;
    }
}
