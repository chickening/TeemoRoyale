using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Path", menuName = "Path Data", order = 51)]
public class Path : ScriptableObject
{
    [SerializeField]
    Transform[] createPathVertexs;
    List<Vector2> path;
    public int size
    {
        get
        {
            return path.Count;
        }
    }
    void OnEnable()
    {
        path = new List<Vector2>();
        for(int i = 0; i < createPathVertexs.Length; i++)
        {
            
            AddVertex(createPathVertexs[i].position);
        }
        
    }
    public void AddVertex(Vector2 pos)
    {
        path.Add(pos);
    }
    public int GetNearstPathIndex(Vector2 pos)  // 가장 가까운 길의 vertex 인덱스 반환
    {
        int nearstIndex = -1;
        float nearstCost = float.MaxValue;
        for(int i = 0; i < path.Count; i++)
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
    public Vector2? GetNearstPathVertex(Vector2 pos)
    {

        int index = GetNearstPathIndex(pos);
        if(index == -1)
            return null;
        return GetVertex(index);
    }
    public List<Vector2> SubPath(int startIndex)
    {
        if(startIndex < 0 || startIndex >= path.Count)
        {
            return null;
        }
        return path.GetRange(startIndex, path.Count - startIndex);
    }
}