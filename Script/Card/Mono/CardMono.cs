using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;
using UnityEngine.EventSystems;

public class CardMono : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler/*,IDragHandler, IBeginDragHandler,IEndDragHandler*/
{
    public TextMeshProUGUI text;

    public AbstractCard cardData = new AbstractCard();

    public CardMonoStateMachile FSM = new CardMonoStateMachile();

    public RectTransform rectTransform;
    public void Initialize(AbstractCard card)
    {
        cardData = card;
        Update();
    }
    // Start is called before the first frame update
    public void Start()
    {
        //rectTransform = GetComponent<RectTransform>();
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
    float counter;
    CardMonoStateMachile.CardMonoStateType tempType;
    public void OnPointerEnter(PointerEventData eventData)
    {
        UIManager.Instance.ShowCardLore(cardData);
        if (FSM.currentState.stateType != CardMonoStateMachile.CardMonoStateType.Selected)
                FSM.ExchangeState(CardMonoStateMachile.CardMonoStateType.Hover);

     
            
        
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        UIManager.Instance.DisCardLore();
        if (FSM.currentState.stateType != CardMonoStateMachile.CardMonoStateType.Selected)
            FSM.ExchangeState(CardMonoStateMachile.CardMonoStateType.None);
    }

    //public void OnDrag(PointerEventData eventData)
    //{
    //    if(Draging)
    //    transform.GetComponent<RectTransform>().position = eventData.position - startPosOffset;
    //}
    //bool Draging = false;
    //public Vector2 startPosOffset;
    //public void OnBeginDrag(PointerEventData eventData)
    //{
    //    Draging = true;
    //    FSM.ExchangeState(CardMonoStateMachile.CardMonoStateType.Drag);
    //    startPosOffset = eventData.position - (Vector2)transform.GetComponent<RectTransform>().position;
    //    Debug.Log("鼠标位置" + eventData.position + "物体位置" + (Vector2)transform.GetComponent<RectTransform>().position + "偏移位置" + startPosOffset);
    //}

    //public void OnEndDrag(PointerEventData eventData)
    //{
    //    Draging = false;
    //    if(AbstractDungeon.Instance.isHovering)
    //    {
    //        if (!AbstractDungeon.Instance.player.IsHaveEnoughEnergy(cardData.cost))
    //        {
    //            FSM.ExchangeState(CardMonoStateMachile.CardMonoStateType.None);

    //        }
    //        else
    //        {
    //            cardData.UseCard(AbstractDungeon.Instance.player, AbstractDungeon.Instance.player);
    //            AbstractDungeon.Instance.player.MoveCardFormHandToDiscard(cardData);
    //            Destroy(gameObject);
    //            return;
    //        }
    //    }
    //    FSM.ExchangeState(CardMonoStateMachile.CardMonoStateType.None);
    //}


}
[Serializable]
public class CardMonoStateMachile
{
    public GameObject parentGameobject;

    public RectTransform rectTransform;

    public CardMonoState currentState = new CardMonoState();

    public void Initialize(GameObject parent)
    {
        parent = parentGameobject;
        //rectTransform = parentGameobject.GetComponent<RectTransform>();
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
        None,Selected,Hover,Drag
    }
    public Dictionary<CardMonoStateType, CardMonoState> cardMonoStateDictionary = new Dictionary<CardMonoStateType, CardMonoState>()
    {
        {CardMonoStateType.None, new CardMonoStateNone()},{CardMonoStateType.Selected,new CardMonoStateSelected()},
        {CardMonoStateType.Hover,new CardMonoStateHover() },{CardMonoStateType.Drag,new CardMonoStateDrag() }
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
        FSM.rectTransform .position += selectOffset;
    }
    public override void ExitState()
    {
        base.ExitState();
        FSM.rectTransform.position -= selectOffset;
    }
}
public class CardMonoStateHover : CardMonoState
{
    Vector3 selectOffset = new Vector3(0, 25,0);
    public override void EnterState()
    {
        base.EnterState();
        stateType = CardMonoStateMachile.CardMonoStateType.Hover;
        FSM.rectTransform.position += selectOffset;
        FSM.rectTransform.localScale = new Vector3(1.25f, 1.25f, 1.25f);

    }
    public override void ExitState()
    {
        base.ExitState();
        FSM.rectTransform.position -= selectOffset;
        FSM.rectTransform.localScale = new Vector3(1,1,1);
    }
}public class CardMonoStateDrag : CardMonoState
{
    Vector3 selectOffset = new Vector3(0, 25,0);
    Vector2 startPosition;
    public override void EnterState()
    {
        base.EnterState();
        startPosition = FSM.rectTransform.position;
        FSM.rectTransform.position += selectOffset;
        stateType = CardMonoStateMachile.CardMonoStateType.Drag;

        //FSM.parentGameobject.GetComponent<RectTransform>().anchoredPosition3D += selectOffset;

    }
    public override void ExitState()
    {
        base.ExitState();
        FSM.rectTransform.position = startPosition;
        Debug.Log("还原到" + startPosition);
        //FSM.parentGameobject.GetComponent<RectTransform>().anchoredPosition3D -= selectOffset;
    }
}