using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseController : MonoBehaviour
{
    public Define.ObjectType ObjectType { get; protected set; }

    void Awake()
    {
        Init();
    }

    bool _init = false;
    public virtual bool Init()
    {
        if (_init)
            return false;

        _init = true;
        return true;
    }

    void Update()
    {
        UpdateController();
    }

    public virtual void UpdateController()
    {

    }
}
