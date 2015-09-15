using UnityEngine;
using System.Collections;

public class Rotator : MonoBehaviour {

	public Vector3 selfRotationSpeed;

	// Update is called once per frame
	void Update () {
		//rotation
		transform.Rotate (selfRotationSpeed * Time.deltaTime);
	}
}
