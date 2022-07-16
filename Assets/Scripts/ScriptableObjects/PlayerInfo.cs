using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace ScriptableObjects
{
    [CreateAssetMenu(menuName = "Player/Info")]
    public class PlayerInfo : ScriptableObject
    {
        public float currentHealth;
        public float maxHealth;
        public UnityAction<float> TakeDamageAction;

        public List<GameObject> actionDices;
        public List<GameObject> elementalDices;
        public List<GameObject> numberDices;
        

        public void TakeDamage(float damage)
        {
            if (currentHealth == 0.0f) return;
            currentHealth -= damage;
            TakeDamageAction?.Invoke(damage);
            if (currentHealth < 0) currentHealth = 0;
            if (currentHealth > maxHealth) currentHealth = maxHealth;
        }
        
    }
}