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

        protected override void Start()
        {
            base.Start();
            ValidateActionList(elementalAbilities);
        }
        protected override void OnValidate()
        {
            base.OnValidate();
            UpdateMaterials(elementalAbilities);
        }

        
    }
}