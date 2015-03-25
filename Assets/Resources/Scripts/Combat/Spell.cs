using UnityEngine;
using System.Collections;

public class Spell : Projectile {
    public GameObject explosion;
    private SpellType spellType;
    public float baseDamage = 25;

    private bool active;

    new void Start() {
        base.Start();
        active = true;
        BoxCollider collider = GetComponentInChildren<BoxCollider>();
        collider.transform.position = new Vector3(collider.transform.position.x, (collider.bounds.size.y / 2) + .01f, collider.transform.position.z);
    }

    public void Initialize(SpellType spellType) {
        this.spellType = spellType;
    }

    public void damage(Character character) {
        character.decreaseHealth((int)baseDamage);
    }

    override public void hit(Collider other) {
        //print("hit: " + other.name);
        if (!active) return;

        if (active) {
            active = false;
            Instantiate(explosion, transform.position, transform.rotation);
        }

        switch (other.tag) {
            case "NonWalkable":
                Destroy(this.gameObject);
                break;

            case "Enemy":
                if (spellType == SpellType.Damage)
                    damage(other.GetComponent<Enemy>());
                Destroy(this.gameObject);
                break;

            case "Ice":
                if (spellType == SpellType.Damage) {
                    other.gameObject.GetComponent<IceMelt>().melting = true;
                }
                Destroy(this.gameObject);
                break;
            default:
                Destroy(this.gameObject);
                break;
        }

    }
}
