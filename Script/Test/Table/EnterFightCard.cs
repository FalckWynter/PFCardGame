using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterFightCard : MonoBehaviour
{
    private void Awake()
    {
        UIManager.Instance.CardObject = this.gameObject.transform.parent.gameObject;
    }
    public void OnMouseUpAsButton()
    {
        UIManager.Instance.EnterFight();
        AbstractDungeon.Instance.InitializeFight(new AbstractMonster());
        AbstractDungeon.Instance.EnterFight();

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
