using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class ScreenFade : MonoBehaviour
{
    [SerializeField] private Image _image;
    // private float _alpha => _image.color.a;
     
    public void FadeIn()
    {
        _image.DOFade(1f, 1f).SetEase(Ease.OutCubic);
    }
    public void FadeOut()
    {
        _image.DOFade(0f, 1f).SetEase(Ease.InCubic);
    }
    async public void AutoFade()
    {
        FadeIn();
        await Task.Delay(1000);
        FadeOut();
        return;
    }
}
