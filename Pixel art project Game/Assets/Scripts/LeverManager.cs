using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverManager : MonoBehaviour
{
    public bool state;

    private bool isPlayerEnterCollider; 

    public Sprite ActivatedLeverSprite, DesactivateLeverSprite;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        print(state);
        if(isPlayerEnterCollider && Input.GetButtonDown("Action")){
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
