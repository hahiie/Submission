using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControal : MonoBehaviour
{
    public GameObject Camera;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            move(0, 1, 0);
        }
        if (Input.GetKey(KeyCode.A))
        {
            move(-1, 0, 0);
        }
        if (Input.GetKey(KeyCode.S))
        {
            move(0, -1, 0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            move(1, 0, 0);
        }
        if (Input.GetKey(KeyCode.Q))
        {
            move(0, 0, 1);
        }
        if (Input.GetKey(KeyCode.E))
        {
            move(0, 0, -1);
        }
    }
    void move(float x,float y,float z)
    {
        Camera.transform.Translate(x * 0.1f, y * 0.1f, z * 0.1f);
    }
}