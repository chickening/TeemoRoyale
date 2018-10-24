using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class GameEntity : Entity    // BT에 의존
{    
    public Contoller contoller;
    public Team team
    {
        get;
        set;
    }//팀
    [SerializeField]
    float _hp;
    public float hp
    {
        private set { _hp = value; }
        get { return _hp; }
    }
    [SerializeField]
    float _maxHp;
    public float maxHp
    {
        get { return _maxHp; }
    }
    [SerializeField]
    float _damage;
    public float damage
    {
        get { return _damage; }
    }
    [SerializeField]
    float _speed;
    public float speed
    {
        get { return _speed; }
    }
    [SerializeField]
    float _attackDistance;
    public float attackDistance
    {
        get { return _attackDistance;}
    }
    /*
        API
    */
    bool isDie = false;
    new Rigidbody2D rigidbody;
    protected List<Vector2> waypointList = new List<Vector2>();       // 이동경로
    protected override void Update()
    {
        contoller.Tick();
    }
    protected override void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }
    public BTState Move()      // 엔티디 이동 함수
    {
        if(waypointList.Count == 0)
            return BTState.SUCCESS;

        Vector2 entityPos = transform.position;
        Vector2 moveDir = (waypointList[0] - entityPos).normalized;
        Vector2 nextPos;
        if((waypointList[0] - entityPos).sqrMagnitude <= Mathf.Pow(Time.deltaTime * speed, 2))
        {
            nextPos = waypointList[0];
            waypointList.RemoveAt(0);
        }
        else   
            nextPos = moveDir * Time.deltaTime * speed + entityPos;
        
        rigidbody.MovePosition(nextPos);
        return BTState.CONTINUE;
    }
    [SerializeField]
    float searchRadius;
    protected GameEntity target;
    public BTState SearchEnemy()
    {
        List<GameEntity> targets = GameData.field.FindEnemyGameEntityRadius(this, searchRadius);
        if(targets.Count == 0)
            return BTState.FAILURE;
        target = targets[0];
        return BTState.SUCCESS;
    }
    
    public BTState FindWayPoint()
    {

        if(waypointList.Count != 0)
        {
            return BTState.SUCCESS;
        }
        int nearstPathIndex = -1;
        float nearstPathCost = float.MaxValue;

        int teamIndex = (int)team;
        for(int i = 0; i < GameData.playerPath.Length; i++)
        {
            float nowCost = ((Vector2)GameData.player[teamIndex].availablePath[i].GetNearstPathVertex(transform.position) - (Vector2)transform.position).sqrMagnitude;
            if(nearstPathCost > nowCost)
            {
                nearstPathCost = nowCost;
                nearstPathIndex = i;
             }
        }
        if(nearstPathIndex == -1)
            return BTState.FAILURE;
        
        int startPathIndex = GameData.player[teamIndex].availablePath[nearstPathIndex].GetNearstPathIndex(transform.position);
        waypointList = GameData.player[teamIndex].availablePath[nearstPathIndex].SubPath(startPathIndex);

        if(team == Team.TEAM_PLAYER && transform.position.y > waypointList[0].y
            || team == Team.TEAM_ENEMY && transform.position.y < waypointList[0].y)
            waypointList.RemoveAt(0);
            
        for(int i = 0; i < waypointList.Count; i++)
        {
            waypointList[i] += new Vector2(Random.Range(0f,0.3f),Random.Range(0f,0.3f));    // 인간미
        }
        return BTState.SUCCESS;
    }
    public BTState WaypointToTarget()
    {
        if(target == null)
            return BTState.FAILURE;
        Vector2 orgPos = target.transform.position;
        Vector2 targetPos = target.transform.position;
        float distance = Mathf.Sqrt((orgPos - targetPos).sqrMagnitude);
        waypointList = new List<Vector2>();


        if(distance <= attackDistance)
            return BTState.SUCCESS;
        else
            waypointList.Add(Vector2.Lerp(orgPos, targetPos, (distance - attackDistance) / distance));
        return BTState.SUCCESS;
    }
    public void HitDamage(float damage)
    {
        /*
            나중에 Damage Indicator
         */
        hp = Mathf.Clamp(hp - damage, 0, maxHp);
        if(Mathf.Approximately(hp,0) && !isDie)
            Die();
    }
    public void Die()
    {
        isDie = true;
        GameData.field.Despawn(gameObject);
    }
    void OnEnable()
    {
        isDie = false;
        hp = maxHp;
    }   

}
