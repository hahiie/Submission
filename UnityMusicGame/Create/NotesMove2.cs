using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotesMove2 : MonoBehaviour
{
    public GameObject StartObj;
    public GameObject GoalObj;
    public float GoalTime;
    float spead;

    bool sentaku = false;//選択中かどうか

    public Material Notes1;//ノーマルノーツマテリアル
    public Material Notes2;//長押しノーツマテリアル
    public Material SentakuMat;//選択中マテリアル

    public int NotesTipe;//4がBPM
    public int lane;//レーン



    // Start is called before the first frame update
    void Start()
    {
        spead = SongControal2.NotesSpead;
        Color memo;
        memo = Notes1.color;
        memo.a = 0.3f;
        Notes1.color = memo;
        memo = Notes2.color;
        memo.a = 0.3f;
        Notes2.color = memo;
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = (1 - ((SongControal2.NowTime - GoalTime + spead) / spead)) * StartObj.transform.position + ((SongControal2.NowTime - GoalTime + spead) / spead) * GoalObj.transform.position;
    }

    public void sentakuONOFF()//オブジェクトの選択状態を切り替える
    {
        if (NotesTipe != 4)
        {
            if (sentaku == false)
            {
                sentaku = true;
                this.GetComponent<Renderer>().material = SentakuMat;
                SelectObjControal.SentakuON(this.gameObject);
            }
            else
            {
                sentaku = false;
                if (NotesTipe == 1)
                {
                    this.GetComponent<Renderer>().material = Notes1;
                }
                else if (NotesTipe == 2)
                {
                    this.GetComponent<Renderer>().material = Notes2;
                }
                SelectObjControal.SentakuOFF();
            }
        }
    }
    public void BPMClick()
    {
        if (NotesTipe == 4)
        {
            SelectObjControal.BPMTimeSet(GoalTime);
        }
    }
}
