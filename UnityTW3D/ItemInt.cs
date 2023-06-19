using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInt : MonoBehaviour
{
    ItemHeelControal Script;
    GameObject ItemHeelPanel;//個別のパネル
    public float HP;
    int ItemNumber;
    public int CostInt;
    public GameObject ManeyLess;//お金が足りないときに表示
    bool IfHPless = false;//HPが減っていたらtrue
    GameObject c;
    KeyList keyList;
    // Start is called before the first frame update
    void Start()
    {
        ItemInfomation a = this.gameObject.GetComponent<ItemInfomation>();
        ItemNumber = a.ItemNumber;
        HP = IntControal.StartHP[ItemNumber];

        float HeelPercent = 1 - (HP / IntControal.StartHP[ItemNumber]);
        float Cost = (IntControal.StartHP[ItemNumber] * HeelPercent) * 0.7f;
        CostInt = (int)Cost;
        //HeelPanelを探す
        c = GameObject.FindWithTag("MainCamera");
        keyList = c.GetComponent<KeyList>();
    }

    // Update is called once per frame
    void Update()
    {

        //デバッグ用
        if (Input.GetKey(KeyCode.T))
        {
            HPDamege(1f);
        }
    }
    public void HPDamege(float Damege)
    {
        HP -= Damege;
        float HeelPercent = 1 - (HP / IntControal.StartHP[ItemNumber]);
        float Cost = (IntControal.StartHP[ItemNumber] * HeelPercent) * 0.7f;
        CostInt = (int)Cost;
        if (IfHPless==false)//HPがMaxから減ったら
        {
            GameObject g = keyList.RepairContent;
            Script = g.GetComponent<ItemHeelControal>();
            ItemHeelPanel = Script.ItemSet(this.gameObject);
            IfHPless = true;
        }
        if (HP <= 0)//HPが無くなったら
        {
            Cost = 0;
            CostInt = 0;
            HPHeelToInfomation();
            ItemKentiku itemKentiku = this.gameObject.GetComponent<ItemKentiku>();
            if (itemKentiku.info == true)
            {
                KeyList.infomationhyouzi = false;
                MenuControal.MenuBack();
            }
            Destroy(this.gameObject);
        }
    }
    public bool HPHeel()
    {
        if (CostInt <= IntControal.Maney)
        {
            IntControal.Maney -= CostInt;
            HP = IntControal.StartHP[ItemNumber];
            IfHPless = false;
            return true;
        }
        else
        {
            return false;
        }
    }
    public int ItemNumberGet()
    {
        return ItemNumber;
    }

    public void HPHeelToInfomation()//情報画面からの修理
    {
        if (IfHPless==true)
        {
            ItemHeel Heel = ItemHeelPanel.GetComponent<ItemHeel>();
            Heel.RepairButtonOn();
        }
    }
}
