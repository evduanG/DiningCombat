using System.Collections;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class RestartController : MonoBehaviour
{
    [SerializeField] GameObject m_Cubeprefab;
    public GameObject m_SpawnPoint;
    [SerializeField] int m_I = 5;
    [SerializeField] int m_LivingPlayerCounter;
    [SerializeField] Text m_Text;
    private const string k_FormatLivingPlayer = "Living: {0}";
    [SerializeField] Text m_GameOverText;
    private int m_NumOfAlivePlayers;
    public event Action GameOverOccured;
    
    private void Start()
    {
        GameOverOccured += ShowGameOverText;
        m_GameOverText.enabled = false;
        m_SpawnPoint = GameObject.FindGameObjectWithTag("SpawnCubePoint");
        m_LivingPlayerCounter = 0;
        m_NumOfAlivePlayers = 0;
        bool isAlive = true;
        while(m_I > 0)
        {
            LivingPlayers++;
            m_I--;
            m_SpawnPoint.transform.position = new Vector3(m_SpawnPoint.transform.position.x + 1.5f, m_SpawnPoint.transform.position.y, m_SpawnPoint.transform.position.z);
            GameObject Cube = Instantiate(m_Cubeprefab, m_SpawnPoint.transform.position, Quaternion.identity);
            DeathAfterRandomTime CubeScript = Cube.GetComponent<DeathAfterRandomTime>();
            CubeScript.CubeDestroyed += cubeScript_CubeDestroyed;
            if (isAlive)
            {
                isAlive = false;
                CubeScript.isAlive = true;
                m_NumOfAlivePlayers++;
            }
        }
    }

    private void cubeScript_CubeDestroyed(bool isAlive)
    {
        Debug.Log("cubeScript_CubeDestroyed " + isAlive + " Alives: " + m_NumOfAlivePlayers);
        LivingPlayers--;
        if (isAlive)
        {
            m_NumOfAlivePlayers--;
        }
        bool isGameOver = LivingPlayers <= 1 || m_NumOfAlivePlayers == 0;
        if (isGameOver) 
        {
            GameOverOccured?.Invoke();
        }
    }

    public void ShowGameOverText()
    {
        m_GameOverText.enabled = true;
    }

    public int LivingPlayers
    {
        get => m_LivingPlayerCounter;
        set
        {
            m_LivingPlayerCounter = value;
            m_Text.text = string.Format(k_FormatLivingPlayer, m_LivingPlayerCounter);
        }
    }
}
