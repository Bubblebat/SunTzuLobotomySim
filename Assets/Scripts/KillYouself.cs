using System.Collections;
using UnityEngine;

public class KillYouself : MonoBehaviour
{
    bool canExecute = true;
    public CountDownCooldown cooldownThing;

    public void ExecuteOrder66()
    {
        if (GameObject.FindGameObjectsWithTag("U").Length > 0 && canExecute)
        {
            Destroy(GameObject.FindGameObjectsWithTag("U")[Random.Range(0, GameObject.FindGameObjectsWithTag("U").Length)]);

            cooldownThing.cooldown = 10;

            StartCoroutine(ExecuteCooldown());
        }
    }

    IEnumerator ExecuteCooldown()
    {
        canExecute = false;
        yield return new WaitForSeconds(10);
        canExecute = true;
    }
}
