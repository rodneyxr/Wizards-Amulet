﻿using UnityEngine;
using System.Collections;

public class Interaction : MonoBehaviour {

    ArrayList actors = new ArrayList();

    void OnTriggerEnter(Collider other) {
        if (other.tag != "Interactable") return;
		print ("on enter");
        actors.Add(other.gameObject);

    }

    void OnTriggerExit(Collider other) {
        if (other.tag != "Interactable") return;
        actors.Remove(other.gameObject);
    }

    public void Interact() {
		print ("interact beginning");
        if (actors.Count == 0) return;
        IInteractable actor = (actors[0] as GameObject).GetComponent<IInteractable>();
		actor.Interact();
    }
}
