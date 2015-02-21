using UnityEngine;
using System.Collections;

public class ButtonScript : MonoBehaviour {
	public GameObject thing;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Interact(){
		Portcullis controller = thing.GetComponent<Portcullis> ();
		if (controller.open)
			controller.open = false;
		else
			controller.open = true;
	}
}
