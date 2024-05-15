using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class DeleteTagConfirmMono : ConfirmScreenMono
{
    //Ҫɾ��Tag�Ŀ� ȡ���뿨�Ƶĵ�һ��
    public AbstractCard cardToDelete;
    //�ɵ������Tag��Prefab
    public GameObject selectableTagPrefab;
    //tag����ĸ�����
    public GameObject tagParent;
    //�������ݵ�Object
    public GameObject cardObject;
    //Ҫɾ����Tag���� * δ���
    int deleteCount;
    /// <summary>
    /// ��ʼ�����
    /// </summary>
    /// <param name="cardMonoList"></param>
    /// <param name="values"></param>
    public override void Initialize(List<SelectGridCardMono> cardMonoList, List<int> values)
    {

        //���ԭ�ж���
        loreMonoList.Clear();
        //��������
        base.Initialize(cardMonoList,values);
        //����Ҫɾ���Ŀ��� ��Ҫɾ��������
        cardToDelete = cardMonoList[0].card;
        deleteCount = values[0];
        //���ÿ����ı� * δ��� Ӧ�õ�������ֵ
        cardObject.transform.Find("CardText").GetComponent<TextMeshProUGUI>().text = cardToDelete.label;
        //����Tag�ĸ�����
            InitializeTagParent();
  
    }
    /// <summary>
    /// ����Tag����
    /// </summary>
    public void InitializeTagParent()
    {
        //* �㲻��
        //LayoutRebuilder.ForceRebuildLayoutImmediate(tagParent.GetComponent<RectTransform>());
        //Debug.Log("Ŀ�꿨�Ƶ�Tag" + cardToDelete.GetTagsCount() + "����������" + tagParent.transform.childCount);
        ////��ȡ������ֵ��������Ⱦ
        //int diff = cardToDelete.GetTagsCount() - tagParent.transform.childCount;
        //GameObject ob = null;
        ////��������������
        //if (diff <= 0)
        //{
        //    //������࣬��ɾ��һЩ
        //    for (int i = 0; i < Mathf.Abs(diff); i++)
        //    {
        //        GameObject.Destroy(tagParent.transform.GetChild(i).gameObject);
        //    }
        //    LayoutRebuilder.ForceRebuildLayoutImmediate(tagParent.GetComponent<RectTransform>());
        //}

        //else
        //{
        //    //������٣�������һЩ
        //    for (int i = 0; i < Mathf.Abs(diff); i++)
        //    {

        //        ob = Instantiate(selectableTagPrefab, tagParent.transform);
        //    }
        //    LayoutRebuilder.ForceRebuildLayoutImmediate(tagParent.GetComponent<RectTransform>());
        //}
        //LayoutRebuilder.ForceRebuildLayoutImmediate(tagParent.GetComponent<RectTransform>());
        ////��λ�ø�ÿһ�ſ���ֵ
        //for (int i = 0; i < cardToDelete.GetTagsCount(); i++)
        //{

        //    tagParent.transform.GetChild(i).gameObject.GetComponent<SelectableLoreMono>().Initialize(cardToDelete.GetTagByPlace(i), this);
        //}

        //������ Ҫǿ�Ƹ��£��������Ϊ�Ҳ���Ԫ�ض�������
        LayoutRebuilder.ForceRebuildLayoutImmediate(tagParent.GetComponent<RectTransform>());
        GameObject ob;
        //��������Tag����
        foreach (AbstractTag tag in cardToDelete.tags)
        {
            ob = GameObject.Instantiate(selectableTagPrefab, tagParent.transform);
            ob.GetComponent<SelectableLoreMono>().Initialize(tag, this);
        }

    }
    /// <summary>
    /// ȷ��ѡ������ - ����Button���� * δ���  
    /// </summary>
    public override void ConfirmSelect()
    {
        base.ConfirmSelect();
        //����ѡ���Tag�ӿ������Ƴ�
        for(int i = loreMonoList.Count - 1; i >= 0;i--)
        {
            cardToDelete.RemoveTagByClass(loreMonoList[i].cardTag);
        }
        //֪ͨ�ϼ������������ȷ��
        isConfirmed = true;
        //�ر����
        CloseScreen();
      
    }
    /// <summary>
    /// �ر����
    /// </summary>
    public override void CloseScreen()
    {
        base.CloseScreen();
    }
    private void OnDisable()
    {
        //�������������
        for (int i = tagParent.transform.childCount - 1; i >= 0; i--)
        {

            if (tagParent.transform.GetChild(i).gameObject == null)
                continue;
            GameObject.Destroy(tagParent.transform.GetChild(i).gameObject);
        }
    }
}
