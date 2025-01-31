using UnityEngine;

public enum GizmoType
{
    Cube,
    Sphere
}

public class EffectGizmo : MonoBehaviour
{
    [Header("Gizmo Settings")]
    public Color32 gizmoColor = Color.white;
    public GizmoType gizmoType = GizmoType.Cube;
    public float radius = 1f;
    public Vector3 size = Vector3.one;

    private Vector3 pivotOffset = Vector3.zero;

    public virtual void OnDrawGizmos()
    {
        Gizmos.color = gizmoColor;

        switch (gizmoType)
        {
            case GizmoType.Cube:
                pivotOffset.y = -size.y / 2;
                Gizmos.DrawWireCube(transform.position - pivotOffset, size);
               
                    Gizmos.DrawCube(transform.position , size);
                break;

            case GizmoType.Sphere:
                Gizmos.DrawWireSphere(transform.position - pivotOffset, radius);
                break;

            default:
                Debug.LogWarning($"GizmoType '{gizmoType}' n�o � suportado.");
                break;
        }
    }

    private void OnValidate()
    {
        radius = Mathf.Max(0, radius);
        size = new Vector3(
            Mathf.Max(0, size.x),
            Mathf.Max(0, size.y),
            Mathf.Max(0, size.z)
        );
    }
}
