using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour {

	#region Singleton

	void Awake()
	{
		if (instance != null)
		{
			Debug.Log("Fix the GameManager");
			return;
		}

		instance = this;

		sentences = new Queue<string>();
	}

	public static DialogueManager instance;

	#endregion

	public Text nameText;
	public Text dialogueText;

	public Animator anim;

	public Queue<string> sentences;
	private IEnumerator typeSentence;

	public void StartDialogue(Dialogue dialogue)
	{
		anim.SetBool("isOpen", true);
		//Adds name to the UI
		nameText.text = dialogue.name;

		sentences.Clear();

		foreach(string sentence in dialogue.sentences)
		{
			sentences.Enqueue(sentence);
		}

		DisplaySentences();
	}

	public void DisplaySentences()
	{
		if(sentences.Count == 0)
		{
			EndDialogue();
			return;
		}

		string tempSentence = sentences.Dequeue();

		StopAllCoroutines();
		StartCoroutine(TypeSentence(tempSentence));
	}

	IEnumerator TypeSentence(string sentence)
	{
		dialogueText.text = "";
		foreach(char letter in sentence.ToCharArray())
		{
			dialogueText.text += letter;
			yield return null;
		}
	}

	void EndDialogue()
	{
		anim.SetBool("isOpen", false);
		Debug.Log("ended");
	}

}
