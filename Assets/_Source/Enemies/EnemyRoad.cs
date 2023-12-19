using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRoad : MonoBehaviour
{
    [SerializeField] private List<Vector2> _points;
    public List<Vector2> Points => _points;

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.gray;
        foreach (Vector2 v in _points)
        {
            Gizmos.DrawSphere(new Vector3(v.x, v.y, 0), 0.2f);
        }

        for (int i = 0; i < _points.Count - 1; i++)
        {
            Gizmos.DrawLine(_points[i], _points[i+1]);
        }
    }
}
