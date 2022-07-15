using DefaultNamespace;
using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(menuName = "Ability/Elemental")]
    public class ElementalAbility : Ability
    {
        public Element element;
        public override void Execute()
        {
            Debug.Log("the element is " + element.elementName);
        }
    }
    
    
}