using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbstractDungeon : Singleton<AbstractDungeon>
{
    public bool isFighting = false;

    public AbstractPlayer player = new AbstractPlayer();

    public AbstractRoom currentRoom = new AbstractRoom();

    public List<CardMono> selectedCardPool = new List<CardMono>();

    public CombatPhase fightPhase = CombatPhase.None;
    public enum CombatPhase
    {
        None,Prepare,Player,Monster,Complete
    }
        

        
    public void EnterFight()
    {
        //��սǰ׼��
        AbstractDungeon.Instance.player.BattlePrepare();
        //�л�ս���׶�
        fightPhase = CombatPhase.Player;
        //ս��׼�����
        AbstractDungeon.Instance.isFighting = true;
        Debug.Log("��������" + AbstractDungeon.Instance.player.drawPile.cardList.Count);
    }
    public void ExchangeToPhase(CombatPhase phase)
    {
        if(phase == CombatPhase.Player)
        {
            player.StartTurnAction();
        }
        else if(phase == CombatPhase.Monster)
        {

        }
    }
    public bool GetFighting()
    {
        return isFighting;
    }
    //public AbstractMonster monster;
    public override void Initialize()
    {
        base.Initialize();
      
    }

}
