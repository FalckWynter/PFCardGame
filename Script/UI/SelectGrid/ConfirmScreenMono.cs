using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfirmScreenMono : MonoBehaviour
{
    //是否以完成确认
    public bool isConfirmed;
    //需要的选择数量
    public int needCount;
    //已选择的Lore参数
    public List<CardLoreMono> loreMonoList = new List<CardLoreMono>();

    //传入参数：参与面板的卡牌数据
    public List<SelectGridCardMono> cardMonoList = new List<SelectGridCardMono>();
    //传入的自定义值参数
    public List<int> values = new List<int>();



    /// <summary>
    /// 获取是否已经完成确认
    /// </summary>
    /// <returns></returns>
    public bool GetIsConfirmed()
    {
        return isConfirmed;
    }
    /// <summary>
    /// 关闭面板
    /// </summary>
    public virtual void CloseScreen()
    {
        if (!this.gameObject.activeSelf)
            return;
        UIManager.Instance.ReduceScreenCounter();
        this.gameObject.SetActive(false);
        Debug.Log("禁用Confirm");
    }
    /// <summary>
    /// 开启面板
    /// </summary>
    /// <param name="count"></param>
    public virtual void OpenScreen(int count)
    {
        needCount = count;
        gameObject.SetActive(true);
        UIManager.Instance.AddScreenCounter();
        Debug.Log("启用Confirm");
    }
    /// <summary>
    /// 初始化面板 - 要参与确认的卡牌和参数
    /// </summary>
    /// <param name="cardMonoList">要参与确认的卡牌</param>
    /// <param name="values">要参与确认的参数</param>
    public virtual void Initialize(List<SelectGridCardMono> cardMonoList,List<int> values)
    {
        //赋值
        this.cardMonoList = cardMonoList;
        this.values = values;
    }
    /// <summary>
    /// 添加选择内容
    /// </summary>
    /// <param name="mono"></param>
    public virtual void AddSelect(CardLoreMono mono)
    {
        //如果超出容量则忽略
        if (loreMonoList.Count >= needCount)
            return;
        //如果包括则取消订阅，否则增加订阅
        if (loreMonoList.Contains(mono))
            loreMonoList.Remove(mono);
        else
            loreMonoList.Add(mono);
    }
    /// <summary>
    /// 移除选择 未完成
    /// </summary>
    public virtual void RemoveSelect()
    {

    }

    /// <summary>
    /// 确认选择并进行操作 - 虚函数 - 交给子类完成
    /// </summary>
    public virtual void ConfirmSelect()
    {

    }
    /// <summary>
    /// 更新面板 交给子类完成
    /// </summary>
    public virtual void UpdateScreen()
    {

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
