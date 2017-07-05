using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class PercentageBar : MonoBehaviour {

	float fillAmt;
	Image image;
	Timer ScoreKeep;

	private float p1_prop;
	private float p2_prop;

	void Start() {
		image = GetComponent<Image>();
		fillAmt = 0.5f;
		ScoreKeep = GameObject.FindGameObjectWithTag ("Canvas").GetComponent<Timer> ();
	}

	void Update() {
		p1_prop = ScoreKeep.p1_score / ((float)ScoreKeep.p1_score + (float)ScoreKeep.p2_score);
		image.fillAmount = p1_prop;
	}
}
