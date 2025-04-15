using System.Collections;
using TMPro;
using UnityEngine;

public class CountDownCooldown : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI text1;
    public int cooldown = 0;
    bool countDown = true;

    private void Update()
    {
        if (countDown && cooldown > 0)
        {
            cooldown--;
            text1.text = cooldown.ToString();
            StartCoroutine(CountDown());
        }
    }

    IEnumerator CountDown()
    {
        countDown = false;
        yield return new WaitForSeconds(1);
        countDown = true;
    }
}
