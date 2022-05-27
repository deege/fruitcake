using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Facing : MonoBehaviour
{

    [SerializeField] public Vector3 Direction { get; set; }   // down

    // Start is called before the first frame update
    void Start()
    {
        this.Direction = -Vector3.up;  // down
    }

    public void SetFacingByDirection(Vector3 facing)
    {

        bool xGreaterThanY = Mathf.Abs(facing.x) > Mathf.Abs(facing.y);
        bool goingLeft = facing.x < 0;
        bool goingRight = facing.x > 0;
        bool goingUp = facing.y > 0;
        bool goingDown = facing.y < 0;

        if (goingLeft && xGreaterThanY)
        {
            this.Direction = new Vector3(-1, 0, 0);
        }
        else if (goingRight && xGreaterThanY)
        {
            this.Direction = new Vector3(1, 0, 0);
        }
        else if (goingUp && !xGreaterThanY)
        {
            this.Direction = transform.up;
        }
        else if (goingDown && !xGreaterThanY)
        {
            this.Direction = -transform.up;
        }
        else
        {
            this.Direction = -transform.up; // default down
        }
    }
}
