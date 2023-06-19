using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntControal : MonoBehaviour
{
    public static bool Create;
    public static int Wave;
    public static int EnemyCount;//ƒQ[ƒ€ã‚É‘¶İ‚·‚é“G‚Ì”
    public static bool EnemyPopCompleta;//“G‚Ìƒ|ƒbƒv‚ªŠ®—¹‚µ‚Ä‚¢‚é‚©‚Ç‚¤‚©
    public static int EnemyKill;
    public static int Maney;
    public static bool[] ItemGet;//{İ‚ğŠJ•ú‚µ‚Ä‚¢‚é‚©‚Ç‚¤‚©
    public static List<Vector3> StartLanges = new List<Vector3>();//{İ‚Ì‰ŠúË’ö
    public static int[] LangeLevel;//{İ‚ÌË’öƒŒƒxƒ‹
    public static int[] NumberBullets;//{İ‚Ì’e–ò‚Ì”
    public static int[] BulletCost = new int[] { 1, 1, 0, 1 };
    public static float[] StartReLoad;//{İ‚ÌƒŠƒ[ƒhŠÔ
    public static float[] StartHP;//{İ‚ÌHP
    public static int[] StartCost;//{İ‚Ì’l’i
    //public static int[] HP_CostLevel;//HP‚Æ’l’i‚ÌƒŒƒxƒ‹
    public static int[] BulletHave;//ƒŠƒ[ƒh‚Ü‚Å‚É‘Å‚Ä‚é”
    public static float[] BulletHaveTime;//ƒŠƒ[ƒh‚ğ‹²‚Ü‚È‚¢˜AË‘¬“x
    public static float[] MyBulletAttack;//©•ª‚Ì’eŠÛ‚ÌUŒ‚—Í
    public static List<Vector3> MyBulletEx = new List<Vector3>();//©•ª‚Ì’eŠÛ‚Ì”š”­”ÍˆÍ
    public static float[] EnemyHP;//“G‚ÌHP
    public static float[] EnemyAttack;//“G‚ÌUŒ‚—Í
    public static List<Vector3> EnemyLange = new List<Vector3>();//“G‚ÌË’ö
    public static int[] EnemyManey;//“G‚ğ“|‚µ‚½‚Æ‚«‚Ì‚¨‹à
    public static int Createterramin = -20, Createterramax = 20;//Œš’z”ÍˆÍ
    void Start()
    {
        ItemGet = new bool[] { true, true, true, true };
        //‰ŠúË’ö‚Ì‘ã“ü
        StartLanges.Add(new Vector3(65.0f, 30.0f, 65.0f));
        StartLanges.Add(new Vector3(60.0f, 30.0f, 60.0f));
        StartLanges.Add(new Vector3(130f, 30f, 130f));
        StartLanges.Add(new Vector3(70.0f, 30.0f, 70.0f));
        //{İ‚ÌË’öƒŒƒxƒ‹‰Šú‰»
        LangeLevel = new int[] { 1, 1 ,1,1};
        //’e–ò‚Ì”‚Ì‰Šú‰»;
        NumberBullets = new int[] { 0, 0 ,0,0};
        //{İ‚Ì‰ŠúƒŠƒ[ƒhŠÔ
        StartReLoad = new float[] { 10f, 7f, 0, 5f };
        //{İ‚Ì‰ŠúHP
        StartHP = new float[] { 500f, 500f, 500f, 500f };
        //’l’i
        StartCost = new int[] { 100, 100, 100, 100 };
        //’l’i‚ÆHP‚ÌƒŒƒxƒ‹
        //HP_CostLevel = new int[] { 1, 1, 1, 1 };
        //ƒŠƒ[ƒh‚Ü‚Å‚É‘Å‚Ä‚é”
        BulletHave = new int[] { 1, 4, 0, 15 };
        //ƒŠƒ[ƒh‚ğ‹²‚Ü‚È‚¢˜AË‘¬“x(ŠÔ)
        BulletHaveTime = new float[] { 0, 0.5f, 0, 0.4f };
        //©•ª‚Ì’eŠÛ‚Ì‰ŠúUŒ‚—Í
        MyBulletAttack = new float[] { 300f, 100f, 0f, 50f };
        //©•ª‚Ì’eŠÛ‚Ì‰Šú”š”­”ÍˆÍ
        MyBulletEx.Add(new Vector3(11f, 11f, 11f));
        MyBulletEx.Add(new Vector3(7f, 7f, 7f));
        MyBulletEx.Add(new Vector3(0, 0, 0));
        MyBulletEx.Add(new Vector3(3f, 3f, 3f));

        //“GHP‚Ì‰Šú‰»
        EnemyHP = new float[] { 500f };
        //“GUŒ‚—Í‚Ì‰Šú‰»
        EnemyAttack = new float[] { 10f };
        //“G‚ÌË’ö‚Ì‰Šú‰»
        EnemyLange.Add(new Vector3(20f, 20f, 20f));
        //“G‚ğ“|‚µ‚½‚Æ‚«‚Ìæ“¾‹àŠz
        EnemyManey = new int[] { 100 };
        Create = true;
        Wave = 1;
        EnemyCount = 0;
        EnemyPopCompleta = false;
        EnemyKill = 0;
        Maney = 1000;
    }
    //©•ª‚ÌƒŠƒ[ƒh‘¬“x‹­‰»
    public static void ReLoadUP(int Bulletnumber)
    {
        float memo = StartReLoad[Bulletnumber];
        memo = memo * 0.9f;
        StartReLoad[Bulletnumber] = memo;
    }
    //©•ª‚ÌUŒ‚—Í‹­‰»
    public static void BulletAttackUP(int Bulletnumber)
    {
        float memo = MyBulletAttack[Bulletnumber];
        memo = memo * 1.2f;
        MyBulletAttack[Bulletnumber] = memo;
    }
    //©•ª‚Ì”š”­”ÍˆÍ‹­‰»
    public static void BulletExUP(int Bulletnumber)
    {
        Vector3 memo = MyBulletEx[Bulletnumber];
        memo.x = memo.x * 1.2f;
        memo.y = memo.y * 1.2f;
        memo.z = memo.z * 1.2f;
        MyBulletEx[Bulletnumber] = memo;
    }
    //“G‚ÌHP‹­‰»
    public static void EnemyHPUP(int Enemynumber)
    {
        float memo = EnemyHP[Enemynumber];
        memo = memo * 1.2f;
        EnemyHP[Enemynumber] = memo;
    }
}
