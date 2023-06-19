using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BPMSet : MonoBehaviour
{
    //BPM関連
    public float BPM;
    public float BPMStart;
    public Text BPMText;
    public Text BPMStartText;
    //曲の長さ用
    public AudioClip SongIN;
    //セット用パネル
    public GameObject Panel;
    bool NowPanel = false;
    public GameObject maincam;

    //BPMノーツ管理
    List<GameObject> BPMList = new List<GameObject>();
    public GameObject BPMNotes;
    int BPMNotesNum = 0;

    //BPMノーツスタートゴールオブジェクト
    public GameObject StartObj;
    public GameObject GoalObj;
    // Start is called before the first frame update
    void Start()
    {
        while(BPMStart+(60f/(BPM))*BPMNotesNum < SongIN.length)//スタート時間＋一拍分の時間
        {
            GameObject NotesP = Instantiate(BPMNotes);//オブジェクト生成
            NotesP.transform.SetParent(maincam.transform,false);//親の設定
            NotesMove2 move = NotesP.GetComponent<NotesMove2>();
            move.StartObj = StartObj;
            move.GoalObj = GoalObj;
            move.GoalTime = BPMStart + (60f / (BPM)) * BPMNotesNum;
            BPMList.Add(NotesP);
            BPMNotesNum++;
        }
    }

    // Update is called once per frame
    void Update()
    {
        BPMText.text = BPM.ToString(".000");
        BPMStartText.text = BPMStart.ToString(".000");
        //パネル
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(NowPanel == false)
            {
                NowPanel = true;
                Panel.SetActive(true);
            }
            else
            {
                NowPanel = false;
                Panel.SetActive(false);
            }
        }

    }
    public void BPMPluse(float i)//時間操作
    {
        BPM = BPM + i;
        BPMReload();
    }
    public void BPMStartPluse(float i)//時間操作
    {
        BPMStart = BPMStart + i;
        BPMReload();
    }

    void BPMReload()//時間操作対応
    {
        int i = 0;
        while (BPMStart + (60f / (BPM)) * i < SongIN.length)
        {
            if(i< BPMNotesNum)
            {
                NotesMove2 move = BPMList[i].GetComponent<NotesMove2>();
                move.GoalTime = BPMStart + (60f / (BPM)) * i;
                i++;
            }
            else
            {
                GameObject NotesP = Instantiate(BPMNotes);//オブジェクト生成
                NotesP.transform.SetParent(maincam.transform,false);//カメラを親に
                NotesMove2 move = NotesP.GetComponent<NotesMove2>();
                move.StartObj = StartObj;
                move.GoalObj = GoalObj;
                move.GoalTime = BPMStart + (60f / (BPM)) * i;
                BPMList.Add(NotesP);
                i++;
            }
        }

        if (i < BPMNotesNum)
        {
            for (int j = i; j < BPMNotesNum; j++)
            {
                Destroy(BPMList[i]);
                BPMList.RemoveAt(i);
            }
        }
        BPMNotesNum = i;
    }
}