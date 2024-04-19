using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Playerpassive : MonoBehaviour
{
    public static Playerpassive instance;
    public TextMeshProUGUI text;
    public List<GameObject> gmo;

    // Start is called before the first frame update
    void Awake()
    {
        text = Resources.Load<TextMeshProUGUI>("Prefabs/PlayerPassive");
        for(int i=0; i<PlayerSlot.instance.PlayerPassive.Count; i++){
            gmo.Add(Instantiate(text.gameObject, gameObject.transform));
        }   
    }

    public void Reload(){
        for(int i = gmo.Count; i < PlayerSlot.instance.PlayerPassive.Count; i++){
            gmo.Add(Instantiate(text.gameObject, gameObject.transform));
        }
        Hide();
        Show();
    }

    public void Show(){
        for(int i = 0; i < PlayerSettingData.instance.PlayerPassive.Count; i++){
            gmo[i].SetActive(true);
        }
    }
    public void Hide(){
        for(int i=0; i < gmo.Count; i++){
            gmo[i].SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
