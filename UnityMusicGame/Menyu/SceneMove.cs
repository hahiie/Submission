using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneMove : MonoBehaviour
{
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
    public void OnClick()
    {
        SaveData.SaveFileCreate();//セーブ用のファイルを作成（初回）
        StartCoroutine(LoadScene());
    }
    IEnumerator LoadScene()
    {
        /*Panel.SetActive(true);
        LoadPanel loadPanel = Panel.GetComponent<LoadPanel>();
        yield return loadPanel.StartCoroutine("CloseStart");*/
        AsyncOperation async = SceneManager.LoadSceneAsync("Song Select");
        while (!async.isDone)
        {

            sliderObj.SetActive(true);
            slider.value = async.progress;
            yield return null;
        }
    }
}
