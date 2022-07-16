using DefaultNamespace;
using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(menuName = "Ability/Multiply")]
    public class MultiplyAbility : Ability
    {
        public int factor;
        public override void Execute()
        {
            Debug.Log("is multiplied by: "+ factor);
        }
    }
    
    
}