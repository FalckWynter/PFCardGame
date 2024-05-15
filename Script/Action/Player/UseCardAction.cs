using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseCardAction : AbstractAction
{
    AbstractCreature source, target;
    AbstractCard cardToUse;
    public UseCardAction(AbstractCard card,AbstractCreature source,AbstractCreature target)
    {
        cardToUse = card;
        this.source = source;
        this.target = target;
    }
    public override void Update()
    {
        base.Update();
        Debug.Log("ʹ����" + source + "��������" +cardToUse.label);
        cardToUse.UseCard(source, target);
        isCompleted = true;
    }
}
