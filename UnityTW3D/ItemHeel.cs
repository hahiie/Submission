using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemHeel : MonoBehaviour
{
    GameObject RepairItem;
    GameObject RepairControal;
    ItemHeelControal ToRemove;
    public Text Info;
    public Text RepairButton;
    ItemInt Script;
    int ItemNumber;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ItemNumber = Script.ItemNumberGet();
        Info.text = KeyList.CreateItem[ItemNumber];
        Info.text += "\n" + Script.CostInt.ToString() + "‰~";
    }
    public void ItemSet(GameObject a,GameObject b)//C—‚·‚éItem,HeelControal
    {
        RepairItem = a;
        Script = RepairItem.GetComponent<ItemInt>();
        RepairControal = b;
        ToRemove = b.GetComponent<ItemHeelControal>();
    }
    public void RepairButtonOn()
    {
        //C—
        bool ok = Script.HPHeel();

        //C—‚ª‚Å‚«‚½‚çi‚¨‹à‚ª‘«‚è‚½‚çj
        if (ok == true)
        {
            ToRemove.ItemRemove(this.gameObject);
            Destroy(this.gameObject);
        }
    }
}
