using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Type2Notes : MonoBehaviour
{
    //黄色ノーツ
    public int lane;
    public float GoalTime;
    NotesMove notesMove;
    float missTime, goodTime, greatTime;
    // Start is called before the first frame update
    void Start()
    {
        notesMove = this.gameObject.GetComponent<NotesMove>();
        //判定の時間設定
        goodTime = 0.1f;
        greatTime = 0.05f;
    }

    // Update is called once per frame
    void Update()
    {
        if (SongControal.AutoPlay==false)
        {
            float Time = GoalTime - (SongControal.NowTime + SongControal.HanteiTyousei2);
            if (Time < 0.3)//時間差が0.3以内(先頭かどうかの判定のため0でなく0.3)
            {
                bool memo = TouchLaneControal.InObj(this.gameObject, lane, GoalTime);
                if (memo == true)
                {
                    notesMove.sentou = true;
                }
                if (notesMove.sentou == true)//先頭だったら
                {
                    if (TouchLaneControal.Lane[lane] == true && Time < 0)//レーンを押している　かつ　時間差が0以下
                    {
                        if (Time > -greatTime)//great
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
