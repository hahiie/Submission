using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public EnemyData data;
    float HP;
    // Start is called before the first frame update
    void Start()
    {
        HP = data.hp;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void HPDown(float attack)
    {
        HP -= attack;
        if (HP <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
