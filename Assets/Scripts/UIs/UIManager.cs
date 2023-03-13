using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using RPSBasic;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject _titlePhaseGroup;
    [SerializeField] private GameObject _selectPhaseGroup;
    [SerializeField] private GameObject _battlePhaseGroup;
    [SerializeField] private GameObject _resultPhaseGroup;
    public ScreenFade ScreenFade;

    // SelectPhase
    [SerializeField] private List<ButtonController> _buttonList = new List<ButtonController>();

    // ResultPhase
    [SerializeField] private List<TextMeshProUGUI> _tmpTextList = new List<TextMeshProUGUI>();
    [SerializeField] private Image _scoreImage;
    [SerializeField] private List<Sprite> _scoreSprites = new List<Sprite>();
    public void UpdateCardUI(Dictionary<handsign, int> _cardRemain)
    {
        foreach (KeyValuePair<handsign,int> kvp in _cardRemain)
        {
            _buttonList[(int)kvp.Key].TextMeshPro.text = kvp.Value.ToString();
            if(kvp.Value == 0)
            {
                _buttonList[(int)kvp.Key].Button.interactable = false;
            }
            else
            {
                _buttonList[(int)kvp.Key].Button.interactable = true;
            }
        }
    }
    public void UpdateResultBoard((Dictionary<result, int>,score) _results)
    {
        foreach (KeyValuePair<result, int> kvp in _results.Item1)
        {
            _tmpTextList[(int)kvp.Key].text = kvp.Value.ToString();
        }
        switch (_results.Item2) 
        {
            case score.s:
                _scoreImage.sprite = _scoreSprites[0];
                break;
            case score.a:
                _scoreImage.sprite = _scoreSprites[1];
                break;
            case score.b:
                _scoreImage.sprite = _scoreSprites[2];
                break;
            case score.c:
                _scoreImage.sprite = _scoreSprites[3];
                break;
        }
    }

    public void ChangePhase(phase _phase)
    {
        switch (_phase)
        {
            case phase.title:
                _titlePhaseGroup.SetActive(true);
                _selectPhaseGroup.SetActive(false);
                _battlePhaseGroup.SetActive(false);
                _resultPhaseGroup.SetActive(false);
                break;
            case phase.select:
                _titlePhaseGroup.SetActive(false);
                _selectPhaseGroup.SetActive(true);
                _battlePhaseGroup.SetActive(false);
                _resultPhaseGroup.SetActive(false);
                break;
            case phase.battle:
                _titlePhaseGroup.SetActive(false);
                _selectPhaseGroup.SetActive(false);
                _battlePhaseGroup.SetActive(true);
                _resultPhaseGroup.SetActive(false);
                break;
            case phase.result:
                _titlePhaseGroup.SetActive(false);
                _selectPhaseGroup.SetActive(false);
                _battlePhaseGroup.SetActive(false);
                _resultPhaseGroup.SetActive(true);
                break;
        }
    }
}
