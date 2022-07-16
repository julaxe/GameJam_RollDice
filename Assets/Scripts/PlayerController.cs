using System;
using Dice;
using ScriptableObjects;
using UnityEngine;

namespace DefaultNamespace
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private PlayerInfo playerInfo;
        [SerializeField] private Transform spawnPointActionDice;
        [SerializeField] private Transform spawnPointElementalDice;
        [SerializeField] private Transform spawnPointNumberDice;

        private GameObject _currentActionDice;
        private GameObject _currentElementalDice;
        private GameObject _currentNumberDice;

        private void OnValidate()
        {
            if(playerInfo.actionDices.Count == 0) Debug.LogWarning("PlayerInfo doesn't have action dices");
            if(playerInfo.elementalDices.Count == 0) Debug.LogWarning("PlayerInfo doesn't have elemental dices");
            if(playerInfo.numberDices.Count == 0) Debug.LogWarning("PlayerInfo doesn't have number dices");
        }
        public void SpawnDices()
        {
            _currentActionDice = Instantiate(playerInfo.actionDices[0], spawnPointActionDice);
            _currentElementalDice = Instantiate(playerInfo.elementalDices[0], spawnPointElementalDice);
            _currentNumberDice = Instantiate(playerInfo.numberDices[0], spawnPointNumberDice);
        }

        public void RollDices()
        {
            _currentActionDice.transform.SetPositionAndRotation(spawnPointActionDice.position, spawnPointActionDice.rotation);
            _currentElementalDice.transform.SetPositionAndRotation(spawnPointElementalDice.position, spawnPointElementalDice.rotation);
            _currentNumberDice.transform.SetPositionAndRotation(spawnPointNumberDice.position, spawnPointNumberDice.rotation);
            
            _currentActionDice.GetComponent<DiceRolling>().RollDice();
            _currentElementalDice.GetComponent<DiceRolling>().RollDice();
            _currentNumberDice.GetComponent<DiceRolling>().RollDice();
        }
        
    }
}