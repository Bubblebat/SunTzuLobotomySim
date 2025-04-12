using TMPro;
using UnityEngine;

public class DisplayPoints : MonoBehaviour
{
    [SerializeField] int score = 0;
    [SerializeField] TextMeshProUGUI text1;

    private void FixedUpdate()
    {
        text1.text = ": " + score;
    }
}
