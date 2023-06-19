using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class NotesControal : MonoBehaviour
{
    Transform cam;
    public GameObject Right;
    public GameObject Left;
    public GameObject parent;
    public GameObject LongNotes;
    public GameObject[] StartGoal = new GameObject[16];//ノーツのゴールと沸き位置
    public GameObject[] LongPoint = new GameObject[20];
    //作成ノーツ管理
    static List<GameObject> NotesList = new List<GameObject>();
    static int NotesNum = 0;//ノーツの数

    [System.Serializable]
    public class NotesMember
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
        cam = parent.transform;
        NotesNum = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public static void NotesON(GameObject Notes)
    {
        NotesList.Add(Notes);
        NotesNum++;
    }
    public static void NotesDelete(GameObject Notes)
    {
        NotesList.Remove(Notes);
        NotesNum--;
    }
    public void NotesSave()
    {
        Notes[] player = new Notes[NotesNum];
        for (int i = 0; i < NotesNum; i++)
        {
            NotesMove2 MoveS = NotesList[i].GetComponent<NotesMove2>();
            if (MoveS == null)
            {
                LongNotes2 LongS = NotesList[i].GetComponent<LongNotes2>();
                Notes notesmemo = new Notes();
                int o1 = NotesList.IndexOf(LongS.Object1);
                int o2 = NotesList.IndexOf(LongS.Object2);
                float of2 = (float)o2;
                NotesCr(notesmemo,3, o1, of2);
                Debug.Log(i +","+notesmemo.type+","+notesmemo.lane+","+notesmemo.time);
                player[i] = notesmemo;
            }
            else
            {
                Notes notes = new Notes();
                NotesCr(notes,MoveS.NotesTipe, MoveS.lane, MoveS.GoalTime);
                Debug.Log(i + "," + notes.type + "," + notes.lane + "," + notes.time);
                player[i] = notes;
            }
        }
        NotesMember notesmember = new NotesMember();
        notesmember.notes = player;


        StreamWriter writer;

        Debug.Log(notesmember.notes[0].type + "," + notesmember.notes[1].type + "," + notesmember.notes[2].type);
        string jsonstr = JsonUtility.ToJson(notesmember);

        //writer = new StreamWriter(Application.dataPath + "/song"+SongControal.SongNumber+".json", false);
        writer = new StreamWriter(Application.streamingAssetsPath + "/song" + SongControal2.SongNumber + "_difficulty" + SongControal2.SongDifficulty + ".json", false);
        writer.Write(jsonstr);
        writer.Flush();
        writer.Close();
    }
    public void NotesLoad()
    {
        string datastr = "";
        StreamReader reader;
        //reader = new StreamReader(Application.dataPath + "/song" + SongControal.SongNumber + ".json");
        reader = new StreamReader(Application.streamingAssetsPath + "/song" + SongControal2.SongNumber + "_difficulty" + SongControal2.SongDifficulty + ".json");
        datastr = reader.ReadToEnd();
        reader.Close();


        NotesMember noteslist = JsonUtility.FromJson<NotesMember>(datastr);
        int i;
        for (i = 0; i < noteslist.notes.Length; i++)
        {
            Debug.Log(i + "," + noteslist.notes.Length);
            if (noteslist.notes[i].type != 3)
            {
                Pop(noteslist.notes[i].type, noteslist.notes[i].lane, noteslist.notes[i].time);
            }
            else
            {
                int obj1 = noteslist.notes[i].lane;
                float obj2memo = noteslist.notes[i].time;
                int obj2 = (int)obj2memo;
                LongPop(NotesList[obj1], NotesList[obj2]);
            }
        }
    }
    public static void NotesCr(Notes notes, int type, int lane, float time)
    {
        notes.type = type;
        notes.lane = lane;
        notes.time = time;
    }

    public void Pop(int Type, int Lane, float GoalTime)//セーブデータからノーツ作成
    {
        GameObject a;
        if (Lane < 4)
        {
            a = Instantiate(Right);//オブジェクト生成
            a.transform.SetParent(cam, false);//カメラを親に
        }
        else
        {
            a = Instantiate(Left);//オブジェクト生成
            a.transform.SetParent(cam, false);//カメラを親に
        }
        NotesMove2 notesMove = a.GetComponent<NotesMove2>();//スクリプト参照
        notesMove.GoalTime = GoalTime;
        notesMove.GoalObj = StartGoal[Lane * 2];
        notesMove.StartObj = StartGoal[Lane * 2 + 1];
        notesMove.lane = Lane;
        notesMove.NotesTipe = Type;
        notesMove.sentakuONOFF();//ノーツを選択状態へ
        NotesON(a);//ノーツをリストで管理
        notesMove.sentakuONOFF();

    }
    public void LongPop(GameObject obj1, GameObject obj2)//セーブデータからロングノーツ
    {
        NotesMove2 Script1 = obj1.GetComponent<NotesMove2>();
        NotesMove2 Script2 = obj2.GetComponent<NotesMove2>();
        GameObject a;
        a = Instantiate(LongNotes);//オブジェクト生成
        //a.transform.SetParent(cam,false);//カメラを親に
        NotesON(a);//ノーツをリストで管理
        LongNotes2 type3Notes = a.GetComponent<LongNotes2>();//スクリプト参照
        type3Notes.Object1 = obj1;
        type3Notes.Object2 = obj2;

        if (Script1.lane < 4)
        {
            type3Notes.StartGoalObj[2] = LongPoint[Script1.lane * 2];
            type3Notes.StartGoalObj[3] = LongPoint[Script1.lane * 2 + 2];
            type3Notes.StartGoalObj[1] = LongPoint[Script1.lane * 2 + 1];
            type3Notes.StartGoalObj[0] = LongPoint[Script1.lane * 2 + 3];
        }
        else
        {
            type3Notes.StartGoalObj[2] = LongPoint[Script1.lane * 2 + 2];
            type3Notes.StartGoalObj[3] = LongPoint[Script1.lane * 2 + 4];
            type3Notes.StartGoalObj[1] = LongPoint[Script1.lane * 2 + 3];
            type3Notes.StartGoalObj[0] = LongPoint[Script1.lane * 2 + 5];
        }
        if (Script2.lane < 4)
        {
            type3Notes.StartGoalObj[6] = LongPoint[Script2.lane * 2];
            type3Notes.StartGoalObj[7] = LongPoint[Script2.lane * 2 + 2];
            type3Notes.StartGoalObj[4] = LongPoint[Script2.lane * 2 + 1];
            type3Notes.StartGoalObj[5] = LongPoint[Script2.lane * 2 + 3];
        }
        else
        {
            type3Notes.StartGoalObj[6] = LongPoint[Script2.lane * 2 + 2];
            type3Notes.StartGoalObj[7] = LongPoint[Script2.lane * 2 + 4];
            type3Notes.StartGoalObj[4] = LongPoint[Script2.lane * 2 + 3];
            type3Notes.StartGoalObj[5] = LongPoint[Script2.lane * 2 + 5];
        }
    }
}
