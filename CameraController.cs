using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	public GameObject MainCharacter;

	public float m_fTMD = 7.0f;
	public Vector2 m_v2BMD = new Vector2(20, 10);

	private Vector3 Direction;

	private float rotationX = 0;
	private float rotationY = 0;

	private Vector3 Sensitivity = new Vector3(4.0f, 1.0f, 1.0f);

	// Use this for initialization
	void Start ()
	{
		GameManager.instance = GameObject.Find("GameManager").GetComponent<GameManager>();
		Direction = new Vector3(0, 0, -m_fTMD);
		transform.position = MainCharacter.transform.forward.normalized + Direction;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetButtonDown("Select"))
			ModeSwitch();
		RotationUpdate();
	}

	private void RotationUpdate()
	{
		rotationX -= Input.GetAxis("RightHorizontal") * Sensitivity.x;
		if(GameManager.instance.GameMode == Mode.TownMode)
			rotationY -= Input.GetAxis("RightVertical") * Sensitivity.y;

		rotationY = Mathf.Clamp(rotationY, 4, 55);
		Quaternion Rotation = Quaternion.Euler(rotationY, rotationX, 0);
		transform.position = Vector3.Lerp(transform.position, MainCharacter.transform.position + Rotation * Direction, 20);

		//-----Lookat Player position
		transform.LookAt(MainCharacter.transform.position);
	}

	private void ModeSwitch()
	{
		if (GameManager.instance.GameMode == Mode.TownMode)
		{
			GameManager.instance.GameMode = Mode.BuildMode;
			Direction = new Vector3(0, m_v2BMD.x, -m_v2BMD.y);
		}
		else if (GameManager.instance.GameMode == Mode.BuildMode)
		{
			GameManager.instance.GameMode = Mode.TownMode;
			Direction = new Vector3(0, 0, -m_fTMD);
		}
	}
}
