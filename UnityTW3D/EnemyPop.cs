using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPop : MonoBehaviour
{
    public GameObject Poppoint1;
    public GameObject Poppoint2;
    public GameObject Poppoint3;
    public GameObject Poppoint4;
    public GameObject Poppoint5;
    public GameObject Poppoint6;
    public GameObject Poppoint7;
    public GameObject Poppoint8;

    public GameObject Enemy1;
    int PopCount;//“G‚Ì•¦‚«”


    bool flag = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (IntControal.EnemyCount > 0)
        {
            flag = true;
        }
        else
        {
            if (flag == true)
            {
                MenuControal.MenuChenge(0);
                flag = false;
                IntControal.Create = true;
                IntControal.Wave++;
            }
        }
    }
    public void PopStart()
    {
        IntControal.Create = false;
        MenuControal.MenuChenge(-1);
        IntControal.EnemyPopCompleta = false;
        int c = Random.Range(0, 3);
        PopCount = IntControal.Wave * 5 + 20;
        if (c == 0)
        {
            StartCoroutine(Fast(Poppoint1, Poppoint2));
        }else if (c == 1)
        {
            StartCoroutine(Fast(Poppoint3, Poppoint4));
        }else if (c == 2)
        {
            StartCoroutine(Fast(Poppoint5, Poppoint6));
        }
        else
        {
            StartCoroutine(Fast(Poppoint7, Poppoint8));
        }
    }

    IEnumerator Fast(GameObject a,GameObject b)
    {
        while (PopCount>0)
        {
            RandomPointPop(a, b);
            PopCount--;
            yield return new WaitForSeconds(1f);
        }
        IntControal.EnemyPopCompleta = true;
    }

    void RandomPointPop(GameObject a,GameObject b)
    {
        float x = Random.Range(a.transform.position.x, b.transform.position.x);
        float y = Random.Range(a.transform.position.y, b.transform.position.y);
        float z = Random.Range(a.transform.position.z, b.transform.position.z);

        Instantiate(Enemy1, new Vector3(x, y, z), Enemy1.transform.rotation);
        IntControal.EnemyCount++;
    }
}
