using UnityEngine;
using System.Collections;

public class SpawnPlayer : MonoBehaviour {
	public GameObject player;
	public GameObject main;

	// Use this for initialization
	void Start () {
		if (GameObject.Find ("Player(Clone)") == null) {
			StartCoroutine(spawn());
		}
		if (GameObject.Find ("_Main(Clone)") == null) {
			StartCoroutine(mainMaker ());
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	IEnumerator spawn(){
		yield return new WaitForSeconds (0.5f);
		Instantiate(player, transform.position, transform.rotation);
	}
	IEnumerator mainMaker(){
		yield return new WaitForSeconds (0.5f);
		Instantiate(main, transform.position, transform.rotation);
	}
}
