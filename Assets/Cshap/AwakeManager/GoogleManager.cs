using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GooglePlayGames;
using GooglePlayGames.BasicApi;

public class GoogleManager : MonoBehaviour
{
    public Text Sibal;
    // Start is called before the first frame update
    void Start()
    {
    }

    public void Signin() {
        PlayGamesPlatform.Instance.Authenticate(ProcessAuthentication);
    }

    internal void ProcessAuthentication(SignInStatus status)
    {
        if (status == SignInStatus.Success)
        {
            Sibal.text = "Success";
            InitManager.instance.TouchLogin.SetActive(false);
            InitManager.instance.Maincanvas.SetActive(true);
        }
        else
        {
            Sibal.text = "Failed";
            InitManager.instance.TouchLogin.gameObject.SetActive(false);
            InitManager.instance.Maincanvas.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
