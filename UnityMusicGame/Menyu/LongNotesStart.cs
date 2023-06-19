using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LongNotesStart : MonoBehaviour
{ 
    public GameObject[] StartGoalObj = new GameObject[8];//始点、終点
    public float GoalTime1;//終点
    public float GoalTime2;//始点
    public int lane1;
    public int lane2;
    float spead;
    //bool lanememo;

    void Start()
    {
        spead = SongControalStart.NotesSpead;
        //テスト用
        /*GameObject testNotes = new GameObject();
        testNotes.AddComponent<MeshFilter>();
        testNotes.AddComponent<MeshRenderer>();
        */

        //位置座標を求める。
        /*Vector3 startPos = new Vector3(-2 * laneWidth + laneWidth * startLane + laneWidth / 2, 0.1f, startTim);
        Vector3 endPos = new Vector3(-2 * laneWidth + laneWidth * endLane + laneWidth / 2, 0.1f, endTim);
        */
        //ロングノーツ生成
        //Generate(startPos, endPos, testNotes);

        //判定用
        /*if (lane1 > lane2)
        {
            lanememo = true;
        }
        else
        {
            lanememo = false;
        }*/
        if (GoalTime1 < GoalTime2)
        {
            float memo = GoalTime1;
            GoalTime1 = GoalTime2;
            GoalTime2 = memo;
        }
    }



    void Update/*Generate*/(/*Vector3 sPos, Vector3 ePos, GameObject notesObj*/)
    {
        //ここからメッシュ生成
        //メッシュを生成し、MeshFilterに渡す。
        //MeshFilterがMeshRendererにメッシュを渡して、メッシュが描画される。
        Mesh mesh = new Mesh();
        this.GetComponent<MeshFilter>().mesh = mesh;

        Vector3[] vertices = new Vector3[4];
        int[] triangles = new int[6];

        vertices[0] = (1 - ((SongControalStart.NowTime - GoalTime1 + spead) / spead)) * StartGoalObj[0].transform.position + ((SongControalStart.NowTime - GoalTime1 + spead) / spead) * StartGoalObj[2].transform.position;//sPos + new Vector3(-laneWidth / 2, 0, 0);//始点の左端
        vertices[1] = (1 - ((SongControalStart.NowTime - GoalTime1 + spead) / spead)) * StartGoalObj[1].transform.position + ((SongControalStart.NowTime - GoalTime1 + spead) / spead) * StartGoalObj[3].transform.position;//sPos + new Vector3(laneWidth / 2, 0, 0); //始点の右端
        vertices[2] = (1 - ((SongControalStart.NowTime - GoalTime2 + spead) / spead)) * StartGoalObj[4].transform.position + ((SongControalStart.NowTime - GoalTime2 + spead) / spead) * StartGoalObj[6].transform.position;//ePos + new Vector3(-laneWidth / 2, 0, 0); //終点の左端
        vertices[3] = (1 - ((SongControalStart.NowTime - GoalTime2 + spead) / spead)) * StartGoalObj[5].transform.position + ((SongControalStart.NowTime - GoalTime2 + spead) / spead) * StartGoalObj[7].transform.position;//ePos + new Vector3(laneWidth / 2, 0, 0); //終点の右端
        if (GoalTime1 < GoalTime2)
        {
            triangles = new int[6] { 0, 1, 2, 3, 2, 1 };
        }
        else
        {
            triangles = new int[6] { 0, 2, 1, 3, 1, 2 };
        }
        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.RecalculateNormals();

        //this.GetComponent<MeshCollider>().sharedMesh = mesh;


        //ここから判定関連

        if ((SongControalStart.NowTime + SongControalStart.HanteiTyousei2) > GoalTime1)
        {
            SongControalStart.NotesSound(2);
            GoalTime1 += SongControalStart.SongLength;
            GoalTime2 += SongControalStart.SongLength;
        }


    }
}
