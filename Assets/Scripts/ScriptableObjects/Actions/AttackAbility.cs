using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(menuName = "Ability/Action/Attack")]
    public class AttackAbility : ActionAbility
    {
        public override void Execute()
        {
            Debug.Log("doing some damage: " + value);
        }
    }
}