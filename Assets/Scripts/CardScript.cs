using UnityEngine;

public class CardScript : MonoBehaviour
{
    [Header("Card sprites")]
    public Sprite inPlaySprite;
    public Sprite flippedSprite;

    [Header("Is in use")]
    public bool isActive = false;
    public bool flippedUp = false;

    [Header("Hp and Attack dmg")]
    public float maxHealth = 10;
    public float healthMult = 1;
    public float attackDmg = 3;
    public float attackMult = 1;
    public float inteligence = 0;

    [Header("ActionModifiers")]
    public float actionCooldown = 0.6f;
    public float actionMult = 1f;
    public float moveStep = 8;

    [Header("Probabilities")]
    public float[] mDirProb = new float[4];
    public float attackProb = 25;

    private void Start()
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();

        spriteRenderer.sprite = flippedSprite;
    }

    private void FixedUpdate()
    {
        if (isActive)
        {
            transform.GetChild(0).gameObject.SetActive(true);
        }

        else
        {
            transform.GetChild(0).gameObject.SetActive(false);
        }
    }
}
