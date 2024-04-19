using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerPassiveT : MonoBehaviour
{
    public int SlotNum;
    public TextMeshProUGUI text;
    // Start is called before the first frame update
    void OnEnable()
    {
        SlotNum = gameObject.transform.GetSiblingIndex();
        text.text = PlayerSettingData.instance.PlayerPassive[SlotNum].Name;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
