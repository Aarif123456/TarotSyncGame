using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Basic Enemy script which will be the parent of all other enemy
public abstract class Enemy : MonoBehaviour
{
    public float sightRange = 5;
    public float speed =1f;
    protected const int PATROL=0, ATTACK=1, SEARCH=2;
    protected int state = PATROL;
    protected Rigidbody rb;
    protected float leftPoint, horizontalRange=5;
    protected Vector3 playerPosition;
    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        leftPoint = transform.position.x;
    }

    void Update(){
        playerPosition = GameObject.Find("Player").GetComponent<Transform>().position;
        if(state == ATTACK || lookForPlayer())
            attack();
        else if(state == SEARCH)
            search();
        else
            patrol();

    }

   void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "boots" ){
            getHitByBoots();
            return;
        }
        if(other.gameObject.tag == "Weapon"){
            getHitByWeapon(other.gameObject);
            return;
        }
        if(other.gameObject.tag == "Player"){
            collideWithPlayer(other.gameObject);
            // Main.S.DamagePlayer(); //**Damage player 
            return;
        }
    }
    // General walking around
    protected abstract void patrol();
    // if we lost player during attack some enemies may start to look for player or
    // if player adds range when patrolling 
    protected abstract bool lookForPlayer();
    protected abstract void search();
    protected abstract void attack();
    protected virtual void getHitByBoots(){
        Destroy(this.gameObject);
    }
    // May need to differentiate between the type of weapon in the future
    protected virtual void getHitByWeapon(GameObject o){
        Destroy(this.gameObject);
    }
    protected virtual void collideWithPlayer(GameObject player){
        Main.S.Die();
        Destroy(this.gameObject);
    }
}
