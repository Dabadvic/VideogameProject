using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Prenivel2 : MonoBehaviour {
	public Text textoEspacio;

	void Start () {
		StartCoroutine (Parpadear());
	}

	IEnumerator Parpadear () {
		while(true) {
			yield return new WaitForSeconds (1);
			textoEspacio.enabled = !textoEspacio.enabled;
		}
	}

	void Update () {
		if (Input.anyKeyDown) {
			Application.LoadLevel("level2");
		}
	}
}
