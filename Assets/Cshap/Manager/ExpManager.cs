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

    // Start is called before the first frame update
    void Start()
    {
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
    
    public void ExpUp(int Value){
        CurExp += Value;
    }

    public void ReLoad(){
        if(MaxExp < CurExp){
            Level += 1;
            MinExp = MaxExp;
            MaxExp = MaxExp + EXP[Level-1];
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
