using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int currentLevel;
    UIManager uIManager;
    // Start is called before the first frame update
    void Awake()
    {
        uIManager = GetComponent<UIManager>();
    }

    private void Start()
    {
        currentLevel = 1;
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    public void GameOver()
    {
        Time.timeScale = 0;
    }
}
