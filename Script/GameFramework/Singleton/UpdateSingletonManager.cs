using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateSingletonManager : Singleton<UpdateSingletonManager>
{
    public List<IUpdateSingleton> singletonList = new List<IUpdateSingleton>();

    public override void Initialize()
    {
        base.Initialize();
    }
    public void AddToSingletonList(IUpdateSingleton singleton)
    {
        if(!singletonList.Contains(singleton))
        singletonList.Add(singleton);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void Update()
    {
        foreach(IUpdateSingleton singleton in singletonList)
        {
            singleton.OnUpdate();
        }
    }
}
