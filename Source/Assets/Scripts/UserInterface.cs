using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UserInterface : MonoBehaviour {

	public Camera camara = null;

	private ChangeOptions cam;

	public void AvanzaCamara(Camera camara) {
		cam = camara.transform.GetComponent<ChangeOptions>();
		StartCoroutine(cam.Transicion(cam.posOpciones, cam.duracion));
		CambiaMenu();
	}

	public void RetrocedeCamara(Camera camara) {
		cam = camara.transform.GetComponent<ChangeOptions>();
		StartCoroutine(cam.Transicion(cam.posInicial, cam.duracion));
		CambiaMenu();
	}

	public void IniciaJuego() {
		Application.LoadLevel("prelevel1");
	}

	public void SalirJuego() {
		Application.Quit();
	}

	/**
	 *  Cambia los botones del menu segun esten activos actualmente
	 **/
	void CambiaMenu() {
		if (this.transform.FindChild("JuegoNuevo").gameObject.activeSelf) {
			this.transform.FindChild("JuegoNuevo").gameObject.SetActive(false);
			this.transform.FindChild("Opciones").gameObject.SetActive(false);
			this.transform.FindChild("Salir").gameObject.SetActive(false);
			
			this.transform.FindChild("Sonidos").gameObject.SetActive(true);
			this.transform.FindChild("Creditos").gameObject.SetActive(true);
			this.transform.FindChild("Atras").gameObject.SetActive(true);
		} else {
			this.transform.FindChild("JuegoNuevo").gameObject.SetActive(true);
			this.transform.FindChild("Opciones").gameObject.SetActive(true);
			this.transform.FindChild("Salir").gameObject.SetActive(true);
			
			this.transform.FindChild("Sonidos").gameObject.SetActive(false);
			this.transform.FindChild("Creditos").gameObject.SetActive(false);
			this.transform.FindChild("Atras").gameObject.SetActive(false);
		}
	}

	// Use this for initialization
	void Start () {
		this.transform.FindChild("Sonidos").gameObject.SetActive(false);
		this.transform.FindChild("Creditos").gameObject.SetActive(false);
		this.transform.FindChild("Atras").gameObject.SetActive(false);
		}

}
