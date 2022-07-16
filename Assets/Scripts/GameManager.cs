using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using ScriptableObjects;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] PlayerController player;
    [SerializeField] PlayerController enemy;

    [SerializeField] private GameEvents gameEvents;

    private bool _outcomeShowed; 
    void Start()
    {
        SpawnDices();
        gameEvents.rollDiceEvent.AddListener(RollDice);
    }
    
    void Update()
    {
        if (_outcomeShowed) return;
        if (player.IsOutcomeReady() && enemy.IsOutcomeReady())
        {
            CalculateOutcome();
            _outcomeShowed = true;
        }
    }

    private void CalculateOutcome()
    {
        Debug.Log("Outcome calculation are here");
        var playerOutcome = player.CalculateOutcome(enemy);
        var enemyOutcome = enemy.CalculateOutcome(player);

        #region PlayerAttacking
            if (player.currentAction == ActionAbility.ActionType.Attack)
            {
                if (enemy.currentAction == ActionAbility.ActionType.Defend ||
                    enemy.currentAction == ActionAbility.ActionType.Heal)
                {
                    var outcome = playerOutcome - enemyOutcome;
                    if (outcome > 0)
                    {
                        Debug.Log("enemy take " + outcome + " damage");
                        enemy.TakeDamage(outcome);
                    }
                    else if (enemy.currentAction == ActionAbility.ActionType.Heal)
                    {
                        Debug.Log("enemy heals by " + -outcome);
                        enemy.TakeDamage(outcome);
                    }
                }
                else
                {
                    Debug.Log("player take " + enemyOutcome + " damage");
                    player.TakeDamage(enemyOutcome);
                    Debug.Log("enemy take " + playerOutcome + " damage");
                    enemy.TakeDamage(playerOutcome);
                }
            }
        #endregion
        #region EnemyAttacking
            else if (enemy.currentAction == ActionAbility.ActionType.Attack)
            {
                if (player.currentAction == ActionAbility.ActionType.Defend ||
                    player.currentAction == ActionAbility.ActionType.Heal)
                {
                    var outcome = enemyOutcome - playerOutcome;
                    if (outcome > 0)
                    {
                        Debug.Log("player take " + outcome + " damage");
                        player.TakeDamage(outcome);
                    }
                    else if (player.currentAction == ActionAbility.ActionType.Heal)
                    {
                        Debug.Log("player heals by " + -outcome);
                        player.TakeDamage(outcome);
                    }
                }
                else
                {
                    Debug.Log("player take " + enemyOutcome + " damage");
                    player.TakeDamage(enemyOutcome);
                    Debug.Log("enemy take " + playerOutcome + " damage");
                    enemy.TakeDamage(playerOutcome);
                }
            }

            #endregion

            #region Both are healing
                else
                {
                    if (player.currentAction == ActionAbility.ActionType.Heal)
                    {
                        Debug.Log("player heals by " + playerOutcome);
                        player.TakeDamage(-playerOutcome);
                    }

                    if (enemy.currentAction == ActionAbility.ActionType.Heal)
                    {
                        Debug.Log("enemy heals by " + enemyOutcome);
                        enemy.TakeDamage(-enemyOutcome);
                    }
                }
            #endregion
    }
    public void CurrentTurn()
    {

    }


    private void SpawnDices()
    {
        player.SpawnDices();
        enemy.SpawnDices();
    }

    private void RollDice()
    {
        player.RollDices();
        enemy.RollDices();
        _outcomeShowed = false;
    }

}
