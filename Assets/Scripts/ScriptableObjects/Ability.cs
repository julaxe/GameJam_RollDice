using UnityEngine;

namespace ScriptableObjects
{
    public abstract class Ability : ScriptableObject
    {
        public string abilityName;
        public Texture2D image;
        public abstract void Execute();
    }
}
