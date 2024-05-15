using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbstractDungeon : UpdateSingleton<AbstractDungeon>
{
    /* ���ƹ��������� */
    public bool isHovering = false;

    public List<CardMono> selectedCardPool = new List<CardMono>();

    /* ս������������ */

    public bool isFighting = false;

    public AbstractPlayer player = new AbstractPlayer();

    public AbstractMonster monster = new AbstractMonster();

    public List<AbstractCreature> creatureTurnList = new List<AbstractCreature>();

    public AbstractRoom currentRoom = new AbstractRoom();

    public CombatPhase fightPhase = CombatPhase.None;
    public enum CombatPhase
    {
        None,Prepare,Player,Monster,Complete
    }
        

    public AbstractCreature GetPlayer()
    {
        return player;
    }
    public void InitializeFight()
    {

    }
    public void InitializeFight(AbstractMonster monster)
    {
        Debug.Log("����ս����ʼ��" + monster.currentHealth);
        this.monster = monster;
    }
    public void InitializeFight(AbstractPlayer player,AbstractMonster monster)
    {
        this.player = player;
        this.monster = monster;
    }
    public void EnterFight()
    {
        //����ս���غ��б�
        creatureTurnList.Clear();

        creatureTurnList.Add(player);
        creatureTurnList.Add(monster);
        //ִ�������սǰ׼��
        player.BattlePrepare();
        monster.BattlePrepare();
        //�л�ս���׶�
        fightPhase = CombatPhase.Player;
        //ս��׼�����
        AbstractDungeon.Instance.isFighting = true;
        //��ʼ��һ������ĻغϽ׶�
        creatureTurnList[0].StartTurnAction();

    }
    int turnCounter = 0,staticCounter = 0;
    public int GetCurrentCreatureID()
    {
        return turnCounter;
    }
    public int GetNextCreatureID()
    {
        return (turnCounter + 1)% creatureTurnList.Count;
    }
    public AbstractCreature GetNextCreature()
    {
        return creatureTurnList[GetNextCreatureID()];
    } 
    public AbstractCreature GetCurrentCreature()
    {
        return creatureTurnList[GetCurrentCreatureID()];
    }
    public void CalculateTurnEnd()
    {
        //GameActionManager.Instance.AddToBottom(new DamageAction(new DamageInfo(GetCurrentCreature(), GetNextCreature(), DamageInfo.DamageType.Normal)));
        GetNextCreature().GetDamage(new DamageInfo(GetCurrentCreature(), GetNextCreature(), DamageInfo.DamageType.Normal));

        EndCurrentTurn();
    }
    public void EndCurrentTurn()
    {
        //creatureTurnList[(turnCounter + 1) % creatureTurnList.Count].BeAttack(creatureTurnList[turnCounter].attack);


        creatureTurnList[turnCounter].EndTurnAction();

        if (AbstractDungeon.Instance.monster.isDead)
            EndFight();
        StartNextTurn();
    }
    public void EndFight()
    {
        UIManager.Instance.ExitFight();
        Debug.LogWarning("ս��������");
    }
    public void StartNextTurn()
    {
        if (!isFighting)
            return;


        turnCounter++;
        turnCounter %= creatureTurnList.Count;
        staticCounter++;
        Debug.Log("��ǰ�غ���" + staticCounter);
        creatureTurnList[turnCounter].StartTurnAction();
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
    public override void OnUpdate()
    {
        base.OnUpdate();
        UpdateFight();
    }
    public void UpdateFight()
    {
        if (!isFighting)
            return;
        creatureTurnList[turnCounter].Update();
    }
}
