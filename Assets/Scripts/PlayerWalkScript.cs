using UnityEngine;
using System.Collections;

public class PlayerWalkScript : MonoBehaviour {
	public float speed = 1;
	public Quaternion originalRotationValue; // declare this as a Quaternion
	float rotationResetSpeed = 1.0f;

	void Start(){
		originalRotationValue = transform.rotation; // save the initial rotation
	}
	
	void Update ()
	{
		if (Input.GetKey (KeyCode.W) || Input.GetKey (KeyCode.A) || Input.GetKey (KeyCode.S) || Input.GetKey (KeyCode.D)) {
			transform.Rotate (Vector3.down, speed * 2);
		}
		else {
			transform.rotation = Quaternion.Slerp (transform.rotation, originalRotationValue, Time.time * rotationResetSpeed); 
			transform.rotation = Quaternion.Euler(transform.parent.root.transform.rotation.eulerAngles.x, transform.parent.root.transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);
		}
	}
}