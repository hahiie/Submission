using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInt : MonoBehaviour
{
    ItemHeelControal Script;
    GameObject ItemHeelPanel;//�ʂ̃p�l��
    public float HP;
    int ItemNumber;
    public int CostInt;
    public GameObject ManeyLess;//����������Ȃ��Ƃ��ɕ\��
    bool IfHPless = false;//HP�������Ă�����true
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
        //HeelPanel��T��
        c = GameObject.FindWithTag("MainCamera");
        keyList = c.GetComponent<KeyList>();
    }

    // Update is called once per frame
    void Update()
    {

        //�f�o�b�O�p
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
        if (IfHPless==false)//HP��Max���猸������
        {
            GameObject g = keyList.RepairContent;
            Script = g.GetComponent<ItemHeelControal>();
            ItemHeelPanel = Script.ItemSet(this.gameObject);
            IfHPless = true;
        }
        if (HP <= 0)//HP�������Ȃ�����
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

    public void HPHeelToInfomation()//����ʂ���̏C��
    {
        if (IfHPless==true)
        {
            ItemHeel Heel = ItemHeelPanel.GetComponent<ItemHeel>();
            Heel.RepairButtonOn();
        }
    }
}
