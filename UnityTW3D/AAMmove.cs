using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AAMmove : MonoBehaviour
{
    Rigidbody rb;
    Vector3 target,tg,me,planeFrom,planeTo;
    GameObject Look = null;
    float a = 300f;
    float times = 0f;
    float yoko, tate;
    float b = 0;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.AddForce(transform.forward * a);
        if (times < 0.05f)
        {
            times += Time.deltaTime;
        }
        else
        {
            times += Time.deltaTime;
            if (times > 5f)
            {
                Destroy(gameObject);
                BulletDamage Script = GetComponent<BulletDamage>();
                Script.NextHPUp(Look);
            }
            if (Look != null)
            {

                tg = Look.transform.position;
                Rigidbody trb = Look.transform.GetComponent<Rigidbody>();
                tg = tg - rb.transform.position;
                tg = tg + tg.magnitude * trb.velocity * 0.001f;
                planeFrom = Vector3.ProjectOnPlane(tg, rb.transform.up);
                planeTo = Vector3.ProjectOnPlane(transform.forward, rb.transform.up);
                yoko = Vector3.SignedAngle(planeFrom, planeTo, rb.transform.up);
                planeFrom = Vector3.ProjectOnPlane(tg, rb.transform.right);
                planeTo = Vector3.ProjectOnPlane(transform.forward, rb.transform.right);
                tate = Vector3.SignedAngle(planeFrom, planeTo, rb.transform.right);


                if (Mathf.Abs(yoko) < 0.5f)
                {
                    b = 1f;
                }
                else if (Mathf.Abs(yoko) >= 0.5f && Mathf.Abs(yoko) < 3)
                {
                    b = 2f;
                }
                else if (Mathf.Abs(yoko) >= 3 && Mathf.Abs(yoko) < 20)
                {
                    b = 3f;
                }
                else if (Mathf.Abs(yoko) >= 20 && Mathf.Abs(yoko) < 40)
                {
                    b = 10f;
                }
                else
                {
                    b = 20f;
                }

                if (yoko < 0)
                {
                    turn(0, 1, 0);
                }
                else
                {
                    turn(0, -1, 0);
                }
                if (Mathf.Abs(tate) < 0.5f)
                {
                    b = 1f;
                }
                else if (Mathf.Abs(tate) >= 0.5f && Mathf.Abs(tate) < 3)
                {
                    b = 2f;
                }
                else if (Mathf.Abs(tate) >= 3 && Mathf.Abs(tate) < 20)
                {
                    b = 3f;
                }
                else if (Mathf.Abs(tate) >= 20 && Mathf.Abs(tate) < 40)
                {
                    b = 10f;
                }
                else
                {
                    b = 20f;
                }
                if (tate < 0)
                {
                    turn(1, 0, 0);
                }
                else
                {
                    turn(-1, 0, 0);
                }
            }
        }
    }
    void turn(int i,int j,int k)
    {
        rb.AddRelativeTorque(b * i, b * j,  b * k);
    }
    public void SetLook(GameObject a)
    {
        Look = a;
        BulletDamage Script = GetComponent<BulletDamage>();
        Script.NextHPDown(Look);
    }
}
