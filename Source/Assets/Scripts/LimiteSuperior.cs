using UnityEngine;
using System.Collections;

public class LimiteSuperior : MonoBehaviour {

	void OnTriggerEnter (Collider other) {
		if (other.tag.Contains("Ammo")) {
			Destroy(other.gameObject);
		}
	}
}
