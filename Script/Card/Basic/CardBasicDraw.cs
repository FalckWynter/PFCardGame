using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardBasicDraw : AbstractCard
{
    public CardBasicDraw()
    {
        label = "BasicDraw";
        AddNewTag(new TagProduceExp(3));
        AddNewTag(new TagDrawCard(1));
    }
}
