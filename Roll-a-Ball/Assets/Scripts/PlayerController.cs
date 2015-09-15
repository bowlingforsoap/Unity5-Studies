using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

	public float speed;
	public Text countText;
	public Text winText;

	private Rigidbody rb;
	private int count;


	void Start () 
	{
		rb = GetComponent<Rigidbody> ();
		count = 0;		
		winText.text = "";
		setCountText ();
	}

	void FixedUpdate () 
	{
		float moveVertical = Input.GetAxis ("Vertical");
		float moveHorizontal = Input.GetAxis ("Horizontal");

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

		rb.AddForce (movement * speed);
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.CompareTag("Pick Up")) {
			other.gameObject.SetActive(false);
			count++;
			setCountText();
		}
	}

	private void setCountText() {
		countText.text = "Count: " + count;
		if (count >= 16)
			winText.text = "You win!";
	}
}
