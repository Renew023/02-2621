using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapSelect : MonoBehaviour
{
    public Text StageTitle;
    public Text StageExplain;
    public Text LevelRound;
    public Text MapDropItem;

    public int Map_int;
    private int N;

    public Text StageRight;
    public Text StageLeft;
    
    void Select_int(){
        StageTitle.text = DataBase.instance.StageArray[Map_int].Title;
        StageExplain.text = DataBase.instance.StageArray[Map_int].Explain;
        LevelRound.text = DataBase.instance.StageArray[Map_int].Level;
        MapDropItem.text = DataBase.instance.StageArray[Map_int].DropItem;

        N = DataBase.instance.StageArray.Count;
        StageRight.text = DataBase.instance.StageArray[(Map_int+N+1)%N].No + "  " + DataBase.instance.StageArray[(Map_int+N+1)%N].Title;
        StageLeft.text = DataBase.instance.StageArray[(Map_int+N-1)%N].No + "  " + DataBase.instance.StageArray[(Map_int+N-1)%N].Title;
    }

    public void Check_Map(){
        PlayerSettingData.instance.SetStage = DataBase.instance.StageArray[Map_int];
    }

    public void StageRightEvent(){
        Map_int += 1;
        if(DataBase.instance.StageArray.Count <= Map_int){
            Map_int = 0;
        }
        Select_int();
    }

    public void StageLeftEvent(){
        Map_int -= 1;
        if(0 > Map_int){
            Map_int = DataBase.instance.StageArray.Count-1;
        }
        Select_int();
    }
    
    // Start is called before the first frame update
    void Start()
    {

        StageTitle = gameObject.transform.GetChild(0).GetComponent<Text>();
        StageExplain = gameObject.transform.GetChild(1).GetComponent<Text>();
        LevelRound = gameObject.transform.GetChild(2).GetComponent<Text>();
        MapDropItem = gameObject.transform.GetChild(3).GetComponent<Text>();

        StageRight = gameObject.transform.GetChild(5).gameObject.transform.GetChild(0).GetComponent<Text>();
        StageLeft = gameObject.transform.GetChild(6).gameObject.transform.GetChild(0).GetComponent<Text>();
        Select_int();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
