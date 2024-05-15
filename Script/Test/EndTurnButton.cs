using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndTurnButton : MonoBehaviour
{
    public void EndTurn()
    {
        //AbstractDungeon.Instance.StartNextTurn();
        //GameActionManager.Instance.AddToBottom(new NextTurnAction());
        GameActionManager.Instance.AddToBottom(new CalculateTurnEndAction());
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
