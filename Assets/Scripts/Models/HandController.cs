using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandController : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    public void SetAnimParametor(int id)
    {
        _animator.SetInteger("CurrentStateID", id);
    }
    public void StopAnimation()
    {
        _animator.SetFloat("Active", 1);
    }
    public void ResumeAnimation()
    {
        _animator.SetFloat("Active", 0);
    }
}
