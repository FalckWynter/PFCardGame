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
        //Debug.Log("�鿨��Ҫ������" + count);
        for (int i = 0; i < count; i++)
        {
            //Debug.Log("���" + i);
            if (!creature.DrawCard())
                break;
            //Debug.Log("���ɹ�");
            if (createPrefab)
            {
                //Debug.Log("����Ԥ����");
                GameObject ob = GameObject.Instantiate(cardPrefab, cardParent.transform);
                ob.GetComponent<CardMono>().Initialize(creature.handPile.GetTopCard());

            }
        }
        //Debug.Log("�����˳鿨�ж�");
        isCompleted = true;
    }
}
