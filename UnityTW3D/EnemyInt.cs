using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInt : MonoBehaviour
{
    public int EnemyNumber;
    public float HP;
    public float NextHP;
    public bool Rader;
    float MaxHP;
    public GameObject colormaterial;
    // Start is called before the first frame update
    void Start()
    {
        //HP�֌W
        HP = IntControal.EnemyHP[EnemyNumber];
        NextHP = HP;
        //�F�֘A
        MaxHP = HP;
        colormaterial.GetComponent<Renderer>().material.color = new Color32(255, 0, 0, 255);
    }

    // Update is called once per frame
    void Update()
    {
        if (HP <= 0)
        {
            Destroy(gameObject);
            IntControal.EnemyCount--;
            IntControal.EnemyKill++;
            IntControal.Maney+=IntControal.EnemyManey[EnemyNumber];
        }
        //�F�֘A
        float rgb = (HP / MaxHP);
        rgb = 1-rgb;
        colormaterial.GetComponent<Renderer>().material.color = new Color(1f, rgb, rgb, 1f);
    }
}
