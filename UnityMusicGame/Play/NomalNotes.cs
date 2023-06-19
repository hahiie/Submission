using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NomalNotes : MonoBehaviour
{
    public int lane;
    public float GoalTime;
    NotesMove notesMove;
    float inTime, missTime, goodTime, greatTime;
    public static bool OutoPlay = false;//オートプレイ
    bool nagaosi = false;//長押し無効
    // Start is called before the first frame update
    void Start()
    {
        notesMove = this.gameObject.GetComponent<NotesMove>();
        //判定の時間設定
        inTime = 0.2f;
        goodTime = 0.1f;
        greatTime = 0.05f;
    }

    // Update is called once per frame
    void Update()
    {
        if (SongControal.AutoPlay == false)//通常プレイ
        {
            float Time = GoalTime - (SongControal.NowTime + SongControal.HanteiTyousei2);
            if (Time < inTime)//時間差が0.3以内
            {
                bool memo = TouchLaneControal.InObj(this.gameObject, lane, GoalTime);
                if (memo == true)
                {
                    notesMove.sentou = true;
                }
                if (notesMove.sentou == true)//先頭だったら
                {
                    if (TouchLaneControal.Lane[lane] == false)
                    {
                        nagaosi = true;
                    }
                    if (TouchLaneControal.Lane[lane] == true && nagaosi == true)
                    {
                        if (Time > goodTime)//失敗
                        {
                            ScoreControal.ScoreCount(lane, 0);
                        }
                        else if (Time > greatTime)//good
                        {
                            ScoreControal.ScoreCount(lane, 1);
                        }
                        else if (Time > -greatTime)//great
                        {
                            ScoreControal.ScoreCount(lane, 2);
                        }
                        else if (Time > -goodTime)//good
                        {
                            ScoreControal.ScoreCount(lane, 1);
                        }
                        else
                        {
                            ScoreControal.ScoreCount(lane, 0);
                        }
                        TouchLaneControal.Noteslist[lane] = null;
                        this.gameObject.SetActive(false);
                    }
                }
            }
            if (Time < -goodTime)//失敗
            {
                ScoreControal.ScoreCount(lane, 0);
                TouchLaneControal.Noteslist[lane] = null;
                this.gameObject.SetActive(false);

            }
        }
        else
        {
            float Time = GoalTime - (SongControal.NowTime + SongControal.HanteiTyousei2);
            if (Time < 0)
            {
                ScoreControal.ScoreCount(lane, 2);
                TouchLaneControal.Noteslist[lane] = null;
                this.gameObject.SetActive(false);
            }
        }
    }
}
