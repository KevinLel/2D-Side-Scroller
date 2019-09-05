using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blockers : MonoBehaviour
{
    public GameObject LeverReference;
    public Sprite ActivatedBlockers, DesactivatedBlockers;

    public bool state;

    void Update()
    {
        state = LeverReference.GetComponent<LeverManager>().state;
        if(!state){
            gameObject.GetComponent<SpriteRenderer>().sprite = ActivatedBlockers;
            gameObject.GetComponent<BoxCollider2D>().enabled = true;
        }
        else{
            gameObject.GetComponent<SpriteRenderer>().sprite = DesactivatedBlockers;
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
        }
    }
}
