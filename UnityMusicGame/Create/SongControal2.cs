using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class SongControal2 : MonoBehaviour
{
    public static bool SongStart = false;//再生中かどうか
    public static float NotesSpeadControal = 4f;//ノーツスピード(数字が大きいほど早い)
    public static float NotesSpead = 80 / NotesSpeadControal;//ノーツスピード(内部処理用/数字が小さいほど早い)
    public static int SongNumber;//曲の番号
    public static int SongDifficulty;//曲の難易度
    public static float NowTime;//音楽の再生時間
    public int SongNumberIN;
    public int SongDifficultyIN;

    public AudioClip SongIN;
    public static AudioClip Song;
    AudioSource audioSource;
    static AudioSource audioSourcest;

    public Text TimeText;//時間表示用テキスト


    //public static string[] SongName = { "あの夏が飽和する" };//曲の名前のリスト
    // Start is called before the first frame update
    void Start()
    {
        Song = SongIN;
        SongNumber = SongNumberIN;
        SongDifficulty = SongDifficultyIN;
        NotesSpead = 80 / NotesSpeadControal;
        NowTime = 0;
        audioSource = this.gameObject.GetComponent<AudioSource>();
        audioSource.clip = SongIN;
        audioSourcest = audioSource;
        audioSource.Play();
        stop();
    }

    // Update is called once per frame
    void Update()
    {
        if (SongStart == true)
        {
            NowTime += Time.deltaTime;
        }

        //Spaceで再生、停止
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(SongStart == true)
            {
                stop();
            }else
            {
                unstop();
            }

        }

        if (NowTime > SongIN.length)//再生が終わったら
        {
            SongStart = false;
            NowTime = SongIN.length;
        }

        //時間表示
        TimeText.text = NowTime.ToString(".000");
    }

    public static void stop()
    {
        SongStart = false;
        audioSourcest.Pause();
    }
    public void unstop()
    {
        SongStart = true;
        audioSourcest.time = NowTime;//今の時間を代入
        audioSourcest.UnPause();
        audioSource.Play();
    }

    public void TimePluseInt(int i)//時間操作
    {
        if (SongStart == false)
        {
            NowTime = NowTime + i;
            if (NowTime < 0)
            {
                NowTime = 0;
            }
        }
    }
}
