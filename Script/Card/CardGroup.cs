using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.Reflection;
using System;
public class CardGroup 
{
    public int maxCount;
    public List<AbstractCard> cardList = new List<AbstractCard>();

    public int GetCardCount()
    {
        return cardList.Count;
    }
    public bool isEmpty()
    {
        return (cardList.Count <= 0);
    }
    public AbstractCard GetTopCard()
    {
        //Debug.Log("卡堆顶部" + cardList[cardList.Count - 1].label + "花费" + cardList[cardList.Count - 1].cost);
        return cardList[cardList.Count - 1];
    }
    public void RemoveCard(AbstractCard card)
    {
        if (!cardList.Contains(card))
            return;
        cardList.Remove(card);
    }
    public void RemoveTopCard()
    {
        if (cardList.Count <= 0)
            return;
        cardList.RemoveAt(cardList.Count - 1);
    }
    public void AddCard(AbstractCard card)
    {
        //Debug.Log("对卡组添加卡牌" + card.label + "花费" + card.cost);
        cardList.Add(card);
        //Debug.Log("添加结束" + card.label + "花费" + card.cost);
    }
    public void Shuffle()
    {
        AbstractCard tempCard;
        int k;
        System.Random random = new System.Random();
        //cardList.OrderBy(x =>  random.Next()).ToList();
        for(int i =0; i< cardList.Count;i++)
        {
            k = random.Next(0, cardList.Count);
            tempCard = cardList[i];
            cardList[i] = cardList[k];
            cardList[k] = tempCard;
        }
    }
    public void InitializeDeckByDeck(CardGroup group)
    {
        cardList.Clear();
        foreach(AbstractCard card in group.cardList)
        {
            cardList.Add(card.CreateDeepCopy());
        }
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
