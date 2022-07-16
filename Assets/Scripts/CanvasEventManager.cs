using ScriptableObjects;
using UnityEngine;

namespace DefaultNamespace
{
    public class CanvasEventManager : MonoBehaviour
    {
        [SerializeField] private GameEvents gameEvents;

        public void RollPressed()
        {
            gameEvents.RollDice();
        }

        public void ChangePlayerDicePressed(int numDice)
        {
            gameEvents.playerChangedDice(numDice);
        }
        public void ChangeEnemyDicePressed(int numDice)
        {
            gameEvents.enemyChangedDice(numDice);
        }
    }
}