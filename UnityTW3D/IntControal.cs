using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntControal : MonoBehaviour
{
    public static bool Create;
    public static int Wave;
    public static int EnemyCount;//ゲーム上に存在する敵の数
    public static bool EnemyPopCompleta;//敵のポップが完了しているかどうか
    public static int EnemyKill;
    public static int Maney;
    public static bool[] ItemGet;//施設を開放しているかどうか
    public static List<Vector3> StartLanges = new List<Vector3>();//施設の初期射程
    public static int[] LangeLevel;//施設の射程レベル
    public static int[] NumberBullets;//施設の弾薬の数
    public static int[] BulletCost = new int[] { 1, 1, 0, 1 };
    public static float[] StartReLoad;//施設のリロード時間
    public static float[] StartHP;//施設のHP
    public static int[] StartCost;//施設の値段
    //public static int[] HP_CostLevel;//HPと値段のレベル
    public static int[] BulletHave;//リロードまでに打てる数
    public static float[] BulletHaveTime;//リロードを挟まない連射速度
    public static float[] MyBulletAttack;//自分の弾丸の攻撃力
    public static List<Vector3> MyBulletEx = new List<Vector3>();//自分の弾丸の爆発範囲
    public static float[] EnemyHP;//敵のHP
    public static float[] EnemyAttack;//敵の攻撃力
    public static List<Vector3> EnemyLange = new List<Vector3>();//敵の射程
    public static int[] EnemyManey;//敵を倒したときのお金
    public static int Createterramin = -20, Createterramax = 20;//建築範囲
    void Start()
    {
        ItemGet = new bool[] { true, true, true, true };
        //初期射程の代入
        StartLanges.Add(new Vector3(65.0f, 30.0f, 65.0f));
        StartLanges.Add(new Vector3(60.0f, 30.0f, 60.0f));
        StartLanges.Add(new Vector3(130f, 30f, 130f));
        StartLanges.Add(new Vector3(70.0f, 30.0f, 70.0f));
        //施設の射程レベル初期化
        LangeLevel = new int[] { 1, 1 ,1,1};
        //弾薬の数の初期化;
        NumberBullets = new int[] { 0, 0 ,0,0};
        //施設の初期リロード時間
        StartReLoad = new float[] { 10f, 7f, 0, 5f };
        //施設の初期HP
        StartHP = new float[] { 500f, 500f, 500f, 500f };
        //値段
        StartCost = new int[] { 100, 100, 100, 100 };
        //値段とHPのレベル
        //HP_CostLevel = new int[] { 1, 1, 1, 1 };
        //リロードまでに打てる数
        BulletHave = new int[] { 1, 4, 0, 15 };
        //リロードを挟まない連射速度(時間)
        BulletHaveTime = new float[] { 0, 0.5f, 0, 0.4f };
        //自分の弾丸の初期攻撃力
        MyBulletAttack = new float[] { 300f, 100f, 0f, 50f };
        //自分の弾丸の初期爆発範囲
        MyBulletEx.Add(new Vector3(11f, 11f, 11f));
        MyBulletEx.Add(new Vector3(7f, 7f, 7f));
        MyBulletEx.Add(new Vector3(0, 0, 0));
        MyBulletEx.Add(new Vector3(3f, 3f, 3f));

        //敵HPの初期化
        EnemyHP = new float[] { 500f };
        //敵攻撃力の初期化
        EnemyAttack = new float[] { 10f };
        //敵の射程の初期化
        EnemyLange.Add(new Vector3(20f, 20f, 20f));
        //敵を倒したときの取得金額
        EnemyManey = new int[] { 100 };
        Create = true;
        Wave = 1;
        EnemyCount = 0;
        EnemyPopCompleta = false;
        EnemyKill = 0;
        Maney = 1000;
    }
    //自分のリロード速度強化
    public static void ReLoadUP(int Bulletnumber)
    {
        float memo = StartReLoad[Bulletnumber];
        memo = memo * 0.9f;
        StartReLoad[Bulletnumber] = memo;
    }
    //自分の攻撃力強化
    public static void BulletAttackUP(int Bulletnumber)
    {
        float memo = MyBulletAttack[Bulletnumber];
        memo = memo * 1.2f;
        MyBulletAttack[Bulletnumber] = memo;
    }
    //自分の爆発範囲強化
    public static void BulletExUP(int Bulletnumber)
    {
        Vector3 memo = MyBulletEx[Bulletnumber];
        memo.x = memo.x * 1.2f;
        memo.y = memo.y * 1.2f;
        memo.z = memo.z * 1.2f;
        MyBulletEx[Bulletnumber] = memo;
    }
    //敵のHP強化
    public static void EnemyHPUP(int Enemynumber)
    {
        float memo = EnemyHP[Enemynumber];
        memo = memo * 1.2f;
        EnemyHP[Enemynumber] = memo;
    }
}
