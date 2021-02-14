using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAt : MonoBehaviour
{
    /* Public Properties */
    public Vector3 Direction { get; set; }                                            // public property to indicate the direction this object is looking
    
    /* Serialized Private fields */
    [SerializeField] private ObjectToLookAt lookAt = ObjectToLookAt.GameObject;       // Enum to specify what the object will look at
    public GameObject Target = null;                                // Target only needs to be set if not looking at mouse (defaults to player)

    /* Determines what this object will look at */
    private enum ObjectToLookAt
    {
        Mouse,
        GameObject,
        None
    }

    private void Start()
    {
        InitializeVariables();
    }

    /* Depending on what the target is, orient object to "look at" that target -- Defaults to orient left */
    void Update()
    {
        if (!Target)
        {
            lookAt = ObjectToLookAt.GameObject;
        }
        
        switch (lookAt)
        {
            case ObjectToLookAt.Mouse:
                Direction = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
                break;
            
            case ObjectToLookAt.GameObject:
                if (!Target)
                {
                    Direction = Vector3.left;
                }
                else
                {
                    var enemy = Target.gameObject.GetComponent<Enemy>();
                    if (enemy)
                    {
                        Direction = enemy.aimPoint.transform.position - transform.position;
                    }
                }
                break;

            default:
                Direction = Vector3.left;
                break;
        }
        
        var angle = Mathf.Atan2(Direction.y, Direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    private void InitializeVariables()
    {
        // TODO delete if not used later on -- can be used to set a default target to lookat
    }
}