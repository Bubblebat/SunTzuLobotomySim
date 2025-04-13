using TMPro;
using UnityEngine;

public class DisplayUnitBaseStats : MonoBehaviour
{
    [SerializeField] UpgradeBaseStats stats;
    [SerializeField] TextMeshProUGUI text1;

    private void FixedUpdate()
    {
        text1.text = "Warrior base stats\nHealth: " + (int)stats.health + "\nDamage: " + (int)stats.damage + "\nAttack Chance: " + (int)stats.attackChance + "\nAction CD: " + stats.actionCooldown + "\nSpeed: " + (int)stats.speed;
    }
}
