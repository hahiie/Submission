using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LangeEnemy : MonoBehaviour
{
    public int EnemyNumber;
    // Start is called before the first frame update
    void Start()
    {
        Vector3 StartLange = IntControal.EnemyLange[EnemyNumber];
        gameObject.transform.localScale = StartLange;
    }
}
