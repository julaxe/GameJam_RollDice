using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject m_Player;
    [SerializeField] GameObject m_Enemy;
    [SerializeField] List<GameObject> m_diceSpawnPoints;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void currentTurn()
    {

    }


    public void SpawnDice()
    {
        
    }

    public void RollDice()
    {

    }

    public GameObject GetPlayer()
    {
        return m_Player;
    }
    public GameObject GetEnemy()
    {
        return m_Enemy;
    }


}
