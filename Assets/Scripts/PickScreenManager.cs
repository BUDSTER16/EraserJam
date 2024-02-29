using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PickScreenManager : MonoBehaviour
{
    public GameObject Capsule;

    public Button AvgPick;
    public Button ProjPick;
    public Button TankPick;
    public Button DemonPick;

    private void Awake()
    {
        AvgPick.onClick.AddListener(PickAvg);
        ProjPick.onClick.AddListener(PickProj);
        TankPick.onClick.AddListener(PickTank);
        DemonPick.onClick.AddListener(PickDemon);
    }

    void PickAvg()
    {
        Capsule.GetComponent<CharSelectData>().setCharacter(0);
        SceneManager.LoadScene("GameMap");
    }

    void PickProj()
    {
        Capsule.GetComponent<CharSelectData>().setCharacter(1);
        SceneManager.LoadScene("GameMap");
    }

    void PickTank()
    {
        Capsule.GetComponent<CharSelectData>().setCharacter(2);
        SceneManager.LoadScene("GameMap");
    }

    void PickDemon()
    {
        Capsule.GetComponent<CharSelectData>().setCharacter(0);
        SceneManager.LoadScene("Tutorial");
    }
}
