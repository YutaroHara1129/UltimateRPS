using RPSBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainPresenter : MonoBehaviour
{
    [SerializeField] private SystemManager _systemManager;
    [SerializeField] protected UIManager _uiManager;

    private void Start()
    {
        BasicObserver<Dictionary<handsign, int>> CardsRemainObserver = new BasicObserver<Dictionary<handsign, int>>();
        CardsRemainObserver.action = (value) => { _uiManager.UpdateUI(value); };

        _systemManager.CardsRemainSubject.Subscrive(CardsRemainObserver);
    }
}
