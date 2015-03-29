using UnityEngine;
using System.Collections;

public class SpawnPlayer : MonoBehaviour {
	public GameObject player;
	public GameObject main;
	public GameObject canvas;

	// Use this for initialization
	void Start () {
		if (GameObject.Find ("Canvas(Clone)") == null) {
			StartCoroutine (canvasMaker());
		}
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
	IEnumerator canvasMaker(){
		yield return new WaitForSeconds (0.5f);
		Instantiate(canvas, transform.position, transform.rotation);
	}
}
