using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KentikuButtonInfomation : MonoBehaviour
{
    public Text Myname;
    public Text HPetc;
    public int ItemNumber;

    // Update is called once per frame
    void Update()
    {
        Myname.text = KeyList.CreateItem[ItemNumber];
        HPetc.text = "HP�@�@�@  �@:" + IntControal.StartHP[ItemNumber].ToString("N1") + "\n";
        HPetc.text += "�U���́@�@�@:" + IntControal.MyBulletAttack[KeyList.UseBulletNumber[ItemNumber]].ToString("N1") + "\n";
        HPetc.text += "�����[�h����:" + IntControal.StartReLoad[ItemNumber].ToString("N1") + "�b\n";
        HPetc.text += "�A�ˑ��x�@�@:" + IntControal.BulletHaveTime[ItemNumber].ToString("N1") + "�b\n";
        HPetc.text += "���e���@�@�@:" + IntControal.BulletHave[ItemNumber].ToString() + "\n";
        HPetc.text += "�g�p�e��@�@:" + KeyList.BulletName[KeyList.UseBulletNumber[ItemNumber]] + "\n";
        HPetc.text += "���i�@�@�@�@:" + IntControal.StartCost[ItemNumber];
    }
    public void NumberSet(int a)
    {
        ItemNumber = a;
    }
}
