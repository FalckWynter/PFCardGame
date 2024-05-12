using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetDefendAction : AbstractAction
{
    public AbstractCreature target;
    public int count;
    public GetDefendAction(AbstractCreature target, int count)
    {
        this.target = target;
        this.count = count;
    }
    public override void Update()
    {
        base.Update();
        target.GetDefend(count);
        isCompleted = true;
    }
}
