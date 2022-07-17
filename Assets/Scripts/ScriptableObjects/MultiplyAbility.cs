using DefaultNamespace;
using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(menuName = "Ability/Multiply")]
    public class MultiplyAbility : Ability
    {
        public int value;
        public override void Execute(PlayerController player, PlayerController enemy)
        {
            player.currentOutcome = value;
        }
    }
    
    
}