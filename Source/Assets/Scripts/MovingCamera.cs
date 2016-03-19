using UnityEngine;
using System.Collections;

public class MovingCamera : MonoBehaviour {

	private bool estado;

	void Start () {
		estado = true;
	}

	void Update () {
		if (estado) {
			Vector3 actual = transform.localPosition;
			transform.localPosition = new Vector3(actual.x, actual.y, actual.z + 0.1f);
		}
	}

	public void paraMovimiento() {
		estado = false;
	}

	public void reanudaMovimiento() {
		estado = true;
	}
}
