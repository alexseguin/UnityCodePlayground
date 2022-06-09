using System;

public class CharacterState
{
    public Hat hat;
    public int health;
    public int attack;
    private int speed;

    public CharacterState(Hat hat) {
        
    }

    public CharacterState() {
        this.health = 5;
        this.attack = 1;
        this.speed = 0;
    }

    public bool Alive() {
        return this.health > 0;
    }

    public int RollInitiative() {
        return new Random().Next(21) + speed;
    }
}
