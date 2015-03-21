using UnityEngine;
using System.Collections;

public class ChangeLevel : MonoBehaviour {
	public string direction;
	public string level;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnTriggerEnter(Collider other){
		print ("test");
		if(other.tag.Equals("Player")){
			StartLevel s = GameObject.Find("_Main").GetComponent<StartLevel>();
			s.StartNewLevel(level, direction);
		}
	}
}