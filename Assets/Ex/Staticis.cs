using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Staticis : MonoBehaviour
{
    public int i,j;
    public Monster2 monster;
    // Start is called before the first frame update
    void Start()
    {
        monster = DataBase.instance.Monster[0];
        i = monster.HP;
        j = monster.HP + 50;

        monster.HP+=50;
        i += 50;
        j += 50;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
