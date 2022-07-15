using System.Collections;
using System.Collections.Generic;
using System.Linq;
using ScriptableObjects;
using UnityEngine;
using UnityEngine.Pool;

public class DiceController : MonoBehaviour
{
    [SerializeField] List<Transform> m_RayEndList;
    [SerializeField] List<ActionAbility> actionAbilities;
    [SerializeField] private Material diceColor;
    [SerializeField] private MeshRenderer meshRenderer;

    [Header("Rolling values")]
    [SerializeField] private float m_VerticalForce;
    [SerializeField] private float m_TorqueAmount;
    [SerializeField] private bool m_StoppedRolling;

    
    private Rigidbody m_rigidbody;

    public void UpdateMaterials()
    {
        var newMaterial = new Material[7];

        newMaterial[0] = actionAbilities[1].material;
        newMaterial[1] = actionAbilities[2].material;
        newMaterial[2] = actionAbilities[4].material;
        newMaterial[3] = actionAbilities[0].material;
        newMaterial[4] = actionAbilities[3].material;
        newMaterial[5] = diceColor;
        newMaterial[6] = actionAbilities[5].material;
        
        meshRenderer.materials = newMaterial;
    }

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
        int topFace = 0;
        for (int i = 0; i < m_RayEndList.Count; i++)
        {
            if (m_RayEndList[i].position.y > m_RayEndList[topFace].position.y)
            {
                topFace = i;
            }
        }
        Debug.Log("The top face is " + topFace);
        actionAbilities[topFace].Execute();

    }


}
