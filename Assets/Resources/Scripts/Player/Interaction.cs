using UnityEngine;
using System.Collections;

public class Interaction : MonoBehaviour {

    ArrayList actors = new ArrayList();

    void OnTriggerEnter(Collider other) {
        if (other.tag != "Interactable") return;
        actors.Add(other.gameObject);

    }

    void OnTriggerExit(Collider other) {
        if (other.tag != "Interactable") return;
        actors.Remove(other.gameObject);
    }

    public void Interact() {
        if (actors.Count == 0) return;
        ButtonScript button = (actors[0] as GameObject).GetComponent<ButtonScript>();
        button.Interact();
    }
}
