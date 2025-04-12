using System.Collections;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    [SerializeField] GameObject enemy;
    [SerializeField] float spawnCd = 10f;

    bool spawnOnCD = true;

    private void Update()
    {
        if (spawnOnCD && GameObject.FindGameObjectsWithTag("E").Length < 5)
        {
            Vector3 pos = RandomPos();
            Instantiate(enemy, pos, Quaternion.identity);
            StartCoroutine(SpawnCooldown());
        }
    }

    Vector3 RandomPos()
    {
        return new Vector3(Random.Range(-6f, 6f), Random.Range(-4.5f, 4.5f), 0);
    }

    IEnumerator SpawnCooldown()
    {
        spawnOnCD = false;
        yield return new WaitForSeconds(spawnCd);
        spawnOnCD = true;
    }
}
