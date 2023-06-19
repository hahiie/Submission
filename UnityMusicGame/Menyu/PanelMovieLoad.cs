using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelMovieLoad : MonoBehaviour
{
    public GameObject OpMovie;
    LoadPanel OpScr;

    public CanvasGroup[] Panels;
    public GameObject[] PanelsObj;
    // Start is called before the first frame update
    void Start()
    {
        OpScr = OpMovie.GetComponent<LoadPanel>();
        StartCoroutine(LoadScene());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator LoadScene()
    {
        OpMovie.SetActive(true);
        LoadPanel loadPanel = OpMovie.GetComponent<LoadPanel>();
        yield return loadPanel.StartCoroutine("CloseStart");
        //OpMovie.SetActive(false);
        int i;
        for (i = 0; i < Panels.Length; i++)
        {
            PanelsObj[i].SetActive(true);
            while (Panels[i].alpha<1f)
            {
                float memo = Panels[i].alpha;
                memo += 0.05f;
                if (memo > 1f)
                {
                    memo = 1f;
                }
                Panels[i].alpha =memo;
                yield return new WaitForSeconds(0.1f);
            }
            yield return new WaitForSeconds(3f);
            while (Panels[i].alpha > 0f)
            {
                float memo = Panels[i].alpha;
                memo -= 0.05f;
                if (memo < 0f)
                {
                    memo = 0f;
                }
                Panels[i].alpha = memo;
                yield return new WaitForSeconds(0.1f);
            }
            PanelsObj[i].SetActive(false);
        }
        OpMovie.SetActive(false);

        SongControalStart.SongStart = true;
    }
}
