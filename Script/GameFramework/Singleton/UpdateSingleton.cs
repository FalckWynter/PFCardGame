using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class UpdateSingleton<T> : IUpdateSingleton where T : class, IUpdateSingleton
{
    private static T instance;
    public static T Instance
    {
        get
        {
            if (instance == null)
            {
                instance = Activator.CreateInstance<T>();
                instance.Initialize();
            }
            return instance;
        }
    }

    public bool IsDisposed { get; set; }

    public virtual void Initialize()
    {
        UpdateSingletonManager.Instance.AddToSingletonList(this);
    }

    public virtual void Dispose()
    {
        IsDisposed = true;
        instance = null;
    }

    public virtual void OnUpdate()
    {

    }
}
