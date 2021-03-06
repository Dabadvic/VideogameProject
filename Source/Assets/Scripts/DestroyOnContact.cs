﻿using UnityEngine;
using System.Collections;

public class DestroyOnContact : MonoBehaviour {

	void OnTriggerEnter(Collider other) {
		if (other.tag == "Ammo") {
			Destroy(other.gameObject);
		}
		Destroy(gameObject);
	}
}
