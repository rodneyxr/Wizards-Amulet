using UnityEngine;
using System.Collections;

public class ButtonScript : MonoBehaviour,IInteractable  {
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
		if (controller.open && !blocked)
			controller.open = false;
		else if (!blocked)
			controller.open = true;
	}

	/*void OnTriggerEnter(Collider other) {
		if (other.tag == "Ice")
			blocker = other.name;
	}*/
}
