using UnityEngine;
using System.Collections;

public abstract class Spell : Projectile {
	public GameObject explosion;
    //private SpellType spellType;
    private float baseDamage;

	public string spellName;
	public int spellDamage;
	public float spellSpeed;
	public float spellRange;
	public string spellType;
	public string spellDamageType;
	
   new void Update() {
		base.Update ();
	}

//
//
//    override public void hit(Collider other) {
//        print("hit: " + other.name);
//		Instantiate(explosion, transform.position, transform.rotation);
//		switch (other.tag) {
//            case "NonWalkable":
//                Destroy(this.gameObject);
//                break;
//
//            case "Enemy":
//                Destroy(this.gameObject);
//                if (spellType == SpellType.Damage)
//                    damage();
//                break;
//
//			case "Ice":
//				if(spellType == SpellType.Damage){
//					other.gameObject.GetComponent <IceMelt>().melting = true;
//				}
//				Destroy(this.gameObject);
//				break;
//        }
//
//    }

	override public abstract void hit(Collider other);
	public abstract void damage ();

}
