using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public void PlayButton(){
        StartCoroutine(ChargementAsynchroneScene());
    }

    IEnumerator ChargementAsynchroneScene(){
       AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("SceneDeTest"); 
       while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }
}
