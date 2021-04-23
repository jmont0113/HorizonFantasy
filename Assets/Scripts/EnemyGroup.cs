using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyGroup : MonoBehaviour
{
    public EnemyEncounter encounter;
    public Transform spawnPoint;
    EnemySpawner enemySpawner;
    NavMeshAgent agent;

    float timer;
    [SerializeField] float maxTimer = 20f;

    [SerializeField]
    Transform boxPivot;
    [SerializeField]
    Vector3 boxHalfSize = Vector3.one;
    Transform target;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        enemySpawner = spawnPoint.GetComponent<EnemySpawner>();
    }

    private void Update()
    {
        CheckVision();

        if(target == null)
        {
            Wandering();
        }
        else
        {
            Chase();
        }
    }

    private void Chase()
    {
        agent.SetDestination(target.position);
    }

    void Wandering()
    {
        timer -= Time.deltaTime;
        if (timer < 0f)
        {
            timer = maxTimer * Random.value;
            SetDestination();
        }
    }

    void SetDestination()
    {
        Vector3 pos = spawnPoint.position;
        pos += Vector3.right * Random.Range(-enemySpawner.wanderingDistance, enemySpawner.wanderingDistance);
        pos += Vector3.forward * Random.Range(-enemySpawner.wanderingDistance, enemySpawner.wanderingDistance);
        agent.SetDestination(pos);
    }

    public void CheckVision()
    {
        target = null;
        Collider[] colliders = Physics.OverlapBox(boxPivot.position, boxHalfSize);
        foreach (Collider c in colliders)
        {
            Targetable targetable = c.GetComponent<Targetable>();
            if (targetable != null)
            {
                target = targetable.transform;
                break;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Party party = collision.gameObject.GetComponent<Party>();
        if(party != null)
        {
            GameManager.instance.combat.InitiateCombat(encounter, party);
            GameManager.instance.combat.SetEnemyGroup(gameObject);
        }
    }
}
