using UnityEngine;
using System.Collections;

public class FinJuego : MonoBehaviour {
	public UserInterface2 ui2;

	void OnTriggerEnter (Collider other) {
		if (other.tag == "Player") {
			ui2.FinJuego();
		}
	}
}
