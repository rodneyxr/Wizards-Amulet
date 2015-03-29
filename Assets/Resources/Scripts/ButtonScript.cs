using UnityEngine;
using System.Collections;

public class ButtonScript : MonoBehaviour {
	public GameObject thing;
	public bool blocked = false;
	public string blockerName;
	public GameObject blocker = null;
	// Use this for initialization
	void Start () {
		//blocker = GameObject.Find (blockerName);
	}
	
	// Update is called once per frame
	void Update () {

	
	}

	public void Interact(){

		blocker = GameObject.Find (blockerName);

		if (blocker == null)
			blocked = false;
		else
			blocked = true;

		Portcullis controller = thing.GetComponent<Portcullis> ();
		if (controller.open && !blocked && !controller.moving) {
			controller.open = false;
			controller.moving = true;
		} else if (!blocked && !controller.moving) {
			controller.open = true;
			controller.moving = true;
		} else if (!controller.open && !blocked && controller.moving) {
			controller.open = true;
			controller.state = !controller.state;
		} else if (controller.open && !blocked && controller.moving) {
			controller.open = false;
			controller.state = !controller.state;
		}
	}

	/*void OnTriggerEnter(Collider other) {
		if (other.tag == "Ice")
			blocker = other.name;
	}*/
}
