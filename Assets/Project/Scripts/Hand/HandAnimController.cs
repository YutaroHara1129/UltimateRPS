using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class HandAnimController : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    public void SetAnimInt(int id)
    {
        _animator.SetInteger("CurrentStateID",id);
    }
}
