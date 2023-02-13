using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using RPSBasic;
using UnityEngine;

public class HandGroupController : MonoBehaviour, IDisposable
{
    [SerializeField] private HandController _ownHandController;
    [SerializeField] private HandController _opponentHandController;

    // Token
    private CancellationTokenSource _cancellationTokenSource =
        new CancellationTokenSource();
    private CancellationToken _token;

    public result Result;

    public void PlaySE_Wind()
    {
        _ownHandController.PlaySE_Wind();
        _opponentHandController.PlaySE_Wind();
    }
    public void PlaySE_Signature()
    {
        _ownHandController.PlaySE_Signature();
        _opponentHandController.PlaySE_Signature();
    }
    public void PlayVFX_Defeat()
    {
        if (_token.CanBeCanceled) Dispose();
        _cancellationTokenSource = new CancellationTokenSource();
        _token = _cancellationTokenSource.Token;
        _ = PlayVFX_Defeat_Async(_token);
    }
    private async Task PlayVFX_Defeat_Async(CancellationToken token)
    {
        switch (Result)
        {
            case result.win:
                _opponentHandController.DefeatVFX();
                _opponentHandController.PlaySE_Impact();
                await Task.Delay(100);
                _opponentHandController.SkinnedMeshRenderer.enabled = false;
                await Task.Delay(1250);
                _opponentHandController.SkinnedMeshRenderer.enabled = true;
                break;
            case result.lose:
                _ownHandController.DefeatVFX();
                _ownHandController.PlaySE_Impact();
                await Task.Delay(100);
                _ownHandController.SkinnedMeshRenderer.enabled = false;
                await Task.Delay(1250);
                _ownHandController.SkinnedMeshRenderer.enabled = true;
                break;
        }
    }
    public void Dispose()
    {
        _cancellationTokenSource.Cancel();
        _cancellationTokenSource.Dispose();
    }
}
