using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatePlatform : MonoBehaviour
{
	public float speed =1f;

    // Update is called once per frame
    void Update()
    {
    	Vector3 twist = transform.eulerAngles;
    	twist.z = Mathf.Min(Mathf.Max(twist.z,-20),20); 
    	if(Mathf.Abs(twist.z)>=20)
    		speed*=-1;

        transform.Rotate(new Vector3(0,0,speed));
    }
}
