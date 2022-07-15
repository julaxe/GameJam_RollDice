using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatController : MonoBehaviour
{
    private float m_health;
    private float m_block;



    // Start is called before the first frame update
    void Start()
    {
        m_health = 20;
        m_block = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void changeHealthAmount(float amount)
    {
        float currentAmount = 0;
        if(amount < 0)
        {
            m_block += amount;
            if (m_block < 0)
            {
                currentAmount = m_block;
                m_block = 0;
            }
            m_health += currentAmount;
            return;
        }

        m_health += amount;
    }
    public void addBlockAmount(float amount)
    {
        m_block += amount;
    }

}
