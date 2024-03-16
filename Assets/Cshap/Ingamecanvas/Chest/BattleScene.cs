using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class BattleScene : MonoBehaviour
{
    public enum State{
       start, playerTurn, enemyTurn, win, Lose
    }
    public State state;
    public bool isLive;
    
    // Start is called before the first frame update
    void Start()
    {
        state = State.start;
        BattleStart();
    }

    private void BattleStart(){
        state = State.playerTurn;
    }

    public void PlayerAttackButton()
    {
        if(state != State.playerTurn){
            return;
        }
        StartCoroutine(PlayerAttack());
    }

    IEnumerator PlayerAttack(){
        yield return new WaitForSeconds(1f);
        Debug.Log("플레이어 공격");
        if(!isLive){
            state = State.win;
            EndBattle();
        }
        else{
            state = State.playerTurn;
            StartCoroutine(EnemyAttack());
        }
    }

    IEnumerator EnemyAttack(){
        yield return new WaitForSeconds(1f);
        Debug.Log("적의 공격");
        if(!isLive){
            state = State.Lose;
            EndBattle();
        }
        else{
            state = State.enemyTurn;
        }
    }

    void EndBattle(){

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
