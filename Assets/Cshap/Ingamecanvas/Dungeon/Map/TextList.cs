using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextList : MonoBehaviour
{
    public static TextList instance;
    public List<MapTile> TextBox;
    public Text QuestTitle, MidText;

    public List<GameObject> ChoiceButton;
    public List<Text> ChoiceButtonText; //선택지 버튼

    public MapGrid mapgrid;
    public Monster2 monster;
    
    public int Monster_HP;
    
    public MonsterHP monsterhp;

    public int Set_Map;
    public List<int> Ran_num;
    public string Title;
    public int HitDamage;
    public string MonsterState;

    public List<Effect> HeroEffect;
    public List<Effect> MonsterEffect;

    public Skill SelectSkill;
    public List<string> RewardType;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        mapgrid = GameObject.Find("MapGrid1").GetComponent<MapGrid>();
        monsterhp = GameObject.Find("InGameMonsterHP").GetComponent<MonsterHP>();
        init();
        HideText();

        CheckMapline();
    }

    void init(){
        QuestTitle = gameObject.transform.GetChild(5).GetComponent<Text>();
        MidText = gameObject.transform.GetChild(4).transform.GetChild(0).transform.GetChild(0).transform.GetChild(0).GetComponent<Text>();
        for(int i=0; i<4; i++){
            ChoiceButton.Add(gameObject.transform.GetChild(i).gameObject);
            ChoiceButton[i].GetComponent<ChoiceRoot>().choice = i;
            ChoiceButtonText.Add(ChoiceButton[i].transform.GetChild(0).GetComponent<Text>());
        }
        monsterhp.SetAct(false);
    }

    public void ShowText()
    {
            QuestTitle.text = PlayerSettingData.instance.Mapline[PlayerSettingData.instance.PlayerPin].TileTitle;
            MidText.text = PlayerSettingData.instance.Mapline[PlayerSettingData.instance.PlayerPin].Explain;

            TextBox = DataBase.instance.MapTileArrayYes.FindAll(x => x.No == PlayerSettingData.instance.Mapline[PlayerSettingData.instance.PlayerPin].No);
            
            for(int i=0; i<TextBox.Count; i++){
                ChoiceButton[i].SetActive(true);
                ChoiceButtonText[i].text = TextBox[i].TileTitle;
            }
    }

    public void HideText()
    {
        for(int i=0; i<4; i++){
            ChoiceButton[i].SetActive(false);
        }
    }

    public void CheckMapline(){ //string _No, string _TileName, string _TileTitle, string _Explain, string _MapInfo, string _RewardType, int _Num
        switch(PlayerSettingData.instance.Mapline[PlayerSettingData.instance.PlayerPin].TileName){
            case "함정": 
                Trap();
            break;

            case "보스": 
            Debug.Log("1입니당");
            break;

            case "휴식": 
            Debug.Log("2입니당");
            break;

            case "몬스터": 
                Debug.Log("3입니당");
                monster = DataBase.instance.Monster.Find(x => x.Name == PlayerSettingData.instance.Mapline[PlayerSettingData.instance.PlayerPin].TileTitle);

                if(MonsterState == ""){
                    QuestTitle.text = PlayerSettingData.instance.Mapline[PlayerSettingData.instance.PlayerPin].TileTitle;
                    MidText.text = monster.Name + " 이 출현했다. 몬스터의 체력 : "+ monster.HP + "\n\n";
                    Monster_HP = monster.HP;
                    monsterhp.Init();
                }
                if(Monster_HP > 0)
                {
                    monsterhp.SetAct(true);
                    Monster();
                    MonsterState = "몬스터";
                }
                else if(MonsterState == "스킬변경")
                {
                    SelectSkillPull();
                }
                else
                {
                    MidText.text = "처치되었습니다.";
                    monsterhp.SetAct(false);
                    Reward();
                    MonsterState = "리워드";
                }
            break;

            case "???": 
                Hidden();
            break;

            case "이벤트": 
            Debug.Log("5입니당");
            break;

            case "상점": 
            Debug.Log("6입니당");
            break;
        }
    }

    void Trap(){ // 0번
        Debug.Log("0입니당");
        ShowText();
    }

    void Boss(){ //1번

    }

    public void SelectSkillPull(){
        for(int i=0; i<PlayerSettingData.instance.PlayerSkill.Count; i++){
                ChoiceButton[i].SetActive(true);
                ChoiceButtonText[i].text = PlayerSettingData.instance.PlayerSkill[i].Name;
        }
        MonsterState = "스킬변경";
    }
    /*
    public void MonsterReload(){
        MidText.text += monster.Name + "의 몬스터의 체력 : "+ (monster.HP - HitDamage);
    }
    */

    void Monster(){

        for(int i=0; i<PlayerSettingData.instance.PlayerSkill.Count; i++){
                ChoiceButton[i].SetActive(true);
                ChoiceButtonText[i].text = PlayerSettingData.instance.PlayerSkill[i].Name;
        }

        //Battle(); 버튼 클릭 시 
    }
    

    public void Reward(){
        for(int i = 0; i<3; i++){
            Ran_num.Add(Random.Range(0, DataBase.instance.RewardList));
            Debug.Log(Ran_num[i]);
            if(Ran_num[i] < DataBase.instance.Item.Count)
            {
                ChoiceButtonText[i].text = DataBase.instance.Item[Ran_num[i]].Name;
                RewardType.Add("아이템");
                //PlayerSettingData.instance.PlayerItem.Add(DataBase.instance.Item[Ran_num]);
            } 
            else
            {
                Ran_num[i] -= DataBase.instance.Item.Count;
                if(Ran_num[i] < DataBase.instance.Skill.Count)
                {
                    ChoiceButtonText[i].text = DataBase.instance.Skill[Ran_num[i]].Name;
                    RewardType.Add("스킬");
                }
                else
                {
                    Ran_num[i] -= DataBase.instance.Skill.Count;
                    ChoiceButtonText[i].text = DataBase.instance.Passive[Ran_num[i]].Name;
                    RewardType.Add("패시브");
                }
            }
            ChoiceButton[i].SetActive(true);
        }
    }


    void Hidden(){ //4번
        Debug.Log("4입니당");
        List<MapTile> A = DataBase.instance.MapTileArray.FindAll(x => x.TileName == ReturnValue());
        MapTile S = A[Random.Range(0, A.Count)];
        PlayerSettingData.instance.Mapline[PlayerSettingData.instance.PlayerPin] = S;
        CheckMapline();
    }

    public string ReturnValue(){
        int Range = Random.Range(0, 6);
        switch(Range){
            case 0: Title = "함정"; break;
            case 1: Title = "보스"; break;
            case 2: Title = "휴식"; break;
            case 3: Title = "몬스터"; break;
            case 4: Title = "이벤트"; break;
            case 5: Title = "상점"; break;

        }
        
        return Title;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
