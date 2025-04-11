using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.InputSystem;

public class SummonSoldier : MonoBehaviour
{
    public GameObject soldier;

    void Update()
    {
        float mPosX = Input.mousePosition.x;
        float mPosY = Input.mousePosition.y;
        Vector3 pos = Camera.main.ScreenToWorldPoint(new Vector3(mPosX, mPosY, 0));
        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(soldier, new Vector3(pos.x, pos.y), Quaternion.identity);
        }
    }
}
