using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public GameObject cam;

    [Header("Playable Characters")]
    public GameObject mrAverage;


    private GameObject selectedCharacter;
    private GameObject player;

    void Start()
    {
        SelectCharacter(0);
        player = Instantiate(selectedCharacter);
        Instantiate(cam, player.transform);
    }

    void Update()
    {
        
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
}
