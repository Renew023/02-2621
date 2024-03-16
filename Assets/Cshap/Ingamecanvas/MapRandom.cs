using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapRandom : MonoBehaviour
{
    public MapTile Set_Map;
    private Image MapIcon;
    private Sprite[] TileImage;
    private Sprite[] TileImageLoad;
    public List<MapTile> LoadText;

    private InitManager InitManager;

    // Start is called before the first frame update
    void Start()
    {

        MapIcon = GetComponent<Image>();
        LoadText = DataBase.instance.MapTileArrayYes.FindAll(x => x.No == Set_Map.No);

        ImageUpload();
        RandomMap();
    }

    void ImageUpload(){
        TileImageLoad = Resources.LoadAll<Sprite>("MapTile");
        //TileImage.add(Resources.LoadAll<Image>());
    }


    void RandomMap(){
        MapIcon.sprite = TileImageLoad[StringInt()]; //
        for(int n=0; n < LoadText.Count; n++){
            Debug.Log(LoadText[n].Explain);
            //Instantiate X)
        }
    }

    int StringInt(){
        int Toint = 0;
        switch(Set_Map.TileName){
            case "함정": Toint = 0;
            break;
            case "보스": Toint = 1;
            break;
            case "휴식": Toint = 2;
            break;
            case "몬스터": Toint = 3;
            break;
            case "???": Toint = 4;
            break;
            case "이벤트": Toint = 5;
            break;
            case "상점": Toint = 6;
            break;
        }
        return Toint;
    }

    /*void RandomSearch(){
        switch(RandomInt){
            case 0: //상점


            break;
            case 1: //이벤트


            break;
            case 2: //?? 선택 시 : 다른 이벤트를 랜덤으로 생성

            break;

            case 3: //몬스터
                Debug.Log("3");

            break;
            case 4: //휴식
                Debug.Log("4");

            break;
            case 5: //보스
                Debug.Log("5");

            break;
            case 6: //함정
                Debug.Log("6");

            break;
        }
    }

    void Event(){
        switch(RandomInt){
            case 0: //상점


            break;
            case 1: //이벤트


            break;
            case 2: //?? 선택 시 : 다른 이벤트를 랜덤으로 생성
                RandomMap();
                Event();
            break;

            case 3: //몬스터
                Debug.Log("3");

            break;
            case 4: //휴식
                Debug.Log("4");

            break;
            case 5: //보스
                Debug.Log("5");

            break;
            case 6: //함정
                Debug.Log("6");

            break;
        }
    }*/

    // Update is called once per frame
    void Update()
    {
        
    }
}
