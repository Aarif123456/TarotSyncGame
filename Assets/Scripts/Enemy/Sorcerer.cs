using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sorcerer : Enemy
{
	public GameObject projectile;
	public float firingRate =2f, lastFired =0, bulletForce=2f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    protected override void Patrol(){
       
    }

    protected override void Search(){
        
    }
    protected override void Attack(){
    	lastFired += Time.deltaTime;
        if(lastFired>=firingRate){
        	Shoot();
        	lastFired =0f;
        }

    }
    public void Shoot(){
    	GameObject shot = Instantiate<GameObject>(projectile);
    	Vector3 pos = transform.position;
    	pos.y +=1;
    	shot.transform.position = pos;
    	shot.transform.rotation = Quaternion.LookRotation(playerPosition);
    	Debug.Log((playerPosition - transform.position).normalized);
    	shot.GetComponent<Rigidbody>().AddForce((playerPosition - transform.position).normalized * bulletForce); 
    	// shot.GetComponent<Rigidbody>().AddForce(new Vector3((playerPosition.x - shot.transform.position.x)*2f,0f,0f));
    	Destroy(shot,5f);
    	
    }

}
