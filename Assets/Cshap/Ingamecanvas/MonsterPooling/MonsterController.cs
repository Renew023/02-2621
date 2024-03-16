using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterController : MonoBehaviour
{
    public int atk, HP, Speed, Dex;
    public float AttackDelay;

    public float inter_MoveWaitTime;
    private float current_interMWT;

    public string atkSound;

    private Vector2 PlayerPos;

    private int random_int;
    private string driection;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
