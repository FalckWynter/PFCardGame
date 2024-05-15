using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class SelectableLoreMono : CardLoreMono,IPointerClickHandler
{
    public Color initColor;
    public void Awake()
    {
        initColor = GetComponent<Image>().color;
    }
    /// <summary>
    /// ��ʼ����ѡ��UI
    /// </summary>
    /// <param name="tag"></param>
    /// <param name="parent"></param>
    public  void Initialize(AbstractTag tag ,ConfirmScreenMono parent)
    {
        //Debug.Log("�����tag" + tag.comment);
        base.Initialize(tag);
        cardTag = tag;
        screenParent = parent;
        GetComponent<Image>().color = initColor;
    }
    /// <summary>
    /// ����¼�
    /// </summary>
    /// <param name="eventData"></param>
    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("�����ѡ����");
        screenParent.AddSelect(this);
        GetComponent<Image>().color = new Color(0, 0, 0, 1);
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
