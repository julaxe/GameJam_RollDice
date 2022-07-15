using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class DiceController : MonoBehaviour
{
    [SerializeField] List<Transform> m_RayEndList;

    [SerializeField] List<string> m_effectList;

    private Rigidbody m_rigidbody;
    [SerializeField] private float m_VerticalForce;
    [SerializeField] private float m_TorqueAmount;
    [SerializeField] private bool m_StoppedRolling;




    private void Awake()
    {
        m_rigidbody = GetComponent<Rigidbody>();
    }

    // Start is called before the first frame update
    void Start()
    {
        RollDice();
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Magnitude(m_rigidbody.velocity) == 0 && !m_StoppedRolling)
        {
            DiceHaveStoppedRolling();
        }
    }

    public void RollDice()
    {
        m_rigidbody.AddForce(Vector3.up * m_VerticalForce, ForceMode.Impulse);
        m_rigidbody.AddTorque(new Vector3(Random.Range(0, m_TorqueAmount), Random.Range(0, m_TorqueAmount), Random.Range(0, m_TorqueAmount)));

    }
    public void DiceHaveStoppedRolling()
    {
        m_StoppedRolling = true;
        Debug.Log("Stopped");
        for (int i = 0; i < m_RayEndList.Count; i++)
        {
            var hit = Physics.Raycast(transform.position, m_RayEndList[i].position);
            if (hit)
            {
                Debug.Log("Hit" + i) ;
            }
        }

    }


}
