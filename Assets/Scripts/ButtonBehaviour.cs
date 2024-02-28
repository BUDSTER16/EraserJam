using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonBehaviour : MonoBehaviour
{
    public short btnID;

    public GameManager gm;

    // Weapon List:
    // 0: Circle, 1: Bow, 2: Whiteout, 3: Pencils
    public short WeapHeld;

    public void OnClick()
    {
        gm.GetComponent<GameManager>().TakeButtonInfo(btnID, WeapHeld);
    }

    public void SetWeaponHeld(short held)
    {
        WeapHeld = held;
    }
}
