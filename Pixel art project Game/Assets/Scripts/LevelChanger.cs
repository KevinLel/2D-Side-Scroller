using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChanger : MonoBehaviour
{
    public string LevelName; 
    private bool IsPlayerInside;
    // Start is called before the first frame update
    void Start()
    {
        IsPlayerInside = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(IsPlayerInside){
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
    void OnTriggerEnter2D(Collider2D col){
        if(col.gameObject.CompareTag("Player")){
            IsPlayerInside = true; 
        }   
    }
}
