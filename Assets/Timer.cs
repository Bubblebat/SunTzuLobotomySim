using System.Collections;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] int roundTime;
    [SerializeField] TextMeshProUGUI text1;

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
    }

    IEnumerator TickDown()
    {
        tickDown = false;
        yield return new WaitForSeconds(1);
        tickDown = true;
    }
}
