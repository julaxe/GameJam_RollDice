using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject m_playerDiceInfo;
    [SerializeField] GameObject m_enemyDiceInfo;
    private GameManager m_gameManager;
    [SerializeField] List<Image> m_playerDiceSidesImageList;


    private bool m_playerPanelActive;
    private bool m_enemyPanelActive;

    private void Awake()
    {
        m_playerPanelActive = m_enemyPanelActive = false;
        m_gameManager = GetComponent<GameManager>(); 
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenDicePanel(int whichButton)
    {
        switch (whichButton)
        {
            case 0:
                m_playerDiceInfo.SetActive(!m_playerPanelActive);
                m_playerPanelActive = !m_playerPanelActive;

                break;
            case 1:
                m_playerDiceInfo.SetActive(!m_playerPanelActive);
                m_playerPanelActive = !m_playerPanelActive;

                break;
            case 2:
                m_playerDiceInfo.SetActive(!m_playerPanelActive);
                m_playerPanelActive = !m_playerPanelActive;

                break;
            case 3:
                m_enemyDiceInfo.SetActive(!m_enemyPanelActive);
                m_enemyPanelActive = !m_enemyPanelActive;

                break;
            case 4:
                m_enemyDiceInfo.SetActive(!m_enemyPanelActive);
                m_enemyPanelActive = !m_enemyPanelActive;

                break;
            case 5:
                m_enemyDiceInfo.SetActive(!m_enemyPanelActive);
                m_enemyPanelActive = !m_enemyPanelActive;

                break;


            default:
                break;
        }
        

    }


}


