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
        public float value;
    }
}
