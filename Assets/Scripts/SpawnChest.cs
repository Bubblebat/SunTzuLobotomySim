using System.Collections;
using UnityEngine;

public class SpawnChest : MonoBehaviour
{
    [SerializeField] GameObject chest;
    [SerializeField] float spawnCd = 20f;

    bool canSpawn = true;

    private void FixedUpdate()
    {
        if (canSpawn)
        {
            Vector3 pos = RandomPos();
            Instantiate(chest, pos, Quaternion.identity);

            StartCoroutine(SpawnCooldown());
        }
    }

    Vector3 RandomPos()
    {
        return new Vector3(Random.Range(-6f, 6f), Random.Range(-4.5f, 4.5f), 0);
    }

    IEnumerator SpawnCooldown()
    {
        canSpawn = false;
        yield return new WaitForSeconds(spawnCd);
        canSpawn = true;
    }
}
