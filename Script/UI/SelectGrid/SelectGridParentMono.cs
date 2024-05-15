using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectGridParentMono : MonoBehaviour
{
    #region 参数
    //* 物体及脚本 *
    //面板的子物体
    public GameObject contentParent;
    //确认页面的脚本
    public ConfirmScreenMono confirmScreen;

    //* 全局资源 *
    //要载入的卡牌Prefab * TODO 改成路径载入而不是拖动 *
    public GameObject cardPrefab;

    //* 选择相关参数 *
    //要选择的卡组
    public CardGroup sourceGroup;
    //已经选择的卡牌数量 最少需要选择的数量
    public int selectCount = 0, needSelectCount = 1;
    //已选择的卡牌脚本
    public List<SelectGridCardMono> cardMonoList = new List<SelectGridCardMono>();
    //是否确认面板已被打开
    public bool isConfirmScreenOpened;
    #endregion

    #region 功能函数
    //打开面板
    /// <summary>
    /// 输入卡组，设置初始化数据
    /// </summary>
    /// <param name="sourceGroup"></param>
    public void OpenScreen(CardGroup sourceGroup)
    {
        //重设数值

        //设置卡组
        this.sourceGroup = sourceGroup;

        //重设数值
        InitializeData();
        //重置面板
        InitializeScreen();
        //cardMonoList.Clear();

        UIManager.Instance.AddScreenCounter();
        Debug.Log("启用Parent");

    }
    public void CloseScreen()
    {
        Debug.Log("禁用Parent");
        UIManager.Instance.ReduceScreenCounter();
        this.gameObject.SetActive(false);
    }
    /// <summary>
    /// 重新设定数值
    /// </summary>
    public void InitializeData()
    {
        //启动物体
        this.gameObject.SetActive(true);
        //重设面板确认状态
        confirmScreen.isConfirmed = false;
        //* TODO 可以设置要选择的卡牌数量 *
        needSelectCount = 1;

        //清理卡牌Mono列表
        for (int i = cardMonoList.Count - 1; i >= 0; i--)
        {
            cardMonoList.RemoveAt(i);
        }
    }
    /// <summary>
    /// 重新绘制图片
    /// </summary>
    public void InitializeScreen()
    {
        //获取数量差值以重新渲染
        int diff = sourceGroup.GetCardCount() - contentParent.transform.childCount;
        GameObject ob = null;
        //先修正物体数量
        if (diff <= 0)
        {
            //如果过多，则删除一些
            for (int i = 0; i < diff; i++)
            {
                GameObject.Destroy(contentParent.transform.GetChild(i).gameObject);
            }
        }
        
        else
        {
            //如果过少，则生成一些
            for (int i = 0; i < Mathf.Abs (diff); i++)
            {

                ob = Instantiate(cardPrefab, contentParent.transform);
            }
        }
        //按位置给每一张卡赋值
        for(int i = 0;i < sourceGroup.GetCardCount();i++)
        {
            contentParent.transform.GetChild(i).gameObject.GetComponent<SelectGridCardMono>().Initialize(sourceGroup.GetCardByPlace(i), this);
        }
    }
    #endregion

    #region 数值互动
    /// <summary>
    /// 改变卡牌的选择状态
    /// </summary>
    /// <param name="gridCardMono">卡牌的Mono脚本</param>
    public void AddSelect(SelectGridCardMono gridCardMono)
    {
        //如果有则去除，没有则添加
        if (cardMonoList.Contains(gridCardMono))
            cardMonoList.Remove(gridCardMono);
        else
        {
            cardMonoList.Add(gridCardMono);
        }
    }
    #endregion

    #region 更新函数
    private void Awake()
    {
        //注册该物体
        UIManager.Instance.GridUI = this.gameObject;
        //隐藏自身
        gameObject.SetActive(false);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    /// <summary>
    /// 更新是否进入确认页面
    /// </summary>
    public void UpdateScreen()
    {
        //如果选择数量足够 且未打开确认面板

        if(cardMonoList.Count == needSelectCount && !isConfirmScreenOpened)
        {
           //打开确认面板，输入要确认的数量Value *Value是个模糊参数
            confirmScreen.OpenScreen(1);
            //改变标记bool
            isConfirmScreenOpened = true;
            //初始化确认面板
            confirmScreen.Initialize(cardMonoList, new List<int> {1});
        }
        //如果数量不足 且面板已经打开 * 理论上不会出现
        else if(cardMonoList.Count != needSelectCount && isConfirmScreenOpened)
        {
            //改变标记
            isConfirmScreenOpened = false;
            //关闭面板
            confirmScreen.CloseScreen();
        }
        //如果确认面板完成确认
        if (confirmScreen.isConfirmed)
        {
            //关闭自身
            //this.gameObject.SetActive(false);
            CloseScreen();
        }
    }
    // Update is called once per frame
    void Update()
    {
        UpdateScreen();
    }
    #endregion
}
