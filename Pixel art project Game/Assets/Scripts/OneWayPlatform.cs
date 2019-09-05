using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneWayPlatform : MonoBehaviour
{
    public float YAxis; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        YAxis = Input.GetAxis("Vertical");
        if(YAxis < 0){
            //gameObject.GetComponent<PlateformEffector2D>().effector.rotationOffset = 180f; 
        }
    }
}
