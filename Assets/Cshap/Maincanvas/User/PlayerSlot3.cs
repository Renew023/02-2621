using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSlot3 : MonoBehaviour
{
    public static PlayerSlot3 instance;

    public GameObject Skill_Prefabs;
    // public GameObject UMul_Prefabs;

    public List<GameObject> PlayerItem;
    // public List<GameObject> PlayerPassive;
    // public List<Text> PlayerPassiveT;

    // public List<GameObject> PlayerUMul;
    // public List<Text> PlayerUMulT;

    // Start is called before the first frame update
    void Awake()
    {
        instance = this;

        Skill_Prefabs = Resources.Load<GameObject>("Prefabs/Slot4");
        
        // ItemLoad();
        // PassiveLoad();
        // UMulLoad();
    }

    void OnEnable(){
        ItemLoad();
    }

    public void ItemLoad()
    {
        for(int i=PlayerItem.Count; i<PlayerSettingData.instance.PlayerItem.Count; i++)
        {
            PlayerItem.Add(Instantiate(Skill_Prefabs, gameObject.transform));
        }
        Hide();
        Show();
    }

    void Show()
    {
        for(int i=0; i<PlayerSettingData.instance.PlayerItem.Count; i++)
            {
                PlayerItem[i].SetActive(true);
            }
    }

    void Hide()
    {
        for(int i=0; i<PlayerItem.Count; i++)
        {
            PlayerItem[i].SetActive(false);
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
