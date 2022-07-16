using System;
using ScriptableObjects;
using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace
{
    public class HealthUI : MonoBehaviour
    {
        [SerializeField] private PlayerInfo playerInfo;

        private Slider _slider;

        private void Awake()
        {
            _slider = GetComponent<Slider>();
        }

        private void Start()
        {
            _slider.value = 100;
            playerInfo.TakeDamageAction += UpdateWhenTakeDamage;
        }

        private void UpdateWhenTakeDamage(float damage)
        {
            var newValue = playerInfo.currentHealth / playerInfo.maxHealth;
            _slider.value = newValue * 100.0f;
        }
    }
}