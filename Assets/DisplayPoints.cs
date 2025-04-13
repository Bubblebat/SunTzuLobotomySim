using TMPro;
using UnityEngine;

public class DisplayPoints : MonoBehaviour
{
    [SerializeField] int score = 0;
    public int roundNeededScore = 60;
    [SerializeField] TextMeshProUGUI text1;

    private void FixedUpdate()
    {
        score = GameObject.FindGameObjectWithTag("PointCounter").GetComponent<ScoreStorage>().points;
        text1.text = ": " + score + " / " + roundNeededScore;
    }
}
