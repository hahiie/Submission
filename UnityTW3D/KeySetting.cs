using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeySetting : MonoBehaviour
{
    int i;
    int j = 1;
    public int number;
    int keep;
    public Text buttonname;
    public Text buttontext;
    bool flag = false;
    // Start is called before the first frame update
    public void powerUPKeysDown()
    {
        buttontext.text = "ÉLÅ[Çì¸óÕÇµÇƒÇ≠ÇæÇ≥Ç¢";
        flag = true;

    }
    public void powerUPKeysUP()
    {
        flag = false;
    }
    void Start()
    {
        int now = PlayerPrefs.GetInt(KeyList.SettingKeys[number], KeyList.StartKaySet[number]);
        buttontext.text = KeyList.Keyname[now];
    }
    void Update()
    {
        buttonname.text = KeyList.SettingKeys[number];
        if (flag == true)
        {
            if (Input.anyKeyDown)
            {
                for (i = 0; i <= KeyList.Keys.Length; i++)
                {
                    KeyCode Code = KeyList.Keys[i];
                    if (Input.GetKey(Code))
                    {
                        keep = i;
                        buttontext.text = KeyList.Keyname[keep];
                        PlayerPrefs.SetInt(KeyList.SettingKeys[number], keep);
                        j = 0;
                        PlayerPrefs.Save();
                        break;
                    }
                }
                if (j == 1)
                {
                    buttontext.text = "ëŒâûÇµÇƒÇ¢Ç‹ÇπÇÒ";
                }
            }
        }
    }
}

