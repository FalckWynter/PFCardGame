using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardBasicAttack : AbstractCard
{
    public CardBasicAttack()
    {
        cost = 1;
        label = "BasicAttack";
        //Debug.Log("²âÊÔ»¨·Ñ" + label + "ÏûºÄ" + cost);
        AddNewTag(new TagCostEnergy(1));
        AddNewTag(new TagProduceExp(6));
        AddNewTag(new TagExhaustExp(6));
        AddNewTag(new TagProduceAttack(6));
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
