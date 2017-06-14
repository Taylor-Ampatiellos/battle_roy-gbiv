using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class Timer : MonoBehaviour {

	Text number;
	public int roundLength;

	// Use this for initialization
	void Start () {
		number = GetComponent<Text> ();
		StartCoroutine ("CountDown");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	IEnumerator CountDown () {
		for (int i = roundLength; i >= 0; i--) {
			number.text = i.ToString();
			yield return new WaitForSeconds (1);
		}
	}
}
