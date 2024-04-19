using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class UMul{
    public UMul(string _No, string _Name, int _HP, int _ATK, int _DEX, int _SPEED, string _Explain, int _turn, string[] _Effect)
    {No = _No; Name = _Name; HP = _HP; ATK = _ATK; DEX = _DEX; SPEED = _SPEED; Explain = _Explain; turn = _turn; Effect = _Effect;}
    
    //까마귀의 날개, 한 턴동안 상대의 공격이 맞지 않습니다.        DEX+100; 

    public string Name, No, Explain;
    public string[] Effect;
    public int HP, ATK, DEX, SPEED, turn;

    /*public Effect(Effect effect)
    {
        No = effect.No; 
        Name = effect.Name; 
        EffectExplain = effect.EffectExplain; 
        DMG = effect.DMG; 
        Turn = effect.Turn;
    }*/
}
