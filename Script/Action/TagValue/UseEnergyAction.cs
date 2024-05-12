using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseEnergyAction : AbstractAction
{
    public AbstractCreature target;
    public int count;

    public UseEnergyAction(AbstractCreature target, int count)
    {
        this.target = target;
        this.count = count;
    }
    public override void Update()
    {
        base.Update();
        target.UseEnergy(count);
        isCompleted = true;
    }
}
