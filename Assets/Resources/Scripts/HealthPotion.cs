using UnityEngine;
using System.Collections;

public class HealthPotion : MonoBehaviour {
	public int healingAmount = 30;
	public AudioSource drinkSound;
	bool readyToDie = false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (drinkSound.isPlaying)
			readyToDie = true;

		if (readyToDie && !drinkSound.isPlaying)
			Destroy (gameObject);
	}

	void OnTriggerEnter(Collider other){
		if(other.tag == "Player"){
			PlayerStats ps = GameObject.Find ("Player(Clone)").GetComponent<PlayerStats>();
			ps.gainHealth(healingAmount);
			//ps.setSound(drinkSound);
			drinkSound.Play();
		}
	}
}
