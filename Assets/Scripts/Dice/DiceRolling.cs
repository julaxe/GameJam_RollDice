using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Dice
{
    public class DiceRolling : MonoBehaviour
    {
        [Header("Rolling values")]
        [SerializeField] protected float m_VerticalForce;
        [SerializeField] protected float m_TorqueAmount;
        [SerializeField] protected bool m_StoppedRolling;
        [SerializeField] public Material diceColor;

        public UnityEvent diceStopRollingEvent;
        public List<Transform> facesTransform;
        private Rigidbody m_rigidbody;
        
        private void Awake()
        {
            m_rigidbody = GetComponent<Rigidbody>();
        }
        void Update()
        {
            if(Vector3.Magnitude(m_rigidbody.velocity) == 0 && !m_StoppedRolling)
            {
                m_StoppedRolling = true;
                diceStopRollingEvent?.Invoke();
            }
        }
        
        public void RollDice()
        {
            m_StoppedRolling = false;
            m_rigidbody.AddForce(Vector3.up * m_VerticalForce, ForceMode.Impulse);
            m_rigidbody.AddTorque(new Vector3(Random.Range(0, m_TorqueAmount), Random.Range(0, m_TorqueAmount), Random.Range(0, m_TorqueAmount)));

        }
    }
}