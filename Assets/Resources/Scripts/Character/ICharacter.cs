public interface ICharacter {

    /// <summary>
    /// Increases the players health.
    /// </summary>
    /// <param name="healthIncreaseAmount"></param>
    void increaseHealth(int healthIncreaseAmount);

    /// <summary>
    /// Decreases the character's health.
    /// </summary>
    /// <param name="healthDecreaseAmount"></param>
    void decreaseHealth(int healthDecreaseAmount);

    /// <summary>
    /// Decreases the characters mana.
    /// </summary>
    /// <param name="manaDecreaseAmount"></param>
    void decreaseMana(int manaDecreaseAmount);


    /// <summary>
    /// increases the characters mana.
    /// </summary>
    /// <param name="manaIncreaseAmount"></param>
    void increaseMana(int manaIncreaseAmount);
}
