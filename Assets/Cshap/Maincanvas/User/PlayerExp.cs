using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerExp : MonoBehaviour
{
    private Slider Expbar;
    private TextMeshProUGUI PText;
    public TextMeshProUGUI Level;
    public Text RewardText;

    // Start is called before the first frame update
    void Start()
    {
        Expbar = GetComponent<Slider>();
        PText = gameObject.transform.GetChild(2).GetComponent<TextMeshProUGUI>();
        Level = gameObject.transform.GetChild(3).transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        RewardText = gameObject.transform.GetChild(4).GetComponent<Text>();

        Expbar.maxValue = ExpManager.instance.MaxExp;
        Expbar.value = ExpManager.instance.CurExp;
        Expbar.minValue = ExpManager.instance.MinExp;
        ReLoad();
    }

    public void ReLoad(){
        Debug.Log(ExpManager.instance.CurExp);
        Expbar.maxValue = ExpManager.instance.MaxExp;
        Expbar.minValue = ExpManager.instance.MinExp;
        Expbar.value = ExpManager.instance.CurExp;
        
        PText.text = Expbar.value + " / " + Expbar.maxValue;
        Level.text = "" + ExpManager.instance.Level;
        RewardText.text = "다음 보상 : " + ExpManager.instance.RewardName[ExpManager.instance.Level-1];
    }

    public void AddExp(){
        ExpManager.instance.CurExp += 10;
        ExpManager.instance.ReLoad();
        ReLoad();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
