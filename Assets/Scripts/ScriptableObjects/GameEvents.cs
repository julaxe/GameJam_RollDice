using UnityEngine;
using UnityEngine.Events;

namespace ScriptableObjects
{
    [CreateAssetMenu(menuName = "Game/Events")]
    public class GameEvents : ScriptableObject
    {
        public UnityEvent rollDiceEvent;
        public UnityAction<int> playerChangedDice;
        public UnityAction<int> enemyChangedDice;
        public void RollDice()
        {
            rollDiceEvent?.Invoke();
        }

        public void ChangePlayerDice(int value)
        {
            playerChangedDice?.Invoke(value);
        }
        
        public void ChangeEnemyDice(int value)
        {
            enemyChangedDice?.Invoke(value);
        }
    }
}