using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VLS : MonoBehaviour
{
    public GameObject SM2Lange;
    public GameObject ESSMLange;
    public GameObject SM2sairo;
    public GameObject ESSMsairo;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SM2()
    {
        SM2Lange.SetActive(true);
        SM2sairo.SetActive(true);
        ESSMLange.SetActive(false);
        ESSMsairo.SetActive(false);
    }
    public void ESSM()
    {
        SM2Lange.SetActive(false);
        SM2sairo.SetActive(false);
        ESSMLange.SetActive(true);
        ESSMsairo.SetActive(true);
    }
}
