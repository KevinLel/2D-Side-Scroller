using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    public Sprite ActivatedButton, DesactivatedButton;
    public bool IsPressed;  
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(IsPressed){
            gameObject.GetComponent<SpriteRenderer>().sprite = ActivatedButton;
        }
        else{
            gameObject.GetComponent<SpriteRenderer>().sprite = DesactivatedButton;
        }
    }
    void OnTriggerEnter2D(Collider2D col){
        if(!col.gameObject.CompareTag("Enemies")){
            IsPressed = true;
        }
    }
    void OnTriggerExit2D(Collider2D col){
        if(!col.gameObject.CompareTag("Enemies")){
            IsPressed = false;
        }
    }
}
