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
}
