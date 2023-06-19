using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LongNotes2 : MonoBehaviour
{
    public GameObject[] StartGoalObj = new GameObject[8];//�n�_�A�I�_
    public float GoalTime1;//�I�_
    public float GoalTime2;//�n�_
    public GameObject Object1;
    public GameObject Object2;
    NotesMove2 Script1;
    NotesMove2 Script2;
    float spead;

    void Start()
    {
        spead = SongControal2.NotesSpead;

    }



    void Update/*Generate*/(/*Vector3 sPos, Vector3 ePos, GameObject notesObj*/)
    {
        if (Object1 == null || Object2 == null)
        {

            NotesControal.NotesDelete(this.gameObject);
            Destroy(this.gameObject);
        }
        else
        {
            //���ʍ쐬�p���
            Script1 = Object1.GetComponent<NotesMove2>();
            Script2 = Object2.GetComponent<NotesMove2>();
            GoalTime1 = Script1.GoalTime;
            GoalTime2 = Script2.GoalTime;

            //�������烁�b�V������
            //���b�V���𐶐����AMeshFilter�ɓn���B
            //MeshFilter��MeshRenderer�Ƀ��b�V����n���āA���b�V�����`�悳���B
            Mesh mesh = new Mesh();
            this.GetComponent<MeshFilter>().mesh = mesh;

            Vector3[] vertices = new Vector3[4];
            int[] triangles = new int[6];

            vertices[0] = (1 - ((SongControal2.NowTime - GoalTime1 + spead) / spead)) * StartGoalObj[0].transform.position + ((SongControal2.NowTime - GoalTime1 + spead) / spead) * StartGoalObj[2].transform.position;//sPos + new Vector3(-laneWidth / 2, 0, 0);//�n�_�̍��[
            vertices[1] = (1 - ((SongControal2.NowTime - GoalTime1 + spead) / spead)) * StartGoalObj[1].transform.position + ((SongControal2.NowTime - GoalTime1 + spead) / spead) * StartGoalObj[3].transform.position;//sPos + new Vector3(laneWidth / 2, 0, 0); //�n�_�̉E�[
            vertices[2] = (1 - ((SongControal2.NowTime - GoalTime2 + spead) / spead)) * StartGoalObj[4].transform.position + ((SongControal2.NowTime - GoalTime2 + spead) / spead) * StartGoalObj[6].transform.position;//ePos + new Vector3(-laneWidth / 2, 0, 0); //�I�_�̍��[
            vertices[3] = (1 - ((SongControal2.NowTime - GoalTime2 + spead) / spead)) * StartGoalObj[5].transform.position + ((SongControal2.NowTime - GoalTime2 + spead) / spead) * StartGoalObj[7].transform.position;//ePos + new Vector3(laneWidth / 2, 0, 0); //�I�_�̉E�[
            if (Script1.GoalTime < Script2.GoalTime)
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

            //this.GetComponent<MeshCollider>().sharedMesh = mesh;//�����蔻��

        }
    }
}
