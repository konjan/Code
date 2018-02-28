using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapAnchor : MonoBehaviour {

	public GameObject Player;

	public int cameraSize = 5;

	// Use this for initialization
	void Start ()
	{
	}
	
	void Update()
	{
		this.GetComponentInChildren<Camera>().orthographicSize = cameraSize;
	}
	// Update is called once per frame
	void LateUpdate ()
	{
		transform.position = Player.transform.position;

		if (Input.GetKeyDown(KeyCode.T))
		{
			if (cameraSize == 20)
				cameraSize = 5;
			else
				cameraSize += 5;
		}
	}
}
