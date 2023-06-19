using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchLaneControal : MonoBehaviour
{
    public static bool[] Lane = { false, false, false, false, false, false, false, false };
    public static GameObject[] Noteslist = new GameObject[8];
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public static bool InObj(GameObject a,int i,float InTime)
    {
        if (Noteslist[i] == null)
        {
            Noteslist[i] = a;
            return true;
        }
        else
        {
            NotesMove nowS = Noteslist[i].GetComponent<NotesMove>();
            float NowTime = nowS.GoalTime;
            if (NowTime > InTime)
            {
                nowS.sentou = false;
                Noteslist[i] = a;
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
