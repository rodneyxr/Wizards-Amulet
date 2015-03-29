using UnityEngine;
using System.Collections;

public class StartLevel : MonoBehaviour {
	string level;
	string direction;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void newLevel(string level, string direction){
		this.level = level;
		this.direction = direction;
		StartCoroutine ("StartNewLevel");
	}

	public IEnumerator StartNewLevel(/*string level, string direction*/){
		string tile = "StartTile";
		if(direction.Equals ("EndTile"))
		   tile = direction;

		GameObject player = GameObject.Find ("Player(Clone)");
		DontDestroyOnLoad(player);
		DontDestroyOnLoad (gameObject);
		yield return new WaitForSeconds(0.3f);
		Application.LoadLevel (level);

		yield return new WaitForSeconds(0.1f);

		print ("test2");
		GameObject startTile = GameObject.Find (tile);
		player.transform.position = new Vector3 (startTile.transform.position.x,
		                                        player.transform.position.y,
		                                        startTile.transform.position.z);
		player.transform.rotation = startTile.transform.rotation;
		player.GetComponent<PlayerStats> ();
		gameObject.GetComponent<GameManager> ().setAllEnemies ();

	}
}
