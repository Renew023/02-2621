using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interface : MonoBehaviour
{
    public List<Text> Infotext;
    public static Interface instance;
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
        SetDis();
    }

    public void Reload(){
        SetDis();
        switch(Inventory.instance.CheckType)
        {
            case "UMul" : 
                Infotext[0].text = DataBase.instance.UMul[Inventory.instance.CheckNum].Name;
                Infotext[1].text = DataBase.instance.UMul[Inventory.instance.CheckNum].Effect;
                SetAct(2);
                break;


            case "Passive" :
                Infotext[0].text = DataBase.instance.Passive[Inventory.instance.CheckNum].Name;
                Infotext[1].text = DataBase.instance.Passive[Inventory.instance.CheckNum].Effect;
                SetAct(2);
                break;


            case "Item" : 
                Infotext[0].text = "" + DataBase.instance.Item[Inventory.instance.CheckNum].Name;
                Infotext[1].text = "" + DataBase.instance.Item[Inventory.instance.CheckNum].HP;
                Infotext[2].text = "" + DataBase.instance.Item[Inventory.instance.CheckNum].ATK;
                Infotext[3].text = "" + DataBase.instance.Item[Inventory.instance.CheckNum].DEX;
                Infotext[4].text = "" + DataBase.instance.Item[Inventory.instance.CheckNum].SPEED;
                Infotext[5].text = "" + DataBase.instance.Item[Inventory.instance.CheckNum].Explain;
                Infotext[6].text = "";
                for(int i = 0; i< DataBase.instance.Item[Inventory.instance.CheckNum].Effect.Length; i++)
                {
                    Infotext[6].text += "" + DataBase.instance.Item[Inventory.instance.CheckNum].Effect[i];
                    if(i+1 < DataBase.instance.Item[Inventory.instance.CheckNum].Effect.Length){
                        Infotext[6].text += ", ";
                    }
                }

                Infotext[7].text = "" + DataBase.instance.Item[Inventory.instance.CheckNum].Type;
                SetAct(8);
                break;

        }
    }

    public void SetAct(int i){
        for(int j=0; j<i; j++)
            Infotext[j].gameObject.SetActive(true);
    }

    public void SetDis(){
        for(int j=0; j<Infotext.Count; j++){
            Infotext[j].gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
