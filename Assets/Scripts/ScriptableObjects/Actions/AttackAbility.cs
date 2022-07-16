using DefaultNamespace;
using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(menuName = "Ability/Action/Attack")]
    public class AttackAbility : ActionAbility
    {
        public override void Execute(PlayerController player, PlayerController enemy)
        {
            player.currentAction = type;
            player.currentOutcome = value;
        }
    }
}