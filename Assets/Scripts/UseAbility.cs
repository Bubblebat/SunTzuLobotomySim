using System.Collections;
using UnityEngine;

public class UseAbility : MonoBehaviour
{
    public GameObject[] ability = new GameObject[3];
    [SerializeField] InspectUnit inspectU;
    bool abilityOnCd = false;
    [SerializeField] float abilityCooldown;

    public CountDownCooldown cooldownThing;

    public void ExecuteAbility()
    {
        if (!abilityOnCd)
        {
            GameObject tmp = Instantiate(ability[Random.Range(0, 3)], inspectU.selectedObj.transform.position, Quaternion.identity);

            Vector2 movDir = inspectU.selectedObj.GetComponent<UnitAction>().moveDir;
            float zRot = 0;
            if (movDir.y == 1)
            {
                zRot = 0;
            }
            else if (movDir.x == 1)
            {
                zRot = -90;
            }
            else if (movDir.y == -1)
            {
                zRot = -180;
            }
            else
            {
                zRot = -270;
            }

            tmp.transform.rotation = Quaternion.Euler(0, 0, zRot);

            cooldownThing.cooldown = (int)abilityCooldown;

            StartCoroutine(Abilitycooldown());
        }
        
    }

    IEnumerator Abilitycooldown()
    {
        abilityOnCd = true;
        yield return new WaitForSeconds(abilityCooldown);
        abilityOnCd = false;
    }
}
