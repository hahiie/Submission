using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lange2 : MonoBehaviour
{
    //リボルバー式のLange
    int NowLevel = 1;
    public int ItemNumber;
    float LangeUP = 1.2f;
    Vector3 memo;
    Collider LangeCollider;
    float ReLoadetime;
    int NumberofBullets;//装弾数
    float HaveTime;//連射速度
    public GameObject LaunchPoint;
    Rigidbody LaunchInfo;
    // Update is called once per frame
    void Start()
    {
        ReLoadetime = IntControal.StartReLoad[ItemNumber];
        NumberofBullets = IntControal.BulletHave[ItemNumber];
        HaveTime = IntControal.BulletHaveTime[ItemNumber];
        Vector3 StartLange = IntControal.StartLanges[ItemNumber];
        gameObject.transform.localScale = StartLange;
        memo = IntControal.StartLanges[ItemNumber];
        LangeCollider = GetComponent<Collider>();
        LaunchInfo = LaunchPoint.GetComponent<Rigidbody>();
    }

    void Update()
    {
        //ここからリドード関係
        if (ReLoadetime >= 0)
        {
            ReLoadetime -= Time.deltaTime;
        }
        else
        {
            if (NumberofBullets < IntControal.BulletHave[ItemNumber])
            {
                NumberofBullets++;
                ReLoadetime = IntControal.StartReLoad[ItemNumber];
            }
        }
        if (HaveTime >= 0)
        {
            HaveTime -= Time.deltaTime;
        }
        //ここから射程関係
        while (NowLevel != IntControal.LangeLevel[ItemNumber])
        {
            memo = memo * LangeUP;
            gameObject.transform.localScale = memo;
            NowLevel++;
        }
        if (IntControal.Create == true)
        {
            LangeCollider.enabled = false;
        }
        else
        {
            LangeCollider.enabled = true;
        }
    }
    void OnTriggerStay(Collider collision)
    {
        EnemyInt Hit = collision.gameObject.GetComponent<EnemyInt>();
        if (Hit != null)
        {
            if (KeyList.tekisei[ItemNumber] == 3 || (KeyList.tekisei[ItemNumber] == 2 && collision.gameObject.tag == "EnemyA") || (KeyList.tekisei[ItemNumber] == 1 && collision.gameObject.tag == "EnemyG"))
            {
                if (Hit.NextHP > 0)
                {
                    if (HaveTime < 0 && NumberofBullets > 0)
                    {
                        if (IntControal.NumberBullets[KeyList.UseBulletNumber[ItemNumber]] > 0)
                        {
                            IntControal.NumberBullets[KeyList.UseBulletNumber[ItemNumber]]--;
                            GameObject Bullet = Instantiate(KeyList.PrefabList[ItemNumber], LaunchInfo.transform.position, LaunchInfo.transform.rotation);
                            AAMmove BulletScript = Bullet.GetComponent<AAMmove>();
                            if (BulletScript != null)
                            {
                                BulletScript.SetLook(collision.gameObject);
                            }
                            砲撃Bullet BulletScript2 = Bullet.GetComponent<砲撃Bullet>();
                            if (BulletScript2 != null)
                            {
                                BulletScript2.SetLook(collision.gameObject);
                            }
                            HaveTime = IntControal.BulletHaveTime[ItemNumber];
                            NumberofBullets--;
                        }
                    }
                }
            }
        }
    }
}
