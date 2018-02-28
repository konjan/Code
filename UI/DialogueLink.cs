using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueLink : ScriptableObject
{
	public List<Dialogue> dialogueOptions;

	public void DialogueTrigger(int triggerID)
	{
		if (triggerID <= dialogueOptions.Count)
			DialogueManager.instance.StartDialogue(dialogueOptions[triggerID]);
		else
		{
			Debug.Log("triggerID out of bounds " + triggerID);
			return;
		}
	}
}
