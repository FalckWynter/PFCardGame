using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardBasicGrowExp : AbstractCard
{
    public CardBasicGrowExp()
    {
        cost = 1;
        label = "BasicGrowExp";
        tags.Add(new TagCostEnergy(1));
        tags.Add(new TagProduceExp(12));

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
