using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public Color[] m_Colors;
    public Material m_ColorMat;
    public void ChangeColor(int colorIndex)
    {
        m_ColorMat.color = m_Colors[colorIndex];
    }
    public void PlayGame()
    {
        SceneManager.LoadScene("V2DiningCombat");
    }
    public void QuitGame()
    {
        Debug.Log("quit");
        Application.Quit();
    }
}
