using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StampShuffle : MonoBehaviour
{
	public float speed = 1f;

    // Update is called once per frame
    void Update()
    {
    Vector3 pos = transform.position;
    if(pos.z>4|| pos.z<-4){
    	speed*=-1;
    }                 
    pos.z += Mathf.Min(Mathf.Max(speed * Time.deltaTime,-4),4); 

    transform.position = pos;        
    }
}
