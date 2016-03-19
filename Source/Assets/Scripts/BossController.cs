using UnityEngine;
using System.Collections;

public class BossController : MonoBehaviour {
	private int vida;

	public GameObject municion;
	public GameObject disparador1;
	public GameObject disparador2;

	private float ratioDisparo;
	private float siguienteDisparo;
	private float movimiento;
	private int dir; //0 derecha, 1 izquierda
	private float distanciaMovimiento;

	public float velocidad = 0.01f;

	void Start () {
		vida = 12;
		siguienteDisparo = Time.time;
		ratioDisparo = 0.5f;
		movimiento = 0;
		dir = 0;
		distanciaMovimiento = 12.0f;
	}
	
	void Update () {
		if (Time.time > siguienteDisparo) {
			siguienteDisparo = Time.time + ratioDisparo;

			GameObject proyectil = Instantiate(municion, disparador1.transform.position, municion.transform.rotation) as GameObject;
			Physics2D.IgnoreCollision(proyectil.collider2D, this.collider2D);

			GameObject proyectil2 = Instantiate(municion, disparador2.transform.position, municion.transform.rotation) as GameObject;
			Physics2D.IgnoreCollision(proyectil2.collider2D, this.collider2D);
		}

		//Moverse izquierda y derecha
		Vector3 actual = transform.localPosition;
		if (dir == 0) {
			transform.localPosition = new Vector3(actual.x + velocidad, actual.y, actual.z);
			movimiento += velocidad;
			if (movimiento > distanciaMovimiento)
				dir = 1;
		} else if (dir == 1) {
			transform.localPosition = new Vector3(actual.x - velocidad, actual.y, actual.z);
			movimiento -= velocidad;
			if (movimiento < -distanciaMovimiento)
				dir = 0;
		}
	}


	void OnTriggerEnter (Collider other) {
		if (other.tag == "Ammo") {
			vida--;
			if (vida <= 0) {
				//muerto
				Destroy (gameObject);
			}
		}
	}
}
