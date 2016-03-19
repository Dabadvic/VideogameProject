using UnityEngine;
using System.Collections;

public class LimiteInferior : MonoBehaviour {

	void OnTriggerEnter (Collider other) {
		if (other.tag.Contains("Enemy")) {
			Destroy(other.gameObject);
		}
	}
}
