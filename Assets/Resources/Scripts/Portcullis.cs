using UnityEngine;
using System.Collections;

public class Portcullis : MonoBehaviour {
	public bool open;
	public bool state;
	public float speed;
	private float baseHeight;
	// Use this for initialization
	void Start () {
		state = false;
		open = false;
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
		if (!state) {
			transform.position = new Vector3 (transform.position.x, transform.position.y - speed, transform.position.z);
		}
		if (transform.position.y <= (baseHeight - 6.0f))
			state = true;
	}

	public void closeIt(){
		if (state) {
			transform.position = new Vector3 (transform.position.x, transform.position.y + speed, transform.position.z);
		}
		if (transform.position.y >= baseHeight)
			state = false;
	}
}
