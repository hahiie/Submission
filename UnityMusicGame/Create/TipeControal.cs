using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TipeControal : MonoBehaviour
{
    public static int NotesTipe = 1;//作成したいノーツの種類
    public Text TipeText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        TipeText.text = NotesTipe.ToString();
    }
    static void TipeIN(int i)
    {
        NotesTipe = i;
    }

    public void TipeChange()//Tipeをボタンで変更
    {
        if (NotesTipe == 1)
        {
            TipeIN(2);
        }else if (NotesTipe == 2)
        {
            TipeIN(3);
        }
        else
        {
            TipeIN(1);
        }
    }
}
