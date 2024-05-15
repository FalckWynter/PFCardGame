using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalculateTurnEndAction : AbstractAction
{
    public override void Update()
    {
        base.Update();

        AbstractDungeon.Instance.CalculateTurnEnd();

        isCompleted = true;
    }
}
