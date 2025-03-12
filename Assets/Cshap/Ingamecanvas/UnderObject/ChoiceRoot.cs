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

    public Effect SkillEffect;

    public int Ran_num;
    public string RewardType;

    public int Stat;

    void Start(){
        playerhp = GameObject.Find("InGamePlayerHP").GetComponent<PlayerHP>();
        monsterhp = GameObject.Find("InGameMonsterHP").GetComponent<MonsterHP>();
        //playerstat = GameObject.Find("InGamePlayerStatus").GetComponent<PlayerInfo>(); 
        End = GameObject.Find("InGamecanvas").transform.GetChild(8).GetComponent<Ending>();
    }

    public void CheckMapline(){ //string _No, string _TileName, string _TileTitle, string _Explain, string _MapInfo, string _RewardType, int _Num
        if(TextList.instance.result == 0)
        {
            TextList.instance.result = 1;
            PlayerSettingData.instance.PlayerPin++;
            TextList.instance.PlayerTurn.text = "" + PlayerSettingData.instance.PlayerPin;
            return;
        }
        TextList.instance.check = choice;
        
        switch(PlayerSettingData.instance.Mapline[PlayerSettingData.instance.PlayerPin].TileName){
            case "함정": 
            EventChoiceSelect();
            break;

            case "보스": 
            Debug.Log("1입니당");
            switch(TextList.instance.MonsterState){
                    
                case "몬스터" : Battle(); break;
                case "리워드" : RewardSelect(); break;
                case "스킬변경" : SkillChange(); break;
                }
            break;

            case "휴식": 
            Debug.Log("2입니당");
            EventChoiceSelect();
            break;

            case "몬스터": 
            Debug.Log("3입니당");
                switch(TextList.instance.MonsterState){
                    
                case "몬스터" : Battle(); break;
                case "리워드" : RewardSelect(); break;
                case "스킬변경" : SkillChange(); break;
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

    public void Attack(int num){
        for(int s=0; s<num; s++){
            TextList.instance.Monster_HP -= PlayerSettingData.instance.PlayerSkill[choice].Damage * AttackSelect();
            
            for(int i=0; i < PlayerSettingData.instance.PlayerItem.Count; i++)
            {
                for(int j=0; j < PlayerSettingData.instance.PlayerItem[i].Effect.Length; j++)
                {
                    SkillEffect = DataBase.instance.EffectArray.Find(x=> x.Name == PlayerSettingData.instance.PlayerItem[i].Effect[j]);
                    MonsterAddBuff(SkillEffect.No, SkillEffect.Turn);
                    Debug.Log(SkillEffect);
                }
            }

            SkillEffect = DataBase.instance.EffectArray.Find(x => x.Name == PlayerSettingData.instance.PlayerSkill[choice].Effect); //스킬의 담겨있는 효과s
            MonsterAddBuff(SkillEffect.No, SkillEffect.Turn);
        }
    }

    public void Battle(){ //string _No, string _Name, int _Damage, int _Shield, string _Explain, string _STAT, int _hitNumber, string _Effect, int _EffectPer, int _HitEffect, string _SkillType, int _Turn
        Attack(PlayerSettingData.instance.PlayerSkill[choice].hitNumber);

        Debug.Log(SkillEffect);

        //TextList.instance.MonsterReload();
        if(TextList.instance.Monster_HP <= 0)
        {
            monsterhp.ReLoad();
            //TextList.instance.MidText.text = "처치되었습니다.";
            
            //RewardSelect();
        }
        else
        {
            
                monsterhp.ReLoad();
                MonsterTurn();  
        }
    }

    public void MonsterTurn(){
        PlayerSettingData.instance.Player.HP -= TextList.instance.monster.ATK;
        TextList.instance.MidText.text += "\n\n" + TextList.instance.monster.ATK + "의 피해를 받았습니다." + "\n\n";
        RootEnd();
        TurnEnd();
    }


    public void EventChoiceSelect(){
        Debug.Log("클릭되었습니다.");
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
        TextList.instance.result = 0;
    }

    public void RootEnd(){
        playerhp.ReLoad();

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

    public void SkillChange(){
        PlayerSettingData.instance.PlayerSkill[choice] = TextList.instance.SelectSkill;
        TextList.instance.MonsterState = "";
        TextList.instance.result = 0;
        TextList.instance.Ran_num.Clear();
        TextList.instance.RewardType.Clear();
        //TextList.instance.HitDamage = 0;
    }

    public void RewardSelect(){
        TextList.instance.MidText.text = PlayerSettingData.instance.Mapline[PlayerSettingData.instance.PlayerPin].Explain;

        Ran_num = TextList.instance.Ran_num[choice];
        RewardType = TextList.instance.RewardType[choice];
        if(RewardType == "아이템")
            {
                PlayerSettingData.instance.PlayerItem.Add(DataBase.instance.Item[Ran_num]);
            } 
        else
            {
                if(RewardType == "스킬")
                {
                    if(PlayerSettingData.instance.PlayerSkill.Count >= 4){
                        TextList.instance.MonsterState = "스킬변경";
                        TextList.instance.SelectSkill = DataBase.instance.Skill[Ran_num];
                        return;
                    }
                    else {
                    PlayerSettingData.instance.PlayerSkill.Add(DataBase.instance.Skill[Ran_num]);
                    }
                }
                else
                {
                    PlayerSettingData.instance.PlayerPassive.Add(DataBase.instance.Passive[Ran_num]);
                }
            }
        //TextList.instance.HitDamage = 0;
        TextList.instance.MonsterState = "";
        TextList.instance.Ran_num.Clear();
        TextList.instance.RewardType.Clear();
        RootEnd();
        TextList.instance.MidText.text = "";
        PlayerSettingData.instance.PlayerPin++;
        TextList.instance.PlayerTurn.text = "" + PlayerSettingData.instance.PlayerPin;
    }
    public void TurnEnd(){
        for(int i=0; i< TextList.instance.MonsterEffect.Count; i++){ //몬스터에게 걸려있는 디버프 및 버프 개수.
            MonsterApplyBuff(TextList.instance.MonsterEffect[i].No, TextList.instance.MonsterEffect[i].DMG, TextList.instance.MonsterEffect[i].Turn);
            TextList.instance.MonsterEffect[i].Turn-=1;
        }
        for (int i= TextList.instance.MonsterEffect.Count; i > 0; i--){
            if(TextList.instance.MonsterEffect[i-1].Turn == 0){
                TextList.instance.MonsterEffect.RemoveAt(i-1);
            }
        }
        for(int i=0; i< TextList.instance.HeroEffect.Count; i++){ //몬스터에게 걸려있는 디버프 및 버프 개수.
            HeroApplyBuff(TextList.instance.HeroEffect[i].No, TextList.instance.HeroEffect[i].DMG, TextList.instance.HeroEffect[i].Turn);
        
        }
        for (int i= TextList.instance.HeroEffect.Count; i > 0; i--){
            if(TextList.instance.HeroEffect[i-1].Turn == 0){
                TextList.instance.HeroEffect.RemoveAt(i-1);
            }
        }
    }
    public void HitEffect(){
        
    }

    public void HeroApplyBuff(string No, int DMG, int Turn){
        switch(No)
        {
            case "0": 
                PlayerSettingData.instance.Player.HP -= DMG;
                Debug.Log("독성으로 인한 피해");
                break;
            case "1":
                PlayerSettingData.instance.Player.HP -= DMG;
                Debug.Log("불꽃으로 인한 피해");
                break;
            case "2":
                break;
            case "3":
                break;
            case "4":
                break;
            
        }
    }

     public void HeroAddBuff(string No, int Turned){
        for(int i=0; i<TextList.instance.HeroEffect.Count; i++)
            {
                if(TextList.instance.HeroEffect[i].No == No)
                {
                    Debug.Log("시발 이게 수행되");
                    TextList.instance.HeroEffect[i].Turn += Turned;
                    return;
                }  
            } 
            Debug.Log("시발 이게 수행되면 안됨");
            TextList.instance.HeroEffect.Add(new Effect(DataBase.instance.EffectArray.Find(x => x.No == No)));
            TextList.instance.HeroEffect[TextList.instance.HeroEffect.Count-1].Turn += Turned-1;
            
    }

    public void MonsterAddBuff(string No, int Turned){
         for(int i=0; i<TextList.instance.MonsterEffect.Count; i++)
            {
                if(TextList.instance.MonsterEffect[i].No == No)
                {
                    Debug.Log("시발 이게 수행되");
                    TextList.instance.MonsterEffect[i].Turn += Turned;
                    return;
                }  
            } 
            Debug.Log("시발 이게 수행되면 안됨");
            TextList.instance.MonsterEffect.Add(new Effect(DataBase.instance.EffectArray.Find(x => x.No == No)));
            TextList.instance.MonsterEffect[TextList.instance.MonsterEffect.Count-1].Turn += Turned-1;
    }

    public void MonsterApplyBuff(string No, int DMG, int Turn){
        switch(No)
        {
            case "0": 
                TextList.instance.Monster_HP -= DMG;
                Debug.Log("독성으로 인한 피해");
                break;
            case "1":
                 TextList.instance.Monster_HP -= DMG;
                Debug.Log("불꽃으로 인한 피해");
                break;
            case "2":
                break;
            case "3":
                break;
            case "4":
                break;
            
        }
    }
}
