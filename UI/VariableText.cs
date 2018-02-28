using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VariableText : MonoBehaviour {

	public Animator textAnimator;
	private Text variableText;

	// Use this for initialization
	void Awake ()
	{
		AnimatorClipInfo[] clipInfo = textAnimator.GetCurrentAnimatorClipInfo(0);
		Destroy(gameObject, clipInfo[0].clip.length);
		variableText = textAnimator.GetComponent<Text>();
	}
	public void SetText (string text)
	{
		variableText.text = text;
	}

	public void SetColor(Color Colour)
	{
		variableText.color = Colour;
	}
}
