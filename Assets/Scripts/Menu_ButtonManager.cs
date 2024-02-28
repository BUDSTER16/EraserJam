using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu_ButtonManager : MonoBehaviour
{
    public Button play;
    public Button quit;
    public Button cutscn;
    public Button stats;
    public Button credit;
    private void Awake()
    {
        cutscn.onClick.AddListener(LoadCutScene);
        play.onClick.AddListener(LoadCharacterSelect);
        quit.onClick.AddListener(QuitGame);
        stats.onClick.AddListener(LoadStats);
        credit.onClick.AddListener(LoadCredits);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void LoadCutScene()
    {
        SceneManager.LoadScene("Opening");
    }

    void LoadCharacterSelect()
    {
        SceneManager.LoadScene("CharSelect");
    }

    void LoadCredits()
    {
        SceneManager.LoadScene("Credits");
    }

    void LoadStats()
    {
        SceneManager.LoadScene("Statistics");
    }

    void QuitGame()
    {
        Application.Quit();
    }
}
