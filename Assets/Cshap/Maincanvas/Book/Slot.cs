using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Pool;

public class Slot : MonoBehaviour
{
    private IObjectPool<Slot> _ManagedPool;
    private Text Slottext;
    private Button btn;
    private GameObject BookMoreInfoScreen;

    // Start is called before the first frame update
    void Start()
    {
        btn = GetComponent<Button>();
        Slottext = gameObject.transform.GetChild(0).GetComponent<Text>();
        Slottext.text = ""+gameObject.transform.GetSiblingIndex();
        //btn.onClick.AddListener(BookMoreInfoScreenOn);
        //BookMoreInfoScreen = GameObject.Find("BookScreen").transform.GetChild(2).gameObject;
    }

    public void BookMoreInfoScreenOn(){
        BookMoreInfoScreen.SetActive(true);
    }

    public void SetManagedPool(IObjectPool<Slot> pool)
    {
        _ManagedPool = pool;
    }
    // Update is called once per frame

    private void DestroySlot()
    {
        _ManagedPool.Release(this);
    }

    void Update()
    {
        
    }
}
