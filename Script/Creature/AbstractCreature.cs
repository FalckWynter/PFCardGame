using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbstractCreature 
{
    public int index;
    public string label;
    public int health, maxHealth;

    public int exp;
    public int attack, defend;
    public int energy = 2, energyForCombat, energyMax = 2;
    public int handPileMaxCount = 4;

    public CreatureType creatureType;
    public AbstractCreature target;

    public CardGroup masterDeck = new CardGroup();

    public CardGroup drawPile = new CardGroup();

    public CardGroup handPile = new CardGroup();

    public CardGroup discardPile = new CardGroup();

    public CardGroup exhaustPile = new CardGroup();

    public void GetDefend(int count)
    {
        defend += count;
    }
    public void GetEnergy(int count)
    {
        energy += count;
    }
    public void UseEnergy(int count)
    {
        Debug.Log("已有能量" + energy + "消耗能量" + count);
        energy -= count;
    }
    public bool IsHaveEnoughEnergy(int count)
    {
        Debug.Log("要检查的结果" + energy + "目标数值" + count);
        if (energy >= count)
            return true;
        else
            return false;
    }
    public void GetAttack(int count)
    {
        attack += count;
    }
    public void GetExp(int count)
    {
        exp += count;
    }
    public void ExhaustExp(int count)
    {
        exp -= count;
    }
    public virtual void BattlePrepare()
    {
        drawPile.InitializeDeckByDeck(masterDeck);
        drawPile.Shuffle();

    }
    public virtual void StartTurnAction()
    {
        GetEnergy(energyMax);

    }
    public bool DrawCard()
    {

        if(drawPile.isEmpty())
        {
            drawPile.InitializeDeckByDeck(discardPile);
            drawPile.Shuffle();
            discardPile.cardList.Clear();
        }
        if (drawPile.isEmpty())
            return false;
        if (handPile.GetCardCount() >= handPileMaxCount)
            return false;
  
        AbstractCard card = drawPile.GetTopCard();
        //Debug.Log("提取出的卡的名字" + card.label + "花费" + card.cost);
        handPile.AddCard(card);
        drawPile.RemoveTopCard();
        return true;
    }
    public void DrawCard(int count)
    {
        for(int i = 0;i<count;i++)
        {
            if (handPile.GetCardCount() >= handPileMaxCount)
                break;
            DrawCard();
        }
    }
    public void MoveCardFormHandToDiscard(AbstractCard card)
    {
        discardPile.AddCard(card);
        handPile.RemoveCard(card);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public enum CreatureType
    {
        Monster,Player
    }
}
