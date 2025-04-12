using System.Collections;
using UnityEngine;

public class SortCards : MonoBehaviour
{
    [SerializeField] Transform PosList;

    int lastSize = 69420;

    private void Update()
    {
        if (lastSize > transform.childCount)
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
        }

        if (transform.childCount > 5)
        {
            for (int i = 5; i < transform.childCount; i++)
            {
                transform.GetChild(i).position = PosList.GetChild(5).position;
            }
            lastSize = transform.childCount;
        }
    }
}
