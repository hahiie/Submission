using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IntText : MonoBehaviour
{
    public Text text;

    public Text Bullet0;
    public Text Bullet1;
    public Text Bullet3;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        text.text = "Kill:" + IntControal.EnemyKill.ToString() + "\nManey:" + IntControal.Maney.ToString()+"\nWave"+IntControal.Wave.ToString();

        Bullet0.text = KeyList.BulletName[0] + ":" + IntControal.NumberBullets[0];
        Bullet1.text = KeyList.BulletName[1] + ":" + IntControal.NumberBullets[1];
        Bullet3.text = KeyList.BulletName[3] + ":" + IntControal.NumberBullets[3];
    }
}
