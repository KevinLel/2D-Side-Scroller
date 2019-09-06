using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : MonoBehaviour
{
    public GameObject OtherGate, Cam, CamSystem;
    private Vector3 OtherGatePosition;
    private bool PlayerEntered;
    private GameObject Player;
    private float TimePassed = 0.0f, Timebet = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        OtherGatePosition = OtherGate.transform.position;
        Player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if(PlayerEntered && Input.GetButtonDown("Action")){
            if(TimePassed < Time.time){
                Player.transform.position = OtherGatePosition;
                Cam.transform.position =  Vector3.Lerp(Cam.transform.position, new Vector3(Player.transform.position.x, Player.transform.position.y + 3,-9), 1 * Time.deltaTime);
                CamSystem.transform.position = Vector3.Lerp(this.transform.position, Player.transform.position, 1 * Time.deltaTime);
                TimePassed = Time.time + Timebet;
            }
            
        }
    }
    void OnTriggerEnter2D(Collider2D col){
        if(col.gameObject.CompareTag("Player")){
            PlayerEntered = true;
        }
    }
    void OnTriggerExit2D(Collider2D col){
        if(col.gameObject.CompareTag("Player")){
            PlayerEntered = false;
        }
    }
}
