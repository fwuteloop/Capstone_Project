using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public int stateIndex;
    public int level;
    public GameObject planningPanel; // hold all UI for planning stage
    public GameObject wavePanel; // holds all UI for the wave start
    public GameObject waveEndPanel; // hold all the UI for the wave end
    public GameObject gameOverPanel;
    public TextMeshProUGUI gameOverText;
    public string gameOverString;
    public void CheckStateFunction(int i)
    {
        stateIndex = i;
        switch(i)
        {
            case 0:
                PlanningStageSetUp();
                break;
            case 1:
                WaveSetUp();
                break;
            case 2:
                WaveEnd();
                break;
            case 3:
                GameOver();
                break;
        }
    }
    public void PlanningStageSetUp()
    {
        planningPanel.SetActive(true);
        wavePanel.SetActive(false);
        waveEndPanel.SetActive(false);
        //Debug.Log("planning");
    }
    public void WaveSetUp()
    {
        planningPanel.SetActive(false);
        wavePanel.SetActive(true);
        waveEndPanel.SetActive(false);
        //Debug.Log("wave started");
    }

    public void WaveEnd()
    {
        planningPanel.SetActive(false);
        wavePanel.SetActive(false);
        waveEndPanel.SetActive(true);
        //Debug.Log("wave end");
    }

    public void GameOver()
    {
        //Debug.Log("game over");
        gameOverPanel.SetActive(true);
        gameOverText.text = gameOverString;

    }
}
