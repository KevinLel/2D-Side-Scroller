using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverManager : MonoBehaviour
{
    public bool state;

    private bool isPlayerEnterCollider; 

    public Sprite ActivatedLeverSprite, DesactivateLeverSprite;

    private GameObject ActionButton;
    private bool ActionButtonState; 
    // Start is called before the first frame update
    void Start()
    {
        ActionButton = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        ActionButtonState = ActionButton.GetComponent<PlayerScript>().Action;
        if(isPlayerEnterCollider && ActionButtonState){
            state = !state;
        }
        if(state){
            gameObject.GetComponent<SpriteRenderer>().sprite = ActivatedLeverSprite;
        }
        if(!state){
            gameObject.GetComponent<SpriteRenderer>().sprite = DesactivateLeverSprite;
        }
    }

    void OnTriggerEnter2D(Collider2D col){
        if(col.gameObject.CompareTag("Player")){
            isPlayerEnterCollider = true;
        }
    }
    void OnTriggerExit2D(Collider2D col){
        if(col.gameObject.CompareTag("Player")){
            isPlayerEnterCollider = false;
        }
    }
}
