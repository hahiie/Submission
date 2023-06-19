using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveandFire : MonoBehaviour
{
    public GameObject Me;
    Rigidbody Myrb;
    bool Fire = false;
    GameObject Base;
    int EnemyNumber;

    //Ç†ÇΩÇËîªíËä÷åW
    GameObject CrroseTarget;
    ItemInt itemInt;
    BaseInt baseInt;
    //çUåÇïpìx
    bool Delay=false;
    // Start is called before the first frame update
    void Start()
    {
        Myrb = Me.GetComponent<Rigidbody>();
        Base = GameObject.FindWithTag("MyBase");
        EnemyInt s = Me.GetComponent<EnemyInt>();
        EnemyNumber = s.EnemyNumber;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Fire == false)
        {
            Myrb.AddForce(transform.forward * 20000);
        }
        else
        {
            StartCoroutine("Attacks");
            if (CrroseTarget == null)
            {
                Fire = false;
            }
        }
        Vector3 Look = Base.transform.position -Me.transform.position;
        Look.y = Me.transform.position.y;
        Me.transform.LookAt(Look);
    }
    void OnTriggerStay(Collider collision)
    {
        if (CrroseTarget == null)
        {
            Fire = true;
            CrroseTarget = collision.gameObject;
            itemInt = CrroseTarget.GetComponent<ItemInt>();
            if (itemInt == null)
            {
                baseInt = CrroseTarget.GetComponent<BaseInt>();
            }
        }
    }
    IEnumerator Attacks()
    {
        if (Delay == false)
        {
            if (itemInt != null)
            {
                itemInt.HPDamege(IntControal.EnemyAttack[EnemyNumber]);
            }
            else
            {
                baseInt.HPDamege(IntControal.EnemyAttack[EnemyNumber]);
            }
            Delay = true;
            yield return new WaitForSeconds(1f);
            Delay = false;
        }
    }
}