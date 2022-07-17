using DefaultNamespace;
using UnityEngine;

namespace ScriptableObjects.Actions
{
    [CreateAssetMenu(menuName = "Ability/Action/Heal")]
    public class HealAbility : ActionAbility
    {
        public override void Execute(PlayerController player, PlayerController enemy)
        {
            player.currentAction = type;
            CalculateOutcome(player, enemy);
        }
    }
}