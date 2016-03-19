using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UserInterface2 : MonoBehaviour {


	void Start () {
		this.transform.FindChild("textPausa").gameObject.SetActive(false);
		this.transform.FindChild("textFinal").gameObject.SetActive(false);
		this.transform.FindChild("textGO").gameObject.SetActive(false);
		this.transform.FindChild("textR").gameObject.SetActive(false);
		this.transform.FindChild("textE").gameObject.SetActive(false);
		Time.timeScale = 1;
	}

	void Update () {
		if (Input.GetKeyDown(KeyCode.Escape)){
			if (Time.timeScale == 0) {
				Time.timeScale = 1;
				this.transform.FindChild("textPausa").gameObject.SetActive(false);
				this.transform.FindChild("textE").gameObject.SetActive(false);
			} else {
				Time.timeScale = 0;
				this.transform.FindChild("textPausa").gameObject.SetActive(true);
				this.transform.FindChild("textE").gameObject.SetActive(true);
			}
		}

		if (Input.GetKeyDown(KeyCode.E)) {
			Application.LoadLevel("MenuPrincipal");
		}

		if (Time.timeScale == 0) {
			this.transform.FindChild("textR").gameObject.SetActive(true);
		} else if (Time.timeScale == 1) {
			this.transform.FindChild("textR").gameObject.SetActive(false);
		}
		
		if (Input.GetKeyDown (KeyCode.R)) {
			Application.LoadLevel (Application.loadedLevel);
			Time.timeScale = 1;
		}
	}

	public void VolverMenu () {
		Application.LoadLevel("MenuPrincipal");
	}

	public void FinJuego () {
		Time.timeScale = 0;
		this.transform.FindChild("textFinal").gameObject.SetActive(true);
		this.transform.FindChild("textR").gameObject.SetActive(true);;
		this.transform.FindChild("textE").gameObject.SetActive(true);
	}
}
