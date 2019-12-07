using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
	
	public Transform playerTransform;
	
    // Update is called once per frame
    void LateUpdate()
    {
    	Vector3 pos = transform.position;
    	pos.x +=  ((playerTransform.position.x-pos.x)-1) * (3f*Time.deltaTime);  
        pos.y +=  ((playerTransform.position.y-pos.y)+10) * Time.deltaTime;  
        // pos.z +=  ((playerTransform.position.z-pos.z)-10) * Time.deltaTime;  
    	transform.position = pos;        
    }
}
