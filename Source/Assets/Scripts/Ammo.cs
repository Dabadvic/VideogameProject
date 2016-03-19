using UnityEngine;
using System.Collections;

public class Ammo : MonoBehaviour {

	public Vector3 direction = new Vector3(0, 0, 1);
	
	public float speed = 7.0f;
	
	public float lifetime = 5.0f;

	private GameController controlador;

	public AudioClip sonidoExplosion;
	
	void Start () {
		//Invoca al metodo de destruir cuando se acaba su tiempo de vida
		Invoke ("DestroyMe", lifetime);

		controlador = GetComponentInParent<GameController>();
	}
	
	void FixedUpdate () {
		transform.position += direction * speed * Time.deltaTime;
	}
	
	void DestroyMe()
	{
		Destroy(gameObject);
	}

	void OnTriggerEnter (Collider other) {
		if (other.tag.Contains("Enemy")) {
			//Añadirlo a la puntuacion
			controlador.sumaPuntos(5);

			if (sonidoExplosion)
				audio.PlayOneShot(sonidoExplosion);

			Destroy(other.gameObject);
			DestroyMe();
		} else if (other.tag.Contains("Player")) {
			DestroyMe();
		} else if (other.tag.Contains("Boss")) {
			DestroyMe();
		}
	}
}
