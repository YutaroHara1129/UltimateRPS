using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RPSBasic;
using UnityEngine.VFX;

public class HandController : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private SoundEffectController _soundEffectController;
    public handsign HandSign = handsign.rock;
    [SerializeField] private VisualEffect _visualEffect;
    public SkinnedMeshRenderer SkinnedMeshRenderer;

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
    public void PlaySE_Wind()
    {
        _soundEffectController.PlayAudioOneShot(3);
    }
    public void PlaySE_Signature()
    {
        switch (HandSign)
        {
            case handsign.rock:
                _soundEffectController.PlayAudioOneShot(0);
                break;
            case handsign.paper:
                _soundEffectController.PlayAudioOneShot(1);
                break;
            case handsign.scissors:
                _soundEffectController.PlayAudioOneShot(2);
                break;
        }
    }
    public void PlaySE_Impact()
    {
        _soundEffectController.PlayAudioOneShot(4);
    }
    public void DefeatVFX()
    {
        _visualEffect.Play();
    }
}
