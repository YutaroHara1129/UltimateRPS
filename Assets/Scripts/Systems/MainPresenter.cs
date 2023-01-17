using RPSBasic;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainPresenter : MonoBehaviour
{
    [SerializeField] private SystemManager _systemManager;
    [SerializeField] protected UIManager _uiManager;

    private void Start()
    {
        
    }
    public class BasicObserver : IBasicObserver<Dictionary<handsign, int>>
    {
        public void OnRecieved(Dictionary<handsign, int> value)
        {
            _uiManager.UpdateUI(value);
        }
    }
}
