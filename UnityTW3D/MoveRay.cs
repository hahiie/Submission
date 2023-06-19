using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRay : MonoBehaviour
{
    public GameObject m;//��ŏ���
    GameObject m_object;
    Vector3 memo = new Vector3(0, 0, 0);
    int ItemNumber;
    bool movethis = false;
    public bool Infomation=false;//�������Ă���Ԃ͏����A�C�e���N���b�N�ŕ\�����Ȃ�
    public GameObject Createmenu;
    public GameObject Maney;
    bool Maneyflag = true;//���������炷���ǂ����i�V�����I�u�W�F�N�g�𓮂����Ă��邩�j

    void Update()
    {
        if (movethis == true)
        {


            Vector2 touchScreenPosition = Input.mousePosition;

            touchScreenPosition.x = Mathf.Clamp(touchScreenPosition.x, 0.0f, Screen.width);
            touchScreenPosition.y = Mathf.Clamp(touchScreenPosition.y, 0.0f, Screen.height);

            Camera gameCamera = Camera.main;
            if (m_object == null)
            {
                m_object = Instantiate(KeyList.PrefabList2[ItemNumber], touchScreenPosition, Quaternion.identity);
            }
            Ray touchPointToRay = gameCamera.ScreenPointToRay(touchScreenPosition);

            RaycastHit hitInfo = new RaycastHit();
            LayerMask layerMask = 1 << 7;
            if (Physics.Raycast(touchPointToRay, out hitInfo, Mathf.Infinity, layerMask))
            {
                m_object.transform.position = hitInfo.point;
                Vector3 memo = m_object.transform.position;
                memo.y = 0;
                memo.x = Mathf.Clamp(memo.x, IntControal.Createterramin + KeyList.ItemSize[ItemNumber], IntControal.Createterramax - KeyList.ItemSize[ItemNumber]);
                memo.z = Mathf.Clamp(memo.z, IntControal.Createterramin + KeyList.ItemSize2[ItemNumber], IntControal.Createterramax - KeyList.ItemSize2[ItemNumber]);
                memo.x = Mathf.Round(memo.x);
                memo.z = Mathf.Round(memo.z);
                m_object.transform.position = memo;
            }

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                movethis = false;
                MenuControal.MenuBack();
                Destroy(m_object);
            }
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                movethis = false;
                ItemKentiku Script = m_object.GetComponent<ItemKentiku>();
                Script.menuHyouzi();

            }
        }
    }
    public void ItemNumberSet(int i)//�{�^������I�u�W�F�N�g������ē�����
    {
        //����������邩
        if (IntControal.StartCost[i] <= IntControal.Maney)
        {
            ItemNumber = i;
            movethis = true;
            Infomation = true;
            MenuControal.MenuChenge(-1);
            Maneyflag = true;
        }
        else
        {
            ManeyLessText M = Maney.GetComponent<ManeyLessText>();
            M.OnText();
        }
    }
    public void ItemMove(GameObject Item)//��x�ݒu�������̂𓮂���
    {
        movethis = true;
        Infomation = true;
        m_object = Item;
        Maneyflag = false;
    }
    public void remove()
    {
        movethis = true;
    }
    public void reset()//�ݒu����
    {
        m_object = null;
        movethis = false;
        Infomation = false;
        if (Maneyflag == true)
        {
            IntControal.Maney -= IntControal.StartCost[ItemNumber];
        }
    }
    public void Backmenu()
    {
        MenuControal.MenuBack();
    }
}
