using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : Enemy
{
    protected override bool lookForPlayer(){
        if(Mathf.Abs(playerPosition.x-transform.position.x)<8 && Mathf.Abs(playerPosition.y-transform.position.y) <5){
            state = ATTACK; // Slime is always in attack mode
            Debug.Log("Found Player");
            return true;
        }
        state = PATROL;
        return false;
    }
    // specific to slime 
    void slimeMove(float v){
        Vector3 pos = transform.position;
        if(pos.x>=leftPoint+ horizontalRange|| pos.x<=leftPoint){
            speed*=-1;
        }                 
        pos.x += speed * Time.deltaTime;
        pos.x = Mathf.Min(Mathf.Max(pos.x,leftPoint),leftPoint+ horizontalRange); 
        rb.MovePosition( pos);   
    }

    protected override void patrol(){
        slimeMove(speed);
    }

    protected override void search(){
        slimeMove(speed*1.5f);
    }
    protected override void attack(){
        Vector3 pos = transform.position;
        float moveSpeed=0f;
        if(playerPosition.x < pos.x)
        	moveSpeed = Mathf.Abs(speed) *-2;
        if(playerPosition.x > pos.x)  
            moveSpeed = Mathf.Abs(speed) *2; 
        pos.x += moveSpeed * Time.deltaTime;
        leftPoint = Mathf.Min(transform.position.x,leftPoint); //if slime followed player he has a new left point
        rb.MovePosition( pos);  
    }
}
