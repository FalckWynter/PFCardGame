using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class PlayerDataUI : MonoBehaviour
{
    public TextMeshProUGUI exp, atk, def,energy,health;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!AbstractDungeon.Instance.GetFighting())
            return;
        health.text = AbstractDungeon.Instance.player.health.ToString();
        energy.text = AbstractDungeon.Instance.player.energy.ToString();
        exp.text = AbstractDungeon.Instance.player.exp.ToString();
        atk.text = AbstractDungeon.Instance.player.attack.ToString();
        def.text = AbstractDungeon.Instance.player.defend.ToString();
    }
}
