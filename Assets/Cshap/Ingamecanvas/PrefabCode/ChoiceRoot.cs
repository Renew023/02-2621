using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoiceRoot : MonoBehaviour
{
    public int choice;
    public List<MapTile> TextBox;
    public PlayerHP playerhp;
    public MonsterHP monsterhp;
    public PlayerInfo playerstat;
    public Ending End;
    public int Ran_num;

    public int Stat;

    void Start(){
        playerhp = GameObject.Find("InGamePlayerHP").GetComponent<PlayerHP>();
        monsterhp = GameObject.Find("InGameMonsterHP").GetComponent<MonsterHP>();
        //playerstat = GameObject.Find("InGamePlayerStatus").GetComponent<PlayerInfo>(); 
        End = GameObject.Find("InGamecanvas").transform.GetChild(6).GetComponent<Ending>();
    }

    public void CheckMapline(){ //string _No, string _TileName, string _TileTitle, string _Explain, string _MapInfo, string _RewardType, int _Num
        switch(PlayerSettingData.instance.Mapline[PlayerSettingData.instance.PlayerPin].TileName){
            case "함정": 
            EventChoiceSelect();
            break;

            case "보스": 
            Debug.Log("1입니당");
            EventChoiceSelect();
            break;

            case "휴식": 
            Debug.Log("2입니당");
            EventChoiceSelect();
            break;

            case "몬스터": 
            Debug.Log("3입니당");
                monsterhp.SetAct(true);
                if(TextList.instance.monster.HP - TextList.instance.HitDamage > 0)
                {
                    Battle();
                }
                else
                {
                    RewardSelect();
                }
            break;

            case "???": 
            EventChoiceSelect();

            break;

            case "이벤트": 
            EventChoiceSelect();
            Debug.Log("5입니당");
            break;

            case "상점": 
            EventChoiceSelect();
            Debug.Log("6입니당");
            break;
        }
    }

    public void Battle(){ //string _No, string _Name, int _Damage, int _Shield, string _Explain, string _STAT, int _hitNumber, string _Effect, int _EffectPer, int _HitEffect, string _SkillType, int _Turn
        TextList.instance.HitDamage += PlayerSettingData.instance.PlayerSkill[choice].Damage * AttackSelect() /100;
        //TextList.instance.MonsterReload();
        if(TextList.instance.monster.HP - TextList.instance.HitDamage <= 0)
        {
            //TextList.instance.MidText.text = "처치되었습니다.";
            
            //RewardSelect();
        }
        else
        {
            if(PlayerSettingData.instance.PlayerSkill[choice].Turn == 0){
                MonsterTurn();  
            }
            else
            {
                PlayerSettingData.instance.PlayerSkill[choice].Turn -= 1;
            }
        }
    }

    public void MonsterTurn(){
        PlayerSettingData.instance.Player.HP -= TextList.instance.monster.ATK;
        TextList.instance.MidText.text += "\n\n" + TextList.instance.monster.ATK + "의 피해를 받았습니다." + "\n\n";
        RootEnd();
    }

    public void EventChoiceSelect(){
        //Debug.Log(mapgrid.Mapline[choice].TileTitle);
        
        TextBox = DataBase.instance.MapTileArrayYes.FindAll(x => x.No == PlayerSettingData.instance.Mapline[PlayerSettingData.instance.PlayerPin].No);
        
        switch(TextBox[choice].RewardType){
            case "ATK" : PlayerSettingData.instance.Player.ATK += TextBox[choice].Num;

            break;
            
            case "DEX" : PlayerSettingData.instance.Player.DEX += TextBox[choice].Num;

            break;
            case "HP" : PlayerSettingData.instance.Player.HP += TextBox[choice].Num;

            break;

            case "SPD" : PlayerSettingData.instance.Player.SPD += TextBox[choice].Num;

            break;
        }
        Debug.Log(TextBox[choice].RewardType + " : " + TextBox[choice].Num);
        RootEnd();
        PlayerSettingData.instance.PlayerPin++;
    }

    public void RootEnd(){
        playerhp.ReLoad();
        monsterhp.ReLoad();

        if(PlayerSettingData.instance.Player.HP <= 0)
            End.End();
    }

    public int AttackSelect(){
        
        switch(PlayerSettingData.instance.PlayerSkill[choice].STAT)
        {
            case "ATK" : Stat = PlayerSettingData.instance.Player.ATK;

            break;
            
            case "DEX" : Stat = PlayerSettingData.instance.Player.DEX;
            break;
            case "HP" : Stat = PlayerSettingData.instance.Player.HP;

            break;

            case "SPD" : Stat = PlayerSettingData.instance.Player.SPD;
            break;
        }
        return Stat;
    }



    public void RewardSelect(){
        Ran_num = TextList.instance.Ran_num[choice];
        if(Ran_num < DataBase.instance.Item.Count)
            {
                PlayerSettingData.instance.PlayerItem.Add(DataBase.instance.Item[Ran_num]);
            } 
        else
            {
                Ran_num -= DataBase.instance.Item.Count;
                if(Ran_num < DataBase.instance.Skill.Count)
                {
                    PlayerSettingData.instance.PlayerSkill.Add(DataBase.instance.Skill[Ran_num]);
                }
                else
                {
                    Ran_num -= DataBase.instance.Skill.Count;
                    PlayerSettingData.instance.PlayerPassive.Add(DataBase.instance.Skill[Ran_num]);
                }
            }
        TextList.instance.Ran_num.Clear();
        RootEnd();
        TextList.instance.HitDamage = 0;
        PlayerSettingData.instance.PlayerPin++;
    }
        
}
