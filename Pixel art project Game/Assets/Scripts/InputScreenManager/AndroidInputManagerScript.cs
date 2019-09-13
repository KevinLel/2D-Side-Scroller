using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AndroidInputManagerScript : MonoBehaviour
{
    public bool Up,Action,Attack;

    public void PauseButton(){
        if(Time.timeScale == 1.0f){
            Time.timeScale = 0.0f;
        }
        else{
            Time.timeScale = 1.0f;
        }
    }
}
