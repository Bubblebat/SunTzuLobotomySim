using System.Collections;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] int roundTime;
    [SerializeField] TextMeshProUGUI text1;
    [SerializeField] LevelSettings levelSettings;
    [SerializeField] ScoreStorage scoreStorage;

    bool tickDown = true;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.N))
        {
            roundTime = 0;
            text1.text = roundTime.ToString();
        }

        if (tickDown && roundTime > 0)
        {
            text1.text = roundTime.ToString();
            roundTime--;
            StartCoroutine(TickDown());
        }

        if (roundTime <= 0)
        {
            GameObject[] units = GameObject.FindGameObjectsWithTag("U");
            for (int i = 0; i < units.Length; i++)
            {
                Destroy(units[i]);
            }

            if (scoreStorage.points >= 60)
            {
                levelSettings.currentLevel += 1;
                roundTime += 300;
                scoreStorage.points = 0;
            }
            else
            {
                Debug.Log("Noob");
            }
        }
    }

    IEnumerator TickDown()
    {
        tickDown = false;
        yield return new WaitForSeconds(1);
        tickDown = true;
    }
}
