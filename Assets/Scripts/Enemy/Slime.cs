using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : Enemy
{
    

    protected override void Attack(){
        Vector3 pos = transform.position;
        float moveSpeed=0f;
        if(playerPosition.x < pos.x)
        	moveSpeed = Mathf.Abs(speed) *-2;
        if(playerPosition.x > pos.x)  
            moveSpeed = Mathf.Abs(speed) *2; 
        // pos.x += moveSpeed * Time.deltaTime;
        leftPoint = Mathf.Min(transform.position.x,leftPoint); //if slime followed player he has a new left point
        rb.velocity = new Vector3(moveSpeed,0,0);  
    }
}
