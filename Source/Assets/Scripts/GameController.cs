using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameController : MonoBehaviour {
	public float esperaInicio = 1f;		//Tiempo de espera para iniciar la creacion de oleadas
	public float esperaOleada = 1f; 	//Tiempo de espera dentro de una oleada para mandar la/s siguiente/s nave/s
	public float siguiente = 1f; 	//Tiemop de espera para mandar la siguiente oleada

	public float rangoOleada = 10f;

	public SiguienteNivel sig;
	public GameObject enemy;	//Enemigo para las oleadas
	public GameObject boss;
	public GameObject spawnPoint;	//Punto de inicio de las oleadas
	private GameObject bossObject;

	public Text textoPuntos;
	public Text textoPausa;
	public Text textoR;
	public Text textoGO;

	public Button salir;

	private int puntos;
	private MovingCamera movimiento;
	private bool gameOver;
	private ShipController nave;

	public AudioClip blink;

	public void VolverMenu () {
		Application.LoadLevel("MenuPrincipal");
	}

	void Start () {
		StartCoroutine (Oleadas());
		movimiento = GetComponent<MovingCamera>();
		puntos = 0;
		textoPausa.enabled = false;
		textoR.enabled = false;
		textoGO.enabled = false;
		salir.gameObject.SetActive(false);
		gameOver = false;
		nave = GetComponentInChildren<ShipController>();
	}

	public void EmpiezaBoss () {
		StopCoroutine(Oleadas ());
		movimiento.paraMovimiento();
		Vector3 spawnPosition = new Vector3 (spawnPoint.transform.position.x, spawnPoint.transform.position.y, spawnPoint.transform.position.z - 6);
		bossObject = Instantiate (boss, spawnPosition, boss.transform.rotation) as GameObject;
		gameOver = true;
	}

	IEnumerator Oleadas() {
		yield return new WaitForSeconds (esperaInicio);
		while (true) {
			float rand = Random.Range((int)-rangoOleada, (int)rangoOleada);
			for (int i = 0; i < 3; i++) {
				Vector3 spawnPosition = new Vector3 (spawnPoint.transform.position.x + rand, spawnPoint.transform.position.y, spawnPoint.transform.position.z);
				Instantiate (enemy, spawnPosition, enemy.transform.rotation);
				yield return new WaitForSeconds (siguiente);
			}
			yield return new WaitForSeconds (esperaOleada);
		}
	}

	public void sumaPuntos (int nuevos) {
		puntos += nuevos;
		textoPuntos.text = "Puntos: " + puntos;
		audio.PlayOneShot(blink);
		nave.cambiaRatioDisparo(puntos);
	}

	void Update () {
		if (Input.GetKeyDown(KeyCode.Escape)){
			if (Time.timeScale == 0) {
				Time.timeScale = 1;
				movimiento.reanudaMovimiento();
				textoPausa.enabled = false;
				salir.gameObject.SetActive(false);
			} else {
				Time.timeScale = 0;
				movimiento.paraMovimiento();
				textoPausa.enabled = true;
				salir.gameObject.SetActive(true);
			}
		}

		if (Time.timeScale == 0) {
			textoR.enabled = true;
		} else if (Time.timeScale == 1) {
			textoR.enabled = false;
		}

		if (Input.GetKeyDown (KeyCode.R)) {
			Application.LoadLevel (Application.loadedLevel);
			Time.timeScale = 1;
			puntos = 0;
		}

		if (gameOver) {
			if (bossObject == null) {
				sig.BossDerrotado();
				gameOver = false;
			}
		}
	}

	public void GameOver () {
		Time.timeScale = 0;
		movimiento.paraMovimiento();
		textoGO.enabled = true;
	}
}
