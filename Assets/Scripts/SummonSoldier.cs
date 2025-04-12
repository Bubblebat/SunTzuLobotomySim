using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEditor.PlayerSettings;

public class SummonSoldier : MonoBehaviour
{
    public GameObject soldier;
    [SerializeField] Transform cardManager;
    public List<CardScript> cScript = new List<CardScript>();

    void Update()
    {
        float mPosX = Input.mousePosition.x;
        float mPosY = Input.mousePosition.y;
        Vector3 pos = Camera.main.ScreenToWorldPoint(new Vector3(mPosX, mPosY, 0));
        pos = new Vector3(Mathf.Clamp(pos.x, -6.4f, 6.4f), pos.y, 0);
        if (Input.GetMouseButtonDown(0))
        {
            CreateWarrior(pos);
        }
    }

    void CreateWarrior(Vector3 instancePos)
    {
        GameObject warrior = Instantiate(soldier, new Vector3(instancePos.x, instancePos.y), Quaternion.identity);
        UnitAction wAction = warrior.GetComponent<UnitAction>();

        for (int i = 0; i < cardManager.childCount; i++)
        {
            if (cardManager.GetChild(i).GetComponent<CardScript>().isActive)
            {
                cScript.Add(cardManager.GetChild(i).GetComponent<CardScript>());
            }
        }

        for (int i = 0; i < cScript.Count; i++)
        {
            wAction.maxHealth += cScript[i].maxHealth;
            wAction.healthMult += cScript[i].healthMult;
            wAction.attackDmg += cScript[i].attackDmg;
            wAction.attackMult += cScript[i].attackMult;
            wAction.actionCooldown += cScript[i].actionCooldown;
            wAction.actionMult += cScript[i].actionMult;
            wAction.moveStep += cScript[i].moveStep;
            for (int j = 0; j < 4; j++)
            {
                wAction.mDirProb[j] += cScript[i].mDirProb[j];
            }
            wAction.attackProb += cScript[i].attackProb;

            Destroy(cScript[i].transform.gameObject);
        }

        cScript.Clear();
    }
}
