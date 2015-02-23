using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerStats : Character {

    //public vars to set initial settings during debugging
    public int playerHealth;
    public int playerMana;
    public float playerMoveSpeed;
    public int playerAttackDamage;

    //UI Text variables
    public Text PlayerHealthText;
    public Text PlayerManaText;

    // Use this for initialization
    void Start() {
        //Give character base stats via public variables
        Health = playerHealth;
        Mana = playerMana;
        AttackDamage = playerAttackDamage;
        MoveSpeed = playerMoveSpeed;
    }

    // Update is called once per frame
    void Update() {
        PlayerHealthText.text = "Health : " + Health;
        PlayerManaText.text = "Mana : " + Mana;
    }
}
