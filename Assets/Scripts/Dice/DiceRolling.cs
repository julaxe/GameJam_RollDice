using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

namespace Dice
{
    public class DiceRolling : MonoBehaviour
    {
        [Header("Rolling values")]
        [SerializeField] protected float m_VerticalForce;
        [SerializeField] protected float m_HorizontalForce;
        [SerializeField] protected float m_TorqueAmount;
        [SerializeField] public Material diceColor;

        private bool _isRolling =false;
        public UnityEvent diceStopRollingEvent;
        public List<Transform> facesTransform;
        private Rigidbody m_rigidbody;

        private void Awake()
        {
            m_rigidbody = GetComponent<Rigidbody>();
        }
        void LateUpdate()
        {
            if (!_isRolling) return;
            if(Vector3.Magnitude(m_rigidbody.velocity) == 0.0f)
            {
                _isRolling = false;
                m_rigidbody.useGravity = false;
                diceStopRollingEvent?.Invoke();
            }
        }
        
        public void RollDice()
        {
            m_rigidbody.useGravity = true;
            m_rigidbody.AddForce(new Vector3(0, m_VerticalForce, m_HorizontalForce), ForceMode.Impulse);
            m_rigidbody.AddTorque(new Vector3(Random.Range(0, m_TorqueAmount), Random.Range(0, m_TorqueAmount), Random.Range(0, m_TorqueAmount)));
            StartCoroutine(IsRollingInSeconds(0.2f));
        }

        IEnumerator IsRollingInSeconds(float seconds)
        {
            yield return new WaitForSeconds(seconds);
            _isRolling = true;
        }
    }
}