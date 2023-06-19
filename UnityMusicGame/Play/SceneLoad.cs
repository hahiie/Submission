using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneLoad : MonoBehaviour
{
    [SerializeField] GameObject Panel;//動画の再生されるパネル(黒画面で終わる)
    [SerializeField] GameObject sliderObj;//スライドのオブジェクト
    [SerializeField] Slider slider;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void LoadStart(string SceneName)
    {
        StartCoroutine(LoadScene(SceneName));
    }
    IEnumerator LoadScene(string SeneName)
    {
        Panel.SetActive(true);
        LoadPanel loadPanel = Panel.GetComponent<LoadPanel>();
        yield return loadPanel.StartCoroutine("CloseStart");
        AsyncOperation async = SceneManager.LoadSceneAsync(SeneName);
        while (!async.isDone)
        {

            sliderObj.SetActive(true);
            slider.value = async.progress;
            yield return null;
        }
    }
}
