using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterEditCardMono : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnMouseUpAsButton()
    {
   
        UIManager.Instance.GridUI.GetComponent<SelectGridParentMono>().OpenScreen(AbstractDungeon.Instance.player.masterDeck);
    }
}
