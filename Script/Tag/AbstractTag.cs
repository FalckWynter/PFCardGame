using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbstractTag 
{
    public int index;
    public string label;
    public string comment;
    public List<int> value = new List<int>();
    public virtual void UseTag(AbstractCreature source, AbstractCreature target)
    {

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
