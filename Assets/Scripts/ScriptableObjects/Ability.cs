using UnityEngine;

namespace ScriptableObjects
{
    public abstract class Ability : ScriptableObject
    {
        public string abilityName;
        public Material material;
        public abstract void Execute();
    }
}
