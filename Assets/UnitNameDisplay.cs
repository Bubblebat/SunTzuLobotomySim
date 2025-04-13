using TMPro;
using UnityEngine;

public class UnitNameDisplay : MonoBehaviour
{

    [SerializeField] UnitAction uAction;
    [SerializeField] TextMeshProUGUI text1;

    private void FixedUpdate()
    {
        text1.text = uAction.warriorName;
    }
}
