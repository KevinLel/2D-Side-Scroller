using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBallCanon : MonoBehaviour
{
    public GameObject FireBallUp, FireBallDown, FireBallLeft, FireBallRight;
    public bool Up, Down, Left, Right;
    public float Value, fireRate;

    private Vector3 LocalPosition; 

    // Start is called before the first frame update
    void Start()
    {
        LocalPosition = this.transform.position; 
        Value = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time > Value){
            if(Up){
                Instantiate(FireBallUp, LocalPosition, Quaternion.identity); 
            }
            if(Down){
                Instantiate(FireBallDown, LocalPosition, Quaternion.identity);
            }
            if(Left){
                Instantiate(FireBallLeft, LocalPosition, Quaternion.identity);
            }
            if(Right){
                Instantiate(FireBallRight, LocalPosition, Quaternion.identity);
            }
            Value = Time.time + fireRate;
        }
    }
}
