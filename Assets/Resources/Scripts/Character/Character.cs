using UnityEngine;
using System.Collections;


/**
 * A generic 'character' abstract class
*/
public abstract class Character : MonoBehaviour {

	//Character Health and Mana
	private int health;
	private int mana;

	//Character Skills
	private int charClass;

	//Character Specific Stats
	private float moveSpeed;
	private int attackDamage;
	
	//functions
	public int Health{
		get{return health;}
		set{health = value;}
	}
	public int Mana{
		get{return mana;}
		set{mana = value;}
	}
	public int CharClass{
		get{return charClass;}
		set{charClass = value;}
	}
	public float MoveSpeed{
		get{return MoveSpeed;}
		set{MoveSpeed = value;}
	}
	public int AttackDamage{
		get{return attackDamage;}
		set{attackDamage = value;}
	}

	public abstract void increaseHealth(int healthIncreaseAmount);
	public abstract void decreaseHealth(int healthDecreaseAmount);
	public abstract void decreaseMana (int manaDecreaseAmount);
	public abstract void increaseMana (int manaIncreaseAmount);
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
