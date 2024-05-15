using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;
public class SelectGridCardMono : MonoBehaviour,IPointerClickHandler
{
    public AbstractCard card;

    public SelectGridParentMono gridParent;

    public TextMeshProUGUI text;
    public void Initialize(AbstractCard card, SelectGridParentMono parent)
    {
        this.card = card;
        text.text = card.label;
        gridParent = parent;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        gridParent.AddSelect(this);
        Debug.Log("µã»÷ÁË");
    }
}
