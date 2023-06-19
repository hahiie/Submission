using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchLight : MonoBehaviour
{
    public int lane;
    Material mat;
    float alfermemo;
    bool flagin = false;
    // Start is called before the first frame update
    void Start()
    {
        mat = this.GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (mat.color.a > 0)
        {
            Color alfermemo = mat.color;
            alfermemo.a = alfermemo.a - 0.07f;
            if (alfermemo.a < 0)
            {
                alfermemo.a = 0;
            }
            mat.color = alfermemo;
        }
        if(flagin && Input.GetMouseButton(0))
        {
            Color alfermemo = mat.color;
            alfermemo.a = 0.65f;
            mat.color = alfermemo;
            TouchLaneControal.Lane[lane] = true;
        }
        else
        {
            TouchLaneControal.Lane[lane] = false;
        }
    }
    public void In()
    {
        flagin = true;
    }
    public void Out()
    {
        flagin = false;
    }
}
