using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndTurnButton : MonoBehaviour
{
    public void EndTurn()
    {
        AbstractDungeon.Instance.ExchangeToPhase(AbstractDungeon.CombatPhase.Player);
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
