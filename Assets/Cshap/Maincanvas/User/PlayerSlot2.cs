using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSlot2 : MonoBehaviour
{
    public static PlayerSlot2 instance;

    public GameObject Skill_Prefabs;
    public GameObject UMul_Prefabs;

    public List<GameObject> PlayerPassive;
    public List<Text> PlayerPassiveT;

    public List<GameObject> PlayerUMul;
    public List<Text> PlayerUMulT;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        Skill_Prefabs = Resources.Load<GameObject>("Prefabs/Slot3");
        PassiveLoad();
        UMulLoad();
    }

    public void PassiveLoad()
    {
        for(int i=PlayerPassive.Count; i<PlayerSettingData.instance.PlayerPassive.Count; i++)
        {
            PlayerPassive.Add(Instantiate(Skill_Prefabs, gameObject.transform.GetChild(0).transform));
        }
        Hide(2);
        Show(2);
    }
    
    public void UMulLoad()
    {
        for(int i=PlayerUMul.Count; i<PlayerSettingData.instance.PlayerUMul.Count; i++)
        {
            PlayerUMul.Add(Instantiate(Skill_Prefabs, gameObject.transform.GetChild(1).transform));
        }
        Hide(1);
        Show(1);
    }


    void Show(int num)
    {
        switch(num)
        {
            case 1 :
            for(int i=0; i<PlayerSettingData.instance.PlayerUMul.Count; i++)
            {
                PlayerUMul[i].SetActive(true);
            }
            break;

            case 2 :
            for(int i=0; i<PlayerSettingData.instance.PlayerPassive.Count; i++)
            {
                PlayerPassive[i].SetActive(true);
            }
            break;
        }
    }

    void Hide(int num)
    {
        switch(num)
        {   
            case 1 :
            for(int i=0; i<PlayerUMul.Count; i++)
            {
                PlayerUMul[i].SetActive(false);
            }
            break;

            case 2:
            for(int i=0; i<PlayerPassive.Count; i++)
            {
                PlayerPassive[i].SetActive(false);
            }
            break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void AddPassive(){

    }

    void ErasePassive(){

    }

    void AddUMul(){

    }

    void EraseUMul(){

    }
}
