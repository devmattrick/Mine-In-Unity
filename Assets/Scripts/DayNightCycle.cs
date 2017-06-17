using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNightCycle : MonoBehaviour {

	[Range(0, 24)]
	public float hourOfDay = 9f;
	public float timeSpeed = 0.6f;

	// Update is called once per frame
	void Update () {
		Quaternion q = transform.rotation;
		q.eulerAngles = new Vector3 (
			( (hourOfDay / 24f) * 360f ) + 90f,
			q.eulerAngles.y,
			q.eulerAngles.z
		);
		transform.rotation = q;
		hourOfDay += Time.deltaTime * Time.timeScale * timeSpeed;
		if (hourOfDay > 24f) {
			hourOfDay -= 24f;
		}
	}

}
