using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardBasicDefend : AbstractCard
{
    public CardBasicDefend()
    {
        cost = 1;
        label = "BasicBasicDefend";
        AddNewTag(new TagCostEnergy(1));
        AddNewTag(new TagProduceExp(6));
        AddNewTag(new TagExhaustExp(6));
        AddNewTag(new TagProduceDefend(6));
    }
}
