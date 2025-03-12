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
    public GameObject SelectButton;

    public int InvLength;

    public GameObject Slot_Prefabs;
    public List<Text> EmptyText;
    public List<GameObject> EmptyGOB;

    //도감 //all my cur 은 메인 캔버스상 UI;
    public List<Item> AllItem, MyItem, CurItem, GameItem, GameCurItem;
    public List<Skill> AllPassive, MyPassive, CurPassive, GamePassive, GameCurPassive;
    public List<Skill> AllUMul, MyUMul, CurUMul, GameUMul, GameCurUMul;

    public Text ClickName;

    public string CurName;
    public int AllPage, CurPage = 1;
    public int Item, Passive, UMul;

    
    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
        EmptyText.Add(gameObject.transform.GetChild(6).GetComponent<Text>()); //Page 수 표기
        ClickName = gameObject.transform.GetChild(3).GetComponent<Text>();
        SelectButton = gameObject.transform.GetChild(9).gameObject;
    }

    public void SelectBag(string Name){
            DataBase.instance.CurPage = 1;
            DataBase.instance.AllPage = 1;
            ClickName.text = "" + Name;
            SelectButton.SetActive(true);
            
        switch(Name){

            case "도감": 
                DataBase.instance.CurName = "Dogam";
                DataBase.instance.SlotAll = DataBase.instance.Item.Count + DataBase.instance.Passive.Count + DataBase.instance.UMul.Count;
                SelectButton.SetActive(false);
                for(int i=6; i<DataBase.instance.SlotAll; i+=6)
                {
                    DataBase.instance.AllPage += 1;
                }
                
                //AllPage = AllItem.Count + AllPassive.Count + AllUMul.Count;
                Debug.Log(DataBase.instance.AllPage);
                break;

            case "유물":
                DataBase.instance.CurName = "UMul";
                DataBase.instance.SlotAll = PlayerSettingData.instance.MainUMul.Count;
                for(int i=6; i<=DataBase.instance.SlotAll; i+=6)
                {
                    DataBase.instance.AllPage += 1;
                }
                //AllPage = AllItem.Count + AllPassive.Count + AllUMul.Count;
                Debug.Log(DataBase.instance.AllPage);
                break;
            
            case "특성":
                DataBase.instance.CurName = "MainPassive";
                DataBase.instance.SlotAll = PlayerSettingData.instance.MainPassive.Count;
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
        for(int i=(CurPage-1)*6; i<DataBase.instance.SlotAll; i++){

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

    public void SelectPassive(){

        switch(DataBase.instance.CurName){
            case "MainPassive" :
            for(int i=PlayerSettingData.instance.PlayerPassive.Count; i>0; i--) //내 패시브 개수가 존재한다면
            {
                if(PlayerSettingData.instance.PlayerPassive[i-1].Name == PlayerSettingData.instance.MainPassive[CheckNum].Name) //패시브가 만약 이름이 동일하다면 제외한다. 다시 얻는다.
                {
                    PlayerSettingData.instance.PassiveSuchi -= PlayerSettingData.instance.MainPassive[CheckNum].SkillRare;
                    PlayerSettingData.instance.PlayerPassive.RemoveAt(i-1);
                    //Slot[CheckNum].SetActive(true); //활성화 보이게 한다.
                    Slot[CheckNum].GetComponent<Image>().color = new Color(1.0f, 1.0f, 1.0f, 1f);
                    PlayerSlot.instance.PassiveLoad();
                    return;
                }
            }
            
            if(PlayerSettingData.instance.PassiveSuchi + PlayerSettingData.instance.MainPassive[CheckNum].SkillRare >= 0)
            {
                PlayerSettingData.instance.PassiveSuchi += PlayerSettingData.instance.MainPassive[CheckNum].SkillRare;
                PlayerSettingData.instance.PlayerPassive.Add(PlayerSettingData.instance.MainPassive[CheckNum]);
                //Slot[CheckNum].SetActive(false);
                Slot[CheckNum].GetComponent<Image>().color = new Color(0.5f, 0.5f, 0.5f, 0.5f);
            }
                
            else
                Debug.Log("패시브 수련치를 맞춰주세요");
                //Playerpassive.instance.Reload();
                PlayerSlot.instance.PassiveLoad();
                //PlayerSlot.instance.UMulLoad();
            break;

        case "UMul":
        for(int i=PlayerSettingData.instance.PlayerUMul.Count; i>0; i--) //내 패시브 개수가 존재한다면
        {
            if(PlayerSettingData.instance.PlayerUMul[i-1].Name == PlayerSettingData.instance.MainUMul[CheckNum].Name) //패시브가 만약 이름이 동일하다면 제외한다. 다시 얻는다.
            {
                PlayerSettingData.instance.PlayerUMul.RemoveAt(i-1);
                //Slot[CheckNum].SetActive(true); //활성화 보이게 한다.
                Slot[CheckNum].GetComponent<Image>().color = new Color(1.0f, 1.0f, 1.0f, 1f);
                PlayerSlot.instance.UMulLoad();
                return;
            }
        }
            PlayerSettingData.instance.PlayerUMul.Add(PlayerSettingData.instance.MainUMul[CheckNum]);
            //Slot[CheckNum].SetActive(false);
            Slot[CheckNum].GetComponent<Image>().color = new Color(0.5f, 0.5f, 0.5f, 0.5f);
            PlayerSlot.instance.UMulLoad();

        break;

        }

    }

    public void Deleteinventory(){

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
