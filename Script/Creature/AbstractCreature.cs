using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbstractCreature 
{
    public int index;
    public string label;
    public int currentHealth, maxHealth;

    public int exp;
    public int attack, defend;
    public int energy = 2, energyForCombat, energyMax = 2;
    public int handPileMaxCount = 4;

    public bool isDead = false;

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
    public void ResetEnergy()
    {
        if (energy > energyMax)
            return;
        energy = energyMax;
    }
    public void GetEnergy(int count)
    {
        energy += count;
    }
    public void UseEnergy(int count)
    {
        //Debug.Log("已有能量" + energy + "消耗能量" + count);
        energy -= count;
    }
    public bool IsHaveEnoughEnergy(int count)
    {
        //Debug.Log("要检查的结果" + energy + "目标数值" + count);
        if (energy >= count)
            return true;
        else
            return false;
    }
    public void GetAttack(int count)
    {
        attack += count;
        //Debug.Log("获得攻击力" + count);
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


    }
    public virtual void StartTurnAction()
    {
        //Debug.Log("回合开始了" + creatureType);
        ResetEnergy();
        //重设护甲
        defend = 0;

    }
    public virtual void EndTurnAction()
    {

        attack = 0;
        //Debug.Log("重设攻击力" + creatureType + "数值" + attack);
    }
    public void GetHurt(int count)
    {
        currentHealth -= count;

        if (currentHealth <= 0)
            isDead = true;
    }
    public void BeAttack(int damage)
    {
        damage -= defend;
        if (damage <= 0)
            damage = 0;
        GetHurt(damage);
    }
    public void GetDamage(DamageInfo info)
    {
        int damageCount = info.damage;
        damageCount -= defend;
        if (damageCount <= 0)
            damageCount = 0;
        GetHurt(damageCount);
    }
    public bool DrawCard()
    {

        if(drawPile.isEmpty())
        {
            //Debug.Log("尝试洗牌");
            //drawPile.CopyFromDeck(discardPile);
            drawPile.InitializeDeckByDeck(discardPile);
            drawPile.Shuffle();
            discardPile.ClearDeck();
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
    public virtual void Update()
    {
        
    }
    public enum CreatureType
    {
        Monster,Player
    }
}
