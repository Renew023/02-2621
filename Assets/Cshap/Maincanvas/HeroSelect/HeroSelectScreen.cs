using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeroSelectScreen : MonoBehaviour
{
    public int SelectHero_int;

    public GameObject HeroPR, HeroSkillPanel, HeroStatusPanel;
    
    public Text HeroName;
    public Image HeroImage;
    public Sprite HeroSprite;
    public Text HeroOneword;
    public Skill HeroSkill, HeroPassive;

    void Select_int(){
        HeroName.text = DataBase.instance.Hero[SelectHero_int].Name;
        HeroImage.sprite = Resources.Load<Sprite>("MapTile" + SelectHero_int);
    }

    public void SelectHero_Right(){
        SelectHero_int += 1;
        if(DataBase.instance.Hero.Count <= SelectHero_int){
            SelectHero_int = 0;
        }
        Select_int();
    }

    public void SelectHeroLeft(){
        SelectHero_int -= 1;
        if(0 > SelectHero_int){
            SelectHero_int = DataBase.instance.Hero.Count-1;
        }
        Select_int();
    }

    public void SelectHero(){
        PlayerSettingData.instance.Player.No = DataBase.instance.Hero[SelectHero_int].No;
        PlayerSettingData.instance.Player.Name = DataBase.instance.Hero[SelectHero_int].Name;
        PlayerSettingData.instance.Player.HP = DataBase.instance.Hero[SelectHero_int].HP;
        PlayerSettingData.instance.Max_HP = DataBase.instance.Hero[SelectHero_int].HP;
        PlayerSettingData.instance.Player.ATK = DataBase.instance.Hero[SelectHero_int].ATK;
        PlayerSettingData.instance.Player.DEX = DataBase.instance.Hero[SelectHero_int].DEX;
        PlayerSettingData.instance.Player.SPD = DataBase.instance.Hero[SelectHero_int].SPD;
        PlayerSettingData.instance.Player.EXP = DataBase.instance.Hero[SelectHero_int].EXP;
        PlayerSettingData.instance.Player.Level = DataBase.instance.Hero[SelectHero_int].Level;

            for(int S=0; S<DataBase.instance.Hero[SelectHero_int].Skill.Length; S++)
            {
                HeroSkill = DataBase.instance.Skill.Find(x => x.Name == DataBase.instance.Hero[SelectHero_int].Skill[S]);
                PlayerSettingData.instance.PlayerSkill.Add(HeroSkill);
            }
            for(int P=0; P<DataBase.instance.Hero[SelectHero_int].Passive.Length; P++)
            {
                HeroPassive = DataBase.instance.Passive.Find(x => x.Name == DataBase.instance.Hero[SelectHero_int].Passive[P]);
                PlayerSettingData.instance.PlayerPassive.Add(HeroPassive);
            }

        }

    // Start is called before the first frame update
    void Start()
    {
        HeroPR = gameObject.transform.GetChild(0).gameObject;
        HeroName = HeroPR.transform.GetChild(0).GetComponent<Text>();
        HeroImage = HeroPR.transform.GetChild(1).GetComponent<Image>();

        HeroSkillPanel = gameObject.transform.GetChild(1).gameObject;
        HeroStatusPanel = gameObject.transform.GetChild(2).gameObject;
        Select_int();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
