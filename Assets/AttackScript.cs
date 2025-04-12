using UnityEngine;

public class AttackScript : MonoBehaviour
{
    [SerializeField] string EnemyTag;

    float attackDmg = 1;

    private void OnTriggerEnter2D(Collider2D other)
    {
        attackDmg = transform.parent.GetComponent<UnitAction>().attackDmg;

        if (other.transform.gameObject.CompareTag(EnemyTag))
        {
            other.GetComponent<UnitAction>().health -= attackDmg;
        }
    }
}
