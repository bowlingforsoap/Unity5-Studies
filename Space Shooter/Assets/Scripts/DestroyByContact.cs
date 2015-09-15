using UnityEngine;
using System.Collections;

public class DestroyByContact : MonoBehaviour {
	void OnTriggerEnter(Collider other) {
		if (other.CompareTag ("Bolt")) {
			Destroy (gameObject);
			Destroy (other.gameObject);
		}
	}
}
