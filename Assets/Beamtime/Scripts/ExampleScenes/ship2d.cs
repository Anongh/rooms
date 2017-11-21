using UnityEngine;
using System.Collections;
using eageramoeba.Lasers;

public class ship2d : MonoBehaviour {

	public GameObject laserObj;
	public float turn = 2;
	public float move = 0.05f;

	private Rigidbody2D rb2D;
	private laser laser;

	// Use this for initialization
	void Start () {
		rb2D = GetComponent<Rigidbody2D>();
		laser = laserObj.GetComponent<laser>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Space)) {
			laser.onM = true;
		}
		if (Input.GetKeyUp(KeyCode.Space)) {
			laser.onM = false;
		}

		if (Input.GetKey(KeyCode.LeftArrow)) {
			transform.Rotate(Vector3.forward * turn);
		}
		if (Input.GetKey(KeyCode.RightArrow)) {
			transform.Rotate(Vector3.forward * -turn);
		}
		if (Input.GetKey(KeyCode.UpArrow)) {
			transform.position += transform.up * move;
		}
		if (Input.GetKey(KeyCode.DownArrow)) {
			transform.position -= transform.up * move;
		}
	}
}
