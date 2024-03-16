using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerExp : MonoBehaviour
{
    private Slider Expbar;
    private Text PText;
    // Start is called before the first frame update
    void Start()
    {
        Expbar = GetComponent<Slider>();
        PText = gameObject.transform.GetChild(2).GetComponent<Text>();
        Expbar.maxValue = ExpManager.instance.MaxExp;
        Expbar.value = ExpManager.instance.CurExp;
        Expbar.minValue = ExpManager.instance.MinExp;
        ReLoad();
    }

    public void ReLoad(){
        Expbar.value = ExpManager.instance.CurExp;
        Expbar.maxValue = ExpManager.instance.MaxExp;
        Expbar.minValue = ExpManager.instance.MinExp;
        PText.text = Expbar.minValue + " / " + Expbar.maxValue;
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
