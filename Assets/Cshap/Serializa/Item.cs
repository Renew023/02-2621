using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Item{
    public Item(string _No, string _Name, int _HP, int _ATK, int _DEX, int _SPEED, string _Explain, string _Type, string[] _Effect)
    {No = _No; Name = _Name; HP = _HP; ATK = _ATK; DEX = _DEX; SPEED = _SPEED; Explain = _Explain; Type = _Type; Effect = _Effect;}
    //체력, 공격력, 방어력, 경험치, 스피드
    public string Name, No, Type, Explain;
    public string[] Effect;
    public int HP, ATK, DEX, SPEED;
}