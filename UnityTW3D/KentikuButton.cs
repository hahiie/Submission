using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class KentikuButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public int ItemNumber;
    public Text text;
    public GameObject Maney;
    public GameObject Info;
    KentikuButtonInfomation InfoSet;
    // Start is called before the first frame update
    void Start()
    {
        if (IntControal.ItemGet[ItemNumber] == false)
        {
            this.gameObject.SetActive(false);
        }
        InfoSet = Info.GetComponent<KentikuButtonInfomation>();
        text.text = KeyList.CreateItem[ItemNumber];
    }

    // Update is called once per frame
    public void Kousinn()
    {
        if (IntControal.ItemGet[ItemNumber] == true)
        {
            this.gameObject.SetActive(true);
        }
    }

    public void OnPointerEnter(PointerEventData pointerEventData)
    {
        InfoSet.NumberSet(ItemNumber);
        Info.SetActive(true);
    }
    public void OnPointerExit(PointerEventData pointerEventData)
    {
        Info.SetActive(false);
    }
}
