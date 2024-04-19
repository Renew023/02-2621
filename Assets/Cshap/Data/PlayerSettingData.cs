using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class PlayerSettingData : MonoBehaviour
{
    //플레이어가 가져야할 정보
    //이외 메인캔버스에서 가져와야할 정보., player 1.특성, 2. 해금된 맵, 3.레벨, 4.유물

    //1. 능력치, 2. 인벤토리, 3.스킬, 4.맵 좌표, 5. 선택된 맵.
    
    public static PlayerSettingData instance;

    public List<Monster> MainMonster; //몬스터 도감
    public List<Item> MainItem; //아이템 도감
    public List<Item> SoBiItem; //소비 아이템

    public List<Skill> MainPassive; //패시브 선택
    public List<Skill> MainUMul; //유물 선택

    
    public int Max_HP;
    public Status Player; // 1. 능력치

    public List<Item> PlayerItem; 
    public List<Item> Selection;
    public List<Skill> PlayerPassive; // 2. 인벤토리 인 게임.
    public int PassiveSuchi;

    public List<Skill> PlayerUMul;

    public List<Skill> PlayerSkill; // 3. 스킬(액티브)


    public int PlayerPin; // 4. 맵 좌표.
    public List<MapTile> Mapline;

    public string MapName; // 5. 선택된 맵.
    public Stage SetStage;

    public List<Skill> Playerskill; //최대 4개까지 얻을 수 있고 그 이후에 스킬 습득 시 기존 것을 삭제함. 

    /*public void GetSkill(){
        if(Skill.Count >= 4)
        {
            ReleaseSkill(Click);
        } 
        else
        {
            Playerskill.Add(skill);
        }
    }

    public void ReleaseSkill(){
        PlayerSkill.RemoveAt(Click);
        PlayerSkill.Insert(Click, GetSkill());
    }

    public void GetPlayer(Status Hero){
        Player = Hero;
    }

    public void GetStage(Stage Stage){
        SetStage = Stage;
    }

    public Status PutPlayer(){
        return Player;
    }

    public Stage PutStage(){
        return SetStage;
    }*/

    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
    }

}
