
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreControal : MonoBehaviour
{
    //リザルト用スコアなど
    public static int conbo;
    public static int score;
    public static int miss;
    public static int good;
    public static int great;
    static int Maxconbo;//最高コンボ数
    public static int MaxNotes;//今の譜面のノーツ数
    //テキストポップ用
    static Text[] Text = new Text[3];//テキスト
    public Text[] TextIN = new Text[3];
    static GameObject Camvas;//親のキャンバス
    public GameObject CamvasIN;
    static Text Create;//作成したテキスト
    //作成位置のオブジェクト
    public GameObject[] LaneIN = new GameObject[8];
    static GameObject[] Lane = new GameObject[8];
    public Text ScoreText;//スコア表示テキスト

    static int[] MaxNotesScore = new int[] { 1000000, 3000000 };//最大スコア
    static int[] MaxConboScore = new int[] { 500000, 1000000 };//最大コンボスコア
    // Start is called before the first frame update
    void Start()
    {
        Text = TextIN;
        
        Camvas = CamvasIN;

        Lane = LaneIN;
        
        conbo = 0;
        score = 0;
        miss = 0;
        good = 0;
        great = 0;
    }

    // Update is called once per frame
    void Update()
    {
        ScoreText.text = "スコア：" + score.ToString("N0") + "\n\n" + "Great：" + great + "\n" + "Good：" + good + "\n" + "Miss：" + miss;
    }
    public static void ScoreCount(int lane,int TextType)
    {
        SongControal.NotesSound(TextType);
        if (TextType == 0)
        {
            conbo = 0;
            miss++;
            Create = Instantiate(Text[TextType],RectTransformUtility.WorldToScreenPoint(Camera.main,Lane[lane].transform.position), Quaternion.identity);//オブジェクト生成
            Create.transform.SetParent(Camvas.transform);
            Create.rectTransform.localScale = new Vector3(1f, 1f, 1f);
            Create.text = "MISS"+ "\n" + "0";
            
        }
        else
        {
            conbo++;
            if (Maxconbo < conbo)
            {
                Maxconbo = conbo;
            }
        }
        if (TextType == 1)
        {
            good++;
            Create = Instantiate(Text[TextType],RectTransformUtility.WorldToScreenPoint(Camera.main, Lane[lane].transform.position), Quaternion.identity);//オブジェクト生成
            Create.transform.SetParent(Camvas.transform);
            Create.rectTransform.localScale = new Vector3(1f, 1f, 1f);
            Create.text = "GOOD" + "\n" + conbo;
        }
        else if(TextType == 2)
        {
            great++;
            Create = Instantiate(Text[TextType], RectTransformUtility.WorldToScreenPoint(Camera.main, Lane[lane].transform.position), Quaternion.identity);//オブジェクト生成
            Create.transform.SetParent(Camvas.transform);
            Create.rectTransform.localScale = new Vector3(1f, 1f, 1f);
            Create.text = "GREAT" + "\n" + conbo;
        }
        /*
        Vector3 TraMemo = Create.rectTransform.anchoredPosition;
        if (TraMemo.x < 139)
        {
            TraMemo.x = 139;
            Create.rectTransform.anchoredPosition = TraMemo;
        }
        if (TraMemo.x > 640)
        {
            TraMemo.x = 640;
            Create.rectTransform.anchoredPosition = TraMemo;
        }*/

    }
    public static void scoreReset()
    {
        conbo = 0;
        score = 0;
        miss = 0;
        good = 0;
        great = 0;
    }
    public static void SongEND(int number,int differ)
    {
        int scoreN;//ノーツスコア
        int scoreC;//コンボスコア
        if (MaxNotes == great)
        {
            scoreN = MaxNotesScore[differ];
        }
        else
        {
            float NotesScoreMemo =  ((float)great + 0.6f * (float)good)/(float)MaxNotes;
            float scoref = (float)MaxNotesScore[differ] * NotesScoreMemo;
            scoreN = (int)scoref;
        }
        if (Maxconbo == MaxNotes)
        {
            scoreC = MaxConboScore[differ];
        }
        else
        {
            float scoref = (float)MaxConboScore[differ] * ((float)Maxconbo / (float)MaxNotes);
            scoreC = (int)scoref;
        }
        score = scoreN + scoreC;
        SaveData.ScoreSave(number, differ, score);//スコアセーブ
    }
}
