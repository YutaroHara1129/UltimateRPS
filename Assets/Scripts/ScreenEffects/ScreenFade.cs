using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class ScreenFade : MonoBehaviour, IDisposable
{
    // Token
    private CancellationTokenSource _cancellationTokenSource =
        new CancellationTokenSource();
    private CancellationToken _token;

    [SerializeField] private Image _image;
    // private float _alpha => _image.color.a;
     
    void FadeIn()
    {
        _image.DOFade(1f, 1f).SetEase(Ease.OutCubic);
    }
    void FadeOut()
    {
        _image.DOFade(0f, 1f).SetEase(Ease.InCubic);
    }
    public void AutoFade(int ms = 0)
    {
        if (_token.CanBeCanceled) Dispose();
        _cancellationTokenSource = new CancellationTokenSource();
        _token = _cancellationTokenSource.Token;
        _ = AutoFadeAsync(_token,ms);
    }
    async public Task AutoFadeAsync(CancellationToken token, int ms)
    {
        FadeIn();
        await Task.Delay(1000 + ms,token);
        FadeOut();
        return;
    }

    public void Dispose()
    {
        _cancellationTokenSource.Cancel();
        _cancellationTokenSource.Dispose();
    }
}
