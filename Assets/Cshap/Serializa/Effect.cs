using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class Effect{
    public Effect(string _No, string _Name, string _EffectExplain, int _DMG, int _Turn)
    {No = _No; Name = _Name; EffectExplain = _EffectExplain; DMG = _DMG; Turn = _Turn;}
    public string No, Name, EffectExplain;
    public int DMG, Turn;
}
