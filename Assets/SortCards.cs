using System.Collections;
using UnityEngine;

public class SortCards : MonoBehaviour
{
    [SerializeField] Transform PosList;

    bool sexyWow = true;

    private void Update()
    {
        if (sexyWow)
        {
            StartCoroutine(CrazyHamburger());
        }
    }

    IEnumerator CrazyHamburger()
    {
        sexyWow = false;

        for (int i = 0; i < 5; i++)
        {
            transform.GetChild(i).GetComponent<CardScript>().flippedUp = true;
            yield return new WaitForSeconds(0.2f);
            transform.GetChild(i).position = PosList.GetChild(i).position;
        }

        for (int i = 5; i < transform.childCount; i++)
        {
            transform.GetChild(i).position = PosList.GetChild(5).position;
        }

        sexyWow = true;
    }
}
