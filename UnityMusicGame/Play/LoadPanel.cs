using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadPanel : MonoBehaviour
{
    public Sprite[] sprites;
    public float speed;
    // Update is called once per frame
    void Update()
    {
        
    }
    private Image image;
    private float current;

    public void OpenImg()
    {
        /*this.gameObject.SetActive(true);
        image = GetComponent<Image>();
        image.sprite = sprites[0];
        current = 0f;*/
        this.gameObject.SetActive(true);
        IEnumerator coroutine = OpenStart();
        StartCoroutine(coroutine);
    }
    public void CloseImg()
    {
        /*this.gameObject.SetActive(true);
        image = GetComponent<Image>();
        image.sprite = sprites[49];
        current = (float)sprites.Length;*/
        this.gameObject.SetActive(true);
        IEnumerator coroutine = CloseStart();
        StartCoroutine(coroutine);
    }
    void Start()
    {
        
    }

    public IEnumerator CloseStart()//0から最後まで再生する
    {
        image = GetComponent<Image>();
        image.sprite = sprites[0];
        current = 0f;
        int index = 0;
        /*while (index < sprites.Length - 1)
        {
            current += Time.deltaTime * speed;
            index = (int)(current) % sprites.Length;
            if (index > sprites.Length - 1) index = sprites.Length - 1;
            image.sprite = sprites[index];
            yield return new WaitForSeconds(0.01f);
        }*/


        for (index = 0; index < sprites.Length; index++)
        {
            image.sprite = sprites[index];
            yield return new WaitForSeconds(1f / (float)speed);
        }

        //this.gameObject.SetActive(false);//白画面で終わる
    }
    public IEnumerator OpenStart()//最後から0まで再生する
    {
        image = GetComponent<Image>();
        image.sprite = sprites[sprites.Length-1];
        current = (float)sprites.Length;
         int index = sprites.Length - 1;
        /*while (index > 0)
        {
            current -= Time.deltaTime * speed;
            index = (int)(current) % sprites.Length;
            if (index < 0) index = 0;
            image.sprite = sprites[index];
            yield return new WaitForSeconds(0.01f);
        }*/
        for(index = sprites.Length - 1; index >= 0; index--)
        {
            image.sprite = sprites[index];
            yield return new WaitForSeconds(1f / (float)speed);
        }

        this.gameObject.SetActive(false);
    }
}
