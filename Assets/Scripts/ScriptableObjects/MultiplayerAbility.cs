using DefaultNamespace;
using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(menuName = "Ability/Multiplayer")]
    public class MultiplayerAbility : Ability
    {
        public int factor;
        public override void Execute()
        {
            Debug.Log("is multiplied by: "+ factor);
        }
    }
    
    
}