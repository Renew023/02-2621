using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameManager : MonoBehaviour
{
    public static InGameManager instance;

    public int MonsterATK, MonsterKill;
    //public int Turn;

    public List<Item> Item; //Clear
    //public List<> UMul; // Clear
    //public int Passive;
    //skill

    void Start()
    {
        instance = this;
    }

    void OnEnable()
    {
        PlayerSettingData.instance.PlayerPassive.Clear();
        PlayerSettingData.instance.PlayerSkill.Clear();
        PlayerSettingData.instance.PlayerUMul.Clear();
        PlayerSettingData.instance.PlayerItem.Clear();
    }

    void Update()
    {
        
    }
}
