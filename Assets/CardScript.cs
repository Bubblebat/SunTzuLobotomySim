using UnityEngine;

public class CardScript : MonoBehaviour
{
    [Header("Is in use")]
    public bool isActive = false;
    public bool flippedUp = false;

    [Header("Hp and Attack dmg")]
    public float maxHealth = 10;
    public float healthMult = 1;
    public float attackDmg = 3;
    public float attackMult = 1;

    [Header("ActionModifiers")]
    public float actionCooldown = 0.6f;
    public float actionMult = 1f;
    public float moveStep = 8;

    [Header("Probabilities")]
    public float[] mDirProb = new float[4];
    public float attackProb = 25;
}
