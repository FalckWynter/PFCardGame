using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetAttackAction : AbstractAction
{
    public AbstractCreature target;
    public int count;
    public GetAttackAction(AbstractCreature target, int count)
    {
        this.target = target;
        this.count = count;
    }
    public override void Update()
    {
        base.Update();
        target.GetAttack(count);
        isCompleted = true;
    }

}
