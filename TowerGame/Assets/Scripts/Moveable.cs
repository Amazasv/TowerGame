using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moveable : MonoBehaviour
{
    public delegate void ArriveDelegate();
    public ArriveDelegate arriveDelegate;

    public enum Direction
    {
        up, down, left, right
    }

    public float MoveSpeed = 3f;
    public Vector3 targetPos = Vector3.zero;
    public Direction dir { get; private set; }
    public Direction dirHor { get; private set; }

    private void Awake()
    {
        targetPos = transform.position;
    }

    private void Start()
    {
        if (Vector2.Distance(targetPos, transform.position) <= 0.1f)
        {
            transform.position = targetPos;
            SendMessage("ArriveTargetReciver", SendMessageOptions.DontRequireReceiver);
        }
    }

    private void Update()
    {
        Vector3 dirVec = targetPos - transform.position;
        dirVec = new Vector3(dirVec.x, dirVec.y, 0.0f);
        if (dirVec.magnitude > 0.1f)
        {
            transform.Translate(dirVec.normalized * MoveSpeed * Time.deltaTime);
            dir = CalcDirection(dirVec);
            if (dir == Direction.left || dir == Direction.right) dirHor = dir;
            if (Vector2.Distance(targetPos, transform.position) <= 0.1f)
            {
                transform.position = targetPos;
                arriveDelegate?.Invoke();
                SendMessage("ArriveTargetReciver", SendMessageOptions.DontRequireReceiver);
            }
        }
    }

    public Direction CalcDirection(Vector2 dirVec)
    {
        float positiveX = Mathf.Abs(dirVec.x);
        float positiveY = Mathf.Abs(dirVec.y);
        Direction dir;
        if (positiveX > positiveY)
        {
            dir = (dirVec.x > 0) ? Direction.right : Direction.left;
        }
        else
        {
            dir = (dirVec.y > 0) ? Direction.up : Direction.down;
        }
        return dir;
    }
}

