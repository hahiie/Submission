using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TipeControal : MonoBehaviour
{
    public static int NotesTipe = 1;//�쐬�������m�[�c�̎��
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

    public void TipeChange()//Tipe���{�^���ŕύX
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
