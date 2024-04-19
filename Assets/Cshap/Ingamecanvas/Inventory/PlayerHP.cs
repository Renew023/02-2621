using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHP : MonoBehaviour
{
    private Slider Hpbar;
    private Text PText;
    // Start is called before the first frame update
    void Start()
    {
        Hpbar = GetComponent<Slider>();
        PText = gameObject.transform.GetChild(1).GetComponent<Text>();
        Hpbar.maxValue = PlayerSettingData.instance.Max_HP;
        Hpbar.value = PlayerSettingData.instance.Player.HP;
    }

    public void ReLoad(){
        Hpbar.value = PlayerSettingData.instance.Player.HP;
        PText.text = Hpbar.value + " / " + Hpbar.maxValue;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
