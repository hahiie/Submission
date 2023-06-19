using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;//ファイルの保存・読み込み

public class NotesPop : MonoBehaviour
{
    public GameObject NotesType1Right;
    public GameObject NotesType1Left;
    public GameObject NotesType2Right;
    public GameObject NotesType2Left;
    static TextAsset jsonFile;
    public GameObject NotesType3;//ロングノーツ
    Transform cam;
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
    public GameObject[] StartGoal = new GameObject[16];//ノーツのゴールと沸き位置
    public GameObject[] LongPoint = new GameObject[20];
    public GameObject RightParent;
    public GameObject LeftParent;
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main.gameObject.transform;
        Pop();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void Pop()
    {
        /*ストリーミングアセットから読み込む(Andoroid非対応)
        string datastr = "";
        StreamReader reader;
        //reader = new StreamReader(Application.dataPath + "/song" + SongControal.SongNumber + ".json");
        reader = new StreamReader(Application.streamingAssetsPath + "/song" + SongControal.SongNumber + "_difficulty" + SongControal.SongDifficulty + ".json");
        datastr = reader.ReadToEnd();
        reader.Close();*/

        //リソースから読み込む
        string datastr = "";
        jsonFile = Resources.Load("song" + SongControal.SongNumber + "_difficulty" + SongControal.SongDifficulty) as TextAsset;              //指定したファイルをTextAssetとして読み込み(ファイル名の.csvは不要なことに注意)　最初の行（タイトル部分）も読み込まれるのでそこは使用しない
        StringReader reader = new StringReader(jsonFile.text);
        datastr = reader.ReadToEnd();
        reader.Close();

        NotesList noteslist = JsonUtility.FromJson<NotesList>(datastr);
        int i;
        ScoreControal.MaxNotes = noteslist.notes.Length;
        for (i = 0; i < noteslist.notes.Length; i++)
        {
            if (noteslist.notes[i].type == 1)//ノーマルノーツ
            {
                GameObject a;
                if (noteslist.notes[i].lane < 4)
                {
                    a = Instantiate(NotesType1Right);//オブジェクト生成
                    //a.transform.SetParent(cma);//カメラを親に
                    a.transform.SetParent(RightParent.transform);
                }
                else
                {
                    a = Instantiate(NotesType1Left);//オブジェクト生成
                    //a.transform.SetParent(cam);//カメラを親に
                    a.transform.SetParent(LeftParent.transform);
                }
                NotesMove notesMove = a.GetComponent<NotesMove>(); NomalNotes nomalNotes = a.GetComponent<NomalNotes>();//スクリプト参照
                notesMove.GoalTime = noteslist.notes[i].time; nomalNotes.GoalTime = noteslist.notes[i].time;
                notesMove.GoalObj = StartGoal[noteslist.notes[i].lane * 2];
                notesMove.StartObj = StartGoal[noteslist.notes[i].lane * 2 + 1];
                nomalNotes.lane = noteslist.notes[i].lane;
            }
            if (noteslist.notes[i].type == 2)//長押しOK
            {
                GameObject a;
                if (noteslist.notes[i].lane < 4)
                {
                    a = Instantiate(NotesType2Right);//オブジェクト生成
                    //a.transform.SetParent(cam);//カメラを親に
                    a.transform.SetParent(RightParent.transform);
                }
                else
                {
                    a = Instantiate(NotesType2Left);//オブジェクト生成
                    //a.transform.SetParent(cam);//カメラを親に
                    a.transform.SetParent(LeftParent.transform);
                }
                NotesMove notesMove = a.GetComponent<NotesMove>(); Type2Notes type2Notes = a.GetComponent<Type2Notes>();//スクリプト参照
                notesMove.GoalTime = noteslist.notes[i].time; type2Notes.GoalTime = noteslist.notes[i].time;
                notesMove.GoalObj = StartGoal[noteslist.notes[i].lane * 2];
                notesMove.StartObj = StartGoal[noteslist.notes[i].lane * 2 + 1];
                type2Notes.lane = noteslist.notes[i].lane;
            }

            if (noteslist.notes[i].type == 3)//ロングノーツ
            {
                GameObject a;
                a = Instantiate(NotesType3);//オブジェクト生成
                a.transform.position = new Vector3(0f, 0f, 0f);
                //a.transform.SetParent(cam);//カメラを親にしない

                LongNotes type3Notes = a.GetComponent<LongNotes>();//スクリプト参照
                type3Notes.GoalTime1 = noteslist.notes[noteslist.notes[i].lane].time;
                type3Notes.GoalTime2 = noteslist.notes[(int)noteslist.notes[i].time].time;

                type3Notes.lane1 = noteslist.notes[noteslist.notes[i].lane].lane;
                type3Notes.lane2 = noteslist.notes[(int)noteslist.notes[i].time].lane;
                if (noteslist.notes[noteslist.notes[i].lane].lane < 4)
                {
                    type3Notes.StartGoalObj[2] = LongPoint[noteslist.notes[noteslist.notes[i].lane].lane * 2];
                    type3Notes.StartGoalObj[3] = LongPoint[noteslist.notes[noteslist.notes[i].lane].lane * 2 + 2];
                    type3Notes.StartGoalObj[1] = LongPoint[noteslist.notes[noteslist.notes[i].lane].lane * 2 + 1];
                    type3Notes.StartGoalObj[0] = LongPoint[noteslist.notes[noteslist.notes[i].lane].lane * 2 + 3];
                }
                else
                {
                    type3Notes.StartGoalObj[2] = LongPoint[noteslist.notes[noteslist.notes[i].lane].lane * 2 + 2];
                    type3Notes.StartGoalObj[3] = LongPoint[noteslist.notes[noteslist.notes[i].lane].lane * 2 + 4];
                    type3Notes.StartGoalObj[1] = LongPoint[noteslist.notes[noteslist.notes[i].lane].lane * 2 + 3];
                    type3Notes.StartGoalObj[0] = LongPoint[noteslist.notes[noteslist.notes[i].lane].lane * 2 + 5];
                }
                if (noteslist.notes[(int)noteslist.notes[i].time].lane < 4)
                {
                    type3Notes.StartGoalObj[6] = LongPoint[noteslist.notes[(int)noteslist.notes[i].time].lane * 2];
                    type3Notes.StartGoalObj[7] = LongPoint[noteslist.notes[(int)noteslist.notes[i].time].lane * 2 + 2];
                    type3Notes.StartGoalObj[4] = LongPoint[noteslist.notes[(int)noteslist.notes[i].time].lane * 2 + 1];
                    type3Notes.StartGoalObj[5] = LongPoint[noteslist.notes[(int)noteslist.notes[i].time].lane * 2 + 3];
                    a.transform.SetParent(RightParent.transform, true);//テスト
                }
                else
                {
                    type3Notes.StartGoalObj[6] = LongPoint[noteslist.notes[(int)noteslist.notes[i].time].lane * 2 + 2];
                    type3Notes.StartGoalObj[7] = LongPoint[noteslist.notes[(int)noteslist.notes[i].time].lane * 2 + 4];
                    type3Notes.StartGoalObj[4] = LongPoint[noteslist.notes[(int)noteslist.notes[i].time].lane * 2 + 3];
                    type3Notes.StartGoalObj[5] = LongPoint[noteslist.notes[(int)noteslist.notes[i].time].lane * 2 + 5];
                    a.transform.SetParent(LeftParent.transform, true);//テスト
                }
            }
        }
    }
}
