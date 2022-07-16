using DefaultNamespace;
using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(menuName = "Ability/Multiply")]
    public class MultiplyAbility : Ability
    {
        public int factor;
        public override void Execute(PlayerController player, PlayerController enemy)
        {
            if (player.currentElement.strongAgainst.Contains(enemy.currentElement))
            {
                player.currentOutcome *= 2f; 
            }
            if (player.currentElement.weakAgainst.Contains(enemy.currentElement))
            {
                player.currentOutcome *= 0.5f; 
            }

            player.currentOutcome *= factor;
        }
    }
    
    
}