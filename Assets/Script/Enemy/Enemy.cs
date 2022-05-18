using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Rendering;

[RequireComponent(typeof(Rigidbody))]

public class Enemy : MonoBehaviour
{
    [SerializeField] private int _hp;
    [SerializeField] private int _damage;
    [SerializeField] private float _speed;
    [SerializeField] private ForceMode _forceMode;
    [SerializeField] private float _speedRotation;
    [SerializeField] private EnemyAnimator _animator;

    public UnityEvent Dead;
    public UnityEvent Run;
    public UnityEvent<Vector3> HitDamage;
    public UnityEvent SimpleAttack;
    public UnityEvent PowerAttack;
    
    private Rigidbody _rigitbody;
    private State _state;

    [SerializeField] public GameObject Target; //{ get; private set;}

    public void MoveToTarget()
    {
        Quaternion rotation = Quaternion.Lerp(_rigitbody.rotation, Quaternion.LookRotation(Target.transform.position),
            Time.deltaTime * _speedRotation);
        rotation = Quaternion.Euler(0,rotation.eulerAngles.y,0);
        _rigitbody.rotation = rotation;
        _rigitbody.AddForce(Vector3.Normalize(Target.transform.position - _rigitbody.transform.position) * Time.deltaTime * _speed * _rigitbody.mass,ForceMode.Force);
        _animator.AnimationSpeed = 1 - Mathf.Clamp(_rigitbody.velocity.magnitude, 0, 0.3f);
        _animator.Run(Mathf.Clamp(_rigitbody.velocity.magnitude,0,1f));
    }

    public void DoIdle()
    {
        _animator.Idle();
    }

    public void SetTarget(GameObject target)
    {
        Target = target;
    }
    
    public void SetState(State state)
    {
        _state = state;
    }

    public void Destroy()
    {
        Dead.Invoke();
        Destroy(gameObject);
    }

    private void Awake()
    {
        _state = new WalkState(this);
        _rigitbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if (_state != null)
        {
            _state.UpdateState();
        }
    }
}
