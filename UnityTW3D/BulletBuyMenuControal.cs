using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BulletBuyMenuControal : MonoBehaviour
{
    //�I���ƍw�����
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

    //�w����ʂł̏���
    int BuyBulletNumber;//�w���e����
    int NumberofBuy;//�w����
    int cost;
    public Text costtext;//�R�X�g�\��
    public Text NumberofBuytext;//���̕\��
    
    public void BuyNumberPurasu(int a)//�w����
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
    public void BuyButton()//�w��
    {
        if (cost <= IntControal.Maney)
        {
            IntControal.NumberBullets[BuyBulletNumber] += NumberofBuy;
            IntControal.Maney -= cost;
            SerectMenuChange();
        }
    }

}
