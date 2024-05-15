using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TagExhaustExp : AbstractTag
{
    public TagExhaustExp(int count)
    {
        value.Add(count);
    }
    public override void UseTag(AbstractCreature source, AbstractCreature target)
    {
        base.UseTag(source, target);
        GameActionManager.Instance.AddToBottom(new ExhaustExpAction(source, value[0]));
        //target.ExhaustExp(value[0]);
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
