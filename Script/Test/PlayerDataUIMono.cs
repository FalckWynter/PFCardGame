using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class PlayerDataUI : MonoBehaviour
{
    public AbstractCreature creature;
    public bool isPlayer = false;
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
        if (isPlayer)
            creature = AbstractDungeon.Instance.player;
        else
            creature = AbstractDungeon.Instance.monster;
        health.text = creature.currentHealth.ToString();
        energy.text = creature.energy.ToString();
        exp.text = creature.exp.ToString();
        atk.text = creature.attack.ToString();
        def.text = creature.defend.ToString();
    }
}
