using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawCardAction : AbstractAction
{
    public AbstractCreature creature;

    public int count;

    public bool createPrefab;

    public static GameObject cardPrefab;

    public static string cardPrefabPath = "Prefabs/Card/CardPrefab";

    public static GameObject cardParent;

    public static string cardParentPath = "BasicUi/PlayerUI/HandCard";
    static DrawCardAction()
    {
        cardPrefab = Resources.Load<GameObject>(cardPrefabPath);
        cardParent = GameObject.Find(cardParentPath);
    }
    public DrawCardAction(AbstractCreature target, int count)
    {
        creature = target;
        this.count = count;
        createPrefab = target.creatureType == AbstractCreature.CreatureType.Player;
    }
    public DrawCardAction(AbstractCreature target,int count,bool create = false)
    {
        creature = target;
        this.count = count;
        createPrefab = create;
    }
    public override void Update()
    {
        base.Update();
        //Debug.Log("抽卡需要的数量" + count);
        for (int i = 0; i < count; i++)
        {
            //Debug.Log("检测" + i);
            if (!creature.DrawCard())
                break;
            //Debug.Log("检测成功");
            if (createPrefab)
            {
                //Debug.Log("生成预制体");
                GameObject ob = GameObject.Instantiate(cardPrefab, cardParent.transform);
                ob.GetComponent<CardMono>().Initialize(creature.handPile.GetTopCard());

            }
        }
        //Debug.Log("结束了抽卡行动");
        isCompleted = true;
    }
}
