using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;


public class ToucheToScreen : MonoBehaviour
{
    public string LevelName; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
     if(Input.GetMouseButtonDown(0)){
         StartCoroutine(ChargementAsynchroneScene());
     }
    }
    IEnumerator ChargementAsynchroneScene(){
        AsyncOperation ChargementAsynchroneScene = SceneManager.LoadSceneAsync(LevelName);
        while(!ChargementAsynchroneScene.isDone){
            //Gestion de l'ecran de chargement
            yield return null;
        }
    }
}
