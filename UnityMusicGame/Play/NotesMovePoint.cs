using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotesMovePoint : MonoBehaviour
{
    public GameObject StartObj;
    public GameObject GoalObj;
    public float GoalTime = 0;
    //float time;
    float spead;
    // Start is called before the first frame update
    void Start()
    {
        //time = GoalTime - 40;
        spead = SongControal.NotesSpead;
        this.transform.position = (1 - ((SongControal.NowTime - GoalTime + spead) / spead)) * StartObj.transform.position + ((SongControal.NowTime - GoalTime + spead) / spead) * GoalObj.transform.position;
        Vector3 memo = (1 - ((SongControal.NowTime - GoalTime + spead) / spead)) * StartObj.transform.position + ((SongControal.NowTime - GoalTime + spead) / spead) * GoalObj.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (SongControal.SongStart == true)
        {
            this.transform.position = (1 - ((SongControal.NowTime - GoalTime + spead) / spead)) * StartObj.transform.position + ((SongControal.NowTime - GoalTime + spead) / spead) * GoalObj.transform.position;
        }
    }
}
