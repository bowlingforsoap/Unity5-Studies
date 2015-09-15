using UnityEngine;
using System.Collections;

public class Circler : MonoBehaviour {
	public Vector3 circlingSpeed;

	// Update is called once per frame
	void Update () {
		transform.Rotate (circlingSpeed * Time.deltaTime, Space.World);
	}
}
