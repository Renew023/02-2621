using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInfo : MonoBehaviour
{
    //PlayerInfo.instance.player.Hp;
    public Status player;
    public int DEX, ATK, SPD;
    public Text T_DEX, T_ATK, T_SPD;

    /*public void AddStatus(){
        ATK, HP, DEX, SPD
    }*/
    
    // Start is called before the first frame update
    void Start()
    {

        T_ATK = gameObject.transform.GetChild(0).GetComponent<Text>();
        T_DEX = gameObject.transform.GetChild(1).GetComponent<Text>();
        T_SPD = gameObject.transform.GetChild(2).GetComponent<Text>();

        ReLoad();
    }

    public void ReLoad(){

        DEX = PlayerSettingData.instance.Player.DEX;
        ATK = PlayerSettingData.instance.Player.ATK;
        SPD = PlayerSettingData.instance.Player.SPD;

        T_ATK.text = "ATK : " + ATK;
        T_DEX.text = "DEX : " + DEX;
        T_SPD.text = "SPD : " + SPD;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
