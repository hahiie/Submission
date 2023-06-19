using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 砲撃Bullet : MonoBehaviour
{
    GameObject target;
    public float BulletSpeed;
    Rigidbody rb;
    Rigidbody tgt;
    Vector3 kyori;
    bool flag = false;
    float bullettime;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (target != null&&flag==false)
        {
            rb = GetComponent<Rigidbody>();
            tgt = target.GetComponent<Rigidbody>();
            kyori = tgt.position - rb.position;
            bullettime = kyori.magnitude / (BulletSpeed*30) ;
            Vector3 memo = kyori;
            memo.y = 0;

            rb.AddForce(memo / bullettime, ForceMode.Impulse);
            rb.AddForce(Vector3.up * 9.8f * (bullettime/2), ForceMode.Impulse);
            rb.AddForce(Vector3.up * (kyori.y / bullettime), ForceMode.Impulse);

            flag = true;
        }
    }
    public void SetLook(GameObject a)
    {
        target = a;
        BulletDamage Script = GetComponent<BulletDamage>();
        Script.NextHPDown(target);
    }
}
