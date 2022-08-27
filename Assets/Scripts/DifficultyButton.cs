using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DifficultyButton : MonoBehaviour {
	private Button button;
	private GameManager gameManager;
	public int difficulty;
	// Use this for initialization
	void Start () {
		Load ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Load(){
		button = GetComponent<Button> ();
		gameManager = GameObject.Find ("Game Manager").GetComponent<GameManager> ();
		button.onClick.AddListener (setDifficult);
	}

	void setDifficult(){
		Debug.Log (button.gameObject.name + "is clicked");
		gameManager.StartGame (difficulty);
	}
}
