using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aspect : MonoBehaviour
{
    Camera cam;
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        cam.sensorSize = new Vector2((Screen.width / 750f) / (Screen.height / 1334f) * 42.41f, 24f);
        this.transform.localScale = new Vector3((Screen.width / 750f) / (Screen.height / 1334f),1, 1);
        //this.transform.localScale = new Vector3(((float )Screen.width / Screen.height) / (750f/1334f), ((float)Screen.height / Screen.width) / (1334f / 750f), 1);
    }
}
