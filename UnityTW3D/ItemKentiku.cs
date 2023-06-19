using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemKentiku : MonoBehaviour, IPointerClickHandler
{
    bool setItem = false;//設置が完了しているか
    int HitItemNumber = 0;
    public GameObject kyohi;
    public GameObject kakuninn;
    public GameObject infometion;
    float times;
    bool kyohihyouzi = false;
    GameObject kentiku;
    MoveRay Ray;
    public bool info = false;
    // Start is called before the first frame update
    void Start()
    {
        kentiku = Camera.main.gameObject;
        Ray = kentiku.GetComponent<MoveRay>();
    }

    // Update is called once per frame
    void Update()
    {
        if (times < 2)
        {
            times += Time.deltaTime;
        }
        else if (kyohihyouzi == true)
        {
            kyohi.SetActive(false);
            kyohihyouzi = false;
        }
        if (Input.GetKey(KeyCode.Escape))
        {
            if (info==true)
            {
                infometion.SetActive(false);
                KeyList.infomationhyouzi = false;
                MenuControal.MenuBack();
                info = false;
            }
        }
        
    }

    void OnCollisionEnter(Collision collision)
    {
        if (setItem == false)
        {
            HitItemNumber++;
        }
    }
    void OnCollisionExit(Collision collision)
    {
        if (setItem == false)
        {
            HitItemNumber--;
        }
    }
    public void menuHyouzi()
    {
        if (HitItemNumber == 0)
        {
            kakuninn.SetActive(true);
        }
        else
        {
            kyohi.SetActive(true);
            times = 0;
            kyohihyouzi = true;
            Ray.remove();
        }
    }
    public void kakuninnYes()//設置
    {
        kakuninn.SetActive(false);
        Ray.Backmenu();
        Ray.reset();
        setItem = true;
    }
    public void kakuninnNo()
    {
        kakuninn.SetActive(false);
        Ray.remove();
    }
    /*void OnMouseOver()
    {
        Onmouse = true;
    }
    void OnMouseExit()
    {
        Onmouse = false;
    }*/
    //クリックで情報の表示
    public void OnPointerClick(PointerEventData eventData)
    {
        if (KeyList.infomationhyouzi == false && setItem == true && Ray.Infomation==false)
        {
            infometion.SetActive(true);
            KeyList.infomationhyouzi = true;
            MenuControal.MenuChenge(-1);
            info = true;

        }
    }
    public void ReMoveButton()
    {
        Ray.ItemMove(this.gameObject);
        setItem = false;
        infometion.SetActive(false);
        KeyList.infomationhyouzi = false;
        info = false;
    }
}
