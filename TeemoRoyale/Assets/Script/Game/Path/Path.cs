using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Path", menuName = "Path Data", order = 51)]
public class Path : ScriptableObject
{
    [SerializeField]
    Transform[] createPathVertexs;
    List<Vector2> path = new List<Vector2>();
    public int size
    {
        get
        {
            return path.Count;
        }
    }
    void OnEnable()
    {
        for(int i = 0; i < createPathVertexs.Length; i++)
            AddVertex(createPathVertexs[i].position);
        Debug.Log("작동하니?");
    }
    public void AddVertex(Vector2 pos)
    {
        path.Add(pos);
    }
    public int GetNearstPathIndex(Vector2 pos)  // 가장 가까운 길의 vertex 인덱스 반환
    {
        if(path.Count == 0)
            return -1;
        int nearstIndex = 0;
        float nearstCost = (pos - path[0]).sqrMagnitude;
        for(int i = 1; i < path.Count; i++)
        {
            float nowCost = (pos - path[i]).sqrMagnitude;
            if(nearstCost > nowCost)
            {
                nearstCost = nowCost;
                nearstIndex = i;
            }
        }
        return nearstIndex;
    }
    public Vector2? GetVertex(int index)
    {
        if(index < 0 || index >= path.Count)
            return null;
        return path[index];
    }
}