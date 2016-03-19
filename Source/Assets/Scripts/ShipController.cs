using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ShipController : MonoBehaviour {

	public float velocidad = 2f;

	public float xMax = 20f, xMin = -20f, yMax = 14f, yMin = -13f;

	public GameObject municion;
	public GameObject disparador1;
	public GameObject disparador2;

	public GameObject ghumo;
	private ParticleSystem humo;

	public GameObject camara;

	private float ratioDisparo = 1f;

	private float siguienteDisparo;
	private int toques;

	public AudioClip sonidoDisparo;

	private float puntos;

	void Start () {
		siguienteDisparo = Time.time;
		toques = 0;
		humo = ghumo.GetComponent<ParticleSystem>();
		humo.enableEmission = false;
		puntos = 0;
	}
	
	void Update () {
		if (Input.GetKeyDown(KeyCode.Space) && Time.time > siguienteDisparo) {
			siguienteDisparo = Time.time + ratioDisparo - puntos;

			if (sonidoDisparo)
				audio.PlayOneShot(sonidoDisparo);

			GameObject proyectil = Instantiate(municion, disparador1.transform.position, municion.transform.rotation) as GameObject;
			Physics2D.IgnoreCollision(proyectil.collider2D, this.collider2D);
			proyectil.rigidbody.velocity = new Vector3(0, 0, 3);
			proyectil.transform.parent = camara.transform;

			GameObject proyectil2 = Instantiate(municion, disparador2.transform.position, municion.transform.rotation) as GameObject;
			Physics2D.IgnoreCollision(proyectil2.collider2D, this.collider2D);
			proyectil2.rigidbody.velocity = new Vector3(0, 0, 3);
			proyectil2.transform.parent = camara.transform;
		}
	}

	public void cambiaRatioDisparo (int cantidad) {
		puntos = cantidad * 0.005f;
	}

	void FixedUpdate () {
		Vector3 actual = transform.localPosition;

		Vector3 dir = new Vector3(Input.GetAxis("Horizontal") * velocidad/10, Input.GetAxis("Vertical") * velocidad/10, 0);

		//Debug.Log("X: " + actual.x.ToString());
		//Debug.Log("Y: " + actual.y.ToString());

		if (actual.x + dir.x > xMax || actual.x + dir.x < xMin)
			dir.x = 0;
		if (actual.y + dir.y > yMax || actual.y + dir.y < yMin)
			dir.y = 0;

		transform.localPosition = new Vector3(actual.x + dir.x, actual.y + dir.y, actual.z + dir.z);
	}

	public void Tocada () {
		toques++;
		if (toques == 1) {
			humo.enableEmission = true;
		}
		if (toques == 3) {
			//Llama a la funcion GameOver
			GameController game = GetComponentInParent<GameController>();
			game.GameOver();
		}
	}

	void OnTriggerEnter (Collider other) {
		if (other.tag.Contains("Enemy") || other.tag.Contains("Ammo")) {
			Destroy(other.gameObject);
			Tocada ();
		}
	}
}
