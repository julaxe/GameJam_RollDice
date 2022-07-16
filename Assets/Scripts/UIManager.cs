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
    [SerializeField] List<GameObject> m_playerButtonList;



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
        //Resetting buttons to not be visable 
        foreach (GameObject button in m_playerButtonList)
        {
            button.SetActive(false);
        }



        switch (whichButton)
        {
            case 0:
                m_playerDiceInfo.SetActive(!m_playerPanelActive);
                m_playerPanelActive = !m_playerPanelActive;

                for (int i = 0; i < m_gameManager.GetPlayer().GetComponent<DiceHolder>().m_actionDice.Count; i++)
                {
                    m_playerButtonList[i].SetActive(true);
                }

                Material[] temp = m_gameManager.GetPlayer().GetComponent<DiceHolder>().m_actionDice[0].GetComponent<MeshRenderer>().materials;
                
                m_playerDiceSidesImageList[0].texture = temp[3].mainTexture;
                m_playerDiceSidesImageList[1].texture = temp[0].mainTexture;
                m_playerDiceSidesImageList[2].texture = temp[1].mainTexture;
                m_playerDiceSidesImageList[3].texture = temp[4].mainTexture;
                m_playerDiceSidesImageList[4].texture = temp[2].mainTexture;
                m_playerDiceSidesImageList[5].texture = temp[6].mainTexture;



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


