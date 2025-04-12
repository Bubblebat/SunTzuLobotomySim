using UnityEngine;

public class CasOpening : MonoBehaviour
{
    [SerializeField] GameObject[] attributeCards = new GameObject[25];

    public bool openCase = false;
    public float itemChance = 1f;

    private void Update()
    {
        if (openCase)
        {
            if (Random.Range(0, 1f) <= itemChance)
            {
                Instantiate(attributeCards[Random.Range(0, attributeCards.Length)], transform.position, Quaternion.identity, GameObject.FindGameObjectWithTag("CardManager").transform);
            }
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("U"))
        {
            openCase = true;
        }
    }
}
