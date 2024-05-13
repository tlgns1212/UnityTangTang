using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//EgoSword : ��Ÿ
// FireProjectile: ����ü
// PosionField_OA: �ٴ�

public class SkillBase : BaseController
{
    public CreatureController Owner { get; set; }
    public Define.SkillType SkillType { get; set; }
    public Data.SkillData SkillData { get; protected set; }

    public int SkillLevel { get; set; } = 0;
    public bool IsLearnSkill { get { return SkillLevel > 0; } }

    public int Damage { get; set; } = 100;

    public SkillBase(Define.SkillType skillType)
    {
        SkillType = skillType;
    }

    public virtual void ActivateSkill() { }

    protected virtual void GenerateProjectile(int templateID, CreatureController owner, Vector3 startPos, Vector3 dir, Vector3 targetPos)
    {
        ProjectileController pc = Managers.Object.Spawn<ProjectileController>(startPos, templateID);
        pc.SetInfo(templateID, owner, dir);
    }

    #region Destroy
    Coroutine _coDestroy;

    public void StartDestroy(float delaySeconds)
    {
        StopDestroy();
        _coDestroy = StartCoroutine(CoDestroy(delaySeconds));
    }

    public void StopDestroy()
    {
        if (_coDestroy != null)
        {
            StopCoroutine(_coDestroy);
            _coDestroy = null;
        }
    }

    IEnumerator CoDestroy(float delaySeconds)
    {
        yield return new WaitForSeconds(delaySeconds);

        if (this.IsValid())
        {
            Managers.Object.Despawn(this);
        }
    }


    #endregion
}
