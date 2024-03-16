using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitManager : MonoBehaviour
{
    public static InitManager instance;
    private GameObject ObjectKing;
    public GameObject Maincanvas; //메인 화면 0 
    private GameObject MaincanvasRespon; // 메인 화면 : 움직임 1
    private GameObject InGamecanvas; //인게임 화면 2
    private GameObject InGamecanvasRespon;// 인게임 화면 : 움직임 3
    private GameObject Fixedcanvas; // 고정된 화면 4
    private GameObject NoGroupcanvas; // 어디서든 호출 가능한 화면 5
    public GameObject TouchLogin;

    private GameObject MapSelectScreen; //맵 선택 창

    private GameObject BookScreen; // 도감 화면
    private GameObject BookInScreen;
    private GameObject BookMoreInfoScreen;
    private GameObject ScreenOverPanel;

    private GameObject HeroSelectScreen; //게임 시작 전, 영웅 확인 창
    private GameObject PassiveItemBookScreen; // 유물
    private GameObject PassiveStatScreen; // 특성

    private GameObject InventoryScreen;

    private GameObject SettingScreen;
    private GameObject RankingScreen;
    private GameObject QuestScreen;
    private GameObject RealShopScreen;
    

    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
        //Screen.SetResolution(1080, 1920, true);
        ObjectKing = GameObject.Find("ObjectKing").gameObject;
        Maincanvas = ObjectKing.transform.GetChild(0).gameObject;

        MaincanvasRespon = ObjectKing.transform.GetChild(1).gameObject;

        MapSelectScreen = MaincanvasRespon.transform.GetChild(0).gameObject;
        BookScreen = MaincanvasRespon.transform.GetChild(1).gameObject;
        HeroSelectScreen = MaincanvasRespon.transform.GetChild(2).gameObject;
        PassiveItemBookScreen = MaincanvasRespon.transform.GetChild(3).gameObject;
        PassiveStatScreen = MaincanvasRespon.transform.GetChild(4).gameObject;
        
        ScreenOverPanel = BookScreen.transform.GetChild(0).gameObject;
        BookInScreen = BookScreen.transform.GetChild(1).gameObject;
        BookMoreInfoScreen = BookScreen.transform.GetChild(2).gameObject;
        
        InGamecanvas = ObjectKing.transform.GetChild(2).gameObject;

        InGamecanvasRespon = ObjectKing.transform.GetChild(3).gameObject;
        //InGamecanvasRespon.transform.GetChild(0).gameObject;
        InventoryScreen = InGamecanvasRespon.transform.GetChild(0).gameObject;

        Fixedcanvas = ObjectKing.transform.GetChild(4).gameObject;

        NoGroupcanvas = ObjectKing.transform.GetChild(5).gameObject;

        SettingScreen = NoGroupcanvas.transform.GetChild(0).gameObject;
        RankingScreen = NoGroupcanvas.transform.GetChild(1).gameObject;
        QuestScreen = NoGroupcanvas.transform.GetChild(2).gameObject;
        RealShopScreen = NoGroupcanvas.transform.GetChild(3).gameObject;

        TouchLogin = ObjectKing.transform.GetChild(6).gameObject;

        Init();
        UnInit();
        DataBaseSetUP();
    }

    public void DataBaseSetUP(){
        DataBase.instance.ItemList();
        DataBase.instance.MonsterList();
        DataBase.instance.HeroList();
        DataBase.instance.SkillList();
        DataBase.instance.EffectList();
        DataBase.instance.StageList();
        DataBase.instance.MapTileList();
        DataBase.instance.MapTileYes();
        DataBase.instance.MapTileNo();
        DataBase.instance.RewardListSum();
        DataBase.instance.PassiveList();
    }

    void Init(){ //최상위층 부모들
        Maincanvas.SetActive(true); // 0번

        //이게 켜져 있어야 인식이 됨.
        Fixedcanvas.SetActive(true); //4번
        MaincanvasRespon.SetActive(true); // 1번
        InGamecanvasRespon.SetActive(true); //3번
        //북 스크린 안에 있는 이게 켜져 있어야 진행이 가능함.
        ScreenOverPanel.SetActive(true);
        BookInScreen.SetActive(true); 
        NoGroupcanvas.SetActive(true); // 5번
        TouchLogin.SetActive(true);
    }

    void UnInit(){ //자식들
        HeroSelectScreen.SetActive(false);
        BookScreen.SetActive(false);
        MapSelectScreen.SetActive(false);
        BookScreen.SetActive(false);
        BookMoreInfoScreen.SetActive(false);
        PassiveItemBookScreen.SetActive(false);
        PassiveStatScreen.SetActive(false);
        //인게임
        InGamecanvas.SetActive(false); // 2번
        
        InventoryScreen.SetActive(false);
        
        
        //5. 오버레이
        SettingScreen.SetActive(false);
        RankingScreen.SetActive(false);
        QuestScreen.SetActive(false);
        RealShopScreen.SetActive(false);
    }
    void InGame(){
        InGamecanvas.SetActive(true);
        InGamecanvasRespon.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
