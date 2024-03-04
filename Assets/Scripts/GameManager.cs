using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public GameObject cam;

    [Header("Playable Characters")]
    public GameObject mrAverage;
    public GameObject rangedMaster;
    public GameObject tank;

    [Header("Enemies")]
    public GameObject lilDemon;
    public GameObject biggerDemon;
    public GameObject boss;

    [Header("Buttons")]
    [SerializeField] public Image[] buttons = new Image[3];

    [Header("Button Sprites")]
    public Sprite circleBTN;
    public Sprite bowBTN;
    public Sprite whiteoutBTN;
    public Sprite pencilsBTN;
    public Sprite chainBTN;
    public Sprite orberacerBTN;
    public Sprite healauraBTN;


    private GameObject selectedCharacter;
    private GameObject player;

    private float GameTime = 0;

    Vector3 spawnPos= Vector3.zero;
    private int lildemonOG = 5;
    private int lilDemonReq = 5;
    private int biggerdemonOG = 1;
    private int biggerDemonReq = 1;
    private int bossOG = 0;
    private int bossReq = 0;
    private int totalEnemyReq = 0;

    private int bossNum = 0;
    private int lilDemonNum = 0;
    private int biggerDemonNum = 0;
    private int totalEnemyNum = 0;


    private int lilDemonKills = 0;
    private int biggerDemonKills = 0;

    void Awake()
    {
        SelectCharacter(Smuggle());
        player = Instantiate(selectedCharacter);
        Instantiate(cam, player.transform);
        ShowButtons();
    }

    void Update()
    {
        totalEnemyReq = lilDemonReq + biggerDemonReq + bossReq;
        totalEnemyNum = lilDemonNum + biggerDemonNum + bossNum;

        if (totalEnemyNum < totalEnemyReq)
        {
            SpawnEnemy();
        }
        CheckPlayerXP();

        GameTime += Time.deltaTime;

        lilDemonReq = lildemonOG + ((int)GameTime / 15);
        biggerDemonReq = biggerdemonOG + ((int)GameTime / 100);
        bossReq = bossOG + ((int)GameTime / 15);

    }

    void SelectCharacter(short selection)
    {
        switch (selection)
        {
            case 0:
                selectedCharacter = mrAverage;
                break;
            case 1:
                selectedCharacter = rangedMaster;
                break;
            case 2:
                selectedCharacter = tank;
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
        else if (biggerDemonNum < biggerDemonReq)
        {
            Instantiate(biggerDemon, spawnPos, Quaternion.identity);
            biggerDemonNum += 1;
        }
        else if (bossReq < bossNum)
        {
            Instantiate(boss, spawnPos, Quaternion.identity);
            bossNum += 1;
        }
        totalEnemyNum = lilDemonNum + biggerDemonNum + bossNum;
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
            case 1:
                biggerDemonNum -= 1;
                biggerDemonKills += 1;
                player.GetComponent<PlayerWeapons>().GainXP(3);
                break;
            case 2:
                bossNum -= 1;
                SceneManager.LoadScene("Win");
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
            choice = Random.Range(0, 7);

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
                case 4:
                    buttons[i].sprite = chainBTN;
                    buttons[i].GetComponentInChildren<TextMeshProUGUI>().text = "Chain\nEraser";
                    break;
                case 5:
                    buttons[i].sprite = healauraBTN;
                    buttons[i].GetComponentInChildren<TextMeshProUGUI>().text = "Heal\nAura";
                    break;
                case 6:
                    buttons[i].sprite = orberacerBTN;
                    buttons[i].GetComponentInChildren<TextMeshProUGUI>().text = "Orberaser";
                    break;
                default:
                    break;
            }
            buttons[i].GetComponent<ButtonBehaviour>().SetWeaponHeld((short)choice);
        }

        


        buttons[0].gameObject.SetActive(true);
        buttons[1].gameObject.SetActive(true);
        buttons[2].gameObject.SetActive(true);
        Time.timeScale = 0f;
    }

    public void ShowButtons(int[] used)
    {
        // Weapon List:
        // 0: Circle, 1: Bow, 2: Whiteout, 3: Pencils


        int choice;

        for (int i = 0; i < buttons.Length; i++)
        {
            choice = used[Random.Range(0, 4)];

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
                case 4:
                    buttons[i].sprite = chainBTN;
                    buttons[i].GetComponentInChildren<TextMeshProUGUI>().text = "Chain\nEraser";
                    break;
                case 5:
                    buttons[i].sprite = healauraBTN;
                    buttons[i].GetComponentInChildren<TextMeshProUGUI>().text = "Heal\nAura";
                    break;
                case 6:
                    buttons[i].sprite = orberacerBTN;
                    buttons[i].GetComponentInChildren<TextMeshProUGUI>().text = "Orberaser";
                    break;
                default:
                    break;
            }
            buttons[i].GetComponent<ButtonBehaviour>().SetWeaponHeld((short)choice);
        }




        buttons[0].gameObject.SetActive(true);
        buttons[1].gameObject.SetActive(true);
        buttons[2].gameObject.SetActive(true);
        Time.timeScale = 0f;
    }

    public void HideButtons()
    {
        buttons[0].gameObject.SetActive(false);
        buttons[1].gameObject.SetActive(false);
        buttons[2].gameObject.SetActive(false);
        Time.timeScale = 1.0f;
    }

    public void TakeButtonInfo(short id, short weap)
    {
        player.GetComponent<PlayerWeapons>().RecieveSelection(weap);
        HideButtons();
    }

    short Smuggle()
    {
        GameObject Capsule = GameObject.Find("DataCapsule");
        short pick = (short)Capsule.GetComponent<CharSelectData>().getCharacter();
        Destroy(Capsule);
        return pick;
    }

    void CheckPlayerXP()
    {
        int exp = player.GetComponent<PlayerWeapons>().GetXP();
        int wNum = player.GetComponent<PlayerWeapons>().GetWeaponCount();
        if (exp >= 20 && wNum != 4) 
        {
            ShowButtons();
            player.GetComponent<PlayerWeapons>().LevelUp();
        }
        else if (exp >= 20)
        {
            ShowButtons(player.GetComponent<PlayerWeapons>().GetEquippedIDs());
            player.GetComponent<PlayerWeapons>().LevelUp();
        }
    }
}
