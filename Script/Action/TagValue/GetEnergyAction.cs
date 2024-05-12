using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetEnergyAction : AbstractAction
{
    public AbstractCreature target;
    public int count;
    public GetEnergyAction(AbstractCreature target, int count)
    {
        this.target = target;
        this.count = count;
    }
    public override void Update()
    {
        base.Update();
        target.GetEnergy(count);
        isCompleted = true;
    }

}
