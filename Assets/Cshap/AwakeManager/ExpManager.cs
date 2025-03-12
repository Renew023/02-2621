using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ExpManager : MonoBehaviour
{ //1.6 , 2.0.... 1.3, 1.5
    public static ExpManager instance;
    public List<int> EXP;
    // Max Level =30 기준 경험치 3000~5000; 1.2 ^4 2^8 //2, 
    //{10, 15, 20, 30, 50, 75, 100} 2*2*2*2  16 * 16  256
    public int Expin = 5; //할당치 300;
    //{10, 20, 32, 64, 100, 200, 320, 640, 1000};
    public int CurExp = 0, MaxExp = 5, MinExp = 0;
    public int PassiveStat, Level = 1;
    public List<string> RewardName;
    public List<string> RewardUMul;

    public int SaveExp;

    // Start is called before the first frame update
    void Start()
    {
        Setting();
        LevelReward();

        instance = this;
        for(int i=1; i<=30; i++){
            EXP.Add(Expin);
            if(i%2 == 1){
                Expin += EXP[i-1]/i;
            }
            else
            {
                Expin += EXP[i-2]/i;
            }
        }
    }

    public void Setting()
    {
        RewardName.Add("[패시브] 대장의 품격");
        RewardName.Add("[패시브] 쇄약");

        RewardUMul.Add("[유물] 몰락한 왕관");
        RewardUMul.Add("[유물] 푹 익은 벼이삭");
    }

    public void LevelReward(){
        PlayerSettingData.instance.PassiveSuchi += 5;
        switch(Level-1)
        {
            case 1:
                Debug.Log(RewardName[0] + "을 습득하셨습니다.");
                PlayerSettingData.instance.MainPassive.Add(DataBase.instance.Passive[0]);

                Debug.Log(RewardUMul[0] + "을 습득하셨습니다.");
                PlayerSettingData.instance.MainUMul.Add(DataBase.instance.UMul[0]);

            break;

            case 2:
                Debug.Log(RewardName[1] + "을 습득하셨습니다.");
                PlayerSettingData.instance.MainPassive.Add(DataBase.instance.Passive[1]);

                Debug.Log(RewardUMul[1] + "을 습득하셨습니다.");
                PlayerSettingData.instance.MainUMul.Add(DataBase.instance.UMul[1]);

            break;
            case 3:

            break;
        }
    }
    
    public void ExpUp(int Value){
        CurExp += Value;
    }

    public void ReLoad(){
        if(MaxExp <= CurExp){
            Level += 1;
            MinExp = MaxExp;
            MaxExp = MaxExp + EXP[Level-1];
            LevelReward();
        }
    }
    
    // public void ClearExp()
    // {
    //     Debug.Log("몬스터 처치 수 : " + Monster + "\t" + Monster*3 + "\n");
    //     Debug.Log("진행한 턴 수 : " + Turn + "\t" + Turn*2 + "\n");
    //     Debug.Log("성장한 능력치 : " + Stat + "\t" + Stat*1 + "\n");
    // }

    // Update is called once per frame
    void Update()
    {
        
    }
}
