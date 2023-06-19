using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BulletBuyButton : MonoBehaviour
{
    public Text text;
    public int BulletNumber;

    // Update is called once per frame
    void Update()
    {
        text.text = KeyList.BulletName[BulletNumber];
        text.text += ":" + IntControal.NumberBullets[BulletNumber] + "ŒÂ";
    }
}
