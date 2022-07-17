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

        [SerializeField] private Transform resultPointActionDice;
        [SerializeField] private Transform resultPointElementalDice;
        [SerializeField] private Transform resultPointNumberDice;

        private GameObject _currentActionDice;
        private GameObject _currentElementalDice;
        private GameObject _currentNumberDice;
        
        private int _diceCounter = 0;
        private bool _dicesReadyForOutcome = false;
        private bool _goingToResultPoints;
        private Camera _camera;

        [HideInInspector] public float currentOutcome = 0.0f;
        [HideInInspector] public ActionAbility.ActionType currentAction;
        [HideInInspector] public Element currentElement;

        private void Start()
        {
            playerInfo.currentHealth = playerInfo.maxHealth;
            _camera = Camera.main;
        }

        private void FixedUpdate()
        {
            if (!_goingToResultPoints) return;
            GoToResultPoint();
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
            _goingToResultPoints = false;
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
            
            //transition to showing points
            _goingToResultPoints = true;
            return currentOutcome;
        }

        private void GoToResultPoint()
        {
            _currentActionDice.transform.position = Vector3.Slerp(_currentActionDice.transform.position, resultPointActionDice.transform.position, 0.1f);
            _currentElementalDice.transform.position = Vector3.Slerp(_currentElementalDice.transform.position, resultPointElementalDice.transform.position, 0.1f);
            _currentNumberDice.transform.position = Vector3.Slerp(_currentNumberDice.transform.position, resultPointNumberDice.transform.position, 0.1f);
            
            // _currentActionDice.transform.LookAt(Camera.main.transform.position, 
            //     _currentActionDice.GetComponent<DiceController>().GetTopFaceDirection());
            // _currentElementalDice.transform.LookAt(Camera.main.transform.position, 
            //     _currentElementalDice.GetComponent<DiceController>().GetTopFaceDirection());
            // _currentNumberDice.transform.LookAt(Camera.main.transform.position, 
            //     _currentNumberDice.GetComponent<DiceController>().GetTopFaceDirection());

            if (AreDicesInResultPoints())
            {
                _goingToResultPoints = false;
                _currentActionDice.GetComponent<Rigidbody>().velocity = Vector3.zero;
                _currentActionDice.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
                _currentElementalDice.GetComponent<Rigidbody>().velocity = Vector3.zero;
                _currentElementalDice.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
                _currentNumberDice.GetComponent<Rigidbody>().velocity = Vector3.zero;
                _currentNumberDice.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
            }
            
        }

        private bool AreDicesInResultPoints()
        {
            float minimunDistance = 1.0f;
            if (Vector3.Distance(_currentActionDice.transform.position, resultPointActionDice.transform.position) <=
                minimunDistance &&
                Vector3.Distance(_currentElementalDice.transform.position, resultPointElementalDice.transform.position) <=
                minimunDistance &&
                Vector3.Distance(_currentNumberDice.transform.position, resultPointNumberDice.transform.position) <= minimunDistance)
            {
                return true;
            }

            return false;
        }
        public void ChangeDice(GameObject newDice, int which )
        {
            switch (which)
            {
                case 0:
                    Destroy(_currentActionDice.gameObject);
                    _currentActionDice = Instantiate(newDice, spawnPointActionDice);
                    _currentActionDice.GetComponent<DiceRolling>().diceStopRollingEvent.AddListener(CountStoppingDices);

                    break;
                case 1:
                    Destroy(_currentElementalDice.gameObject);
                    _currentElementalDice = Instantiate(newDice, spawnPointElementalDice);
                    _currentElementalDice.GetComponent<DiceRolling>().diceStopRollingEvent.AddListener(CountStoppingDices);
                    

                    break;
                case 2:

                    Destroy(_currentNumberDice.gameObject);
                    _currentNumberDice = Instantiate(newDice, spawnPointNumberDice);
                    _currentNumberDice.GetComponent<DiceRolling>().diceStopRollingEvent.AddListener(CountStoppingDices);
                    
                    break;
               
                default:
                    break;
            }


        }
        
    }
}