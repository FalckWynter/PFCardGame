using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbstractMonster : AbstractCreature
{
    public AbstractMonster()
    {
        maxHealth = 20;
        currentHealth = maxHealth;
        creatureType = CreatureType.Monster;
        //masterDeck.AddCard(new CardBasicAttack());
        //masterDeck.AddCard(new CardBasicAttack());
        //masterDeck.AddCard(new CardBasicDefend());
        //masterDeck.AddCard(new CardBasicDefend());
        masterDeck.AddCard(new CardBasicGrowExp());
        masterDeck.AddCard(new CardBasicGrowExp());
        //masterDeck.AddCard(new CardBasicDraw());
        //masterDeck.AddCard(new CardBasicDraw());
    }
    public override void BattlePrepare()
    {
        base.BattlePrepare();
        drawPile.InitializeDeckByDeck(masterDeck);
        DrawCard();
        //Debug.Log("怪物起手手牌" + drawPile.GetCardCount());
        drawPile.Shuffle();
        //开局抽满手牌
  
    }

    public override void StartTurnAction()
    {
   
        base.StartTurnAction();
        //Debug.Log("开始前抽牌堆数量" + drawPile.GetCardCount());
        //GameActionManager.Instance.AddToBottom(new DrawCardAction(this, 1));
        ////强制更新
        //GameActionManager.Instance.OnUpdate();

        //Debug.Log("开始后抽牌堆数量" + drawPile.GetCardCount());
        //Debug.Log("抽牌堆" + drawPile.GetCardCount() + "手牌" + handPile.GetCardCount() + "弃牌堆" + discardPile.GetCardCount());
        AbstractCard card = handPile.GetTopCard();
        //card.UseCard(this, AbstractDungeon.Instance.GetPlayer());

        //AbstractDungeon.Instance.monster.MoveCardFormHandToDiscard(card);

        //DrawCard();
        //GameActionManager.Instance.OnUpdate();

        //AbstractDungeon.Instance.StartNextTurn();
        GameActionManager.Instance.AddToBottom(new UseCardAction(card, this, AbstractDungeon.Instance.player));
        GameActionManager.Instance.AddToBottom(new MoveCardHandToDiscardAction(this, card));
        GameActionManager.Instance.AddToBottom(new DrawCardAction(this, 1));


        //GameActionManager.Instance.AddToLate(new NextTurnAction());
        //GameActionManager.Instance.AddToBottom(new EndTurnAction());
        GameActionManager.Instance.AddToLate(new CalculateTurnEndAction());


        //GameActionManager.Instance.AddToBottom(new )
    }
    // Start is called before the first frame update
    void Start()
    {

    }
    public void UpdateFightLogic()
    {

    }
    // Update is called once per frame
    public override void Update()
    {
        base.Update();
        UpdateFightLogic();
    }
}
