using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Round
{

    private List<BattleMember> turnOrder;

    private Party a;
    private Party b;

    public Round(Party a, Party b) {
        this.a = a;
        this.b = b;

        this.turnOrder = new List<BattleMember>();

        // Add parties & sort
        this.turnOrder.AddRange(this.a.partyMembers.Values.Select( m => new BattleMember(m)));
        this.turnOrder.AddRange(this.b.partyMembers.Values.Select( m => new BattleMember(m)));

        this.turnOrder.Sort((b, a) => a.initiative.CompareTo(b.initiative));
    }

}

class BattleMember : CharacterState {
    
    public int initiative;

    public BattleMember(CharacterState member) : base()
    {
        this.initiative = member.RollInitiative();
    }
}