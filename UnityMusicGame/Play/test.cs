using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class test : MonoBehaviour
{

    private void Awake()
    {
        Mesh mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;

        Vector3[] vertices = new Vector3[3];
        int[] triangles = new int[3];
        for (int i = 0; i < 3; i++)
        {
            float angle = i * 120f * Mathf.Deg2Rad;
            vertices[i] = new Vector3(Mathf.Sin(angle), Mathf.Cos(angle), 0);
        }
        triangles = new int[3] { 0, 1, 2 };

        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.RecalculateNormals();
    }
}
