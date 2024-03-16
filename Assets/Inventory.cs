using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public static Inventory instance;

    public GameObject its;
    
    public List<GameObject> Slot;
    public int CheckNum;
    public string CheckType;

    public int InvLength;

    public GameObject Slot_Prefabs;
    public List<Text> EmptyText;
    public List<GameObject> EmptyGOB;

    //도감 //all my cur 은 메인 캔버스상 UI;
    public List<Item> AllItem, MyItem, CurItem, GameItem, GameCurItem;
    public List<Skill> AllPassive, MyPassive, CurPassive, GamePassive, GameCurPassive;
    public List<Skill> AllUMul, MyUMul, CurUMul, GameUMul, GameCurUMul;

    public string CurName;
    public int AllPage, CurPage = 1;
    public int Item, Passive, UMul;

    
    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
        EmptyText.Add(gameObject.transform.GetChild(5).GetComponent<Text>()); //Page 수 표기
    }

    public void SelectBag(string Name){
            DataBase.instance.CurPage = 1;
            DataBase.instance.AllPage = 1;

        switch(Name){

            case "Dogam": 
                DataBase.instance.CurName = "Dogam";
                DataBase.instance.SlotAll = DataBase.instance.Item.Count + DataBase.instance.Passive.Count + DataBase.instance.UMul.Count;
                for(int i=6; i<DataBase.instance.SlotAll; i+=6)
                {
                    DataBase.instance.AllPage += 1;
                }
                
                //AllPage = AllItem.Count + AllPassive.Count + AllUMul.Count;
                Debug.Log(DataBase.instance.AllPage);
                break;

            case "UMul":
                DataBase.instance.CurName = "UMul";
                DataBase.instance.SlotAll = DataBase.instance.UMul.Count;
                for(int i=6; i<=DataBase.instance.SlotAll; i+=6)
                {
                    DataBase.instance.AllPage += 1;
                }
                //AllPage = AllItem.Count + AllPassive.Count + AllUMul.Count;
                Debug.Log(DataBase.instance.AllPage);
                break;
            
            case "Item":
                DataBase.instance.CurName = "Item";
                DataBase.instance.SlotAll = DataBase.instance.Item.Count;
                for(int i=6; i<=DataBase.instance.SlotAll; i+=6)
                {
                    DataBase.instance.AllPage += 1;
                }
                //AllPage = AllItem.Count + AllPassive.Count + AllUMul.Count;
                Debug.Log(DataBase.instance.AllPage);
                break;

        }

        EmptyText[0].text = DataBase.instance.CurPage + " / " + DataBase.instance.AllPage;
        AddInv();
    }

    public void Right(GameObject gameobject){
        CurPage += 1;
        if(CurPage <= 1)
            gameobject.SetActive(false);
        EmptyText[0].text = CurPage + " / " + AllPage;
    }
    public void Left(GameObject gameobject){
        CurPage -= 1;
        if(CurPage <= 1)
            gameobject.SetActive(false);
        EmptyText[0].text = CurPage + " / " + AllPage;
    }

    public void InventoryOpen(){
    }

    public void Showinventory(string Name){
        switch(Name)
        {
            case "All":
            break;
            case "Item":
                //Showitem();
            break;
            case "Passive":
                //ShowPassive();
            break;
            case "UMul" :
                //ShowUmul();
            break;
        }
    }

    public void ShowAll()
    {
        for(int i=0; i< Slot.Count; i++){
            Slot[i].SetActive(true);
        }
    }

    public void ShowInv(){
        for(int i=(CurPage-1)*6; i<(CurPage*6)+6; i++){
            Slot[i].SetActive(true);
            if(Slot.Count-1 == i)
                break;
        }
    }

    void HideItem()
    {
        for(int All=0; All < Slot.Count; All++)
        {
            Slot[All].SetActive(false);
        }
    }
    public void ShowItem()
    {
        AddInv();
    }

    void ViewItem(){
        //Item = PlayerSettingData.instance.PlayerItem;
        //for(int item = 0; item < Item.Count; item++){
            //Slot[item] = Item[item];
        //}
    }

    public void AddInv()
    {
        //InvLength = PlayerSettingData.instance.PlayerItem.Count + PlayerSettingData.instance.PlayerPassive.Count + PlayerSettingData.instance.PlayerUMul.Count;
        for(int i=Slot.Count; i < DataBase.instance.SlotAll; i++){
            Slot.Add(Instantiate(ResourceManager.instance.Slot_Prefabs, gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.transform));
        }
        HideItem();
        ShowInv();
    }

    public void Deleteinventory(){

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
