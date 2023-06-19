using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TextMove : MonoBehaviour
{
    Text me;
    // Start is called before the first frame update
    void Start()
    {
        me = this.gameObject.GetComponent<Text>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 memo = me.rectTransform.position;
        memo.y += 4f;
        me.rectTransform.position = memo;
        Color co = me.color;
        co.a -= 0.02f;
        me.color = co;
        if (me.color.a < 0)
        {
            this.gameObject.SetActive(false);
        }
    }
}
