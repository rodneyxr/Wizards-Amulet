using UnityEngine;
using System.Collections;

public class Spell : Projectile {
	public GameObject explosion;
    private SpellType spellType;
    private float baseDamage;

    new void Start() {
        base.Start();
        BoxCollider collider = GetComponentInChildren<BoxCollider>();
        collider.transform.position = new Vector3(collider.transform.position.x, (collider.bounds.size.y / 2) + .01f, collider.transform.position.z);
    }

    public void Initialize(SpellType spellType) {
        this.spellType = spellType;
    }

    public void damage() {
        //print("TODO: Cause damage to the enemy!");
    }

    override public void hit(Collider other) {
        //print("hit: " + other.name);
		Instantiate(explosion, transform.position, transform.rotation);
		switch (other.tag) {
            case "NonWalkable":
                Destroy(this.gameObject);
                break;

            case "Enemy":
                Destroy(this.gameObject);
                if (spellType == SpellType.Damage)
                    damage();
                break;

			case "Ice":
				if(spellType == SpellType.Damage){
					other.gameObject.GetComponent <IceMelt>().melting = true;
				}
				Destroy(this.gameObject);
				break;
        }

    }
}
