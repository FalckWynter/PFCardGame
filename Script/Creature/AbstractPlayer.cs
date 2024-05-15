using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbstractPlayer : AbstractCreature
{
    public AbstractPlayer()
    {
        maxHealth = 100;
        currentHealth = maxHealth;
        creatureType = CreatureType.Player;
        masterDeck.AddCard(new CardBasicAttack());
        masterDeck.AddCard(new CardBasicAttack());
        masterDeck.AddCard(new CardBasicAttack());
        masterDeck.AddCard(new CardBasicAttack());
        //masterDeck.AddCard(new CardBasicDefend());
        //masterDeck.AddCard(new CardBasicDefend());
        //masterDeck.AddCard(new CardBasicGrowExp());
        //masterDeck.AddCard(new CardBasicDraw());
        //masterDeck.AddCard(new CardBasicDraw());
    }
    public override void BattlePrepare()
    {
        base.BattlePrepare();
        //¿ª¾Ö³éÂúÊÖÅÆ
        drawPile.InitializeDeckByDeck(masterDeck);
        drawPile.Shuffle();
        GameActionManager.Instance.AddToBottom(new DrawCardAction(this, 4, true));
    }

    public override void StartTurnAction()
    {
        base.StartTurnAction();
        GameActionManager.Instance.AddToBottom(new DrawCardAction(this, handPileMaxCount - handPile.GetCardCount(), creatureType == CreatureType.Player));
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update();
    }
}
