using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class RepeatSkill : SkillBase
{
    public float CoolTime { get; set; } = 1.0f;

    public RepeatSkill() : base(Define.SkillType.Repeat)
    {

    }

    #region CoSkill
    Coroutine _coSkill;

    public override void ActivateSkill()
    {
        if (_coSkill != null)
            StopCoroutine(_coSkill);

        _coSkill = StartCoroutine(CoStartSkill());
    }

    protected abstract void DoSkillJob();

    protected virtual IEnumerator CoStartSkill()
    {
        WaitForSeconds wait = new WaitForSeconds(CoolTime);

        while (true)
        {
            // TODO : Repeat Skill

            yield return wait;
        }
    }
    #endregion

}
