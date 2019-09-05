using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform Target;
    public float SmoothSpeed = 10;
    public Vector3 offsetCam;

    private GameObject Player;
    Vector2 PlayerVelocity;
    
    void Start(){
        Player = GameObject.Find("Player");
    }
    void Update(){
        PlayerVelocity = Player.GetComponent<Rigidbody2D>().velocity;
    }
    void FixedUpdate(){
        Vector3 desiredPosition = Target.position + offsetCam;
        if(Input.GetAxis("Vertical") == -1 && PlayerVelocity == new Vector2(0,0)){
            desiredPosition.y -= 4;
        }    
        
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, SmoothSpeed * Time.deltaTime);
        transform.position = smoothedPosition;

        
    }
}
