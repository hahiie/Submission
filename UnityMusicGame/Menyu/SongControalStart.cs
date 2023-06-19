using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SongControalStart : MonoBehaviour
{
    public static bool SongStart = false;
    public static float NotesSpeadControal = 4.0f;
    public static float NotesSpead;
    public static int SongNumber = -1;
    public static int SongDifficulty = -1;
    public static float NowTime;
    public AudioClip MISSIN;
    public AudioClip GOODIN;
    static AudioClip MISS;
    static AudioClip GOOD;
    static AudioClip SongIN;
    AudioSource audioSource;
    static AudioSource audioSourcest;
    bool memo = false;

    public static float HanteiTyousei1;//判定調整(ノーツの位置も変わる)
    public static float HanteiTyousei2;//判定調整(ノーツの位置は変わらない)

    public static float HanteiMS1;//ms単位の調整
    public static float HanteiMS2;//同上

    //public static string[] SongName = { "あの夏が飽和する" };//不要

    public static float SongLength;//曲の長さ

    public static bool AutoPlay = true;//オートプレイ
    float SongEnd;
    // Start is called before the first frame update
    void Start()
    {
        SongStart = false;
        NotesSpead = 80 / NotesSpeadControal;
        MISS = MISSIN;
        GOOD = GOODIN;
        HanteiTyousei1 = HanteiMS1 / 1000;
        HanteiTyousei2 = HanteiMS2 / 1000;
        NowTime = HanteiTyousei1;
        //SongSet(0,0,"あの夏が飽和する");//テスト用 後で消す
        audioSource = this.gameObject.GetComponent<AudioSource>();
        audioSource.clip = SongIN;
        audioSourcest = audioSource;
        SongLength = SongIN.length;

        SongEnd = SongLength;
    }

    // Update is called once per frame
    void Update()
    {
        if (SongStart == true)
        {
            NowTime += Time.deltaTime;
            if (memo == false)
            {
                audioSource.Play();
                memo = true;
            }
        }
        if (NowTime > SongEnd + HanteiTyousei1)//再生が終わったら
        {
            //NowTime = 0;
            audioSource.Play();
            SongEnd += SongLength;
        }
    }
    public static void SongSet(int songnumber, int songdifficulty, string songname)
    {
        SongNumber = songnumber;
        SongDifficulty = songdifficulty;
        //SongIN = Resources.Load<AudioClip>(SongName[SongNumber]);
        SongIN = Resources.Load<AudioClip>("Songs/" + songname);
    }
    public static void NotesSound(int i)
    {
        if (i == 0)
        {
            audioSourcest.PlayOneShot(MISS);
        }
        else
        {
            audioSourcest.PlayOneShot(GOOD);
        }

    }

    public static void stop()
    {
        SongStart = false;
        audioSourcest.Pause();
    }
    public void unstop()
    {
        SongStart = true;
        audioSourcest.UnPause();
    }
    public void restart()
    {
        memo = false;
        audioSourcest.Stop();
        ScoreControal.scoreReset();

    }
}
