using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FinalScore : MonoBehaviour {

	// Use this for initialization
	void Start ()
	{
		TextMeshProUGUI finalScoreText = GetComponent<TextMeshProUGUI>();
		GameSession gameSession = FindObjectOfType<GameSession>();
		finalScoreText.text = "Final Score: " + gameSession.GameScore;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
