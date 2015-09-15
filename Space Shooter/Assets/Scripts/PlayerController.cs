using UnityEngine;
using System.Collections;

[System.Serializable]
public class Boundary {
	public float xMin, xMax, zMin, zMax; 
}

public class PlayerController : MonoBehaviour {

	public float speed;
	public float tilt;
	public Boundary boundary;
	public Transform boltSpawnTransform;
	public GameObject shot;
	public float fireRate;
	
	private Rigidbody rb;
	private float nextShot;

	void Start() {
		rb = GetComponent<Rigidbody> ();
	}

	void Update() {
		if (Input.GetButton ("Jump") && Time.time > nextShot) {
			nextShot = Time.time + fireRate;
			Instantiate (shot, boltSpawnTransform.position, Quaternion.Euler(new Vector3(0.0f, 0.0f, 0.0f)));
		}
	}

	void FixedUpdate() {
		float moveVertical = Input.GetAxis ("Vertical");
		float moveHorizontal = Input.GetAxis ("Horizontal");

		rb.velocity =  new Vector3(moveHorizontal * speed, 0.0f, moveVertical * speed);

		rb.position = new Vector3
		(
			Mathf.Clamp (rb.position.x, boundary.xMin, boundary.xMax),
			0.0f,
			Mathf.Clamp (rb.position.z, boundary.zMin, boundary.zMax)
		);

		rb.rotation = Quaternion.Euler (0.0f, 0.0f, rb.velocity.x * tilt);

	}
}
