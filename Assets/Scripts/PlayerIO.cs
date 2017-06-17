using UnityEngine;
using System.Collections;

public class PlayerIO : MonoBehaviour {

	public static PlayerIO currentPlayerIO;
	public float maxInteractDistance = 8;
	public byte selectedInventory = 0;
	public bool resetCamera = false;
	public Vector3 campos;
	public Animator playerAnimator;

	// Use this for initialization
	void Start () {
		currentPlayerIO = this;
	}
	
	// Update is called once per frame
	void Update () {
		playerAnimator.SetBool ("walking", Input.GetKey (KeyCode.W) || Input.GetKey (KeyCode.A) || Input.GetKey (KeyCode.S) || Input.GetKey (KeyCode.D));
		if (GameObject.FindWithTag ("FPSController").transform.position.y < -20) {
			Debug.Log("Test");
			GameObject.FindWithTag("FPSController").transform.position = new Vector3(GameObject.FindWithTag("FPSController").transform.position.x, 60, GameObject.FindWithTag("FPSController").transform.position.z);
		}
		if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1) || Input.GetMouseButtonDown(2)){
			Ray ray = GetComponent<Camera>().ViewportPointToRay(new Vector3(0.5f,0.5f,0.5f));
			RaycastHit hit;
			if (Physics.Raycast (ray,out hit, maxInteractDistance)) {
				Chunk chunk = hit.transform.GetComponent<Chunk>();
				if (chunk == null){
					return;
				}
				if (Input.GetMouseButtonDown(0)){
					Vector3 p = hit.point;
					p -= hit.normal / 4;
					chunk.SetBrick(0, p);
				} 
				if (Input.GetMouseButtonDown (1)) {
					Vector3 p = hit.point;
					if (selectedInventory != 0){
						p += hit.normal / 4;
						chunk.SetBrick(selectedInventory, p);
					}
				}
				if (Input.GetMouseButtonDown(2)) {
					Vector3 p = hit.point;
					p -= hit.normal / 4;
					selectedInventory = chunk.GetByte(p);
				}
			}
		}
		if (Input.GetKeyDown (KeyCode.F5)) {
			if (!resetCamera) {
				transform.localPosition -= Vector3.forward * 2;
				GameObject.FindWithTag("MinecraftPlayer").layer = 1;
				resetCamera = true;
			} else {
				transform.position = transform.parent.root.transform.localPosition + new Vector3(0f, 0.7f, 0.06f);
				transform.rotation = transform.parent.root.transform.rotation;
				GameObject.FindWithTag("MinecraftPlayer").layer = 8;
				resetCamera = false;
			}
		}
		if (Input.GetKey (KeyCode.Escape) && Input.GetKey (KeyCode.F1)) {
			Application.Quit();
		}
	}
}