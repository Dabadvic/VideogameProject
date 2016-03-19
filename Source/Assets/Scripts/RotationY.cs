using UnityEngine;
using System.Collections;

public class RotationY : MonoBehaviour {

	public float x = 0f, y = 0f, z = 0f;

	void Update () {
		this.transform.Rotate(x, y, z);// = new Quaternion(0, transform.localRotation.y + 1, 0, 0);
	}
}
