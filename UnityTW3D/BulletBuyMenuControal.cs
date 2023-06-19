using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BulletBuyMenuControal : MonoBehaviour
{
    //‘I‘ğ‚Æw“ü‰æ–Ê
    public GameObject SerectMenu;
    public GameObject BuyMenu;
    public void BuyMenuChange(int BulletNumber)
    {
        SerectMenu.SetActive(false);
        BuyMenu.SetActive(true);
        BuyBulletNumber = BulletNumber;
        NumberofBuy = 0;
        BuyNumberPurasu(0);
    }
    public void SerectMenuChange()
    {
        SerectMenu.SetActive(true);
        BuyMenu.SetActive(false);
    }

    //w“ü‰æ–Ê‚Å‚Ìˆ—
    int BuyBulletNumber;//w“ü’e–òí—Ş
    int NumberofBuy;//w“üŒÂ”
    int cost;
    public Text costtext;//ƒRƒXƒg•\¦
    public Text NumberofBuytext;//ŒÂ”‚Ì•\¦
    
    public void BuyNumberPurasu(int a)//w“üŒÂ”
    {
        NumberofBuy += a;
        if (NumberofBuy < 0)
        {
            NumberofBuy = 0;
        }
        cost = IntControal.BulletCost[BuyBulletNumber] * NumberofBuy;
        costtext.text = "Maney" + cost.ToString();
        NumberofBuytext.text = NumberofBuy.ToString();
    }
    public void BuyButton()//w“ü
    {
        if (cost <= IntControal.Maney)
        {
            IntControal.NumberBullets[BuyBulletNumber] += NumberofBuy;
            IntControal.Maney -= cost;
            SerectMenuChange();
        }
    }

}
