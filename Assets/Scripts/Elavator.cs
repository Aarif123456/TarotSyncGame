using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elavator : MonoBehaviour
{
   public float speed = 1f;
   Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
    Vector3 pos = transform.position;
    if(pos.y>=4|| pos.y<=1){
    	speed*=-1;
    }                 
    pos.y += speed * Time.deltaTime;
    pos.y = Mathf.Min(Mathf.Max(pos.y,1),4); 
    rb.MovePosition( pos);
    // transform.position = pos;        
    }
}
