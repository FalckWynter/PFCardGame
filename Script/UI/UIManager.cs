using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : UpdateSingleton<UIManager>
{
    public GameObject FightUI;
    public GameObject CardObject;
    public GameObject LoreUI;
    public GameObject GridUI;
    public GameObject Blocker;
    public static GameObject lorePrefab;

    public List<AbstractScreenPanel> ScreenStack = new List<AbstractScreenPanel>();

    public int ScreenCounter = 0;
    public int AddScreenCounter()
    {
        return ExchangeScreentCounter(1);
    }
    public int ReduceScreenCounter()
    {
        return ExchangeScreentCounter(-1);
    }
    public int ExchangeScreentCounter(int counter)
    {
        Debug.Log("�������޸�" + counter + "��" + ScreenCounter);
        ScreenCounter += counter;
        if (ScreenCounter > 0)
            Blocker.SetActive(true);
        else if (ScreenCounter == 0)
            Blocker.SetActive(false);
        else
            Debug.LogWarning("Ϊʲô���渲�Ǽ�����Ϊ������");
        return ScreenCounter;
    }
    public void AddNewScreen(AbstractScreenPanel ob)
    {
        ScreenStack.Add(ob);
    }
    public AbstractScreenPanel GetCurrentScreen()
    {
        return ScreenStack[ScreenStack.Count - 1];
    }
    public void ClostCurrentScreen()
    {
        GameObject.Destroy(ScreenStack[ScreenStack.Count - 1].gameObject);

    }
    static UIManager()
    {
        lorePrefab = Resources.Load<GameObject>("Prefabs/Tag/TagPrefab");
    }
    public UIManager()
    {
        //FightUI = Transform.Find("BasicUi");
     
    }
    public void ShowCardLore(AbstractCard cardToLore)
    {
        Debug.Log("Ҫչʾ�Ŀ���" + cardToLore.tags.Count + "Ҫ�ݻٵ�����" + LoreUI.transform.childCount);
        for (int i = 0; i < LoreUI.transform.childCount; i++)
        {
            GameObject.Destroy(LoreUI.transform.GetChild(i).gameObject);
        }
        GameObject ob;
        LoreUI.SetActive(true);
        foreach (AbstractTag tag in cardToLore.tags)
        {
            ob = GameObject.Instantiate(lorePrefab, LoreUI.transform);
            ob.GetComponent<CardLoreMono>().Initialize(tag);
        }
    }
    public void DisCardLore()
    {
        LoreUI.SetActive(false);
    }
    public void EnterFight()
    {
        FightUI.SetActive(true);
        CardObject.SetActive(false);
    }
    public void ExitFight()
    {
        FightUI.SetActive(false);
        CardObject.SetActive(true);
    }
    public void OpenGridUI(CardGroup source)
    {
        Blocker.SetActive(true);
        GridUI.GetComponent<SelectGridParentMono>().OpenScreen(source);
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
