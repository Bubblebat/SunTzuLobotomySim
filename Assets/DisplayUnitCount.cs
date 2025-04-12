using TMPro;
using UnityEngine;

public class DisplayUnitCount : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI text1;

    private void FixedUpdate()
    {
        text1.text = ": " + GameObject.FindGameObjectsWithTag("U").Length;
    }
}
