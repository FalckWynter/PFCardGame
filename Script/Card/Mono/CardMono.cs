using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;
using UnityEngine.EventSystems;
public class CardMono : MonoBehaviour,IPointerClickHandler,IPointerEnterHandler,IPointerExitHandler
{
    public TextMeshProUGUI text;

    public AbstractCard cardData = new AbstractCard();

    public CardMonoStateMachile FSM = new CardMonoStateMachile();

    public void Initialize(AbstractCard card)
    {
        cardData = card;
        Update();
    }
    // Start is called before the first frame update
    public void Start()
    {
        FSM.Initialize(this.gameObject);
        FSM.parentGameobject = this.gameObject;
        //UnityAction<BaseEventData> action = new UnityAction<BaseEventData>(onHomeItemDown);
        //eventTrigger = GetComponent<EventTrigger>();
        //EventTrigger.Entry entry = new EventTrigger.Entry();
        //entry.eventID = EventTriggerType.PointerEnter;
        //entry.callback.AddListener(OnMouseEnter);
    }

    // Update is called once per frame
    public void Update()
    {
        FSM.UpdateState();
        text.text = cardData.label;
    }
    //public void OnMouseEnter()
    //{
    //    Debug.Log("鼠标进入");
    //}

    public void OnPointerClick(PointerEventData eventData)
    {
        if (FSM.currentState.stateType != CardMonoStateMachile.CardMonoStateType.Selected)
        {
            //Debug.Log("测试" + cardData.label + "花费" + cardData.cost);
            AbstractDungeon.Instance.selectedCardPool.Add(this);
            FSM.ExchangeState(CardMonoStateMachile.CardMonoStateType.Selected);
        }
        else
        {
            AbstractDungeon.Instance.selectedCardPool.Remove(this);
            FSM.ExchangeState(CardMonoStateMachile.CardMonoStateType.None);
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (FSM.currentState.stateType != CardMonoStateMachile.CardMonoStateType.Selected)
            FSM.ExchangeState(CardMonoStateMachile.CardMonoStateType.Hover);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (FSM.currentState.stateType != CardMonoStateMachile.CardMonoStateType.Selected)
            FSM.ExchangeState(CardMonoStateMachile.CardMonoStateType.None);
    }
}
[Serializable]
public class CardMonoStateMachile
{
    public GameObject parentGameobject;

    public CardMonoState currentState = new CardMonoState();

    public void Initialize(GameObject parent)
    {
        parent = parentGameobject;
    }
    public void ExchangeState(CardMonoStateType type)
    {
        currentState.ExitState();
        currentState = (CardMonoState)Activator.CreateInstance(cardMonoStateDictionary[type].GetType());
        currentState.Initialize(this);
        currentState.EnterState();
    }
    public void UpdateState()
    {
        currentState.UpdateState();
    }
    public enum CardMonoStateType
    {
        None,Selected,Hover
    }
    public Dictionary<CardMonoStateType, CardMonoState> cardMonoStateDictionary = new Dictionary<CardMonoStateType, CardMonoState>()
    {
        {CardMonoStateType.None, new CardMonoStateNone()},{CardMonoStateType.Selected,new CardMonoStateSelected()},
        {CardMonoStateType.Hover,new CardMonoStateHover() }
    };
}
public class CardMonoState
{
    public CardMonoStateMachile FSM;

    public CardMonoStateMachile.CardMonoStateType stateType;
    public virtual void Initialize(CardMonoStateMachile machine)
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
public class CardMonoStateNone :CardMonoState
{
    public override void EnterState()
    {
        base.EnterState();
        stateType = CardMonoStateMachile.CardMonoStateType.None;
    }
}
public class CardMonoStateSelected : CardMonoState
{
    Vector3 startPosition, selectOffset = new Vector3(0, 50,0);

    public override void EnterState()
    {
        base.EnterState();
        stateType = CardMonoStateMachile.CardMonoStateType.Selected;
        FSM.parentGameobject.GetComponent<RectTransform>() .anchoredPosition3D += selectOffset;
    }
    public override void ExitState()
    {
        base.ExitState();
        FSM.parentGameobject.GetComponent<RectTransform>().anchoredPosition3D -= selectOffset;
    }
}
public class CardMonoStateHover : CardMonoState
{
    Vector3 selectOffset = new Vector3(0, 25,0);
    public override void EnterState()
    {
        base.EnterState();
        stateType = CardMonoStateMachile.CardMonoStateType.Hover;
        FSM.parentGameobject.GetComponent<RectTransform>().anchoredPosition3D += selectOffset;
       
    }
    public override void ExitState()
    {
        base.ExitState();
        FSM.parentGameobject.GetComponent<RectTransform>().anchoredPosition3D -= selectOffset;
    }
}