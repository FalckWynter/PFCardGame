using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextTurnAction : AbstractAction
{
    public override void Update()
    {
        base.Update();
        AbstractDungeon.Instance.StartNextTurn();
        isCompleted = true;
    }
}
