using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotesPop2 : MonoBehaviour
{
    Transform cam;
    public GameObject Right;
    public GameObject Left;
    public GameObject parent;
    public GameObject LongNotes;
    public GameObject[] StartGoal = new GameObject[16];//ノーツのゴールと沸き位置
    public GameObject[] LongPoint = new GameObject[20];
    // Start is called before the first frame update
    void Start()
    {
        cam = parent.transform;
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void Pop(int Lane)//画面上で作成
    {
        if (Input.GetKey(KeyCode.LeftShift)&& TipeControal.NotesTipe != 3)//シフトを押しているとき且つロングノーツでない
        {
            GameObject a;
            if (Lane < 4)
            {
                a = Instantiate(Right);//オブジェクト生成
                a.transform.SetParent(cam,false);//カメラを親に
            }
            else
            {
                a = Instantiate(Left);//オブジェクト生成
                a.transform.SetParent(cam,false);//カメラを親に
            }
            NotesMove2 notesMove = a.GetComponent<NotesMove2>();//スクリプト参照
            notesMove.GoalTime = SongControal2.NowTime;
            notesMove.GoalObj = StartGoal[Lane * 2];
            notesMove.StartObj = StartGoal[Lane * 2 + 1];
            notesMove.lane = Lane;
            notesMove.NotesTipe = TipeControal.NotesTipe;
            notesMove.sentakuONOFF();//ノーツを選択状態へ
            NotesControal.NotesON(a);//ノーツをリストで管理
        }
    }
    public void LongPop(GameObject obj1,GameObject obj2)//ロングノーツ
    {
        NotesMove2 Script1 = obj1.GetComponent<NotesMove2>();
        NotesMove2 Script2 = obj2.GetComponent<NotesMove2>();
        GameObject a;
        a = Instantiate(LongNotes);//オブジェクト生成
        //a.transform.SetParent(cam,false);//カメラを親に
        NotesControal.NotesON(a);//ノーツをリストで管理
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
