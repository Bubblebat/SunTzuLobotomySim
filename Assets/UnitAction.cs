using System.Collections;
using Unity.VisualScripting;
using UnityEditor.Timeline;
using UnityEngine;

public class UnitAction : MonoBehaviour
{
    [Header("Don't touch!")]
    [SerializeField] Vector2 sceneSize;
    [SerializeField] float moveStep = 1;
    [SerializeField] GameObject attackCone;

    [Header("Probabilities")]
    public float[] mDirProb = new float[4];
    public float attackProb = 25;
    

    bool canMoveAction = true;
    bool canAttackAction = false;

    Vector3 moveDir = Vector3.zero;
    Vector3 moveStartPos = Vector3.zero;

    private void Update()
    {
        if (canMoveAction)
        {
            moveDir = RandomMoveAction();
            moveStartPos = transform.position;

            StartCoroutine(MoveActionCooldown());
            StartCoroutine(AttackActionCooldown());
        }
        
        if (canAttackAction)
        {
            RandomFightAction();
        }

        MoveUnit(moveDir);
    }

    Vector3 RandomMoveAction()
    {
        float rVal = Mathf.RoundToInt(Random.Range(0, mDirProb[0] + mDirProb[1] + mDirProb[2] + mDirProb[3]));

        if (rVal < mDirProb[0])
        {
            moveDir = new Vector3(0,1);
        }

        else if (rVal < mDirProb[0] + mDirProb[1])
        {
            moveDir = new Vector3(1, 0);
        }

        else if (rVal < mDirProb[0] + mDirProb[1] + mDirProb[2])
        {
            moveDir = new Vector3(0, -1);
        }

        else
        {
            moveDir = new Vector3(-1, 0);
        }

        return moveDir;
    }

    void RandomFightAction()
    {
        float zRot = 0;

        if (moveDir.y == 1)
        {
            zRot = 0;
        }

        else if (moveDir.x == 1)
        {
            zRot = -90;
        }

        else if (moveDir.y == -1)
        {
            zRot = -180;
        }

        else
        {
            zRot = -270;
        }

        if (Random.Range(0, 100) < attackProb)
        {
            GameObject tmp = Instantiate(attackCone, transform.position, Quaternion.Euler(new Vector3(0, 0, zRot)));
            Destroy(tmp, 0.2f);
        }
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
        yield return new WaitForSeconds(0.6f);
        canMoveAction = true;
    }

    IEnumerator AttackActionCooldown()
    {
        yield return new WaitForSeconds(0.5f);
        canAttackAction = true;
        yield return new WaitForNextFrameUnit();
        canAttackAction = false;
    }
}
