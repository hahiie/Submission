using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotesMoveStart : MonoBehaviour
{
    public GameObject StartObj;
    public GameObject GoalObj;
    public float GoalTime;
    //float time;
    float spead;
    public bool sentou = false;//レーンの先頭かどうか
    // Start is called before the first frame update
    void Start()
    {
        //time = GoalTime - 40;
        spead = SongControalStart.NotesSpead;
        this.transform.position = (1 - ((SongControalStart.NowTime - GoalTime + spead) / spead)) * StartObj.transform.position + ((SongControalStart.NowTime - GoalTime + spead) / spead) * GoalObj.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (SongControalStart.SongStart == true)
        {
            this.transform.position = (1 - ((SongControalStart.NowTime - GoalTime + spead) / spead)) * StartObj.transform.position + ((SongControalStart.NowTime - GoalTime + spead) / spead) * GoalObj.transform.position;
        }
    }
    public void GoalTimeSet(float i)
    {
        GoalTime = i;
    }
}
