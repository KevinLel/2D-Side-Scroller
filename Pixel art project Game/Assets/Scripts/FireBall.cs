using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{
    public bool Up, Down, Left, Right;
    private Rigidbody2D rb;

    public float FireBallSpeed;  
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Up){
            rb.MovePosition(transform.position + transform.up * Time.fixedDeltaTime * FireBallSpeed);  
        }
        if(Down){
            rb.MovePosition(transform.position + -transform.up * Time.fixedDeltaTime * FireBallSpeed); 
        }
        if(Left){
            rb.MovePosition(transform.position + -transform.right * Time.fixedDeltaTime * FireBallSpeed); 
        }
        if(Right){
            rb.MovePosition(transform.position + transform.right * Time.fixedDeltaTime * FireBallSpeed); 
        }
    }
    void OnTriggerEnter2D(Collider2D col){
        if(col.gameObject.layer == LayerMask.NameToLayer("Ground")){
            Destroy(gameObject);
        }
        if(col.gameObject.CompareTag("Player")){
            Destroy(gameObject);
        }
        
    }
}
