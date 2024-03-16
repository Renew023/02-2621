using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager : MonoBehaviour
{
    public static ResourceManager instance;

    public GameObject Slot_Prefabs;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        Slot_Prefabs = Resources.Load<GameObject>("Prefabs/Slot2");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
