using UnityEngine;

public class Activatecards : MonoBehaviour
{
    [SerializeField] LayerMask mask;

    private void Update()
    {
        float mPosX = Input.mousePosition.x;
        float mPosY = Input.mousePosition.y;
        Vector3 pos = Camera.main.ScreenToWorldPoint(new Vector3(mPosX, mPosY, 0));

        if (Input.GetMouseButtonDown(1))
        {
            RaycastHit2D hit = Physics2D.Raycast(pos, transform.forward, Mathf.Infinity, mask);

            if (hit && hit.transform.GetComponent<CardScript>().flippedUp)
            {
                if (hit.transform.GetComponent<CardScript>().isActive)
                {
                    hit.transform.GetComponent<CardScript>().isActive = false;
                }
                
                else
                {
                    hit.transform.GetComponent<CardScript>().isActive = true;
                }
            }
        }
    }
}
