using System;
using System.Collections.Generic;
using ScriptableObjects;
using UnityEditor;
using UnityEngine;
using UnityEngine.Serialization;

namespace Dice
{
    
    public class NumberDice : DiceController
    { 
        
        [SerializeField] private DiceFaces<MultiplyAbility> multiplyAbilities;

        protected override void Start()
        {
            base.Start();
            ValidateActionList(multiplyAbilities);
        }
        protected override void OnValidate()
        {
            base.OnValidate();
            UpdateMaterials(multiplyAbilities);
        }

        
    }
}