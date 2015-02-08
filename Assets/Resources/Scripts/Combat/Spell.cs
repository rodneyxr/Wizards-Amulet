using UnityEngine;
using System.Collections;

public class Spell : Projectile {

    private SpellType spellType;
    private float baseDamage;

    void Start() {
        base.Start();
        BoxCollider collider = GetComponentInChildren<BoxCollider>();
        collider.transform.position = new Vector3(collider.transform.position.x, (collider.bounds.size.y / 2) + .01f, collider.transform.position.z);
    }

    public void Initialize(SpellType spellType) {
        this.spellType = spellType;
    }

    public void damage() {
        print("TODO: Cause damage to the enemy!");
    }

    override public void hit(Collider other) {
        print("hit: " + other.name);
        switch (other.tag) {
            case "Unwalkable":
                Destroy(this.gameObject);
                break;

            case "Enemy":
                Destroy(this.gameObject);
                if (spellType == SpellType.Damage)
                    damage();
                break;
        }

    }
}
