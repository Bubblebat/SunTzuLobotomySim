using UnityEngine;

public class UpgradeBaseStats : MonoBehaviour
{
    public float health, damage, attackChance, actionCooldown, speed, inteligence;
    [SerializeField] ScoreStorage score;
    [SerializeField] int upgradeCost;

    public void UpgradeUnit()
    {
        int rand = Random.Range(0, 6);
        float changeSize = Random.Range(1f, 4f);

        if (score.points >= upgradeCost)
        {
            switch (rand)
            {
                case 0:
                    health += changeSize * 1f;
                    break;
                case 1:
                    damage += changeSize * 1f;
                    break;
                case 2:
                    attackChance += changeSize * 1f;
                    break;
                case 3:
                    actionCooldown -= changeSize * 0.01f;
                    break;
                case 4:
                    speed += changeSize * 0.2f;
                    break;
                case 5:
                    inteligence += changeSize * 0.4f;
                    break;
            }

            score.points -= upgradeCost;
        }
    }
}
