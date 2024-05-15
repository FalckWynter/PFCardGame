using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageAction : AbstractAction
{

    public DamageInfo info;
    public DamageAction(DamageInfo inf)
    {
   
        info = inf;
    }
    // Start is called before the first frame update

    // Update is called once per frame
    public override void Update()
    {
        base.Update();
        info.target.GetDamage(info);
        isCompleted = true;
    }
}
