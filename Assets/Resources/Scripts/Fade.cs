using UnityEngine;
using System.Collections;

public class Fade : Spell {
	public int FadeRate = 0;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Vector3.Distance (startPosition, transform.position) > range * GameManager.TileSize * .85) {
			this.gameObject.GetComponent<ParticleSystem>().emissionRate /= 10; 
		}
	}
}
