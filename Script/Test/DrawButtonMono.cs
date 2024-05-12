using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawButtonMono : MonoBehaviour
{
    public GameObject CardPrefab;
    public GameObject cardParent;

    public void PlayerDrawCard()
    {
        //Debug.Log(AbstractDungeon.Instance.player.drawPile.GetCardCount());
        //if (AbstractDungeon.Instance.player.drawPile.GetCardCount() == 0 && AbstractDungeon.Instance.player.discardPile.GetCardCount() == 0)
        //    return;
        Debug.Log("抽卡");
        GameActionManager.Instance.AddToBottom(new DrawCardAction(AbstractDungeon.Instance.player,1,true));
         //AbstractDungeon.Instance.player.DrawCard();
        //GameObject ob = Instantiate(CardPrefab, cardParent.transform);
        //Debug.Log("顶层卡的名字" + AbstractDungeon.Instance.player.handPile.GetTopCard().label + "花费" + AbstractDungeon.Instance.player.handPile.GetTopCard().cost);
        //ob.GetComponent<CardMono>().cardData = AbstractDungeon.Instance.player.handPile.GetTopCard();/*AbstractDungeon.Instance.player.handPile.cardList[AbstractDungeon.Instance.player.handPile.cardList.Count - 1];*/
        //ob.GetComponent<CardMono>().Update();
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
