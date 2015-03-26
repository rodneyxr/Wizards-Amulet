using UnityEngine;
using System.Collections;

public class SpawnPlayer : MonoBehaviour {
	public GameObject player;

	// Use this for initialization
	void Start () {
		if (GameObject.Find ("Player") == null) {
			StartCoroutine(spawn());
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	IEnumerator spawn(){
		yield return new WaitForSeconds (0.5f);
		Instantiate(player, transform.position, transform.rotation);
	}
}
