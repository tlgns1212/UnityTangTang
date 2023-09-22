using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager
{
    public PlayerController Player { get { return Managers.Object?.Player; } }

    #region ��ȭ
    public int Gold { get; set; }
    public int Gem { get; set; }
    #endregion

    #region �̵�
    Vector2 _moveDir;

    public event Action<Vector2> OnMoveDirChanged;

    public Vector2 MoveDir
    {
        get { return _moveDir; }
        set
        {
            _moveDir = value;
            OnMoveDirChanged?.Invoke(_moveDir);
        }
    }
    #endregion
}
