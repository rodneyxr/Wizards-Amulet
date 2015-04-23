using UnityEngine;
using System.Collections;

public class ChangeToEndScene : MonoBehaviour {
	public string direction;
	public string level;

	
	void OnTriggerEnter(Collider other) {
		if (other.tag.Equals("Player")) {
			Application.LoadLevel(level);
		}
	}
}