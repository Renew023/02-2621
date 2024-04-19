/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class ObjectPoolingManager : MonoBehaviour
{
    private GameObject _BulletPrefab; 
    private IObjectPool<TextBox> _Pool;


    
    // Start is called before the first frame update
    void Start()
    {
        _Pool = new ObjectPool<TextBox>(CreateTextBox, OnGetTextBox, OnReleaseTextBox, maxsize:4);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(0))
        {
        
        }
        
    }
    private TextBox CreateTextBox(){
        TextBox textbox = Instantiate().GetComponent<TextBox>();
        textbox.SetManagedPool(_Pool);
        return textbox;
    }

    private void OnGetTextBox(TextBox textbox)
    {
        textbox.gameObject.SetActive(true);
    }

    private void OnReleaseTextBox(TextBox textbox)
    {
        textbox.gameObject.SetActive(false);
    }

    private void OnDestroyTextBox(TextBox textbox)
    {
        Destroy(textbox.gameObject);
    }

}
*/