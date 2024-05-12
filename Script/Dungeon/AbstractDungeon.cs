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
        //做战前准备
        AbstractDungeon.Instance.player.BattlePrepare();
        //切换战斗阶段
        fightPhase = CombatPhase.Player;
        //战斗准备完成
        AbstractDungeon.Instance.isFighting = true;
        Debug.Log("卡牌数量" + AbstractDungeon.Instance.player.drawPile.cardList.Count);
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
