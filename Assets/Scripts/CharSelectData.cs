using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharSelectData : MonoBehaviour
{
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
