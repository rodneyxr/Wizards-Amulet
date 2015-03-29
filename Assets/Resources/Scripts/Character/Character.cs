using UnityEngine;
using System.Collections;


/**
 * A generic 'character' abstract class
*/
public abstract class Character : MonoBehaviour, ICharacter {

    //Character Health and Mana
    private int health;
    private int mana;

    //Character Skills
    private int charClass;

    //Character Specific Stats
    private float moveSpeed;
    private int attackDamage;

    //functions
    public int Health {
        get { return health; }
        set { health = value; }
    }
    public int Mana {
        get { return mana; }
        set { mana = value; }
    }
    public int CharClass {
        get { return charClass; }
        set { charClass = value; }
    }
    public float MoveSpeed {
        get { return moveSpeed; }
        set { moveSpeed = value; }
    }
    public int AttackDamage {
        get { return attackDamage; }
        set { attackDamage = value; }
    }

    public virtual void increaseHealth(int healthIncreaseAmount) {
        Health += healthIncreaseAmount;
    }

    public virtual void decreaseHealth(int healthDecreaseAmount) {
        Health -= healthDecreaseAmount;
    }

    public virtual void decreaseMana(int manaDecreaseAmount) {
        Mana -= manaDecreaseAmount;
    }

    public virtual void increaseMana(int manaIncreaseAmount) {
        Mana += manaIncreaseAmount;
		if (Mana > 100) {
			Mana = Mana - (Mana - 100);
		}
    }

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }
}
