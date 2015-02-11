using UnityEngine;
using System.Collections;

public class SpellCaster : MonoBehaviour {

    protected static SpellCaster instance;

    public GameObject fireBall;
    public GameObject iceBlitz;

    void Start() {
        instance = this;
    }

    public static void castSpell(SpellBook spellBook, Vector3 position, Quaternion rotation) {
        Object prefab = instance.fireBall;
        SpellType spellType = SpellType.Damage;

        switch (spellBook) {
            case SpellBook.FireBall:
                prefab = instance.fireBall;
                spellType = SpellType.Damage;
                break;
            case SpellBook.IceBlitz:
                prefab = instance.iceBlitz;
                spellType = SpellType.Damage;
                break;
        }

        Vector3 offset = rotation * Vector3.forward * GameScript.tileSize / 2f;
        var o = Object.Instantiate(prefab, position + offset, rotation) as GameObject;
        Spell spell = o.GetComponent<Spell>();
        spell.Initialize(spellType);
    }

}

public enum SpellBook {
    FireBall, IceBlitz
}

public enum SpellType {
	Damage,
    Healing,
    Special
}