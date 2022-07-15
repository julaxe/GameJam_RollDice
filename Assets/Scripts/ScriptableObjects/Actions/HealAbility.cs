using UnityEngine;

namespace ScriptableObjects.Actions
{
    [CreateAssetMenu(menuName = "Ability/Action/Heal")]
    public class HealAbility : ActionAbility
    {
        public override void Execute()
        {
            Debug.Log("healing: " + value);
        }
    }
}