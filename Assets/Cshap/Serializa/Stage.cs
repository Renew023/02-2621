using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Stage{
    public Stage(string _No, string _Title, string _Explain, string _Level, string _DropItem)
    {No = _No; Title = _Title; Explain = _Explain; Level = _Level; DropItem = _DropItem;}
    
    public string No, Title, Explain, Level, DropItem;
}
