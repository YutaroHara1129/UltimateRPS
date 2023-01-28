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
        // Transfer of phase information
        BasicObserver<phase> PhaseObserver = new BasicObserver<phase>();
        PhaseObserver.action = (value) => { _uiManager.ChangePhase(value); };
        _systemManager.PhaseSubject.Subscrive(PhaseObserver);

        // Transfer of remaining card count information
        BasicObserver<Dictionary<handsign, int>> CardsRemainObserver = new BasicObserver<Dictionary<handsign, int>>();
        CardsRemainObserver.action = (value) => { _uiManager.UpdateUI(value); };
        _systemManager.CardsRemainSubject.Subscrive(CardsRemainObserver);
    }
}
