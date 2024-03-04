using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AOEWeapon : MonoBehaviour
{
    public string weaponName;
    [Header("Stats")]
    public float damage;
    public float regen;
    public bool isCursed;
    private float curseDmg;
    private Vector3 size;

    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        size = this.transform.localScale;
        player = this.gameObject.transform.parent.gameObject;
        damage *= player.GetComponent<PlayerWeapons>().dmgMultiplier;
        regen *= player.GetComponent<PlayerWeapons>().healMultiplier;
        curseDmg = player.GetComponent<PlayerWeapons>().curseDamage;

        this.transform.localPosition = new Vector3(0, -0.6f, 0);
    }

    

    public void Upgrade()
    {
        short stat = (short)Random.Range(0, 2);

        switch (stat)
        {
            case 0:
                damage += 0.5f;
                break;
            case 1:
                size.x += 5f;
                size.y += 5f;
                AdjustTransform();
                break;
            default:
                break;
        }
    }

    void AdjustTransform()
    {
        transform.localScale = size;
    }
}
