using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExhaustExpAction : AbstractAction
{
    public AbstractCreature target;
    public int count;
    public ExhaustExpAction(AbstractCreature target,int count)
    {
        this.target = target;
        this.count = count;
    }
    public override void Update()
    {
        base.Update();
        target.ExhaustExp(count);
        isCompleted = true;
    }
}
