using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfirmScreenMono : MonoBehaviour
{
    //�Ƿ������ȷ��
    public bool isConfirmed;
    //��Ҫ��ѡ������
    public int needCount;
    //��ѡ���Lore����
    public List<CardLoreMono> loreMonoList = new List<CardLoreMono>();

    //����������������Ŀ�������
    public List<SelectGridCardMono> cardMonoList = new List<SelectGridCardMono>();
    //������Զ���ֵ����
    public List<int> values = new List<int>();



    /// <summary>
    /// ��ȡ�Ƿ��Ѿ����ȷ��
    /// </summary>
    /// <returns></returns>
    public bool GetIsConfirmed()
    {
        return isConfirmed;
    }
    /// <summary>
    /// �ر����
    /// </summary>
    public virtual void CloseScreen()
    {
        if (!this.gameObject.activeSelf)
            return;
        UIManager.Instance.ReduceScreenCounter();
        this.gameObject.SetActive(false);
        Debug.Log("����Confirm");
    }
    /// <summary>
    /// �������
    /// </summary>
    /// <param name="count"></param>
    public virtual void OpenScreen(int count)
    {
        needCount = count;
        gameObject.SetActive(true);
        UIManager.Instance.AddScreenCounter();
        Debug.Log("����Confirm");
    }
    /// <summary>
    /// ��ʼ����� - Ҫ����ȷ�ϵĿ��ƺͲ���
    /// </summary>
    /// <param name="cardMonoList">Ҫ����ȷ�ϵĿ���</param>
    /// <param name="values">Ҫ����ȷ�ϵĲ���</param>
    public virtual void Initialize(List<SelectGridCardMono> cardMonoList,List<int> values)
    {
        //��ֵ
        this.cardMonoList = cardMonoList;
        this.values = values;
    }
    /// <summary>
    /// ���ѡ������
    /// </summary>
    /// <param name="mono"></param>
    public virtual void AddSelect(CardLoreMono mono)
    {
        //����������������
        if (loreMonoList.Count >= needCount)
            return;
        //���������ȡ�����ģ��������Ӷ���
        if (loreMonoList.Contains(mono))
            loreMonoList.Remove(mono);
        else
            loreMonoList.Add(mono);
    }
    /// <summary>
    /// �Ƴ�ѡ�� δ���
    /// </summary>
    public virtual void RemoveSelect()
    {

    }

    /// <summary>
    /// ȷ��ѡ�񲢽��в��� - �麯�� - �����������
    /// </summary>
    public virtual void ConfirmSelect()
    {

    }
    /// <summary>
    /// ������� �����������
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
