using UnityEngine;
using System.Collections;
using UnityEngine.Events;

public class Movement : MonoBehaviour {

	private Rigidbody rb;
	public Animator anim;
	public AnimationCurve speedCurve;
	public float accelerateTime = 1.0f;

	private float speedModifier = 0.2f;
	private bool isMoving;
	public bool isGrounded = true;
	private bool isBlocking = false;

	// Use this for initialization
	void Start () {
		anim = gameObject.GetComponentInChildren<Animator>();
		rb = gameObject.GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (GameManager.instance.GameMode == Mode.TownMode || GameManager.instance.GameMode == Mode.DungeonMode)
			speedModifier = 0.2f;
		else
			speedModifier = 0.3f;
	}

	void FixedUpdate()
	{
		FreeMovement();

		if (Input.GetButtonDown("YButton") && isGrounded == true)
		{
			Jump();
		}
	}

	void FreeMovement()
	{
		//-----Animation Code-----//
		if ((Input.GetAxis("LeftVertical") < 0 || Input.GetAxis("LeftVertical") > 0 || Input.GetAxis("LeftHorizontal") < 0 || Input.GetAxis("LeftHorizontal") > 0))
			isMoving = true;
		else
			isMoving = false;

		anim.SetFloat("MovementX", Mathf.Abs(Input.GetAxis("LeftHorizontal")));
		anim.SetFloat("MovementY", Mathf.Abs(Input.GetAxis("LeftVertical")));

		anim.SetBool("isMoving", isMoving);

		Vector3 inputDirection = new Vector3(Input.GetAxis("LeftHorizontal"), 0, Input.GetAxis("LeftVertical"));
		inputDirection = Camera.main.transform.TransformDirection(inputDirection);
		inputDirection.y = 0;

		Vector3 moveDirection = inputDirection.normalized;

		//-----Move Player in the desired direction
		rb.transform.position += moveDirection * speedModifier;
		//-----Rotate Player towards desired Joystick direction
		if (inputDirection.magnitude != 0)
		{
			Quaternion targetRotation = Quaternion.LookRotation(moveDirection, Vector3.up);
			rb.transform.rotation = Quaternion.RotateTowards(rb.transform.rotation, targetRotation, 1000 * Time.deltaTime);
		}

		//Testing if the player is above the ground.
		if (Physics.Raycast(transform.position, Vector3.down, 2) == false && isGrounded == true)
		{
			isGrounded = false;
			anim.SetBool("isGrounded", isGrounded);
		
			anim.SetTrigger("FallTrigger");
		}
	}
	void Jump()
	{
		rb.AddForce(0, 8, 0, ForceMode.Impulse);

		anim.SetBool("isGrounded", isGrounded = false);
		anim.SetTrigger("JumpPressed");
	}

	void Attack()
	{
		Block();


	}

	void Block()
	{
		//-----BLOCK CODE-----//
		if (isGrounded && Input.GetButtonDown("RTrigger"))
		{
			isBlocking = true;
			anim.SetBool("isBlocking", isBlocking);
			anim.SetTrigger("Block");
		}
		else if (Input.GetButtonUp("RTrigger"))
		{
			isBlocking = false;
			anim.SetBool("isBlocking", isBlocking);
		}
	}

	void OnCollisionEnter(Collision col)
	{
		//Player Landed
		if (col.gameObject.tag == "Ground")
		{
			anim.SetBool("isGrounded", isGrounded = true);
		}
	}
}