using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharSelectData : MonoBehaviour
{
    // 0 = Avj,1 = Proj, 2 = Tank, 3 = Demon
    int charSelected;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void setCharacter(int choice)
    { 
        charSelected = choice;
    }

    public int getCharacter()
    {
        return charSelected;
    }
}
