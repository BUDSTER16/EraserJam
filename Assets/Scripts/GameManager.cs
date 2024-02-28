using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;



public class GameManager : MonoBehaviour
{

    public GameObject cam;

    [Header("Playable Characters")]
    public GameObject mrAverage;

    [Header("Enemies")]
    public GameObject lilDemon;

    [Header("Buttons")]
    [SerializeField] public Image[] buttons = new Image[3];

    [Header("Button Sprites")]
    public Sprite circleBTN;
    public Sprite bowBTN;
    public Sprite whiteoutBTN;
    public Sprite pencilsBTN;


    private GameObject selectedCharacter;
    private GameObject player;

    Vector3 spawnPos= Vector3.zero;

    private int lilDemonReq = 5;
    private int totalEnemyReq = 0;

    private int lilDemonNum = 0;
    private int totalEnemyNum = 0;


    private int lilDemonKills = 0;


    

    void Start()
    {
        SelectCharacter(0);
        player = Instantiate(selectedCharacter);
        Instantiate(cam, player.transform);

        buttons[0].gameObject.SetActive(false);
        buttons[1].gameObject.SetActive(false);
        buttons[2].gameObject.SetActive(false);
    }

    void Update()
    {
        totalEnemyReq = lilDemonReq;

        if (totalEnemyNum < totalEnemyReq)
        {
            SpawnEnemy();
        }

        if (Input.GetKeyDown(KeyCode.V))
        {
            ShowButtons();
        }
        
    }

    void SelectCharacter(short selection)
    {
        switch (selection)
        {
            case 0:
                selectedCharacter = mrAverage;
                break;
            default:
                selectedCharacter = mrAverage;
                break;
        }
    }

    void SpawnEnemy()
    {
        int spawnDir = Random.Range(0, 8);
        switch (spawnDir)
        {
            case 0:
                spawnPos.y = 12;
                break;
            case 1:
                spawnPos.y = -12;
                break;
            case 2:
                spawnPos.x = 12;
                break;
            case 3:
                spawnPos.x = -12;
                break;
            case 4:
                spawnPos.y = 8;
                spawnPos.x = 8;
                break;
            case 5:
                spawnPos.y = -8;
                spawnPos.y = -8;
                break;
            case 6:
                spawnPos.x = 8;
                spawnPos.y = -8;
                break;
            case 7:
                spawnPos.x = -8;
                spawnPos.y = 8;
                break;
            default:
                spawnPos = Vector3.zero;
                break;
        }
        spawnPos.x += player.transform.position.x;
        spawnPos.y += player.transform.position.y;

        if (lilDemonNum < lilDemonReq)
        {
            Instantiate(lilDemon, spawnPos, Quaternion.identity);
            lilDemonNum += 1;
        }
    }

    public void EnemyKilled(short enemyType)
    {
        switch (enemyType)
        {
            case 0:
                lilDemonNum -= 1;
                lilDemonKills += 1;
                player.GetComponent<PlayerWeapons>().GainXP(1);
                break;
            default:
                break;
        }
    }

    public void ShowButtons()
    {
        // Weapon List:
        // 0: Circle, 1: Bow, 2: Whiteout, 3: Pencils


        int choice;
        
        for (int i = 0; i < buttons.Length; i++)
        {
            choice = Random.Range(0, 4);

            switch (choice)
            {
                case 0:
                    buttons[i].sprite = circleBTN;
                    buttons[i].GetComponentInChildren<TextMeshProUGUI>().text = "Eraser\nCircle";
                    break;
                case 1:
                    buttons[i].sprite = bowBTN;
                    buttons[i].GetComponentInChildren<TextMeshProUGUI>().text = "Bow";
                    break;
                case 2:
                    buttons[i].sprite = whiteoutBTN;
                    buttons[i].GetComponentInChildren<TextMeshProUGUI>().text = "White\nOut";
                    break;
                case 3:
                    buttons[i].sprite = pencilsBTN;
                    buttons[i].GetComponentInChildren<TextMeshProUGUI>().text = "Pencil\nStar";
                    break;
                default:
                    break;
            }
            buttons[i].GetComponent<ButtonBehaviour>().SetWeaponHeld((short)choice);
        }

        


        buttons[0].gameObject.SetActive(true);
        buttons[1].gameObject.SetActive(true);
        buttons[2].gameObject.SetActive(true);
    }

    public void HideButtons()
    {
        buttons[0].gameObject.SetActive(false);
        buttons[1].gameObject.SetActive(false);
        buttons[2].gameObject.SetActive(false);
    }

    public void TakeButtonInfo(short id, short weap)
    {
        player.GetComponent<PlayerWeapons>().RecieveSelection(weap);
        HideButtons();
    }
}
