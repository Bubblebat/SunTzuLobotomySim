using UnityEngine;

public class InspectUnit : MonoBehaviour
{
    [SerializeField] LayerMask mask;

    public GameObject selectedObj;

    private void Update()
    {
        float mPosX = Input.mousePosition.x;
        float mPosY = Input.mousePosition.y;
        Vector3 pos = Camera.main.ScreenToWorldPoint(new Vector3(mPosX, mPosY, 0));

        if (Input.GetMouseButtonDown(2))
        {
            RaycastHit2D hit = Physics2D.Raycast(pos, transform.forward, Mathf.Infinity, mask);

            if (hit.transform == null)
            {
                selectedObj = null;
            }

            else
            {
                selectedObj = hit.transform.gameObject;
            }
        }
    }
}
