using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class CombatStateMachine
{
    public GameObject parentGameobject;

    public CombatState currentState = new CombatState();

    public void Initialize(GameObject parent)
    {
        parent = parentGameobject;
    }
    public void ExchangeState(CombatStateType type)
    {
        currentState.ExitState();
        currentState = (CombatState)Activator.CreateInstance(CombatStateDictionary[type].GetType());
        currentState.Initialize(this);
        currentState.EnterState();
    }
    public void UpdateState()
    {
        currentState.UpdateState();
    }
    public enum CombatStateType
    {
        None, Selected, Hover
    }
    public Dictionary<CombatStateType, CombatState> CombatStateDictionary = new Dictionary<CombatStateType, CombatState>()
    {
        {CombatStateType.None, new CombatStateNone()},{CombatStateType.Selected,new CombatStateSelected()},
        {CombatStateType.Hover,new CombatStateHover() }
    };
}
public class CombatState
{
    public CombatStateMachine FSM;

    public CombatStateMachine.CombatStateType stateType;
    public virtual void Initialize(CombatStateMachine machine)
    {
        FSM = machine;
    }
    public virtual void EnterState()
    {

    }
    public virtual void UpdateState()
    {

    }
    public virtual void ExitState()
    {

    }
}
public class CombatStateNone : CombatState
{
    public override void EnterState()
    {
        base.EnterState();
        stateType = CombatStateMachine.CombatStateType.None;
    }
}
public class CombatStateSelected : CombatState
{
    Vector3 startPosition, selectOffset = new Vector3(0, 50, 0);

    public override void EnterState()
    {
        base.EnterState();
        stateType = CombatStateMachine.CombatStateType.Selected;

    }
    public override void ExitState()
    {
        base.ExitState();

    }
}
public class CombatStateHover : CombatState
{
    Vector3 selectOffset = new Vector3(0, 25, 0);
    public override void EnterState()
    {
        base.EnterState();
        stateType = CombatStateMachine.CombatStateType.Hover;


    }
    public override void ExitState()
    {
        base.ExitState();

    }
}

