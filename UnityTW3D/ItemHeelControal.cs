using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemHeelControal : MonoBehaviour
{
    public List<GameObject> HeelPanel = new List<GameObject>();
    public GameObject Panel;
    static ItemHeel itemHeel;
    public GameObject ParentPanel;
    GameObject Obj;//ŒÂ•Ê‚Ìƒpƒlƒ‹
    // Start is called before the first frame update
    void Start()
    {
        ParentPanel = this.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public GameObject ItemSet(GameObject a)
    {
        Obj = Instantiate(Panel);
        Obj.transform.SetParent(ParentPanel.transform);
        //Obj.transform.parent = ParentPanel.transform;
        itemHeel = Obj.GetComponent<ItemHeel>();
        itemHeel.ItemSet(a,this.gameObject);
        HeelPanel.Add(Obj);
        return Obj;
    }
    public void AllRepairButtonOn()
    {
        int i;
        int t = HeelPanel.Count;
        for (i = 0; i < t; i++)
        {
            ItemHeel Script = HeelPanel[0].GetComponent<ItemHeel>();
            Script.RepairButtonOn();
        }
    }

    public void ItemRemove(GameObject a)
    {
        HeelPanel.Remove(a);
    }

}
