using UnityEngine;
using System.Collections;

public class FireBall : Spell {

	// Use this for initialization
	void Start () {
		base.Start();
		BoxCollider collider = GetComponentInChildren<BoxCollider>();
		collider.transform.position = new Vector3(collider.transform.position.x, (collider.bounds.size.y / 2) + .01f, collider.transform.position.z);
	}
	// Update is called once per frame
	void Update () {
	}

	override public void hit(Collider other){
		print("hit: " + other.name);
		Instantiate(explosion, transform.position, transform.rotation);
		switch (other.tag) {
            case "Enemy":
                Destroy(this.gameObject);
                damage();
               	break;

			case "Ice":
				other.gameObject.GetComponent <IceMelt>().melting = true;
				Destroy(this.gameObject);
				break;
        }
	}
	override public void damage (){

	}
}
