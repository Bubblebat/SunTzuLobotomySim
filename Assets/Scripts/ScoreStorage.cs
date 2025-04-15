using UnityEngine;

public class ScoreStorage : MonoBehaviour
{
    public int points = 0;
    [SerializeField] int totalPoints = 0;
    int lastPoint = 0;

    private void FixedUpdate()
    {
        if (points > lastPoint && points != 0)
        {
            totalPoints += points - lastPoint;
            lastPoint = points;
        }

        if (points == 0)
        {
            lastPoint = 0;
        }
    }
}
