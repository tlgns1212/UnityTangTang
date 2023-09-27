using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatureController : BaseController
{
    // 나한테 걸어준 버프 목록

    protected float _speed = 1.0f;

    public int HP { get; set; } = 100;
    public int MaxHP { get; set; } = 100;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public virtual void OnDamaged(BaseController attacker, int damage)
    {
        HP -= damage;
        if(HP < 0)
        {
            HP = 0;
            OnDead();
        }
    }

    protected virtual void OnDead() 
    {
        
    }
}
