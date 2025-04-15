using TMPro;
using UnityEngine;

public class DisplayStats : MonoBehaviour
{
    [SerializeField] InspectUnit inspectUnit;
    [SerializeField] TextMeshProUGUI text1;

    private void Update()
    {
        if (inspectUnit.selectedObj != null)
        {
            text1.gameObject.SetActive(true);
            text1.text = CreateGragaString();
        }

        else
        {
            text1.gameObject.SetActive(false);
            text1.text = "";
        }
    }

    string CreateGragaString()
    {
        UnitAction uS = inspectUnit.selectedObj.GetComponent<UnitAction>();

        string garga = "Selected Unit: " + uS.warriorName 
            + "\nMove ( Up: " + uS.mDirProb[0] + ", Right: " + uS.mDirProb[1] + ", Down: " + uS.mDirProb[2] + ", Left: " + uS.mDirProb[3] + " )\n" 
            + "Health: " + uS.health 
            + "\nAttackDmg: " + uS.attackDmg 
            + "\nAttackChance: " + uS.attackProb 
            + "\nActionCD: " + uS.actionCooldown 
            + "\nSpeed: " + uS.moveStep 
            + "\nIntelligence: " + uS.inteligence;
        return garga;
    }
}
