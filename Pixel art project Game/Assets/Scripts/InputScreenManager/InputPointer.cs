using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InputPointer : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public bool Up,Action,Attack;
    private GameObject Player;
    public void Start(){
        Player = GameObject.Find("Player");
    }
    public void OnPointerDown (PointerEventData eventData) 
     {
         if(Up){
            print("test");
            Player.GetComponent<PlayerScript>().Jump = true;
        }
        if(Action){
            Player.GetComponent<PlayerScript>().Action = true;
        }
        if(Attack){
            Player.GetComponent<PlayerScript>().Attack = true;
        }
     }
     public void OnPointerUp (PointerEventData eventData) 
     {
         if(Up){
            print("DEPUSH");
            Player.GetComponent<PlayerScript>().Jump = false;
        }
        if(Action){
            Player.GetComponent<PlayerScript>().Action = false;
        }
        if(Attack){
            Player.GetComponent<PlayerScript>().Attack = false;
        }
     }
}
