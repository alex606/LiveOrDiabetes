using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FollowPath : MonoBehaviour
{
    public enum FollowType
    {
        MoveTowards,
        Lerp
    }

    public FollowType Type = FollowType.MoveTowards;
    public PathDefinition Path;
    public float Speed = 1;
    public float MaxDistanceToGoal = .1f;
    private IEnumerator<Transform> mCurrentPoint;

    public void Start()
    {
        if (Path == null)
        {
            Debug.LogError("Path cannot be null");
            return;
        }

        mCurrentPoint = Path.GetPathsEnumerator();
        mCurrentPoint.MoveNext();

        if (mCurrentPoint.Current == null)
        {
            return;
        }

        transform.position = mCurrentPoint.Current.position;
    }

    
    public void Update()
    {
        if (mCurrentPoint == null || mCurrentPoint.Current == null)
        {
            return;
        }

        if (Type == FollowType.MoveTowards)
        {
            transform.position = Vector3.MoveTowards(transform.position, mCurrentPoint.Current.position, Time.deltaTime * Speed);
        }
        else if (Type == FollowType.Lerp)
        {
            transform.position = Vector3.Lerp(transform.position, mCurrentPoint.Current.position, Time.deltaTime * Speed);
        }

        var distanceSquared = (transform.position - mCurrentPoint.Current.position).sqrMagnitude;

        if (distanceSquared < MaxDistanceToGoal * MaxDistanceToGoal)
        {
            mCurrentPoint.MoveNext();
        }
    }
}
