using DefaultNamespace;
using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(menuName = "Ability/Action/Defend")]
    public class DefendAbility : ActionAbility
    {
        public override void Execute(PlayerController player, PlayerController enemy)
        {
            player.currentAction = type;
            player.currentOutcome = value;
        }
    }
}