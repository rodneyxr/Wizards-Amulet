using UnityEngine;
using System.Collections;

public class ChangeToEndScene : MonoBehaviour {
	public string direction;
	public string level;

	
	void OnTriggerEnter(Collider other) {
		if (other.tag.Equals("Player")) {
			GameObject[] GameObjects = (FindObjectsOfType<GameObject>() as GameObject[]);
			for (int i = 0; i < GameObjects.Length; i++)
			{
				Destroy(GameObjects[i]);
			}
			Application.LoadLevel(level);
		}
	}
}