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
            Debug.Log("Outcome calculation are here");
            _outcomeShowed = true;
        }
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
