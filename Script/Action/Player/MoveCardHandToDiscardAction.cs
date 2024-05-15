using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCardHandToDiscardAction : AbstractAction
{
    AbstractCreature creature;
    AbstractCard card;
    public MoveCardHandToDiscardAction(AbstractCreature creature,AbstractCard card)
    {
        this.creature = creature;
        this.card = card;
    }
    public override void Update()
    {
        base.Update();

        creature.MoveCardFormHandToDiscard(card);

        isCompleted = true;
    }
}
