using UnityEngine;
using System.Collections;

public class TileMover : MonoBehaviour
{
    private bool isMoving;
    private float moveTime;
    private Vector3 origin = Vector3.zero;
    private Vector3 target = Vector3.zero;
    private bool hasMoved = false;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (isMoving)
        {
            // Debug.Log(this + "; " + origin + "; " + target);
            moveTime += Time.deltaTime;
            transform.position = Vector3.Lerp(origin, target, 2 * moveTime);

            if (transform.position.Equals(target))
            {
                transform.position = target;
                this.moveTime = 0;
                this.origin = transform.position;
                this.target = Vector3.zero;
                this.isMoving = false;
                this.hasMoved = true;
            }
        }
    }

    internal void MoveTo(Vector3 target)
    {
        this.origin = transform.position;
        this.target = target;
        this.isMoving = true;
    }

    public bool IsMoving()
    {
        return isMoving;
    }

    public bool HasMoved()
    {
        return hasMoved;
    }
}
