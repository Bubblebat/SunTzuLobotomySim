using UnityEngine;

public class AttackScript : MonoBehaviour
{
    [SerializeField] string EnemyTag;

    [SerializeField] bool needsUnitAction = true;
    public float attackDmg = 1;
    public float abilityTime = 1;

    private void Start()
    {
        if (!needsUnitAction)
        {
            Destroy(gameObject, abilityTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (needsUnitAction)
        {
            attackDmg = transform.parent.GetComponent<UnitAction>().attackDmg;
        }
        
        if (other.transform.gameObject.CompareTag(EnemyTag))
        {
            other.GetComponent<UnitAction>().health -= attackDmg;
        }
    }
}
