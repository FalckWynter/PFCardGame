using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndTurnAction : AbstractAction
{
    public override void Update()
    {
        base.Update();
        AbstractDungeon.Instance.EndCurrentTurn();

        GameActionManager.Instance.AddToLate(new NextTurnAction());
        isCompleted = true;
    }
}
