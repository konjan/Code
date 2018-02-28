using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AIState
{
	Seek,
	Flee,
	Attack,
	Defend
}

public class AIPathing : MonoBehaviour {

	public Rigidbody m_rb;

	public bool test = true;

	public GameObject Target;

	public float distance;
	// Use this for initialization
	void Start ()
	{
		m_rb = transform.GetComponent<Rigidbody>();

		Target = GameObject.Find("Player");
	}
	
	// Update is called once per frame
	void Update ()
	{
		distance = Vector3.Distance(Target.transform.position, transform.position);

		if (test == true)
			Seek();
		else if (test != true)
			Flee();
	}

	private void Seek()
	{
		Vector3 target = new Vector3();

		target = Target.transform.position - transform.position;
		target.y = 0;

		transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(target), Time.deltaTime * 5 /*ADD A ROTATION SPEED VARIABLE*/);

		if (Vector3.Distance(Target.transform.position, transform.position) > 3)
		{
			transform.position += transform.forward * /*ADD A NORMAL SPEED VARIABLE*/ 3 * Time.deltaTime;
		}
	}
	private void Flee()
	{
		Vector3 target = new Vector3();

		target = transform.position - Target.transform.position - (transform.forward * -1);
		target.y = 0;

		if (Vector3.Distance(Target.transform.position, transform.position) < 25)
		{
			//This will likely be changed to accomodate movement animation rather than normal movement
			transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(target), Time.deltaTime * 10 /*ADD A ROTATION SPEED VARIABLE*/);
			transform.position = Vector3.MoveTowards(transform.position, target, 3 * Time.deltaTime);
		}
    }
	private void Retreat()
	{
		Vector3 target = new Vector3();

		target = transform.position - Target.transform.position - transform.forward;
		target.y = 0;

		if (Vector3.Distance(Target.transform.position, transform.position) < 25)
			transform.position = Vector3.MoveTowards(transform.position, target, 3 * Time.deltaTime);
	}
}