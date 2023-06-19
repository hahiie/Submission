using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pause : MonoBehaviour
{
    bool flag = false;
    bool flag2 = false;
    float time = 0;
    public GameObject panel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (SongControal.SongStart == true)
        {
#if !UNITY_EDITOR && UNITY_ANDROID

            if (Input.touchCount == 3)
            {
                if (flag == false)
                {
                    flag = true;
                }
                if (flag2 == true)
                {
                    panel.SetActive(true);
                    SongControal.stop();
                }
            }
            if (Input.touchCount == 0)
            {
                if (flag == true)
                {
                    flag2 = true;
                }
            }
            if (flag == true)
            {
                time += Time.deltaTime;
            }
            if (time > 0.2f)
            {
                flag = false;
                flag2 = false;
                time = 0;
            }
#else
            if (Input.GetKey(KeyCode.W) == true)
            {
                if (flag == false)
                {
                    flag = true;
                }
                if (flag2 == true)
                {
                    panel.SetActive(true);
                    SongControal.stop();
                }
            }
            if (Input.GetKey(KeyCode.W) == false)
            {
                if (flag == true)
                {
                    flag2 = true;
                }
            }
            if (flag == true)
            {
                time += Time.deltaTime;
            }
            if (time > 0.2f)
            {
                flag = false;
                flag2 = false;
                time = 0;
            }
#endif
        }
    }
    public void unstart()
    {
        panel.SetActive(false);
    }
    /*public void reStart()
    {
        SceneManager.LoadScene("Play");
    }*/
}
