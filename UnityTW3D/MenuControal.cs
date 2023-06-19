using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuControal : MonoBehaviour
{

    static List<GameObject> Menu = new List<GameObject>();
    static int New;
    static int old = 0;
    static int Now = 0;

    public GameObject menu0;
    public GameObject menu1;
    public GameObject menu2;
    public GameObject menu3;
    public GameObject menu4;

    // Start is called before the first frame update
    void Start()
    {
        Menu.Add(menu0);
        Menu.Add(menu1);
        Menu.Add(menu2);
        Menu.Add(menu3);
        Menu.Add(menu4);
    }
    public static void MenuChenge(int number)
    {
        New = number;
        MenuReload();
    }
    public static void MenuBack()
    {
        if (Now != -1)
        {
            Menu[Now].SetActive(false);
        }
        if (old != -1)
        {
            Menu[old].SetActive(true);
        }
        else if(IntControal.Create==true)
        {
            Menu[0].SetActive(true);
        }
        Now = old;
        old = -1;
    }
    static void MenuReload()
    {
        if (New == -1)
        {
            if (Now != -1)
            {
                Menu[Now].SetActive(false);
            }
            old = Now;
            Now = -1;
        }
        else
        {
            if (Now != -1)
            {
                Menu[Now].SetActive(false);
            }
            Menu[New].SetActive(true);
            old = Now;
            Now = New;
        }
    }
}
