using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class GuardAI : MonoBehaviour
{

    public List<Transform> wayPoints;
    public bool coinTossed;
    public Vector3 coinPos; 
    private NavMeshAgent _agent;
    [SerializeField]
    private int _currentTarget;
    private bool _reverse;
    private bool _targetReached;

    private Animator _anim;
    
    // Start is called before the first frame update
    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(wayPoints.Count > 1 && wayPoints[_currentTarget] != null && coinTossed == false)
        {
            _agent.SetDestination(wayPoints[_currentTarget].position);
            float distance = Vector3.Distance(transform.position, wayPoints[_currentTarget].position);

            if(distance < 1.0f && _targetReached == false)
            {
                if(_currentTarget == 0 || _currentTarget == wayPoints.Count - 1)
                {
                    _targetReached = true;
                    StartCoroutine(WaitBeforeMoving());
                }
                else
                {
                    EnemyMoving();
                }
            }

        }
        else
        {
            float distance = Vector3.Distance(transform.position, coinPos);
            if(distance < 4.0f)
            {
                _anim.SetBool("Walk", false);
            }
        }
        
    }

    IEnumerator WaitBeforeMoving()
    {
        float wait = Random.Range(2.0f, 5.0f);
        _anim.SetBool("Walk", false);
        yield return new WaitForSeconds(wait);

        EnemyMoving();
        _targetReached = false;
    }

    private void EnemyMoving()
    {
        _anim.SetBool("Walk", true);
        if (_reverse)
        {
            _currentTarget--;
            if (_currentTarget == 0)
            {
                _reverse = false;
            }
        }
        else
        {
            _currentTarget++;
            if (_currentTarget == wayPoints.Count - 1)
            {
                _reverse = true;
            }
        }
    }

}
