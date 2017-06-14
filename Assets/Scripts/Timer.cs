using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class Timer : MonoBehaviour {

	public GameObject p1_text;
	public GameObject p2_text;

	private Text number;
	private Text p1;
	private Text p2;

	public int roundLength;

	private GameObject[] p1_points;
	private GameObject[] p2_points;

	private int p1_score;
	private int p2_score;

	// Use this for initialization
	void Start () {
		number = GetComponent<Text> ();
		p1 = p1_text.GetComponent<Text> ();
		p2 = p2_text.GetComponent<Text> ();
		StartCoroutine ("CountDown");
	}
	
	// Update is called once per frame
	void Update () {
		p1_points = GameObject.FindGameObjectsWithTag ("p1_point");
		p2_points = GameObject.FindGameObjectsWithTag ("p2_point");

		p1_score = p1_points.Length;
		p2_score = p2_points.Length;

		p1.text = "P1 Score:" + "\n" + p1_score.ToString();
		p2.text = "P2 Score:" + "\n" + p2_score.ToString();
	}

	IEnumerator CountDown () {
		for (int i = roundLength; i >= 0; i--) {
			number.text = i.ToString();
			yield return new WaitForSeconds (1);
		}

		winner ();
	}

	void winner () {
		if (p1_score > p2_score) {
			number.text = "PLAYER 1 WINS!!!";
		} else if (p2_score > p1_score) {
			number.text = "PLAYER 2 WINS!!!";
		} else {
			number.text = "IT'S A TIE!!!";
		}
	}
}
