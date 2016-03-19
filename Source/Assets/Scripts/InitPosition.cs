using UnityEngine;
using System.Collections;

public class InitPosition : MonoBehaviour {

	public GameObject player;

	// Use this for initialization
	void Start () {
		player.transform.position = transform.position;
	}
}
