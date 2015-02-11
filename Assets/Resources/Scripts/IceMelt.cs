using UnityEngine;
using System.Collections;

public class IceMelt : MonoBehaviour {
	public bool melting;
	float oneTenthYScale;
	// Use this for initialization
	void Start () {
		melting = false;
		oneTenthYScale = transform.localScale.y/10.0f;
	}
	
	// Update is called once per frame
	void Update () {
		if (melting) {
			transform.localScale = new Vector3 (transform.localScale.x, transform.localScale.y - oneTenthYScale, transform.localScale.z);
			transform.position = new Vector3(transform.position.x, transform.position.y - oneTenthYScale/2, transform.position.z);
		}
		if (transform.localScale.y <= 0.0f) {
			Destroy (gameObject);
		}
	}

	void OnTriggerEnter(Collider other) {
		if(other.tag == "Fire")
			melting = true;
	}
}
