using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class DeleteTagConfirmMono : ConfirmScreenMono
{
    //要删除Tag的卡 取输入卡牌的第一张
    public AbstractCard cardToDelete;
    //可点击互动Tag的Prefab
    public GameObject selectableTagPrefab;
    //tag物体的父物体
    public GameObject tagParent;
    //卡牌数据的Object
    public GameObject cardObject;
    //要删除的Tag数量 * 未完成
    int deleteCount;
    /// <summary>
    /// 初始化面板
    /// </summary>
    /// <param name="cardMonoList"></param>
    /// <param name="values"></param>
    public override void Initialize(List<SelectGridCardMono> cardMonoList, List<int> values)
    {

        //清除原有订阅
        loreMonoList.Clear();
        //重置数据
        base.Initialize(cardMonoList,values);
        //设置要删除的卡牌 和要删除的数量
        cardToDelete = cardMonoList[0].card;
        deleteCount = values[0];
        //设置卡牌文本 * 未完成 应该单独做赋值
        cardObject.transform.Find("CardText").GetComponent<TextMeshProUGUI>().text = cardToDelete.label;
        //重设Tag的父物体
            InitializeTagParent();
  
    }
    /// <summary>
    /// 重设Tag内容
    /// </summary>
    public void InitializeTagParent()
    {
        //* 搞不定
        //LayoutRebuilder.ForceRebuildLayoutImmediate(tagParent.GetComponent<RectTransform>());
        //Debug.Log("目标卡牌的Tag" + cardToDelete.GetTagsCount() + "子物体数量" + tagParent.transform.childCount);
        ////获取数量差值以重新渲染
        //int diff = cardToDelete.GetTagsCount() - tagParent.transform.childCount;
        //GameObject ob = null;
        ////先修正物体数量
        //if (diff <= 0)
        //{
        //    //如果过多，则删除一些
        //    for (int i = 0; i < Mathf.Abs(diff); i++)
        //    {
        //        GameObject.Destroy(tagParent.transform.GetChild(i).gameObject);
        //    }
        //    LayoutRebuilder.ForceRebuildLayoutImmediate(tagParent.GetComponent<RectTransform>());
        //}

        //else
        //{
        //    //如果过少，则生成一些
        //    for (int i = 0; i < Mathf.Abs(diff); i++)
        //    {

        //        ob = Instantiate(selectableTagPrefab, tagParent.transform);
        //    }
        //    LayoutRebuilder.ForceRebuildLayoutImmediate(tagParent.GetComponent<RectTransform>());
        //}
        //LayoutRebuilder.ForceRebuildLayoutImmediate(tagParent.GetComponent<RectTransform>());
        ////按位置给每一张卡赋值
        //for (int i = 0; i < cardToDelete.GetTagsCount(); i++)
        //{

        //    tagParent.transform.GetChild(i).gameObject.GetComponent<SelectableLoreMono>().Initialize(cardToDelete.GetTagByPlace(i), this);
        //}

        //无语子 要强制更新，否则会因为找不到元素而出问题
        LayoutRebuilder.ForceRebuildLayoutImmediate(tagParent.GetComponent<RectTransform>());
        GameObject ob;
        //重置所有Tag物体
        foreach (AbstractTag tag in cardToDelete.tags)
        {
            ob = GameObject.Instantiate(selectableTagPrefab, tagParent.transform);
            ob.GetComponent<SelectableLoreMono>().Initialize(tag, this);
        }

    }
    /// <summary>
    /// 确认选择内容 - 交给Button触发 * 未完成  
    /// </summary>
    public override void ConfirmSelect()
    {
        base.ConfirmSelect();
        //将已选择的Tag从卡牌上移除
        for(int i = loreMonoList.Count - 1; i >= 0;i--)
        {
            cardToDelete.RemoveTagByClass(loreMonoList[i].cardTag);
        }
        //通知上级该物体已完成确认
        isConfirmed = true;
        //关闭面板
        CloseScreen();
      
    }
    /// <summary>
    /// 关闭面板
    /// </summary>
    public override void CloseScreen()
    {
        base.CloseScreen();
    }
    private void OnDisable()
    {
        //清除所有子物体
        for (int i = tagParent.transform.childCount - 1; i >= 0; i--)
        {

            if (tagParent.transform.GetChild(i).gameObject == null)
                continue;
            GameObject.Destroy(tagParent.transform.GetChild(i).gameObject);
        }
    }
}
