using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RPSBasic;

public class MainPresenter : MonoBehaviour
{
    [SerializeField] private SystemManager _systemManager;
    [SerializeField] protected UIManager _uiManager;
    [SerializeField] private SoundEffectController _SystemSEController;

    private void Start()
    {
        // Transfer of phase information
        BasicObserver<phase> PhaseObserver = new BasicObserver<phase>();
        PhaseObserver.action = (value) => { _uiManager.ChangePhase(value); };
        _systemManager.PhaseSubject.Subscrive(PhaseObserver);

        // Transfer of remaining card count information
        BasicObserver<Dictionary<handsign, int>> CardsRemainObserver = new BasicObserver<Dictionary<handsign, int>>();
        CardsRemainObserver.action = (value) => { _uiManager.UpdateCardUI(value); };
        _systemManager.CardsRemainSubject.Subscrive(CardsRemainObserver);

        // Transfer of results information
        BasicObserver<(Dictionary<result, int>,score)> ResultsObserver = new BasicObserver<(Dictionary<result, int>, score)>();
        ResultsObserver.action = (value) => { _uiManager.UpdateResultBoard(value); };
        _systemManager.ResultsSubject.Subscrive(ResultsObserver);

        // Transfer of effect activation request
        BasicObserver EffectRequestObserver = new BasicObserver();
        EffectRequestObserver.action = () => { _uiManager.ScreenFade.AutoFade(); };
        _systemManager.EffectRequestSubject.Subscrive(EffectRequestObserver);

        // Transfer of system SE request
        BasicObserver<int> SystemSERequestObserver = new BasicObserver<int>();
        SystemSERequestObserver.action = (value) => { _SystemSEController.PlayAudioOneShot(value); };
        _systemManager.SystemSERequestSubject.Subscrive(SystemSERequestObserver);
    }
}
