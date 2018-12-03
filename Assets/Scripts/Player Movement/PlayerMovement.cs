using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    /*
     *This is the script that will allow for basic player movement
     * It contains left and right movement and a jump feature as of right now
     * Aidan Polese
     */

	//Sound
	public AudioSource jumpSound1;
	public AudioSource jumpSound2;
	public AudioSource swordSound;

	//Animation
	Animator anim;
	float speed;
	bool duckAnim;

    //Public and Private attribute declaration for general movement
	//Max Speed
    public float maxSpeed = 10f;

	//DUCKING
	//Ducking scale
	public float duckScale = 0.5f;
	//if the player is ducking
	public bool duckCheck;
	//So we dont see the player jump or move when the colider changes size
	//Used for changing cirlce size but I dont want to do that right now
	//public float offSetY = 0f;
	//private CircleCollider2D circleC2D;
	//private Vector2 origCenter;
	private BoxCollider2D boxC2D;
	private Vector2 boxOrigSize;
	private Vector2 boxOrigOffset;

	//JUMPING
	//Jump speed
	public float jumpSpeed = 10f;
	//LayerMask used for jumping
    public LayerMask playerMask;
	//Checking to see if the plaer is touching the ground
	private bool isGrounded;
	//The player groundedCheck transform component
	private Transform groundedCheck;

	//DIRECTION FACING
	//Detecting which way the player is looking
    private bool lookRight = true; //false means looking left

	//PHYSICS AND MOVEMENT
	//The player transform component
    private Transform playerTrans;
	//The player rigidBody
    private Rigidbody2D playerBody;

	//PLAYER ABILITIES
	//Attributes here are used for when the player is randomly rolled and here are the abilities they can have
	//They have accessors associated with them for setting them
	//Double jump, if the have the jump ability and if they have a doublejump charge available 
	private bool doubleJumpAbility;
	private bool doubleJumpCharge;
	//Long Jump, if they have the long jump ability and if the have a long jump charge available
	private bool longJumpAbility;
	private bool longJumpCharge;

	void Start () {
		Time.timeScale = 1;
		gameObject.tag = "Player";
        playerTrans = this.GetComponent<Transform>();
        playerBody = this.GetComponent<Rigidbody2D>();
        groundedCheck = GameObject.Find(this.name + "/PlayerGroundCheck").transform;
		anim = GetComponent<Animator>();
		setDoubleJump (); //Used for testing as of right now
		setLongJump ();
		if (doubleJumpAbility == true) {
			doubleJumpCharge = true;
		}
		if (longJumpAbility == true) {
			longJumpCharge = true;
		}
		//Audio
		AudioSource[] audios = GetComponents<AudioSource> ();
		jumpSound1 = audios [0];
		jumpSound2 = audios [1];
		swordSound = audios [2];
	}

	protected void Awake () {
		//Used for changing circle colider size, but I dont want to do that right now
		//circleC2D = GetComponent<CircleCollider2D> ();
		//origCenter = circleC2D.offset;
		boxC2D = GetComponent<BoxCollider2D> ();
		boxOrigSize = boxC2D.size;
		boxOrigOffset = boxC2D.offset;
	}

	void FixedUpdate () {
		speed = Input.GetAxisRaw ("Horizontal");
		bool jumpButton = Input.GetButtonDown ("Jump");
        isGrounded = Physics2D.Linecast(playerTrans.position, groundedCheck.position, playerMask);
		anim.SetBool ("isGrounded", isGrounded);
		anim.SetFloat ("Speed", Mathf.Abs (speed));
        move(speed);
		var canDuck = Input.GetAxisRaw ("Vertical");
		if (canDuck < 0 && !duckCheck && isGrounded) {
			duck (true);
		} else if (duckCheck && canDuck >= 0) {
			duck (false);
		}
        if (speed > 0 && !lookRight) {
            flip();
        }
        else if (speed < 0 && lookRight) {
            flip();
        }
		if (jumpButton && !duckCheck) {
			jump();
		}
		if (jumpButton && doubleJumpAbility == true && isGrounded == false && doubleJumpCharge == true) {
			doubleJump ();
		}
		if (doubleJumpAbility == true && isGrounded == true) {
			doubleJumpCharge = true;
		}
		//if (Input.GetButtonDown("Fire1") && longJumpAbility == true && isGrounded == true && longJumpCharge == true) {
		//	longJump ();
		//}
		if (longJumpAbility == true && isGrounded == true) {
			longJumpCharge = true;
		}

    }

    void flip() {
        lookRight = !lookRight;
        Vector3 tScale = transform.localScale;
        tScale.x *= -1;
        transform.localScale = tScale;
    }

    public void move(float hMove) {
        Vector2 moveV = playerBody.velocity;
        moveV.x = hMove * maxSpeed;
        playerBody.velocity = moveV;
    }

    private void jump() {
        if (isGrounded) {
            playerBody.velocity += jumpSpeed * Vector2.up;
			jumpSound1.Play ();
        }
    }

	//There are no duck/slide animations yet
	private void duck (bool check){
		duckCheck = check;
		//var size = circleC2D.radius;
		//float newOffSetY;
		//float sizeReciprocal;
		if (duckCheck) {
			//sizeReciprocal = duckScale;
			//newOffSetY = circleC2D.offset.y - size / 2 + offSetY;
			boxC2D.offset = new Vector2 (0, -1.8f);
			boxC2D.size = new Vector2 (6, 2);
			duckAnim = true;
			anim.SetBool ("Duck", duckAnim);
		} else {
			//sizeReciprocal = 1 / duckScale;
			//newOffSetY = origCenter.y;
			boxC2D.size = boxOrigSize;
			boxC2D.offset = boxOrigOffset;
			duckAnim = false;
			anim.SetBool ("Duck", duckAnim);
		}
		//size = size * sizeReciprocal;
		//circleC2D.radius = size;
		//circleC2D.offset = new Vector2 (circleC2D.offset.x, newOffSetY);
	}

	private void doubleJump () {
		doubleJumpCharge = false;
		playerBody.velocity = Vector2.zero;
		playerBody.velocity += jumpSpeed * Vector2.up;
		jumpSound2.Play ();
	}

	//DOESN'T WORK RIGHT NOW
	private void longJump () {
		longJumpCharge = false;
		Vector2 moveV = playerBody.velocity;
		moveV.x = 10f * maxSpeed;
		moveV.y = maxSpeed;
		playerBody.velocity = moveV;

		//Vector2 moveV = playerBody.velocity;
		//playerBody.velocity = Vector2.zero;
		//playerBody.velocity = new Vector2 (10f, 10f);
		//playerBody.velocity += jumpSpeed * Vector2.up;
	}

	public void setDoubleJump() {
		doubleJumpAbility = true;
	}

	public void setLongJump() {
		longJumpAbility = true;
	}
}
