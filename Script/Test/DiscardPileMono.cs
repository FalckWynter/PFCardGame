using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class DiscardPileMono : MonoBehaviour
{
    public TextMeshProUGUI discardCount;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!AbstractDungeon.Instance.isFighting)
            return;
        //Debug.Log("ÆúÅÆ¶ÑÊýÁ¿" + AbstractDungeon.Instance.player.discardPile.GetCardCount());
        discardCount.text = AbstractDungeon.Instance.player.discardPile.GetCardCount().ToString();
    }
}
