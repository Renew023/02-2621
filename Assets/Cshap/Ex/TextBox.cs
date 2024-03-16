/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextBox : MonoBehaviour
{

    private IObjectPool<TextBox> _ManagedPool;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void SetManagedPool(IObjectPool<TextBox> pool)
    {
        _ManagedPool = pool;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DestroyTextBox()
    {
        _ManagedPool.Release(this);
    }
}
*/