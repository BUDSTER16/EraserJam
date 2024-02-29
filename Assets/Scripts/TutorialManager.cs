using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class TutorialManager : MonoBehaviour
{

    private GameObject player;

    public GameObject txtBox;

    private float timer = 4f;
    private int phase = 0;

    string[] dialogues = new string[8];
    
    void Start()
    {
        player= GameObject.FindWithTag("Player");

        SetDialogues();
    }

    
    void Update()
    {
        timer -= Time.deltaTime;
        if(Input.GetKeyDown(KeyCode.Space))
        {
            timer = 0;
        }
        if (timer <= 0)
        {
            phase += 1;
            PhaseActivate();
        }
    }

    void PhaseActivate()
    {
        TextMeshProUGUI txt = txtBox.GetComponentInChildren<TextMeshProUGUI>();
        switch (phase)
        {
            case 0:
                txt.text = dialogues[phase];
                phase = 1;
                timer = 7f;
                break;
            case 1:
                txt.text = dialogues[phase];
                timer = 7f;
                break;
            case 2:
                txt.text = dialogues[phase];
                timer = 7f;
                break;
            case 3:
                txt.text = dialogues[phase];
                timer = 7f;
                break;
            case 4:
                txt.text = dialogues[phase];
                timer = 7f;
                break;
            case 5:
                txt.text = dialogues[phase];
                timer = 7f;
                break;
            case 6:
                txt.text = dialogues[phase];
                timer = 7f;
                break;
            case 7:
                txt.text = dialogues[phase];
                timer = 7f;
                break;
            case 8:
                SceneManager.LoadScene("MainMenu");
                break;
            default:
                break;
        }
    }

    void SetDialogues()
    {
        dialogues[0] = "Start each\ngame by\nchoosing a weapon!";
        dialogues[1] = "Stay away from\nthe map edges!";
        dialogues[2] = "Press Space to\nskip a message";
        dialogues[3] = "Don't let demons\nget too close!";
        dialogues[4] = "Your weapon\n attacks by\nitself!";
        dialogues[5] = "The game gets\nharder the longer\nyou survive";
        dialogues[6] = "There IS\nan end";
        dialogues[7] = "Sadly, this\ntutorial is\nover";
    }
}
