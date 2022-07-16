using DefaultNamespace;
using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(menuName = "Ability/Elemental")]
    public class ElementalAbility : Ability
    {
        public Element element;
        public override void Execute(PlayerController player, PlayerController enemy)
        {
            player.currentElement = element;
        }
    }
    
    
}