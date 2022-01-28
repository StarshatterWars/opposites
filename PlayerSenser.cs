using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSenser : MonoBehaviour
{
    public float ViewRadius;
    [Range(0, 360)] public float ViewAngle;

    public LayerMask TargetMask;
    public LayerMask ObsticaleMask;

    [HideInInspector]
    public List<Transform> visibleTargets = new List<Transform>();

    void Start()
    {
        StartCoroutine("FindTargetsWithDelay", .2f);
    }

    IEnumerator FindTargetsWithDelay(float delay)
    {
        while (true)
        {
            yield return new WaitForSeconds(delay);
            FindVisibleTargets();
        }
    }

    void FindVisibleTargets()
    {
        //Collider[] TargetsInViewRadius = Physics.OverlapSphere(transform.position, ViewRadius, TargetMask);

        Collider2D[] TargetsInViewRadius = Physics2D.OverlapCircleAll(transform.position, ViewRadius, TargetMask);

        for (int i = 0; i < TargetsInViewRadius.Length; i++)
        {
            Transform Target = TargetsInViewRadius[i].transform;
            Vector2 DirectionToTarget = (Target.position - transform.position).normalized;
            if (Vector2.Angle(transform.forward, DirectionToTarget) < ViewAngle / 2)
            {
                float DistanceToTarget = Vector2.Distance(transform.position, Target.position);
                if (!Physics.Raycast(transform.position, DirectionToTarget, DistanceToTarget, ObsticaleMask))
                {
                    visibleTargets.Add(Target);
                }
            }
        }
    }

    public Vector3 DirFromAngle(float angleInDegrees, bool angleIsGlobal)
    {
        if (!angleIsGlobal)
        {
            angleInDegrees += transform.eulerAngles.y;
        }
        return new Vector2(Mathf.Sin(angleInDegrees * Mathf.Deg2Rad),  Mathf.Cos(angleInDegrees * Mathf.Deg2Rad));

    }
}
