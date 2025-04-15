using UnityEngine;

public class SortCards : MonoBehaviour
{
    [SerializeField] Transform PosList;
    public int mixAmount = 10;

    int lastSize = 69420;

    private void Start()
    {
        MixMF();
    }

    private void Update()
    {
        if (lastSize != transform.childCount)
        {
            SortMF();
        }
    }

    void SortMF()
    {
        for (int i = 0; i < Mathf.Clamp(transform.childCount, 0, 5); i++)
        {
            transform.GetChild(i).GetComponent<CardScript>().flippedUp = true;
            transform.GetChild(i).position = PosList.GetChild(i).position;
            transform.GetChild(i).GetComponent<SpriteRenderer>().sortingOrder = 102;
            transform.GetChild(i).GetComponent<SpriteRenderer>().sprite = transform.GetChild(i).GetComponent<CardScript>().inPlaySprite;
            transform.GetChild(i).GetComponent<BoxCollider2D>().enabled = true;
        }

        if (transform.childCount > 5)
        {
            for (int i = 5; i < transform.childCount; i++)
            {
                transform.GetChild(i).position = PosList.GetChild(5).position;
                transform.GetChild(i).GetComponent<SpriteRenderer>().sortingOrder = 101;
                transform.GetChild(i).GetComponent<BoxCollider2D>().enabled = false;
            }
            lastSize = transform.childCount;
        }
    }

    void MixMF()
    {
        for (int i = 0; i < mixAmount; i++)
        {
            transform.GetChild(i).SetSiblingIndex(Random.Range(0, PosList.childCount));
        }
    }
}
