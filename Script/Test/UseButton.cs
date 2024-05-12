using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseButton : MonoBehaviour
{
    public void UseCurrentCard()
    {
        foreach(CardMono card in AbstractDungeon.Instance.selectedCardPool)
        {
            Debug.Log("Ҫ���Ŀ���" + card.cardData.label + "��⵽����" +card.cardData.cost);
            //������ò���
            if (!AbstractDungeon.Instance.player.IsHaveEnoughEnergy(card.cardData.cost))
            {
                card.FSM.ExchangeState(CardMonoStateMachile.CardMonoStateType.None);
                continue;
            }
            else
            {
                card.cardData.UseCard(AbstractDungeon.Instance.player, AbstractDungeon.Instance.player);
                AbstractDungeon.Instance.player.MoveCardFormHandToDiscard(card.cardData);
                Destroy(card.gameObject);
            }
            //card.FSM.ExchangeState(CardMonoStateMachile.CardMonoStateType.None);
        }
        AbstractDungeon.Instance.selectedCardPool.Clear();
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
