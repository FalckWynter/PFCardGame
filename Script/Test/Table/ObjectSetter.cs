using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSetter : MonoBehaviour
{
    public GameObject FightUI;
    public GameObject LoreUI;
    public GameObject Blocker;
    // Start is called before the first frame update
    void Awake()
    {
        UIManager.Instance.FightUI = FightUI;
        UIManager.Instance.LoreUI = LoreUI;
        UIManager.Instance.Blocker = Blocker;
        UIManager.Instance.LoreUI.SetActive(false);
        UIManager.Instance.FightUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
