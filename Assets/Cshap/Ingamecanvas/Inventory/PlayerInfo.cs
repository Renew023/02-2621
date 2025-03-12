using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInfo : MonoBehaviour
{
    public static PlayerInfo instance;

    //PlayerInfo.instance.player.Hp;
    //public Text T_DEX, T_ATK, T_SPD;
    public Text PlayerDate;
    /*public void AddStatus(){
        ATK, HP, DEX, SPD
    }*/
    
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        PlayerDate = gameObject.transform.GetChild(0).GetComponent<Text>();
        //T_DEX = gameObject.transform.GetChild(1).GetComponent<Text>();
        //T_SPD = gameObject.transform.GetChild(2).GetComponent<Text>();

        ReLoad();
    }

    public void ReLoad(){
        PlayerDate.text = "";

        PlayerDate.text += PlayerSettingData.instance.Player.Level + "\n";
        PlayerDate.text += PlayerSettingData.instance.Player.HP + "\n";
        PlayerDate.text += PlayerSettingData.instance.Player.ATK + "\n";
        PlayerDate.text += PlayerSettingData.instance.Player.DEX + "\n";
        PlayerDate.text += PlayerSettingData.instance.Player.SPD + "\n";
        PlayerDate.text += "\n";
        for(int i=0; i<PlayerSettingData.instance.PlayerSkill.Count; i++)
        {
            PlayerDate.text += PlayerSettingData.instance.PlayerSkill[i].Name + "\n";
        }
    
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
