using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Monster2{
    public Monster2(string _No, string _Name, int _HP, int _ATK, int _DEX, int _EXP, int _SPEED, int _Level, string _Map)
    {No = _No; Name = _Name; HP = _HP; ATK = _ATK; DEX = _DEX; EXP = _EXP; SPEED = _SPEED; Level = _Level; Map = _Map;}
    //체력, 공격력, 방어력, 경험치, 스피드
    public string Name, No, Map;
    public int HP, ATK, DEX, EXP, SPEED, Level;
}
