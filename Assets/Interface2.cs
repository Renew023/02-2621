using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interface2 : MonoBehaviour
{
    public List<Text> Infotext;
    public Text Infortant;
    public int EffectNumber = 0;
    public static Interface2 instance;
    public GameObject ButtonUp;
    public int CurSlot;
    // Start is called before the first frame update
    
    void Start()
    {
        instance = this;

        for(int i = 0; i< 9; i++)
        {// Name, Status(HP, ATK, DEX, SPEED), Explain, Effect, Explain, Type 
            Infotext.Add(gameObject.transform.GetChild(i).gameObject.GetComponent<Text>());
            Infotext[i].text = "";
        }
        Infortant = Infotext[6].transform.GetChild(0).transform.GetChild(0).GetComponent<Text>();
        ButtonUp = Infotext[6].transform.GetChild(0).transform.GetChild(1).gameObject;
        
        Infortant.text = "";
        SetDis();
    }

    public void AddPage(int num){
        EffectNumber += num;
        if(EffectNumber >= DataBase.instance.Item[Inventory.instance.CheckNum].Effect.Length)
        {
            EffectNumber = 0;
        }
        Screen();
    }

    public void Screen(){
        ButtonUp.SetActive(true);
        Infortant.text = "" + DataBase.instance.Item[Inventory.instance.CheckNum].Effect[EffectNumber] + " : " + DataBase.instance.EffectArray.Find(x => x.Name == DataBase.instance.Item[Inventory.instance.CheckNum].Effect[EffectNumber]).EffectExplain;
    }

    public void Reload(){
        SetDis();
        switch(Inventory.instance.CheckType)
        {
            case "UMul" : 
                Infotext[0].text = DataBase.instance.UMul[Inventory.instance.CheckNum].Name;
                Infotext[1].text = DataBase.instance.UMul[Inventory.instance.CheckNum].Explain;
                SetAct(2);
                break;


            case "Passive" :
                Infotext[0].text = PlayerSettingData.instance.PlayerPassive[Inventory.instance.CheckNum].Name;
                Infotext[1].text = PlayerSettingData.instance.PlayerPassive[Inventory.instance.CheckNum].Explain;
                SetAct(2);
                break;


            case "Item" : 
                EffectNumber = 0;
                Infotext[0].text = "" + DataBase.instance.Item[Inventory.instance.CheckNum].Name;
                Infotext[1].text = "" + DataBase.instance.Item[Inventory.instance.CheckNum].Explain;
                Infotext[2].text = "HP : " + DataBase.instance.Item[Inventory.instance.CheckNum].HP;
                Infotext[3].text = "ATK : " + DataBase.instance.Item[Inventory.instance.CheckNum].ATK;
                Infotext[4].text = "DEX : " + DataBase.instance.Item[Inventory.instance.CheckNum].DEX;
                Infotext[5].text = "SPEED : " + DataBase.instance.Item[Inventory.instance.CheckNum].SPEED;
                Infotext[6].text = "효과 : ";
                Infortant.text = "";
                for(int i = 0; i< DataBase.instance.Item[Inventory.instance.CheckNum].Effect.Length; i++)
                {
                    Infotext[6].text += "" + DataBase.instance.Item[Inventory.instance.CheckNum].Effect[i];
                    if(i+1 < DataBase.instance.Item[Inventory.instance.CheckNum].Effect.Length){
                        Infotext[6].text += ", ";
                    }
                }

                Infotext[7].text = "" + DataBase.instance.Item[Inventory.instance.CheckNum].Type;
                Screen();
                SetAct(8);
                break;

        }
    }

    public void SetAct(int i){
        for(int j=0; j<i; j++)
            if(!(Infotext[j].text == "") && !(Infotext[j].text == "0"))
                Infotext[j].gameObject.SetActive(true);
    }

    public void SetDis(){
        for(int j=0; j<Infotext.Count; j++){
            Infotext[j].gameObject.SetActive(false);
        }
    }
    public void OnEnable(){
        Debug.Log("켜짐");
    }

    public void OnDisable(){
        Debug.Log("꺼짐");
        SetDis();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
