using System.Collections;
using System.Collections.Generic;
using ScriptableObjects;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject m_playerDiceInfo;
    [SerializeField] GameObject m_enemyDiceInfo;
    
    [SerializeField] List<RawImage> m_playerDiceSidesImageList;
    [SerializeField] List<RawImage> m_enemyDiceSidesImageList;

    [SerializeField] List<GameObject> m_playerButtonList;
    [SerializeField] List<GameObject> m_enemyButtonList;

    [SerializeField] private PlayerInfo playerInfo;
    [SerializeField] private PlayerInfo enemyInfo;
    [SerializeField] private GameEvents gameEvents;
    private List<GameObject> m_currentDiceList;

    private bool m_playerPanelActive;
    private bool m_enemyPanelActive;
    private int m_playerLastButtonPressed;
    private int m_ememyLastButtonPressed;


    private void Awake()
    {
        m_playerPanelActive = m_enemyPanelActive = false;
        m_playerLastButtonPressed = m_ememyLastButtonPressed = -1;
        gameEvents.playerChangedDice += PlayerWhichDiceToLookAt;
        gameEvents.enemyChangedDice += EnemyWhichDiceToLookAt;
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

        

        switch (whichButton)
        {
            case 0:
                m_playerDiceInfo.SetActive(m_playerPanelActive);


                for (int i = 0; i < playerInfo.actionDices.Count; i++)
                {
                    m_playerButtonList[i].SetActive(true);
                }
                
                UpdateDicePanel(m_playerDiceSidesImageList,playerInfo.actionDices, 0);
                m_currentDiceList = playerInfo.actionDices;
            
            
            break;
            case 1:
                m_playerDiceInfo.SetActive(m_playerPanelActive);
                
                for (int i = 0; i < playerInfo.elementalDices.Count; i++)
                {
                    m_playerButtonList[i].SetActive(true);
                }
            
                UpdateDicePanel(m_playerDiceSidesImageList,playerInfo.elementalDices, 0);
                m_currentDiceList = playerInfo.elementalDices;
            
            
                break;
            case 2:
                m_playerDiceInfo.SetActive(m_playerPanelActive);
            
                for (int i = 0; i < playerInfo.numberDices.Count; i++)
                {
                    m_playerButtonList[i].SetActive(true);
                }
            
                UpdateDicePanel(m_playerDiceSidesImageList,playerInfo.numberDices, 0);
                m_currentDiceList = playerInfo.numberDices;
            
            
                break;
            case 3:
                m_enemyDiceInfo.SetActive(m_enemyPanelActive);
            
                for (int i = 0; i < enemyInfo.actionDices.Count; i++)
                {
                    m_enemyButtonList[i].SetActive(true);
                }
                UpdateDicePanel(m_enemyDiceSidesImageList, enemyInfo.actionDices, 0);
                m_currentDiceList = enemyInfo.actionDices;
            
                break;
            case 4:
                m_enemyDiceInfo.SetActive(m_enemyPanelActive);
            
                for (int i = 0; i < enemyInfo.elementalDices.Count; i++)
                {
                    m_enemyButtonList[i].SetActive(true);
                }
                UpdateDicePanel(m_enemyDiceSidesImageList,enemyInfo.elementalDices, 0);
                m_currentDiceList = enemyInfo.elementalDices;
            
                break;
            case 5:
                m_enemyDiceInfo.SetActive(m_enemyPanelActive);
            
                for (int i = 0; i < enemyInfo.numberDices.Count; i++)
                {
                    m_enemyButtonList[i].SetActive(true);
                }
                UpdateDicePanel(m_enemyDiceSidesImageList,enemyInfo.numberDices, 0);
                m_currentDiceList = enemyInfo.numberDices;

                break;


            default:
                break;
        }

       
    }
    private void UpdateDicePanel(List<RawImage> diceSideImageList ,List<GameObject> dice, int whichDice)
    {
        if (dice == null || dice.Count == 0) return;
        Material[] temp = dice[whichDice].GetComponent<MeshRenderer>().sharedMaterials;

        diceSideImageList[0].texture = temp[3].mainTexture;
        diceSideImageList[1].texture = temp[0].mainTexture;
        diceSideImageList[2].texture = temp[1].mainTexture;
        diceSideImageList[3].texture = temp[4].mainTexture;
        diceSideImageList[4].texture = temp[2].mainTexture;
        diceSideImageList[5].texture = temp[6].mainTexture;
    }

    private void PlayerWhichDiceToLookAt(int numDice)
    {
        UpdateDicePanel(m_playerDiceSidesImageList, m_currentDiceList, numDice);
    }
    private void EnemyWhichDiceToLookAt(int numDice)
    {
        UpdateDicePanel(m_enemyDiceSidesImageList,m_currentDiceList, numDice);
    }



}


