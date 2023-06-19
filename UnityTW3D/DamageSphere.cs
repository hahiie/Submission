using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageSphere : MonoBehaviour
{
    public GameObject Bullet;
    int BulletNumber;
    int Delay = 0;
    public Vector3 ExLange;
    // Start is called before the first frame update
    void Start()
    {
        BulletDamage bulletDamage = Bullet.GetComponent<BulletDamage>();
        BulletNumber = bulletDamage.BulletNumber;
        ExLange = IntControal.MyBulletEx[BulletNumber];
        gameObject.transform.localScale = ExLange;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Delay == 1)
        {
            Destroy(gameObject);
            Destroy(Bullet);

        }
        Delay++;
    }
    void OnTriggerEnter(Collider collision)
    {
        EnemyInt HPScript = collision.gameObject.GetComponent<EnemyInt>();
        if (HPScript != null)
        {
            Vector3 kyori = collision.gameObject.transform.position - gameObject.transform.position;
            float gensui = ExLange.x -kyori.magnitude ;
            gensui = gensui / ExLange.x;
            HPScript.HP -= IntControal.MyBulletAttack[BulletNumber]*gensui;
            HPScript.NextHP -= IntControal.MyBulletAttack[BulletNumber]*gensui;
        }
    }
}
