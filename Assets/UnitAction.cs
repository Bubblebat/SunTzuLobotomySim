using System.Collections;
using UnityEngine;

public class UnitAction : MonoBehaviour
{
    [SerializeField] Vector2 sceneSize;

    [SerializeField] bool canMoveAction = true;

    [SerializeField] float[] mDirProb = new float[4];

    [SerializeField] float moveStep = 1;

    Vector3 moveDir = Vector3.zero;
    Vector3 moveStartPos = Vector3.zero;

    private void Update()
    {
        if (canMoveAction)
        {
            moveDir = RandomMoveAction();
            StartCoroutine(MoveActionCooldown());
            moveStartPos = transform.position;
        }

        MoveUnit(moveDir);
    }

    Vector3 RandomMoveAction()
    {
        float rVal = Mathf.RoundToInt(Random.Range(0, 4));

        if (rVal == 0)
        {
            moveDir = new Vector3(0,1);
        }

        else if (rVal == 1)
        {
            moveDir = new Vector3(1, 0);
        }

        else if (rVal == 2)
        {
            moveDir = new Vector3(0, -1);
        }

        else if (rVal == 3)
        {
            moveDir = new Vector3(-1, 0);
        }

        return moveDir;
    }

    void RandomFightAction()
    {

    }

    void MoveUnit(Vector3 translation)
    {
        Vector3 futurePos = transform.position + translation * moveStep * Time.deltaTime;

        if (futurePos.x < sceneSize.x && futurePos.x > -sceneSize.x)
        {
            if (futurePos.y < sceneSize.y && futurePos.y > -sceneSize.y)
            {
                transform.position = Vector3.MoveTowards(transform.position, moveStartPos + translation, moveStep * Time.deltaTime);
            }
        } 
    }

    IEnumerator MoveActionCooldown()
    {
        canMoveAction = false;
        yield return new WaitForSeconds(0.5f);
        canMoveAction = true;
    }
}
