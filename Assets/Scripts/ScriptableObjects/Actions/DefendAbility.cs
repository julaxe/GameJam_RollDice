using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(menuName = "Ability/Action/Defend")]
    public class DefendAbility : ActionAbility
    {
        public override void Execute()
        {
            Debug.Log("defending: " + value);
        }
    }
}