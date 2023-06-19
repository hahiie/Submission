using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaderLange : MonoBehaviour
{
    int NowLevel = 1;
    public int ItemNumber;
    float LangeUP = 1.2f;
    Vector3 memo;
    Collider LangeCollider;
    // Update is called once per frame
    void Start()
    {
        Vector3 StartLange = IntControal.StartLanges[ItemNumber];
        gameObject.transform.localScale = StartLange;
        memo = IntControal.StartLanges[ItemNumber];
        LangeCollider = GetComponent<Collider>();
    }

    void Update()
    {
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
        EnemyInt enemy = collision.gameObject.GetComponent<EnemyInt>();
        if (enemy != null)
        {
            enemy.Rader = true;
        }
    }
    void OnTriggerExit(Collider collision)
    {
        EnemyInt enemy = collision.gameObject.GetComponent<EnemyInt>();
        if (enemy != null)
        {
            enemy.Rader = false;
        }
    }

}
