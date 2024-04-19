using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MonsterHP : MonoBehaviour
{
    public Slider Hpbar;
    public Text PText;
    // Start is called before the first frame update
    void Start()
    {
        Hpbar = GetComponent<Slider>();
        PText = gameObject.transform.GetChild(2).GetComponent<Text>();
    }
    
    public void Init(){
        Hpbar.maxValue = TextList.instance.monster.HP;
        Hpbar.value = TextList.instance.Monster_HP;
        ReLoad();
    }

    public void ReLoad(){
        if(TextList.instance.Monster_HP <= 0){
            Hpbar.value = 0;
        } else {
        Hpbar.value = TextList.instance.Monster_HP;
        }
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
