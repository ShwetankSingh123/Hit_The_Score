using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour {
	private Rigidbody targetRb;
	private float minSpeed = 15;
	private float maxSpeed = 17;
	private float maxTorque = 5;
	private float xRange = 2.5f;
	public float yRange = -1.5f;
	private GameManager gameManager;
	public int pointValue;
	public ParticleSystem explosionParticle;


	// Use this for initialization
	void Start () {
		targetRb = GetComponent<Rigidbody> ();
		gameManager = GameObject.Find ("Game Manager").GetComponent<GameManager> ();
		targetRb.AddForce (RandomForce(), ForceMode.Impulse);
		targetRb.AddTorque (RandomTorque(), RandomTorque(), RandomTorque(), ForceMode.Impulse);
		transform.position = RandomSpawnPos();

	}

	Vector3 RandomForce(){
		return Vector3.up * Random.Range (minSpeed,maxSpeed);
	}

	float RandomTorque(){
		return Random.Range (-maxTorque, maxTorque);
	}

	Vector3 RandomSpawnPos(){
		return new Vector3 (Random.Range (-xRange, xRange), -yRange);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnMouseDown(){
		if (gameManager.isGameActive) {
			Destroy (gameObject);
			Instantiate (explosionParticle, transform.position, explosionParticle.transform.rotation);
			gameManager.UpdateScore (pointValue);
		}
	}

	private void OnTriggerEnter(){
		Destroy (gameObject);
		if (!gameManager.CompareTag ("Bad")) {
			gameManager.GameOver ();

		}
	}


}
