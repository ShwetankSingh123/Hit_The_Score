using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
	public List<GameObject> target1;
	public float spawnRate = 1.0f;
	public Text scoreText;
	public int score = 0;
	public Text gameOverText;
	public bool isGameActive;
	public Button restartButton;
	public GameObject titlescreen;
	// Use this for initialization
	void Start () {
		

	}


	
	// Update is called once per frame
	void Update () {
		
	}

	IEnumerator SpawnTarget(){
		while (isGameActive) {
			yield return new WaitForSeconds (spawnRate);
			int index = Random.Range (0,target1.Count);
			Instantiate (target1 [index]);

		}

	}

	public void UpdateScore(int AddScore){
		score += AddScore;
		scoreText.text = "score  " + score.ToString();
	}

	public void GameOver(){
		restartButton.gameObject.SetActive (true);
		gameOverText.gameObject.SetActive (true);
		isGameActive = false;
	}

	public void RestartGame(){
		SceneManager.LoadScene (SceneManager.GetActiveScene().name);
	}

	public void StartGame(int difficulty){
		isGameActive = true;
		spawnRate /= difficulty;
		StartCoroutine (SpawnTarget());
		score = 0;
		UpdateScore (0);
		titlescreen.gameObject.SetActive (false);
	}
}
