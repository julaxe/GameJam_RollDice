using DefaultNamespace;
using UnityEngine;

namespace ScriptableObjects
{
    public abstract class ActionAbility : Ability
    {
        public enum ActionType
        {
            Attack,
            Defend,
            Heal
        }

        public ActionType type;

        //this has to be called after the elemental dice ----> IMPORTANT!
        protected void CalculateOutcome(PlayerController player, PlayerController enemy)
        {
            if (player.currentElement.strongAgainst.Contains(enemy.currentElement))
            {
                player.currentOutcome *= 2f; 
            }
            if (player.currentElement.weakAgainst.Contains(enemy.currentElement))
            {
                player.currentOutcome *= 0.5f; 
            }
        }
    }
}
