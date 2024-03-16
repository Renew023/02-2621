using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot2 : MonoBehaviour
{
    private Text Slottext;
    private Button btn;
    public int SlotNum;
    public string SlotType;
    public int ItemCount, PassiveCount, UMulCount;

    // Start is called before the first frame update
    
    void Awake()
    {
        gameObject.SetActive(true);
        btn = GetComponent<Button>();
        Slottext = gameObject.transform.GetChild(0).GetComponent<Text>();
        SlotNum = gameObject.transform.GetSiblingIndex();
        Debug.Log(SlotNum);
        returnSlot();
    }

    public void ClickSlot(){
        Inventory.instance.CheckType = SlotType;
        Inventory.instance.CheckNum = SlotNum;
        Interface.instance.Reload();
    }

    public void returnSlot(){
        Debug.Log(DataBase.instance.CurName);

        switch(DataBase.instance.CurName){
            case "Dogam" :
                ItemCount = DataBase.instance.Item.Count;
                PassiveCount = DataBase.instance.Passive.Count;
                UMulCount = DataBase.instance.UMul.Count;

                Debug.Log("Return SLot");
                if(SlotNum >= ItemCount)//7
                {
                    SlotNum -= ItemCount;
                    if(SlotNum >= PassiveCount)//7 + 8
                    {
                        SlotNum -= PassiveCount;
                        SlotType = "UMul";
                        Slottext.text = SlotType + DataBase.instance.UMul[SlotNum].Name;
                    }
                    else
                    {
                        SlotType = "Passive";
                        Slottext.text = SlotType + DataBase.instance.Passive[SlotNum].Name;
                    }
                }
                else
                {
                    SlotType = "Item";
                    Slottext.text = SlotType + DataBase.instance.Item[SlotNum].Name;
                }
                break;
        }
        
        /*ItemCount = PlayerSettingData.instance.PlayerItem.Count;
        PassiveCount = PlayerSettingData.instance.PlayerPassive.Count;
        UMulCount = PlayerSettingData.instance.PlayerUMul.Count;
        //Inventory.instance.AllPage;

        if(SlotNum >= ItemCount)//7
        {
            SlotNum -= ItemCount;
            if(SlotNum >= PassiveCount)//7 + 8
            {
                SlotNum -= PassiveCount;
                SlotType = "UMul";
                Slottext.text = SlotType + PlayerSettingData.instance.PlayerUMul[SlotNum].Name;
            }
            else
            {
                SlotType = "Passive";
                Slottext.text = SlotType + PlayerSettingData.instance.PlayerPassive[SlotNum].Name;
            }
        }
        else
        {
            SlotType = "Item";
            Slottext.text = SlotType + PlayerSettingData.instance.PlayerItem[SlotNum].Name;
        }*/
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
