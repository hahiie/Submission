using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SaveData : MonoBehaviour
{
    [System.Serializable]
    public class ScoreData
    {
        public int Score;
        public int SongDefficulty;
        public int SongNumber;
    }
    [System.Serializable]
    public class ScoreDataList
    {
        public ScoreData[] score;
    }
    // Start is called before the first frame update
    void Start()
    {

    }
    int i = 0;
    // Update is called once per frame
    void Update()
    {
        if (i == 0)
        {
            i = 2;
            ScoreSave(1,1,3200);
            Debug.Log("Save");
        }
    }
    public static void ScoreSave(int SongNumber,int SongDifficulty, int Score)//スコアを保存
    {
        //読み込み
        string datastr = "";
        StreamReader reader;
        reader = new StreamReader(GetWritableDirectoryPath() + "/ScoreSave/Score.json");
        datastr = reader.ReadToEnd();
        reader.Close();

        ScoreDataList scoreDataList = JsonUtility.FromJson<ScoreDataList>(datastr);
        bool DataGet = false;//セーブデータがあるかどうか
        int DataPoint = 0;//データがあった場所
        int i;
        if (scoreDataList != null)
        {
            for (i = 0; i < scoreDataList.score.Length; i++)
            {
                if (scoreDataList.score[i].SongDefficulty == SongDifficulty && scoreDataList.score[i].SongNumber == SongNumber)
                {
                    DataGet = true;
                    DataPoint = i;
                    break;
                }
            }
        }

        if (DataGet == true && scoreDataList.score[DataPoint].Score < Score)
        {

            //書き込み
            StreamWriter writer;
            scoreDataList.score[DataPoint].Score = Score;

            string jsonstr = JsonUtility.ToJson(scoreDataList);

            writer = new StreamWriter(GetWritableDirectoryPath() + "/ScoreSave/Score.json", false);
            writer.Write(jsonstr);
            writer.Flush();
            writer.Close();
        }
        if (DataGet == false)
        {
            ScoreData memo = new ScoreData();//保存するスコア
            memo.Score = Score;
            memo.SongDefficulty = SongDifficulty;
            memo.SongNumber = SongNumber;
            ScoreData[] scoreDatas = new ScoreData[1];
            if (scoreDataList != null)
            {
                scoreDatas = new ScoreData[scoreDataList.score.Length + 1];
                for (i = 0; i < scoreDataList.score.Length; i++)
                {
                    scoreDatas[i] = scoreDataList.score[i];
                }
                scoreDatas[scoreDataList.score.Length] = memo;
            }
            else
            {
                scoreDatas[0] = memo;
            }
            //書き込み
            ScoreDataList SaveList = new ScoreDataList();
            SaveList.score = scoreDatas;
            StreamWriter writer;

            string jsonstr = JsonUtility.ToJson(SaveList);

            writer = new StreamWriter(GetWritableDirectoryPath() + "/ScoreSave/Score.json", false);
            writer.Write(jsonstr);
            writer.Flush();
            writer.Close();
        }
        
    }
    public static string GetWritableDirectoryPath()//セーブ用のパスを返す
    {
        // Androidの場合、Application.persistentDataPathでは外部から読み出せる場所に保存されてしまうため
        // アプリをアンインストールしてもファイルが残ってしまう
        // ここではアプリ専用領域に保存するようにする
#if !UNITY_EDITOR && UNITY_ANDROID
        using (var unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer"))
        using (var currentActivity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity"))
        using (var getFilesDir = currentActivity.Call<AndroidJavaObject>("getFilesDir"))
        {
            return getFilesDir.Call<string>("getCanonicalPath");
        }
#else
        return Application.persistentDataPath;
#endif

    }
    public static void SaveFileCreate()//セーブファイルがなければ作成する(ゲーム開始時に実行)
    {
        if (!System.IO.Directory.Exists(GetWritableDirectoryPath() + "/ScoreSave"))
        {
            //ディレクトリ作成
            System.IO.Directory.CreateDirectory(GetWritableDirectoryPath() + "/ScoreSave");
            //ファイル作成
            System.IO.File.Create(GetWritableDirectoryPath() + "/ScoreSave/Score.json");
        }
    }
    public static int ScoreCall(int SongNumber,int SongDifficulty)//スコアを返す
    {
        //読み込み
        string datastr = "";
        StreamReader reader;
        reader = new StreamReader(GetWritableDirectoryPath() + "/ScoreSave/Score.json");
        datastr = reader.ReadToEnd();
        reader.Close();

        ScoreDataList scoreDataList = JsonUtility.FromJson<ScoreDataList>(datastr);
        bool DataGet = false;//セーブデータがあるかどうか
        int DataPoint = 0;//データがあった場所
        int i;
        if (scoreDataList != null)
        {
            for (i = 0; i < scoreDataList.score.Length; i++)
            {
                if (scoreDataList.score[i].SongDefficulty == SongDifficulty && scoreDataList.score[i].SongNumber == SongNumber)
                {
                    DataGet = true;
                    DataPoint = i;
                    break;
                }
            }
        }
        if (DataGet == true)
        {
            return scoreDataList.score[DataPoint].Score;
        }
        else
        {
            return 0;
        }
    }
}
