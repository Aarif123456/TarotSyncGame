using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    [Header("Set in Inspector: Player")]
	public float speed = 5f;
	public float maxVelocity = 10f;
	public float jumpForce = 500.0f;
    public LayerMask maskGround = -1;
    public int ySize = 1; //length of our player used to calculate distance
    public float runningBoast =1.2f;

    [Header("Set in Dynamically")]
    public float running = 1f;
    public bool isSafe = false, onGround = true, doubleJump = false;
	public Rigidbody rb;

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
	    rb.AddForce ((xAxis* speed *running),0,0);
        if(Input.GetKeyDown(KeyCode.LeftControl)||Input.GetKeyDown(KeyCode.RightControl)){
            running =runningBoast;
        }
         if(Input.GetKeyUp(KeyCode.LeftControl)||Input.GetKeyUp(KeyCode.RightControl)){
            running =1f;
        }
    	if (rb.velocity.magnitude >= (maxVelocity*running)) {
    		Vector3 v = rb.velocity.normalized * (maxVelocity*running);
    		rb.velocity = v;
    	}
        if( Physics.Raycast(transform.position,-Vector3.up,ySize,maskGround)){
            this.OnGround = true;
            doubleJump = false;
        }
        else{
            this.OnGround = false;
        }
        if (Input.GetKeyDown(KeyCode.Space) && (onGround ||!doubleJump))
        {
            if(!onGround)
                doubleJump = true;
            var rb = GetComponent<Rigidbody>();
            rb.AddForce(Vector3.up * jumpForce);
        }
    }
    // void Update () {
    // }

    void OnTriggerEnter(Collider other) {
     	//if hit the ground then player becomes grounded
     	if(other.gameObject.tag == "deathZone" && !isSafe){
            // transform.position = new Vector3(0f,0.5f,0f);
            Main.S.PlayerDamage();
            Destroy(this);
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
    }

    void OnTriggerExit(Collider other)
    {
    	if(other.gameObject.tag == "safeZone"){
            this.isSafe = false;
            return;
        }
    }
}
