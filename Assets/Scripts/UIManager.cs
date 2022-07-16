using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject m_playerDiceInfo;
    [SerializeField] GameObject m_enemyDiceInfo;
    private GameManager m_gameManager;
    [SerializeField] List<RawImage> m_playerDiceSidesImageList;
    [SerializeField] List<RawImage> m_enemyDiceSidesImageList;

    [SerializeField] List<GameObject> m_playerButtonList;
    [SerializeField] List<GameObject> m_enemyButtonList;

    private List<GameObject> m_currentDiceList;

    private bool m_playerPanelActive;
    private bool m_enemyPanelActive;
    private int m_playerLastButtonPressed;
    private int m_ememyLastButtonPressed;


    private void Awake()
    {
        m_playerPanelActive = m_enemyPanelActive = false;
        m_gameManager = GetComponent<GameManager>();
        m_playerLastButtonPressed = m_ememyLastButtonPressed = -1;
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
        //Toggle control for the player panel
        if(whichButton <= 2 && (whichButton == m_playerLastButtonPressed || m_playerPanelActive == false))
        {
            m_playerPanelActive = !m_playerPanelActive;
        }
        if (whichButton <= 2)
        {
            m_playerLastButtonPressed = whichButton;
            //Resetting buttons to not be visable 
            for (int i = 0; i < m_playerButtonList.Count; i++)
            {
                m_playerButtonList[i].SetActive(false);
            }
        }

        //Toggle control for the enemy panel
        if (whichButton >= 3 && (whichButton == m_ememyLastButtonPressed || m_enemyPanelActive == false))
        {
            m_enemyPanelActive = !m_enemyPanelActive;
        }
        if (whichButton >= 3)
        {
            m_ememyLastButtonPressed = whichButton;
            //Resetting buttons to not be visable 
            for (int i = 0; i < m_playerButtonList.Count; i++)
            {
                m_enemyButtonList[i].SetActive(false);
            }
        }

        Debug.Log(m_playerLastButtonPressed + "   "+ m_ememyLastButtonPressed);

        switch (whichButton)
        {
            case 0:
                m_playerDiceInfo.SetActive(m_playerPanelActive);


                for (int i = 0; i < m_gameManager.GetPlayer().GetComponent<DiceHolder>().m_actionDice.Count; i++)
                {
                    m_playerButtonList[i].SetActive(true);
                }

                UpdateDicePanel(m_gameManager.GetPlayer().GetComponent<DiceHolder>().m_actionDice, 0);
                m_currentDiceList = m_gameManager.GetPlayer().GetComponent<DiceHolder>().m_actionDice;


                break;
            case 1:
                m_playerDiceInfo.SetActive(m_playerPanelActive);
                
                for (int i = 0; i < m_gameManager.GetPlayer().GetComponent<DiceHolder>().m_elementDice.Count; i++)
                {
                    m_playerButtonList[i].SetActive(true);
                }

                UpdateDicePanel(m_gameManager.GetPlayer().GetComponent<DiceHolder>().m_elementDice, 0);
                m_currentDiceList = m_gameManager.GetPlayer().GetComponent<DiceHolder>().m_elementDice;


                break;
            case 2:
                m_playerDiceInfo.SetActive(m_playerPanelActive);

                for (int i = 0; i < m_gameManager.GetPlayer().GetComponent<DiceHolder>().m_elementDice.Count; i++)
                {
                    m_playerButtonList[i].SetActive(true);
                }

                UpdateDicePanel(m_gameManager.GetPlayer().GetComponent<DiceHolder>().m_valueDice, 0);
                m_currentDiceList = m_gameManager.GetPlayer().GetComponent<DiceHolder>().m_valueDice;


                break;
            case 3:
                m_enemyDiceInfo.SetActive(m_enemyPanelActive);

                for (int i = 0; i < m_gameManager.GetEnemy().GetComponent<DiceHolder>().m_actionDice.Count; i++)
                {
                    m_enemyButtonList[i].SetActive(true);
                }

                break;
            case 4:
                m_enemyDiceInfo.SetActive(m_enemyPanelActive);

                for (int i = 0; i < m_gameManager.GetEnemy().GetComponent<DiceHolder>().m_elementDice.Count; i++)
                {
                    m_enemyButtonList[i].SetActive(true);
                }

                break;
            case 5:
                m_enemyDiceInfo.SetActive(m_enemyPanelActive);

                for (int i = 0; i < m_gameManager.GetEnemy().GetComponent<DiceHolder>().m_valueDice.Count; i++)
                {
                    m_enemyButtonList[i].SetActive(true);
                }


                break;


            default:
                break;
        }

       
    }
    private void UpdateDicePanel(List<GameObject> dice, int whichDice)
    {
        if (dice == null || dice.Count == 0) return;
        Material[] temp = dice[whichDice].GetComponent<MeshRenderer>().materials;

        m_playerDiceSidesImageList[0].texture = temp[3].mainTexture;
        m_playerDiceSidesImageList[1].texture = temp[0].mainTexture;
        m_playerDiceSidesImageList[2].texture = temp[1].mainTexture;
        m_playerDiceSidesImageList[3].texture = temp[4].mainTexture;
        m_playerDiceSidesImageList[4].texture = temp[2].mainTexture;
        m_playerDiceSidesImageList[5].texture = temp[6].mainTexture;
    }

    public void WhichDiceToLookAt(int numDice)
    {
        UpdateDicePanel(m_currentDiceList, numDice);
    }



}


