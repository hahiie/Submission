using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseInt : MonoBehaviour
{
    public float HP;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void HPDamege(float Damege)
    {
        HP -= Damege;
        if (HP <= 0)//HP‚ª–³‚­‚È‚Á‚½‚ç
        {
            Destroy(this.gameObject);
        }
    }
}
