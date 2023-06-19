using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManeyLessText : MonoBehaviour
{
    bool on = false;
    float times=0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (times < 2)
        {
            times += Time.deltaTime;
        }
        else if (on == true)
        {
            this.gameObject.SetActive(false);
            on = false;
        }
    }
    public void OnText()
    {
        on = true;
        this.gameObject.SetActive(true);
        times = 0;
    }
}
