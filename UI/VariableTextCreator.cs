using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VariableTextCreator : MonoBehaviour {

	private static VariableText m_VT;

	public static void Initialize()
	{
		m_VT = Resources.Load<VariableText>("Prefabs/VTextParent");

	}
	public static void CreateVT(string text, Transform location, Color textColour)
	{
		VariableText vt = Instantiate(m_VT);
		Vector2 screenPosition = Camera.main.WorldToScreenPoint(location.position);

		vt.transform.SetParent(GameObject.Find("Canvas").transform, false);
		vt.transform.position = screenPosition;
		vt.SetText(text);
		vt.SetColor(textColour);
	}
}
