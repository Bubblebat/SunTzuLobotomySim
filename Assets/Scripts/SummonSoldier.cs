using System.Collections.Generic;
using UnityEngine;

public class SummonSoldier : MonoBehaviour
{
    public GameObject soldier;
    [SerializeField] Transform cardManager;
    public List<CardScript> cScript = new List<CardScript>();
    [SerializeField] UpgradeBaseStats newStats;

    void Update()
    {
        float mPosX = Input.mousePosition.x;
        float mPosY = Input.mousePosition.y;
        Vector3 pos = Camera.main.ScreenToWorldPoint(new Vector3(mPosX, mPosY, 0));
        if (pos.x > -6.4f && pos.x < 6.4f)
        {
            if (pos.y > -4.4f && pos.y < 4.4f)
            {
                pos = new Vector3(Mathf.Clamp(pos.x, -6.4f, 6.4f), pos.y, 0);
                if (Input.GetMouseButtonDown(0) && GameObject.FindGameObjectsWithTag("U").Length < 5)
                {
                    CreateWarrior(pos);
                }
            }
        }
    }

    void CreateWarrior(Vector3 instancePos)
    {
        GameObject warrior = Instantiate(soldier, new Vector3(instancePos.x, instancePos.y), Quaternion.identity);
        UnitAction wAction = warrior.GetComponent<UnitAction>();

        wAction.maxHealth = newStats.health;
        wAction.attackDmg = newStats.damage;
        wAction.attackProb = newStats.attackChance;
        wAction.actionCooldown = newStats.actionCooldown;
        wAction.moveStep = newStats.speed;
        wAction.inteligence = newStats.inteligence;

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
            wAction.inteligence += cScript[i].inteligence;
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
