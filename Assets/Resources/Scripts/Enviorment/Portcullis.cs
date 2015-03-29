using UnityEngine;
using System.Collections;

public class Portcullis : MonoBehaviour {
	public bool open;
	public bool state;
	public float speed = 0.1f;
	public bool moving = false;
	private float baseHeight;
	// Use this for initialization
	void Start () {
		state = false;
		open = false;
		moving = false;
		baseHeight = transform.position.y;
	}
	
	// Update is called once per frame
	void Update () {
		if (open)
			openIt ();
		else
			closeIt ();
	}

	public void openIt(){
		if (!state && moving) {
			transform.position = new Vector3 (transform.position.x, transform.position.y - speed, transform.position.z);
		}
		if (transform.position.y <= (baseHeight - 6.0f)) {
			state = true;
			moving = false;
		}
	}

	public void closeIt(){
		if (state && moving) {
			transform.position = new Vector3 (transform.position.x, transform.position.y + speed, transform.position.z);
		}
		if (transform.position.y >= baseHeight) {
			state = false;
			moving = false;
		}
	}
}
