using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MonsterHP : MonoBehaviour
{
    private Slider Hpbar;
    private Text PText;
    // Start is called before the first frame update
    void Start()
    {
        Hpbar = GetComponent<Slider>();
        Hpbar.maxValue = TextList.instance.monster.HP;
        PText = gameObject.transform.GetChild(1).GetComponent<Text>();
        Hpbar.value = TextList.instance.monster.HP - TextList.instance.HitDamage;
    }

    public void ReLoad(){
        if(TextList.instance.monster.HP - TextList.instance.HitDamage <= 0){
            Hpbar.value = 0;
        } else
        Hpbar.value = TextList.instance.monster.HP - TextList.instance.HitDamage;
        PText.text = Hpbar.value + " / " + Hpbar.maxValue;
    }

    public void SetAct(bool boo){
        gameObject.SetActive(boo);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
