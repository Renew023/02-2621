using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

public class DataBase : MonoBehaviour
{
    public static DataBase instance;
    
    public List<Monster2> Monster;
    
    public List<Image> MonsterImage;

    public List<Hero> Hero;
    public List<Image> HeroImage;

    public List<Skill> Skill; //액티브
    public List<Skill> Passive;
    public List<Skill> UMul;
    public List<Skill> PassiveSkill;

    public List<Effect> EffectArray;

    public List<Item> Item;

    public List<Stage> StageArray;
    public List<MapTile> MapTileArray;
    public List<MapTile> MapTileArrayYes;
    public List<MapTile> MapTileArrayNo;

    public int RewardList;
    public string CurName;
    public int AllPage, SlotAll, CurPage = 1;

    // Start is called before the first frame update

    void Awake()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ItemList(){
        Item.Add(new Item("0", "롱소드", 0, 10, 0, 5, "잘만들어진 칼", "장검", new string[]{"불꽃", "독성"}));
        Item.Add(new Item("1", "롱소드", 0, 10, 0, 5, "별이 빛나는 밤", "장검", new string[]{"독성"}));
    }

    public void MonsterList(){
        Monster.Add(new Monster2("0", "고블린", 100, 5, 0, 2, 20, 1, "버섯집"));
        Monster.Add(new Monster2("1", "오크", 200, 10, 1, 5, 12, 1, "버섯집"));
        Monster.Add(new Monster2("2", "박쥐", 30, 10, 0 , 3, 60, 1, "버섯집"));
        Monster.Add(new Monster2("3", "드레이크", 3000, 10, 0 , 3, 60, 1, "버섯집"));
        Monster.Add(new Monster2("4", "양아취", 1000, 100, 0 , 10, 20, 1, "버섯집"));
        MonsterImage.AddRange(Resources.LoadAll<Image>("Monster"));
        }

    public void HeroList(){ //string _No, string _Name, int _HP, int _ATK, int _DEX, int _EXP, int _SPD, int _Level
        Hero.Add(new Hero("0", "청소부", 10000, 10, 10, 0, 10, 1, "청소를 좋아하는 청소부. 그의 청소능력은 몬스터에게도 통한다.", new string[] {"강렬한 일격", "독바른 쌍연격"}, new string[]{"대장의 품격"}));
        Hero.Add(new Hero("1", "게이머", 50, 10, 5, 0, 50, 1, "프로게이머로 체력은 낮지만 빠른 반응속도를 자랑한다.", new string[] {"강렬한 일격", "독바른 쌍연격"}, new string[]{}));
        Hero.Add(new Hero("2", "농부", 200, 30, 30, 0, 10, 1, "농사로 단련된 농부. 허나 관절이 좋지 않아 몸이 다소 느리다.", new string[] {"강렬한 일격", "독바른 쌍연격"}, new string[]{}));
        MonsterImage.AddRange(Resources.LoadAll<Image>("Hero"));
    }

    public void SkillList(){ //string _No, string _Name, int _Damage, int _shield, string _Explain, string _STAT, int _hitNumber, string _Effect, int _EffectPer, string _SkillType, int _Turn
        Skill.Add(new Skill("0", "강렬한 일격", 120, 0, "강력한 힘으로 상대를 타격합니다.", "ATK", 1, "독성", 50, 1, "Active", 1, 20));
        Skill.Add(new Skill("1", "독바른 쌍연격", 60, 0, "강력한 힘으로 상대를 타격합니다.", "SPD", 2, "불꽃", 80, 2, "Active", 2, 20));
        Skill.Add(new Skill("2", "강철의 심장", 0, 100,"체력을 순간적으로 증폭시킨다.", "DEX", 1, "쉴드", 100, 2, "Active", 2, 20));
    }
    public void PassiveList(){
        Passive.Add(new Skill("0", "대장의 품격", 0, 0, "게임 시작 시 상대에게 데미지를 줍니다", "ATK", 10, "", 0, 0, "Passive",0, 2));
        Passive.Add(new Skill("1", "쇄약", 0, 0, "공격력이 일정치만큼 감소합니다.", "ATK", 1, "", 0, 0, "Self",0, -5));
    }

    public void EffectList(){//No, Name, EffectExplain, DMG, Turn
        EffectArray.Add(new Effect("0", "독성", "해당 수치*10(데미지)만큼 데미지를 부여한다. / 턴 마다 1 감소", 10 , 1));
        EffectArray.Add(new Effect("1", "불꽃", "해당 수치*50(데미지)만큼 데미지를 부여한다. / 공격할때마다 1 감소", 50 , 1));
        EffectArray.Add(new Effect("2", "쉴드", "해당 쉴드량을 그대로 보존한다.", 1, 1));
    }

    public void StageList(){
        StageArray.Add(new Stage("0", "버섯집", "사람만한 버섯으로 유명했던 버섯.\n 어느 날부터인가 감당안될 정도로 커졌고 그곳에서 몬스터가 나오기 시작하여 \n 마을의 주민들이 토벌을 의뢰했다.", "1", ""));
        StageArray.Add(new Stage("1", "그림집", "어린 아이가 그린 것 같은 집. \n 어린 시절 그림을 본 건축가가 초심을 되찾고 싶어 만들었다. \n 허나 영감을 받아 만든 건축물이 원인인지 귀신이 실체화되어 나오기 시작했고 \n 건축가가 토벌의뢰를 하였다.", "15", ""));
        StageArray.Add(new Stage("2", "언어마술사", "ㅇㅇ", "300", ""));
    }

    public void MapTileList(){
        MapTileArray.Add(new MapTile("0000", "함정", "압정 지뢰", "길거리에 압정이 깔려있습니다.", "Hard", "", 0));
        MapTileArray.Add(new MapTile("0001", "함정", "통나무 기관", "누군가 악의적으로 설치한듯 보이는 통나무 기관이 보입니다.","Hard", "", 0));
        MapTileArray.Add(new MapTile("1000", "몬스터", "고블린", "흉악하다", "Easy", "Item", 2));
        MapTileArray.Add(new MapTile("1001", "몬스터", "오크", "귀엽다", "Easy", "DEX", 3));
        MapTileArray.Add(new MapTile("1002", "몬스터", "박쥐", "날쌔다", "Easy", "SPD", 5));
        MapTileArray.Add(new MapTile("1003", "몬스터", "양아취", "씨발럼", "Easy", "SPD", 5));
        MapTileArray.Add(new MapTile("2000", "이벤트", "짜장면", "세계에서 제일 맛있는 짜장면입니다. 한 입 먹어볼래요?", "Easy", "SPD", 5));
        MapTileArray.Add(new MapTile("3000", "보스", "드레이크", "가장 강력한 생명체라고 불리우는 드래곤의 아종입니다.", "Hard", "SPD", 10));
        
        /*MapTileArray.Add(new MapTile("2", "보스", "Hard"));
        MapTileArray.Add(new MapTile("3", "휴식", "Hard"));
        MapTileArray.Add(new MapTile("4", "몬스터", "Hard"));
        MapTileArray.Add(new MapTile("5", "???", "Hard"));
        MapTileArray.Add(new MapTile("6", "이벤트", "Hard"));
        MapTileArray.Add(new MapTile("7", "상점", "Hard"));*/
    }
    public void MapTileYes(){
        MapTileArrayYes.Add(new MapTile("0000", "함정", "피해 간다", "압정을 피해 안전하게 갔습니다.", "Hard", "", 0));
        MapTileArrayYes.Add(new MapTile("0000", "함정", "밟고 간다", "이런 것도 기연일까요? 압정에 자극을 받아 강해졌습니다", "Hard", "ATK", 1)); //switch로 STR 대신 숫자를 부여하거나 애초에 String 값.
        MapTileArrayYes.Add(new MapTile("0001", "함정", "수련 장소로 이용한다.", "통나무는 그리 안전한 장치가 아니였습니다...", "Hard", "HP", -50));
        MapTileArrayYes.Add(new MapTile("0001", "함정", "통나무를 가져간다.", "통나무는 거대했습니다. 그리고 무거웠죠", "Hard", "HP", -30));
        MapTileArrayYes.Add(new MapTile("1000", "몬스터", "고블린", "흉악하다", "Easy", "ATK", 2));
        MapTileArrayYes.Add(new MapTile("1001", "몬스터", "오크", "흉악하다", "Easy", "ATK", 2));
        MapTileArrayYes.Add(new MapTile("1002", "몬스터", "박쥐", "흉악하다", "Easy", "ATK", 2));
        MapTileArrayYes.Add(new MapTile("1003", "몬스터", "양아취", "흉악하다", "Easy", "ATK", 2));

        MapTileArrayYes.Add(new MapTile("2000", "이벤트", "맛있겠쥐?", "맛있네", "Easy", "ATK", 2));
        MapTileArrayYes.Add(new MapTile("2000", "이벤트", "맛없겠쥐?", "맛없네", "Easy", "ATK", 2));
        MapTileArrayYes.Add(new MapTile("3000", "보스", "드레이크", "강한 상대였지만 맛있었습니다.", "Hard", "SPD", 10));
    }

    public void RewardListSum(){
        RewardList = Item.Count + Skill.Count + Passive.Count;

    }

    public void MapTileNo(){
        //MapTileArrayNo.Add(new MapTile("1", "함정", "밟고 간다", "이런 것도 기연일까요? 압정에 자극을 받아 강해졌습니다", "Hard", "STR", 1));
        //MapTileArrayNo.Add(new MapTile())
    }

    void Effecting(){
    }
}
