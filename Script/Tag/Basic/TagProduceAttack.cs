using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TagProduceAttack : AbstractTag
{
    public TagProduceAttack(int count)
    {
        value.Add(count);
    }
    public override void UseTag(AbstractCreature source, AbstractCreature target)
    {
        base.UseTag(source, target);
        GameActionManager.Instance.AddToBottom(new GetAttackAction(target, value[0]));
        //target.GetAttack(value[0]);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
