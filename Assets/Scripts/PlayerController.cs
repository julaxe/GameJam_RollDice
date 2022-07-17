using System;
using Dice;
using ScriptableObjects;
using UnityEngine;

namespace DefaultNamespace
{
    public class PlayerController : MonoBehaviour
    {
        public PlayerInfo playerInfo;
        [SerializeField] private Transform spawnPointActionDice;
        [SerializeField] private Transform spawnPointElementalDice;
        [SerializeField] private Transform spawnPointNumberDice;

        private GameObject _currentActionDice;
        private GameObject _currentElementalDice;
        private GameObject _currentNumberDice;
        
        private int _diceCounter = 0;
        private bool _dicesReadyForOutcome = false;

        [HideInInspector] public float currentOutcome = 0.0f;
        [HideInInspector] public ActionAbility.ActionType currentAction;
        [HideInInspector] public Element currentElement;

        private void Start()
        {
            playerInfo.currentHealth = playerInfo.maxHealth;
        }

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
            
            _currentActionDice.GetComponent<DiceRolling>().diceStopRollingEvent.AddListener(CountStoppingDices);
            _currentElementalDice.GetComponent<DiceRolling>().diceStopRollingEvent.AddListener(CountStoppingDices);
            _currentNumberDice.GetComponent<DiceRolling>().diceStopRollingEvent.AddListener(CountStoppingDices);
        }

        public void RollDices()
        {
            _currentActionDice.transform.SetPositionAndRotation(spawnPointActionDice.position, spawnPointActionDice.rotation);
            _currentElementalDice.transform.SetPositionAndRotation(spawnPointElementalDice.position, spawnPointElementalDice.rotation);
            _currentNumberDice.transform.SetPositionAndRotation(spawnPointNumberDice.position, spawnPointNumberDice.rotation);
            
            _currentActionDice.GetComponent<DiceRolling>().RollDice();
            _currentElementalDice.GetComponent<DiceRolling>().RollDice();
            _currentNumberDice.GetComponent<DiceRolling>().RollDice();

            _diceCounter = 0;
            _dicesReadyForOutcome = false;
            currentOutcome = 0.0f;
        }

        private void CountStoppingDices()
        {
            _diceCounter += 1;
            if (_diceCounter == 3)
            {
                _dicesReadyForOutcome = true;
            }
        }

        public void TakeDamage(float damage)
        {
            playerInfo.TakeDamage(damage);
        }
        public bool IsOutcomeReady()
        {
            _currentNumberDice.GetComponent<DiceController>().ExecuteTopFace(this, null);
            _currentElementalDice.GetComponent<DiceController>().ExecuteTopFace(this, null);
            return _dicesReadyForOutcome;
        }

        public float CalculateOutcome(PlayerController enemy)
        {
            _currentActionDice.GetComponent<DiceController>().ExecuteTopFace(this, enemy);
            Debug.Log("this player is " + currentAction + " with the element "+ currentElement.elementName + "for a value of " + currentOutcome);
            return currentOutcome;
        }

        public void ChangeDice(GameObject newDice, int which )
        {
            switch (which)
            {
                case 0:
                    Destroy(_currentActionDice.gameObject);
                    _currentActionDice = Instantiate(newDice, spawnPointActionDice);
                    

                    break;
                case 1:
                    Destroy(_currentElementalDice.gameObject);

                    _currentElementalDice = Instantiate(newDice, spawnPointElementalDice);
                    

                    break;
                case 2:

                    Destroy(_currentNumberDice.gameObject);

                    _currentNumberDice = Instantiate(newDice, spawnPointNumberDice);
                    
                    break;
               
                default:
                    break;
            }


        }

        public GameObject GetActionDice()
        {
            return _currentActionDice;
        }
        public GameObject GetElementalDice()
        {
            return _currentElementalDice;
        }
        public GameObject GetNumberDice()
        {
            return _currentNumberDice;
        }
        public Transform GetActionTransfromDice()
        {
            return spawnPointActionDice;
        }
        public Transform GetElementalTransfromDice()
        {
            return spawnPointElementalDice;
        }
        public Transform GetNumberTransfromDice()
        {
            return spawnPointNumberDice;
        }
    }
}