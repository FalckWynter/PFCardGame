using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectGridParentMono : MonoBehaviour
{
    #region ����
    //* ���弰�ű� *
    //����������
    public GameObject contentParent;
    //ȷ��ҳ��Ľű�
    public ConfirmScreenMono confirmScreen;

    //* ȫ����Դ *
    //Ҫ����Ŀ���Prefab * TODO �ĳ�·������������϶� *
    public GameObject cardPrefab;

    //* ѡ����ز��� *
    //Ҫѡ��Ŀ���
    public CardGroup sourceGroup;
    //�Ѿ�ѡ��Ŀ������� ������Ҫѡ�������
    public int selectCount = 0, needSelectCount = 1;
    //��ѡ��Ŀ��ƽű�
    public List<SelectGridCardMono> cardMonoList = new List<SelectGridCardMono>();
    //�Ƿ�ȷ������ѱ���
    public bool isConfirmScreenOpened;
    #endregion

    #region ���ܺ���
    //�����
    /// <summary>
    /// ���뿨�飬���ó�ʼ������
    /// </summary>
    /// <param name="sourceGroup"></param>
    public void OpenScreen(CardGroup sourceGroup)
    {
        //������ֵ

        //���ÿ���
        this.sourceGroup = sourceGroup;

        //������ֵ
        InitializeData();
        //�������
        InitializeScreen();
        //cardMonoList.Clear();

        UIManager.Instance.AddScreenCounter();
        Debug.Log("����Parent");

    }
    public void CloseScreen()
    {
        Debug.Log("����Parent");
        UIManager.Instance.ReduceScreenCounter();
        this.gameObject.SetActive(false);
    }
    /// <summary>
    /// �����趨��ֵ
    /// </summary>
    public void InitializeData()
    {
        //��������
        this.gameObject.SetActive(true);
        //�������ȷ��״̬
        confirmScreen.isConfirmed = false;
        //* TODO ��������Ҫѡ��Ŀ������� *
        needSelectCount = 1;

        //������Mono�б�
        for (int i = cardMonoList.Count - 1; i >= 0; i--)
        {
            cardMonoList.RemoveAt(i);
        }
    }
    /// <summary>
    /// ���»���ͼƬ
    /// </summary>
    public void InitializeScreen()
    {
        //��ȡ������ֵ��������Ⱦ
        int diff = sourceGroup.GetCardCount() - contentParent.transform.childCount;
        GameObject ob = null;
        //��������������
        if (diff <= 0)
        {
            //������࣬��ɾ��һЩ
            for (int i = 0; i < diff; i++)
            {
                GameObject.Destroy(contentParent.transform.GetChild(i).gameObject);
            }
        }
        
        else
        {
            //������٣�������һЩ
            for (int i = 0; i < Mathf.Abs (diff); i++)
            {

                ob = Instantiate(cardPrefab, contentParent.transform);
            }
        }
        //��λ�ø�ÿһ�ſ���ֵ
        for(int i = 0;i < sourceGroup.GetCardCount();i++)
        {
            contentParent.transform.GetChild(i).gameObject.GetComponent<SelectGridCardMono>().Initialize(sourceGroup.GetCardByPlace(i), this);
        }
    }
    #endregion

    #region ��ֵ����
    /// <summary>
    /// �ı俨�Ƶ�ѡ��״̬
    /// </summary>
    /// <param name="gridCardMono">���Ƶ�Mono�ű�</param>
    public void AddSelect(SelectGridCardMono gridCardMono)
    {
        //�������ȥ����û�������
        if (cardMonoList.Contains(gridCardMono))
            cardMonoList.Remove(gridCardMono);
        else
        {
            cardMonoList.Add(gridCardMono);
        }
    }
    #endregion

    #region ���º���
    private void Awake()
    {
        //ע�������
        UIManager.Instance.GridUI = this.gameObject;
        //��������
        gameObject.SetActive(false);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    /// <summary>
    /// �����Ƿ����ȷ��ҳ��
    /// </summary>
    public void UpdateScreen()
    {
        //���ѡ�������㹻 ��δ��ȷ�����

        if(cardMonoList.Count == needSelectCount && !isConfirmScreenOpened)
        {
           //��ȷ����壬����Ҫȷ�ϵ�����Value *Value�Ǹ�ģ������
            confirmScreen.OpenScreen(1);
            //�ı���bool
            isConfirmScreenOpened = true;
            //��ʼ��ȷ�����
            confirmScreen.Initialize(cardMonoList, new List<int> {1});
        }
        //����������� ������Ѿ��� * �����ϲ������
        else if(cardMonoList.Count != needSelectCount && isConfirmScreenOpened)
        {
            //�ı���
            isConfirmScreenOpened = false;
            //�ر����
            confirmScreen.CloseScreen();
        }
        //���ȷ��������ȷ��
        if (confirmScreen.isConfirmed)
        {
            //�ر�����
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
