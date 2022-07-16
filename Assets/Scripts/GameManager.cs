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
    // Start is called before the first frame update
    void Start()
    {
        SpawnDices();
        gameEvents.rollDiceEvent.AddListener(RollDice);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CurrentTurn()
    {

    }


    private void SpawnDices()
    {
        player.SpawnDices();
        enemy.SpawnDices();
    }

    public void RollDice()
    {
        player.RollDices();
        enemy.RollDices();
    }

}
