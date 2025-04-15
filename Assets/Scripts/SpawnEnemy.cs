using System.Collections;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    [SerializeField] GameObject enemy;
    [SerializeField] float spawnCd = 10f;
    [SerializeField] float difficultyFactor = 1.0f;
    [SerializeField] float difficultyScaling = 0.5f;
    [SerializeField] LevelSettings levelSettings;

    int lastLevel = 0;

    bool spawnOnCD = true;

    private void Update()
    {
        if (spawnOnCD && GameObject.FindGameObjectsWithTag("E").Length < 5)
        {
            //Fix the difficulty using levelSetting
            if (levelSettings.currentLevel > lastLevel)
            {
                difficultyFactor = 0;
                difficultyFactor = levelSettings.baseDifficulty[levelSettings.currentLevel-1];
                difficultyScaling = levelSettings.difficultyScaling[levelSettings.currentLevel-1];
                lastLevel = levelSettings.currentLevel;
            }

            Vector3 pos = RandomPos();
            GameObject enemyInst = Instantiate(enemy, pos, Quaternion.identity);
            UnitAction unitAction = enemyInst.GetComponent<UnitAction>();
            MonsterScaling(unitAction);
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
        difficultyFactor += difficultyScaling;
        spawnOnCD = true;
    }

    void MonsterScaling(UnitAction fiendScript)
    {
        fiendScript.maxHealth += Random.Range(0, 1.5f) * difficultyFactor;
        fiendScript.healthMult += Random.Range(0, 0.2f) * difficultyFactor;
        fiendScript.attackDmg += Random.Range(0, 1f) * difficultyFactor;
        fiendScript.attackMult += Random.Range(0, 0.1f) * difficultyFactor;
        fiendScript.actionMult += Random.Range(0, 0.1f) * difficultyFactor;
        fiendScript.moveStep += Random.Range(0, 0.5f) * difficultyFactor;
        fiendScript.attackProb += Random.Range(0, 4f) * difficultyFactor;
        fiendScript.inteligence += Random.Range(0, 1f) * difficultyFactor * 0.5f;
    }
}
