using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using UnityEngine;

public class InspectUnitMouseLess : MonoBehaviour
{
    [SerializeField] InspectUnit inspectUnit;
    List<GameObject> warriors = new List<GameObject>();

    bool isActive = false;
    int n = 0;

    private void Update()
    {
        for (int i = 0; i < GameObject.FindGameObjectsWithTag("U").Length; ++i)
        {
            warriors.Add(GameObject.FindGameObjectsWithTag("U")[i]);
        }

        if (warriors.Count > 0)
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                if (!isActive)
                {
                    inspectUnit.selectedObj = warriors[0];
                    isActive = true;
                }

                else
                {
                    inspectUnit.selectedObj = null;
                    isActive = false;
                }
            }

            if (isActive)
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    n++;
                    if (n >= warriors.Count)
                    {
                        n = 0;
                    }
                    inspectUnit.selectedObj = warriors[n];
                }

                else if (Input.GetKeyDown(KeyCode.Q))
                {
                    n--;
                    if (n < 0)
                    {
                        n = warriors.Count - 1;
                    }
                    inspectUnit.selectedObj = warriors[n];
                }
            }
        }
        
        warriors.Clear();
    }
}
