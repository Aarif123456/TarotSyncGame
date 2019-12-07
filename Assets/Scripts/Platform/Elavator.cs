using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elavator : MonoBehaviour
{
   public float speed = 1f;
   public float lowestPoint = 1.5f , highestPoint=4.5f;
   Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Vector3 pos = transform.position;
        if(pos.y>=highestPoint|| pos.y<=lowestPoint){
        	speed*=-1;
        }                 
        pos.y += speed * Time.deltaTime;
        pos.y = Mathf.Min(Mathf.Max(pos.y,lowestPoint),highestPoint); 
        rb.MovePosition( pos);
    // transform.position = pos;        
    }
}
