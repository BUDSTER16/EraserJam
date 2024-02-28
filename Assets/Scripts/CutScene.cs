using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class CutScene : MonoBehaviour
{
    public GameObject kid;
    private Animator kidAnim;

    public GameObject BG;
    public GameObject txtBox;

    private float animTimer = 5f;
    private bool paused = false;
    short phase = 0;

    string[] dialogues = new string[4];

    // Start is called before the first frame update
    void Start()
    {
        BG.SetActive(false);
        txtBox.SetActive(false);

        kidAnim = kid.GetComponent<Animator>();

        kidAnim.SetTrigger("Write");

        SetDialogues();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetMouseButtonDown(0))
        {
            phase= 5;
            PhaseActivate();
        }

        if (!paused) { animTimer -= Time.deltaTime; }


        if (animTimer <= 0)
        {
            phase += 1;
            PhaseActivate();
        }
    }

    void PhaseActivate ()
    {
        TextMeshProUGUI txt = txtBox.GetComponentInChildren<TextMeshProUGUI>();
        switch (phase)
        {
            case 0:
                kidAnim.ResetTrigger("Write");
                phase = 1;
                kidAnim.SetTrigger("Sleep");
                animTimer = 2.5f;
                break;
            case 1:
                Destroy(kid);
                BG.SetActive(true);
                txt.text = dialogues[phase-1];
                txtBox.SetActive(true);
                animTimer = 4f;
                break;
            case 2:
                txt.text = dialogues[phase - 1];
                animTimer = 4f;
                break;
            case 3:
                txt.text = dialogues[phase - 1];
                animTimer = 4f;
                break;
            case 4:
                txt.text = dialogues[phase - 1];
                animTimer = 4f;
                break;
            case 5:
                SceneManager.LoadScene("MainMenu");
                break;
            default:
                break;
        }
    }

    void SetDialogues()
    {
        dialogues[0] = "You drift off\nin class...";
        dialogues[1] = "You're falling\ninto a dream";
        dialogues[2] = "Too late to\nturn back";
        dialogues[3] = "You'll have to\nfind a way out";
    }
}

