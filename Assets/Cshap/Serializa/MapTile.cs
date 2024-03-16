using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class MapTile
{
    public MapTile(string _No, string _TileName, string _TileTitle, string _Explain, string _MapInfo, string _RewardType, int _Num)
    {No = _No; TileName = _TileName; TileTitle = _TileTitle; Explain = _Explain; MapInfo = _MapInfo; RewardType = _RewardType; Num = _Num; }
    //RewardType = Stat/STR
    public string No, TileName, TileTitle, Explain, MapInfo, RewardType;
    public int Num; //순서, 타일 이름, 

}
