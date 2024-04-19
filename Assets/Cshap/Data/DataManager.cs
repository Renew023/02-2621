using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

[System.Serializable]
public class Serialization<T>
{
    public Serialization(List<T> _target) => target = _target;
    public List<T> target; //배열 저장
}


/*public class DataManager : MonoBehaviour
{
    public static DataManager instance;

    // Start is called before the first frame update
    void Start()
    {
        path = Application.dataPath + "/save";

        Load();
    }

    void Save()
    {
        string data = JsonUtility.ToJson(nowPlayer);
        File.WriteAllText(path + "saveData.json", data);
    }

    void Load()
    {
        if(File.Exists(path + "saveData.json")){
        string data = File.ReadAllText(path + "saveData.json");
        nowPlayer = JsonUtility.FromJson<Serializaiotn<T>>(data).target;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}*/
