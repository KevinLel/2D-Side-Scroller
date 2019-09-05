using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakyCamScripts : MonoBehaviour
{
    public IEnumerator shake (float duration, float magnitude){
        Vector3 originalPosition = transform.localPosition;
        float TimePassed = 0.0f;  
        while(TimePassed < duration){
            float PositionXCam = Random.Range(-1f,1f) * magnitude;
            float PositionYCam = Random.Range(-1f,1f) * magnitude;
            transform.localPosition = new Vector3(PositionXCam,PositionYCam,originalPosition.z);
            TimePassed += Time.deltaTime;
            yield return null;
        }
        transform.localPosition = originalPosition;
    }
}
