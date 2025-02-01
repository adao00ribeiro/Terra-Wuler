using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class RaycastObject : MonoBehaviour
{      public enum RaycastType { Sphere, Line }
    public RaycastType raycastType = RaycastType.Line;
    public GameObject CollisionObject;
    public float MaxDistance = 3f;
    public float SphereRadius = 0.5f;
    public float GroundedOffset;
    public LayerMask Layers;
    public Vector3 spherePosition;
    public Vector3 RaycastDirection = Vector3.down;
    public bool AdjustRayLength = false;
    public bool UseGlobalRaycast = false;
    private float currentRayDistance;

    void Update()
    {
        RaycastHit hit;
        spherePosition = new Vector3(transform.position.x, transform.position.y - GroundedOffset, transform.position.z);
        
        PhysicsScene physicsScene = gameObject.scene.GetPhysicsScene();
        bool hitDetected = false;
        currentRayDistance = MaxDistance;

        Vector3 direction = UseGlobalRaycast ? RaycastDirection : transform.TransformDirection(RaycastDirection);

        if (raycastType == RaycastType.Sphere)
        {
            hitDetected = physicsScene.SphereCast(spherePosition, SphereRadius, direction, out hit, MaxDistance, Layers, QueryTriggerInteraction.UseGlobal);
        }
        else // Line Raycast
        {
            hitDetected = physicsScene.Raycast(spherePosition, direction, out hit, currentRayDistance, Layers);
        }

        if (hitDetected)
        {
            CollisionObject = hit.collider.gameObject;
            if (AdjustRayLength)
            {
                currentRayDistance = hit.distance; // Ajusta o raio para não ultrapassar o objeto
            }
        }
        else
        {
            CollisionObject = null;
        }
    }

    public bool IsGrounded => CollisionObject != null;

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Vector3 direction = UseGlobalRaycast ? RaycastDirection : transform.TransformDirection(RaycastDirection);
        
        if (raycastType == RaycastType.Sphere)
        {
            Gizmos.DrawLine(spherePosition, spherePosition + direction * currentRayDistance);
            Gizmos.DrawWireSphere(spherePosition + direction * currentRayDistance, SphereRadius);
        }
        else
        {
            Gizmos.DrawLine(spherePosition, spherePosition + direction * currentRayDistance);
        }
    }
}
