using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectObjControal : MonoBehaviour
{
    //移動量
    int bunshi = 1;//分子
    int bunbo = 1;//分母

    public GameObject BPMControal;
    BPMSet BPMS;

    public Text ueText;
    public Text shitaText;

    //ロングノーツ用
    static bool LongNotesmemo = false;
    static GameObject Long1;
    public GameObject PopObjectIn;
    static GameObject PopObject;
    // Start is called before the first frame update
    void Start()
    {
        BPMS = BPMControal.GetComponent<BPMSet>();
        PopObject = PopObjectIn;
    }

    // Update is called once per frame
    void Update()
    {
        ueText.text = bunshi.ToString();
        shitaText.text = bunbo.ToString();

        if (SentakuObj != null)//選択されたノーツに対する操作
        {
            NotesMove2 Script = SentakuObj.GetComponent<NotesMove2>();
            if (Input.GetKeyDown(KeyCode.W))
            {
                Script.GoalTime += (60f / (BPMS.BPM)) * ((float)bunshi / (float)bunbo);
            }
            if (Input.GetKeyDown(KeyCode.S))
            {
                Script.GoalTime -= (60f / (BPMS.BPM)) * ((float)bunshi / (float)bunbo);
            }
            if (Input.GetKey(KeyCode.E))
            {
                Script.GoalTime += (60f / (BPMS.BPM)) * 0.005f;
            }
            if (Input.GetKey(KeyCode.D))
            {
                Script.GoalTime -= (60f / (BPMS.BPM)) * 0.005f;
            }
            if (Script.GoalTime < 0)
            {
                Script.GoalTime = 0;
            }
            if (Script.GoalTime > SongControal2.Song.length)
            {
                Script.GoalTime = SongControal2.Song.length;
            }

            if (Input.GetKey(KeyCode.Backspace))//ノーツ削除
            {
                NotesControal.NotesDelete(SentakuObj);
                Destroy(SentakuObj);
                SentakuObj = null;
            }
        }
    }
    static GameObject SentakuObj;//選択中のオブジェクト
    public static void SentakuON(GameObject Obj)
    {
        if (LongNotesmemo == true && TipeControal.NotesTipe != 3)
        {
            LongNotesmemo = false;
        }
        if (SentakuObj != null)
        {
            NotesMove2 Script = SentakuObj.GetComponent<NotesMove2>();
            Script.sentakuONOFF();
        }
        else
        {
            LongNotesmemo = false;
        }
        SentakuObj = Obj;
        //ロングノーツの作成
        if (TipeControal.NotesTipe == 3)
        {
            if (LongNotesmemo == false)
            {
                LongNotesmemo = true;
                Long1 = SentakuObj;
            }
            else
            {
                NotesPop2 notesPop2 = PopObject.GetComponent<NotesPop2>();
                notesPop2.LongPop(Long1, SentakuObj);
                LongNotesmemo = false;
            }
        }
    }
    public static void SentakuOFF()
    {
        SentakuObj = null;
    }

    public void bunshiint(int i)
    {
        bunshi = bunshi + i;
        if (bunshi <= 0)
        {
            bunshi = 1;
        }
    }
    public void bunboint(int i)
    {
        bunbo = bunbo + i;
        if (bunbo <= 0)
        {
            bunbo = 1;
        }
    }
    public static void BPMTimeSet(float BPMTime)//BPMノーツをクリックしたとき
    {
        NotesMove2 Script = SentakuObj.GetComponent<NotesMove2>();
        Script.GoalTime = BPMTime;
    }
}
