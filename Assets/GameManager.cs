using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public int killCount = 0;
    [SerializeField] GameObject victory_ui;
    [SerializeField] GameObject defeat_ui;
    // Start is called before the first frame update
    void Start()
    {
        killCount = 0;
        victory_ui.SetActive(false);
        defeat_ui.SetActive(false);
    }

    public void AddKillCount()
    {
        killCount++;
        if (killCount >= 10)
        {
            Victory();
        }
    }

    public void Victory()
    {
        victory_ui.SetActive(true);
    }

    public void Defeat()
    {
        defeat_ui.SetActive(true);
    }
}
