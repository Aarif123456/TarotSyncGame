using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSphere : MonoBehaviour
{
	private bool isSafe = false, onGround = true, doubleJump = false;
	public float speed = 5f;
	public float maxVelocity = 10f;
	public float jumpForce = 500.0f;
    public LayerMask maskGround = -1;
    public int ySize = 1; //length og our player used to calculate distance
	Rigidbody rb;
	public bool IsSafe {
		get { return isSafe; }
		set { isSafe = value; }
	}
    public bool OnGround {
        get { return onGround; }
        set { onGround = value; }
    }
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        doubleJump = false;
    }
    void FixedUpdate () {
    	float xAxis = Input.GetAxis("Horizontal");                            
	    rb.AddForce ((xAxis* speed),0,0);
    	if (rb.velocity.magnitude >= maxVelocity) {
    		Vector3 v = rb.velocity.normalized * maxVelocity;
    		rb.velocity = v;
    	}
        // Ray downRay = new Ray(transform.position, -Vector3.up);
        if( Physics.Raycast(transform.position,-Vector3.up,ySize,maskGround)){
            this.OnGround = true;
            doubleJump = false;
        }
        else
            this.OnGround = false;
    }
    void Update () {
    	if (Input.GetKeyDown(KeyCode.Space) && (onGround ||!doubleJump))
    	{
            if(!onGround)
                doubleJump = true;
    		var rb = GetComponent<Rigidbody>();
    		rb.AddForce(Vector3.up * jumpForce);
    	}
    }

    void OnTriggerEnter(Collider other) {
     	//if hit the ground then player becomes grounded
     	if(other.gameObject.tag == "deathZone" && !isSafe){
            transform.position = new Vector3(0f,0.5f,0f);
            Main.S.lives -= 1;
            return;
        }
        if(other.gameObject.tag == "safeZone"){
        	this.isSafe = true;
        	return;
        }
        if(other.gameObject.tag == "collectible"){
        	Destroy(other.gameObject);
            return;
        }
        // if(other.gameObject.tag == "Ground_Tag"){
        //     this.OnGround =true;
        // }
    }

    void OnTriggerExit(Collider other)
    {
    	if(other.gameObject.tag == "safeZone"){
            this.isSafe = false;
            return;
        }
        // if(other.gameObject.tag == "Ground_Tag"){
        //      this.OnGround = false;
        // }
    }
}
