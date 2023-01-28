using RPSBasic;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject _selectPhaseGroup;
    [SerializeField] private GameObject _battlePhaseGroup;
    [SerializeField] private GameObject _resultPhaseGroup;

    [SerializeField] private List<ButtonController> _buttonList = new List<ButtonController>();
    public void UpdateUI(Dictionary<handsign, int> _cardRemain)
    {
        foreach (KeyValuePair<handsign,int> kvp in _cardRemain)
        {
            _buttonList[(int)kvp.Key].TextMeshPro.text = kvp.Value.ToString();
            if(kvp.Value == 0)
            {
                _buttonList[(int)kvp.Key].Button.interactable = false;
            }
        }
    }

    public void ChangePhase(phase _phase)
    {
        switch (_phase)
        {
            case phase.select:
                _selectPhaseGroup.SetActive(true);
                _battlePhaseGroup.SetActive(false);
                _resultPhaseGroup.SetActive(false);
                break;
            case phase.battle:
                _selectPhaseGroup.SetActive(false);
                _battlePhaseGroup.SetActive(true);
                _resultPhaseGroup.SetActive(false);
                break;
            case phase.result:
                _selectPhaseGroup.SetActive(false);
                _battlePhaseGroup.SetActive(false);
                _resultPhaseGroup.SetActive(true);
                break;
        }
    }
}
