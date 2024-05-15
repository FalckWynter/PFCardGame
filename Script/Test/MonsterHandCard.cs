using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class MonsterHandCard : MonoBehaviour
{
    public TextMeshProUGUI text;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(AbstractDungeon.Instance.monster.handPile.GetTopCard() != null)
        text.text = AbstractDungeon.Instance.monster.handPile.GetTopCard().label;
    }
}
