using System;
using System.Collections.Generic;
using ScriptableObjects;
using UnityEditor;
using UnityEngine;
using UnityEngine.Serialization;

namespace Dice
{
    public class ActionDice : DiceController
    {
        [SerializeField] private DiceFaces<ActionAbility> actionAbilities;
        protected override void Start()
        {
            base.Start();
            ValidateActionList(actionAbilities);
        }

        protected override void OnValidate()
        {
            base.OnValidate();
            UpdateMaterials(actionAbilities);
        }

        
        
    }
}