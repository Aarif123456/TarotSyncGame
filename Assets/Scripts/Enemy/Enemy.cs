using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Basic Enemy script which will be the parent of all other enemy
public abstract class Enemy : MonoBehaviour
{
    public float horizontalSightRange = 8f,verticalSightRange=5f;
    public float speed =1f, searchTime =5f;
    protected const int PATROL=0, ATTACK=1, SEARCH=2;
    protected int state = PATROL;
    protected Rigidbody rb;
    protected float leftPoint, horizontalRange=5;
    protected Vector3 playerPosition;
    protected float currentSearchTime = 0;
    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        leftPoint = transform.position.x;
    }

    void Update(){
        playerPosition = GameObject.Find("Player").GetComponent<Transform>().position;
        GetState();
        if(state ==ATTACK)
            Attack();
        else if(state == SEARCH)
            Search();
        else
            Patrol();

    }

   void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "boots" ){
            GetHitByBoots();
            return;
        }
        if(other.gameObject.tag == "PlayerWeapon"){
            GetHitByWeapon(other.gameObject);
            return;
        }
        if(other.gameObject.tag == "Player"){
            CollideWithPlayer(other.gameObject);
            return;
        }
    }
    protected void GeneralMove(float v){
        Vector3 pos = transform.position;
        if(pos.x>=leftPoint+ horizontalRange|| pos.x<=leftPoint){
            speed*=-1;
        }             
        pos.x = Mathf.Min(Mathf.Max(pos.x,leftPoint),leftPoint+ horizontalRange); 
        rb.velocity = new Vector3(speed,0,0);     
        rb.MovePosition( pos);         
    }
    // General walking around
    protected virtual void Patrol(){
        GeneralMove(speed);
    }
    protected virtual void Search(){
        GeneralMove(speed*1.5f);
    }
    protected abstract void Attack();
    protected virtual void GetHitByBoots(){
        Destroy(this.gameObject);
    }
    // May need to differentiate between the type of weapon in the future
    protected virtual void GetHitByWeapon(GameObject o){
        Destroy(this.gameObject);
    }
    protected virtual void CollideWithPlayer(GameObject player){
        Main.S.PlayerDamage();
        Destroy(this.gameObject);
    }
    // if we lost player during attack some enemies may start to look for player or
    // if player adds range when patrolling 
    protected virtual void GetState(){
        if(Mathf.Abs(playerPosition.x-transform.position.x)<horizontalSightRange && Mathf.Abs(playerPosition.y-transform.position.y) <verticalSightRange){
            state = ATTACK; 
        }
        else if(state == ATTACK){
            state = SEARCH;
            currentSearchTime =0f;
        }
        else if(state == SEARCH){
            currentSearchTime += Time.deltaTime;
            if(currentSearchTime>searchTime){
                state = PATROL;
            }
        }
    }

}
