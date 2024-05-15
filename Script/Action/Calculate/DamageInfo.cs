using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageInfo 
{
    public int damage,output;
    public AbstractCreature source, target;
    public DamageType type;
    public DamageInfo( AbstractCreature sour,AbstractCreature tar, int dmg, DamageType t = DamageType.None)
    {
        damage = dmg;
        source = sour;
        target = tar;
        type = t;
        output = damage;
    }    public DamageInfo( AbstractCreature sour,AbstractCreature tar,  DamageType t = DamageType.None)
    {
        damage = sour.attack;
        source = sour;
        target = tar;
        type = t;
        output = damage;
    }
    public enum DamageType
    {
        None,Normal,True,Magic,Poison
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
