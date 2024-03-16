using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Hero{
    public Hero(string _No, string _Name, int _HP, int _ATK, int _DEX, int _EXP, int _SPD, int _Level, string _Explain, string[] _Skill, string[] _Passive)
    {No = _No; Name = _Name; HP = _HP; ATK = _ATK; DEX = _DEX; EXP = _EXP; SPD = _SPD; Level = _Level; Explain = _Explain; Skill = _Skill; Passive = _Passive;}
    //체력, 공격력, 방어력, 경험치, 스피드
    public string Name, No, Explain;
    public int HP, ATK, DEX, EXP, SPD, Level;
    public string[] Skill, Passive;
}
