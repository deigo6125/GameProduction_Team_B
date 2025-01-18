using System.Collections.Generic;
using UnityEngine;

public class LineInstantiate : MonoBehaviour
{
    [SerializeField] LineRenderer lineRenderer;
    private Queue<Transform> points = new Queue<Transform>();

    private void Update()
    {
        ReflectLineRenderer();
    }

    //�������ʒu�̒ǉ�

    public void Add(Transform point)
    {
        points.Enqueue(point);
    }

    //�������ʒu�̍폜
    public void Remove()
    {
        points.Dequeue();
    }

    void ReflectLineRenderer()// LineRenderer�ɔ��f
    {
        int index = 0;
        lineRenderer.positionCount = points.Count;
        foreach (Transform point in points)
        {
            lineRenderer.SetPosition(index, point.position);
            index++;
        }
    }

    //public void LineSet(Transform transform)
    //{
    //    //    Transform newposition = transform;
    //    //    // �V�����_��ǉ�
    //    //    points.Enqueue(newposition);
    //    //if(points.Count > pointNumber)
    //    //{
    //    //    points.Dequeue();
    //    //}
    //    //    // LineRenderer�ɔ��f
    //    //    lineRenderer.positionCount = points.Count;
    //    //    int index = 0;
    //    //    foreach (Transform point in points)
    //    //    {
    //    //        lineRenderer.SetPosition(index, point.position);
    //    //        index++;
    //    //    }
        
    //}
}