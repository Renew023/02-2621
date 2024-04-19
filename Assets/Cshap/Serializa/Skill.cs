using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Skill{
    public Skill(string _No, string _Name, int _Damage, int _Shield, string _Explain, string _STAT, int _hitNumber, string _Effect, int _EffectPer, int _HitEffect, string _SkillType, int _Turn, int _SkillRare)
    { No = _No; Name = _Name; Explain = _Explain; STAT = _STAT; Effect = _Effect; Damage = _Damage; Sheild = _Shield; hitNumber = _hitNumber; EffectPer = _EffectPer; HitEffect = _HitEffect; SkillType = _SkillType;
     Turn = _Turn; SkillRare = _SkillRare;}
    public string No, Name, Explain, STAT, Effect, SkillType;
    public int Damage, hitNumber, EffectPer, Turn, HitEffect, Sheild, SkillRare;//스킬 할당치
}
