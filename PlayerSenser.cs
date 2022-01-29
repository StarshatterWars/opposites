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
    public List<Transform> VisibleTargets = new List<Transform>();

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
        VisibleTargets.Clear();
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
                    VisibleTargets.Add(Target); // adds enemy to seen list
                }
            }
        }
         for (int i = 0; i < VisibleTargets.Count; i++) // looks through all found objects
        {
            //Debug.Log(VisibleTargets[i].name);
            if(VisibleTargets[i].tag == "Enemy Tag")
            {
                 VisibleTargets[i].gameObject.GetComponent<>().Insights(0.5f); // put in script youd like to access for that sepcific enemy
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
    
    
    
    
    //-----------------------------------------------------------------------------------------------------------
    //Add this to enemy script to detect it
    float CountDown;
    bool EnemyInPlayerView = false;
    void CheckIfInSight() // call this in an update funtion
    {
        if (EnemyInPlayerView)
        {
            if (CountDown > 0)
                CountDown -= 1 * Time.deltaTime;
            else
                OutOfSight();
        }
    }

    public void Insights(float Delay)
    {
        
        CountDown = Delay; // resets clock

        if (CountDown > 0 && !EnemyInPlayerView)
        {
            EnemyInPlayerView = true; // put in enemy script if this is true, the enemy can begin to chase/shoot at player
            //Debug.Log("Target In Sights");
        }
        
    }

    public void OutOfSight()
    {            
        EnemyInPlayerView = false;
        Debug.Log("Target has looked away");
        
    }
    
}
