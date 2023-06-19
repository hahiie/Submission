using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Open : MonoBehaviour//ロード明けを作りたい
{
    public GameObject OpenL;
    // Start is called before the first frame update
    void Start()
    {
        OpenL.GetComponent<LoadPanel>().OpenImg();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
