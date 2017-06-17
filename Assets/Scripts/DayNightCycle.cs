using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNightCycle : MonoBehaviour {
	
	float hourOfDay = 9f;
	public float timeSpeed = 0.6f;

	// Update is called once per frame
	void Update () {
		transform.Rotate (Time.deltaTime * Time.timeScale * timeSpeed, 0f, 0f);
	}

	public float HourOfDay{
		get {
			return (transform.rotation.eulerAngles.x / 360f) * 24f;
		}
		set {
			Quaternion q = transform.rotation;
			q.eulerAngles = new Vector3 ((value / 24f) * 360f , q.eulerAngles.y, q.eulerAngles.z);
			transform.rotation = q;
		}
	}

}
