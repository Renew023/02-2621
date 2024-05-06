using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerPassiveT : MonoBehaviour
{
    public int SlotNum;
    public Text text2;
    // Start is called before the first frame update
    void OnEnable()
    {
        text2 = transform.GetChild(0).GetComponent<Text>();
        SlotNum = gameObject.transform.GetSiblingIndex();
        text2.text = PlayerSettingData.instance.PlayerPassive[SlotNum-1].Name;
    }

    public void OnDisable()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
