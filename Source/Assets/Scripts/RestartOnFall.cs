using UnityEngine;
using System.Collections;

public class RestartOnFall : MonoBehaviour {

	void Update () {
		if(transform.position.y < -3) {
			Debug.Log("Has caido del escenario");
			Application.LoadLevel(Application.loadedLevel);
		}
	}

	void OnTriggerEnter (Collider other) {
		Debug.Log("Game Over");
		Application.LoadLevel(Application.loadedLevel);
	}
}
