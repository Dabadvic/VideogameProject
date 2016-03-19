using UnityEngine;
using System.Collections;

public class ChangeOptions : MonoBehaviour {

	public float duracion = 2.5f; 
	public Transform posOpciones; 
	public Transform posInicial;

	public IEnumerator Transicion(Transform destino, float duracion) { 
		float t = 0.0f; 
		Vector3 posInicial = transform.position; 

		while (t < 1.0f) { 
			t += Time.deltaTime * (Time.timeScale/duracion);
			transform.position = Vector3.Lerp(posInicial, destino.position, t);
			yield return 0;
		}
	}
}
