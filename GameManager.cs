using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Mode
{
	TownMode,
	BuildMode,
	DungeonMode
}

public class GameManager : MonoBehaviour {

	#region Singleton

	void Awake()
	{
		if(instance != null)
		{
			Debug.Log("Fix the GameManager");
			return;
		}

		instance = this;
	}

	public static GameManager instance;

	#endregion

	public Mode GameMode = Mode.TownMode;
	public Dialogue testDialogue;

	CharacterData CurrentPC;
	CharacterData CurrentNPC;

	public int tempilvl =1;
	public int tempwlvl =1;
	public int baseexp = 30;

	// Use this for initialization
	void Start ()
	{
		CurrentPC = GameObject.Find("Player").GetComponent<CharacterData>();
		CurrentNPC = CurrentPC;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetKeyDown(KeyCode.J))
			DialogueManager.instance.StartDialogue(testDialogue);
		if (Input.GetKeyDown(KeyCode.K))
			DialogueManager.instance.DisplaySentences();
		if (Input.GetKeyDown(KeyCode.C))
			LevelCalculator();
		if (Input.GetKeyDown(KeyCode.V))
			tempwlvl++;
		if (Input.GetKeyDown(KeyCode.F))
			tempwlvl = 1;
		if (Input.GetKeyDown(KeyCode.B))
			tempilvl++;
		if (Input.GetKeyDown(KeyCode.G))
			tempilvl = 1;
    }

	public void ModeSwitch(Mode mode)
	{
		GameMode = mode;
	}

	void LevelCalculator()
	{
		float endlevel;
		endlevel = tempwlvl + tempilvl * (tempilvl + 10);
		Debug.Log(endlevel);
	}
}
