using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetExpAction : AbstractAction
{
    public AbstractCreature target;
    public int count;

    public GetExpAction(AbstractCreature target, int count)
    {
        this.target = target;
        this.count = count;
    }
    public override void Update()
    {
        base.Update();
        target.GetExp(count);
        isCompleted = true;
    }

}
