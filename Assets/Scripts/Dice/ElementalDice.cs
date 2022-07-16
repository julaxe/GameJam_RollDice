using System;
using System.Collections.Generic;
using ScriptableObjects;
using UnityEditor;
using UnityEngine;
using UnityEngine.Serialization;

namespace Dice
{
    
    public class ElementalDice : DiceController
    { 
        
        [SerializeField] private DiceFaces<ElementalAbility> elementalAbilities;

        private void Start()
        {
            ValidateActionList(elementalAbilities);
        }
        protected override void OnValidate()
        {
            base.OnValidate();
            UpdateMaterials(elementalAbilities);
        }

        
    }
}