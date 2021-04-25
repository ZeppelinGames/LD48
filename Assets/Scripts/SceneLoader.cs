using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public Animator fadeAnim;

    public void LoadScene(int index)
    {
        if (index < SceneManager.sceneCountInBuildSettings)
        {
            if (fadeAnim != null)
            {
                fadeAnim.SetTrigger("FadeOut");
                StartCoroutine(delayLoad(index));
            } else
            {
                SceneManager.LoadSceneAsync(index);
            }    
        }
    }

    IEnumerator delayLoad(int index)
    {
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadSceneAsync(index);
    }
}
