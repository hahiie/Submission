using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntControal : MonoBehaviour
{
    public static bool Create;
    public static int Wave;
    public static int EnemyCount;//�Q�[����ɑ��݂���G�̐�
    public static bool EnemyPopCompleta;//�G�̃|�b�v���������Ă��邩�ǂ���
    public static int EnemyKill;
    public static int Maney;
    public static bool[] ItemGet;//�{�݂��J�����Ă��邩�ǂ���
    public static List<Vector3> StartLanges = new List<Vector3>();//�{�݂̏����˒�
    public static int[] LangeLevel;//�{�݂̎˒����x��
    public static int[] NumberBullets;//�{�݂̒e��̐�
    public static int[] BulletCost = new int[] { 1, 1, 0, 1 };
    public static float[] StartReLoad;//�{�݂̃����[�h����
    public static float[] StartHP;//�{�݂�HP
    public static int[] StartCost;//�{�݂̒l�i
    //public static int[] HP_CostLevel;//HP�ƒl�i�̃��x��
    public static int[] BulletHave;//�����[�h�܂łɑłĂ鐔
    public static float[] BulletHaveTime;//�����[�h�����܂Ȃ��A�ˑ��x
    public static float[] MyBulletAttack;//�����̒e�ۂ̍U����
    public static List<Vector3> MyBulletEx = new List<Vector3>();//�����̒e�ۂ̔����͈�
    public static float[] EnemyHP;//�G��HP
    public static float[] EnemyAttack;//�G�̍U����
    public static List<Vector3> EnemyLange = new List<Vector3>();//�G�̎˒�
    public static int[] EnemyManey;//�G��|�����Ƃ��̂���
    public static int Createterramin = -20, Createterramax = 20;//���z�͈�
    void Start()
    {
        ItemGet = new bool[] { true, true, true, true };
        //�����˒��̑��
        StartLanges.Add(new Vector3(65.0f, 30.0f, 65.0f));
        StartLanges.Add(new Vector3(60.0f, 30.0f, 60.0f));
        StartLanges.Add(new Vector3(130f, 30f, 130f));
        StartLanges.Add(new Vector3(70.0f, 30.0f, 70.0f));
        //�{�݂̎˒����x��������
        LangeLevel = new int[] { 1, 1 ,1,1};
        //�e��̐��̏�����;
        NumberBullets = new int[] { 0, 0 ,0,0};
        //�{�݂̏��������[�h����
        StartReLoad = new float[] { 10f, 7f, 0, 5f };
        //�{�݂̏���HP
        StartHP = new float[] { 500f, 500f, 500f, 500f };
        //�l�i
        StartCost = new int[] { 100, 100, 100, 100 };
        //�l�i��HP�̃��x��
        //HP_CostLevel = new int[] { 1, 1, 1, 1 };
        //�����[�h�܂łɑłĂ鐔
        BulletHave = new int[] { 1, 4, 0, 15 };
        //�����[�h�����܂Ȃ��A�ˑ��x(����)
        BulletHaveTime = new float[] { 0, 0.5f, 0, 0.4f };
        //�����̒e�ۂ̏����U����
        MyBulletAttack = new float[] { 300f, 100f, 0f, 50f };
        //�����̒e�ۂ̏��������͈�
        MyBulletEx.Add(new Vector3(11f, 11f, 11f));
        MyBulletEx.Add(new Vector3(7f, 7f, 7f));
        MyBulletEx.Add(new Vector3(0, 0, 0));
        MyBulletEx.Add(new Vector3(3f, 3f, 3f));

        //�GHP�̏�����
        EnemyHP = new float[] { 500f };
        //�G�U���͂̏�����
        EnemyAttack = new float[] { 10f };
        //�G�̎˒��̏�����
        EnemyLange.Add(new Vector3(20f, 20f, 20f));
        //�G��|�����Ƃ��̎擾���z
        EnemyManey = new int[] { 100 };
        Create = true;
        Wave = 1;
        EnemyCount = 0;
        EnemyPopCompleta = false;
        EnemyKill = 0;
        Maney = 1000;
    }
    //�����̃����[�h���x����
    public static void ReLoadUP(int Bulletnumber)
    {
        float memo = StartReLoad[Bulletnumber];
        memo = memo * 0.9f;
        StartReLoad[Bulletnumber] = memo;
    }
    //�����̍U���͋���
    public static void BulletAttackUP(int Bulletnumber)
    {
        float memo = MyBulletAttack[Bulletnumber];
        memo = memo * 1.2f;
        MyBulletAttack[Bulletnumber] = memo;
    }
    //�����̔����͈͋���
    public static void BulletExUP(int Bulletnumber)
    {
        Vector3 memo = MyBulletEx[Bulletnumber];
        memo.x = memo.x * 1.2f;
        memo.y = memo.y * 1.2f;
        memo.z = memo.z * 1.2f;
        MyBulletEx[Bulletnumber] = memo;
    }
    //�G��HP����
    public static void EnemyHPUP(int Enemynumber)
    {
        float memo = EnemyHP[Enemynumber];
        memo = memo * 1.2f;
        EnemyHP[Enemynumber] = memo;
    }
}
