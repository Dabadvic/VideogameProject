using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SiguienteNivel : MonoBehaviour {
	public Text textoFinal;
	public GameController controlador;

	void Start () {
		textoFinal.enabled = false;
	}

	void OnTriggerEnter (Collider other) {
		if (other.tag.Contains("Finish")) {
			//Empieza el boss
			controlador.EmpiezaBoss();
			Debug.Log("Empieza boss");
		}
	}

	public void BossDerrotado () {
		//Para el tiempo
		Time.timeScale = 0;
		//Muestra que se ha completado el nivel
		textoFinal.enabled = true;
		//Cargar siguiente nivel
		Application.LoadLevel("prelevel2");
	}
}
