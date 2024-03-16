using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MonsterInfo : MonoBehaviour
{
    public List<Status> Monster;
    public int RandomMonster;
    public Status MonsterMe;

    public void MonsterList(){
        
    }

    public void MonsterRandom(){
        RandomMonster = Random.Range(0, Monster.Count);
        MonsterMe = Monster[RandomMonster];
    }

    // Start is called before the first frame update
    void Start()
    {
        MonsterList();
        MonsterRandom();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
