using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
public class MainPanel : MonoBehaviour
{
    private Animator animator;
     Slider slider;
    Text text;
    private void Start()
    {
        animator = GetComponent<Animator>();
        slider = transform.GetChild(transform.childCount - 1).GetComponent<Slider>();
        text = slider.transform.GetChild(0).GetComponent<Text>();
    }
    #region PlayScene
    public void Play()
    {
        if (slider.gameObject!=null)
            for (int i = 0; i < transform.childCount-1; i++)
            {
                var a = transform.GetChild(i);
                a.gameObject.SetActive(false);
            }
            slider.gameObject.SetActive(true);
            StartCoroutine(LoadScene(1));
    }
    IEnumerator LoadScene(int i)
    {
        AsyncOperation o = SceneManager.LoadSceneAsync(i);
        while (!o.isDone)
        {
            slider.value = Mathf.RoundToInt(o.progress*100);
            text.text = slider.value.ToString()+"%";
            yield return null;
        }
        o.allowSceneActivation = false;
        text.text = slider.value+9.ToString() + "%";
        yield return new WaitForSeconds(1);
        o.allowSceneActivation = true;
    }
    #endregion
    public void Option()
    {
        animator.SetTrigger("OptionPlay");
    }
    public void OptionBack()
    {
        animator.SetTrigger("OptionBack");
    }
    public void Quit()
    {
        Application.Quit();
    }
    public void Info()
    {
        System.Diagnostics.Process.Start(Application.streamingAssetsPath);
    }
}