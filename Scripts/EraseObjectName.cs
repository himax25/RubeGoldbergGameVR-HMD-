using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EraseObjectName : MonoBehaviour {

	public Text objName;
	private Color zeroColor = new Color(1, 1, 1, 0);
	// Use this for initialization
	void Start () {
		StartCoroutine (EraseObjName ());
	}
	// Erase obj name
	private IEnumerator EraseObjName () {
		yield return new WaitForSeconds (1.5f);
		objName.CrossFadeColor (zeroColor, 1.5f, true, true);
	}
}
