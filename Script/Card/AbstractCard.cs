using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbstractCard 
{
    public int cost = 0;
    //public int cost { get { return Cost; } set { Cost = value;Debug.Log("cost被修改到了" + value); } }
        public int costForTurn = 1;
    public string label;
    public int index;

    public int maxTagsCount = 4;

    public AbstractCreature owner;

    public List<AbstractTag> tags = new List<AbstractTag>();

    public AbstractCard CreateDeepCopy()
    {
        AbstractCard cardToReturn = new AbstractCard();
        cardToReturn.tags = this.tags;
        cardToReturn.label = this.label;
        cardToReturn.cost = this.cost;
        return cardToReturn;
    }
    public void UseCard(AbstractCreature source,AbstractCreature target)
    {
        foreach(AbstractTag tag in tags)
        {
            tag.UseTag(source,target);
        }
    }
    public bool AddNewTag(AbstractTag tagToAdd)
    {
        if (tags.Count >= maxTagsCount)
            return false;
        tags.Add(tagToAdd);
        return true;
    }
    public bool RemoveTagByClass(AbstractTag tagToRemove)
    {
        if (!tags.Contains(tagToRemove))
            return false;
        tags.Remove(tagToRemove);
        return true;
    }
    public bool RemoveTagByPlace(int place)
    {
        if (place >= tags.Count)
            return false;
        tags.RemoveAt(place);
        return true;
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
