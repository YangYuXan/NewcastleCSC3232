using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisionScan : MonoBehaviour
{

    public GameObject target;

    /// <summary>
    /// 视线范围-半径
    /// </summary>
    public float sightViewRadius = 5;

    /// <summary>
    /// 视线范围-欧拉角
    /// </summary>
    public float sightViewEuler = 120;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        DrawSemicircle(sightViewRadius, sightViewEuler, Color.yellow);
        CanSeeTarget();
    }

    /// <summary>
    /// 画扇形
    /// </summary>
    /// <param name="radius"></param>
    /// <param name="euler"></param>
    /// <param name="color"></param>
    private void DrawSemicircle(float radius, float euler, Color color)
    {
        int segments = 10;
        float deltaAngle = euler / segments;
        Vector3 forward = transform.forward;

        Vector3[] vertices = new Vector3[segments + 2];
        vertices[0] = transform.position;
        for (int i = 1; i < vertices.Length; i++)
        {
            Vector3 pos = Quaternion.Euler(0f, -euler / 2 + deltaAngle * (i - 1), 0f) * forward * radius + transform.position;
            vertices[i] = pos;
        }

        // 画圆弧
        for (int i = 1; i < vertices.Length - 1; i++)
        {
            UnityEngine.Debug.DrawLine(vertices[i], vertices[i + 1], color);
        }

        // 画两条边
        UnityEngine.Debug.DrawLine(vertices[0], vertices[vertices.Length - 1], color);
        UnityEngine.Debug.DrawLine(vertices[0], vertices[1], color);

    }

    public GameObject CanSeeTarget()
    {
        float distance = Vector3.Distance(transform.position, target.transform.position);

        Vector3 forward = transform.rotation * Vector3.forward;
        Vector3 dir = target.transform.position - transform.position;

        // 计算两个向量间的夹角，必须归一化normalized
        float angle = Mathf.Acos(Vector3.Dot(forward.normalized, dir.normalized)) * Mathf.Rad2Deg;

        if (distance < sightViewRadius)
        {
            if (angle <= sightViewEuler / 2)
            {
                //UnityEngine.Debug.Log("CanSeeTarget: "+target);
                return target;
            }
        }

        //UnityEngine.Debug.Log("CanSeeTarget: {false}");

        return null;

    }
}
