using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDamage : MonoBehaviour
{
    public int BulletNumber;
    public GameObject ExDamageSphere;//îöî≠É_ÉÅÅ[ÉWÇÃîÕàÕ
    public GameObject Look;
    EnemyInt HPScript2;
    Rigidbody rb;
    Collider BulletCollider;
    bool graund=false;
    bool damage = false;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        BulletCollider = GetComponent<Collider>();
        BulletCollider.enabled = false;
        if (rb.transform.position.y > 0)
        {
            graund = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (graund == false)
        {
            if (rb.transform.position.y > 2)
            {
                graund = true;
            }
        }
        else
        {
            BulletCollider.enabled = true;
        }
    }
    public void NextHPDown(GameObject a)
    {
        HPScript2 = a.GetComponent<EnemyInt>();
        HPScript2.NextHP -= IntControal.MyBulletAttack[BulletNumber] * 1.5f;
    }
    public void NextHPUp(GameObject a)
    {
        if (a != null)
        {

            HPScript2 = a.GetComponent<EnemyInt>();
            HPScript2.NextHP += IntControal.MyBulletAttack[BulletNumber] * 1.5f;
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        EnemyInt HPScript = collision.gameObject.GetComponent<EnemyInt>();
        ExDamageSphere.SetActive(true);
        if (HPScript != null)
        {
            HPScript.HP -= IntControal.MyBulletAttack[BulletNumber];
            HPScript.NextHP -= IntControal.MyBulletAttack[BulletNumber];
        }
        if (damage == false)
        {
            HPScript2.NextHP += IntControal.MyBulletAttack[BulletNumber] * 1.5f;
            damage = true;
        }
    }
}
