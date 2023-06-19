using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemInfomation : MonoBehaviour
{
    public Text Myname;
    public Text HPetc;
    public GameObject Item;
    ItemInt itemIntScript;
    public int ItemNumber;

    // Start is called before the first frame update
    void Start()
    {
        itemIntScript = Item.GetComponent<ItemInt>();
    }

    // Update is called once per frame
    void Update()
    {
        Myname.text = KeyList.CreateItem[ItemNumber];
        HPetc.text = "HP　　　  　:" + itemIntScript.HP.ToString("N1")+"/"+IntControal.StartHP[ItemNumber].ToString("N1") + "\n";
        HPetc.text += "攻撃力　　　:" + IntControal.MyBulletAttack[KeyList.UseBulletNumber[ItemNumber]].ToString("N1") + "\n";
        HPetc.text += "リロード時間:" + IntControal.StartReLoad[ItemNumber].ToString("N1") + "秒\n";
        HPetc.text += "連射速度　　:" + IntControal.BulletHaveTime[ItemNumber].ToString("N1") + "秒\n";
        HPetc.text += "装弾数　　　:" + IntControal.BulletHave[ItemNumber].ToString() + "\n";
        HPetc.text += "使用弾薬　　:" + KeyList.BulletName[KeyList.UseBulletNumber[ItemNumber]] + "\n";
    }
}
