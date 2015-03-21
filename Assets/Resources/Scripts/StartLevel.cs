using UnityEngine;
using System.Collections;

public class StartLevel : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void StartNewLevel(string level, string direction){
		string tile = "StartTile";
		if(direction.Equals ("EndTile"))
		   tile = direction;

		GameObject player = GameObject.Find ("Player");
		DontDestroyOnLoad(player);
		DontDestroyOnLoad (gameObject);
		Application.LoadLevel (level);
		GameObject startTile = GameObject.Find (tile);
		player.transform.position = new Vector3 (startTile.transform.position.x,
		                                        player.transform.position.y,
		                                        startTile.transform.position.z);

	}
}
