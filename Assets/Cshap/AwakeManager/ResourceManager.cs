using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager : MonoBehaviour
{
    public static ResourceManager instance;

    public GameObject Slot_Prefabs;
    public GameObject RewardText;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        Slot_Prefabs = Resources.Load<GameObject>("Prefabs/Slot2");
        RewardText = Resources.Load<GameObject>("Prefabs/RewardText"); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
