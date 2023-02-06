using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using RPSBasic;
using Cinemachine;

public class SystemManager : MonoBehaviour
{
    private phase _phase;
    private handsign _ownHandSign;
    private handsign _opponentHandSign;
    private Dictionary<handsign, int> _cardsRemain = new Dictionary<handsign, int>();
    private Dictionary<handsign, int> _opponentCardsRemain = new Dictionary<handsign, int>();
    private List<handsign> _opponentCardsList = new List<handsign>();

    [SerializeField] private List<int> _numberOfCards = new List<int>(){3,3,3};
    private Dictionary<result, int> _results = new Dictionary<result, int>() 
    { { result.win, 0 }, { result.draw, 0 }, { result.lose, 0 } };
    private int _resultParameter => _results[result.win] + _results[result.draw] + _results[result.lose];

    // An error will occur if you don't assign it in the inspector
    [SerializeField] private List<CinemachineVirtualCamera> _vCamList;
    [SerializeField] private HandController _opponentHandController;
    [SerializeField] private PlayableDirector _playableDirector;

    // Subjects
    public BasicSubject<phase> PhaseSubject = new BasicSubject<phase>();
    public BasicSubject<Dictionary<handsign, int>> CardsRemainSubject = new BasicSubject<Dictionary<handsign, int>>();
    public BasicSubject<(Dictionary<result, int>,score)> ResultsSubject = new BasicSubject<(Dictionary<result, int>, score)>();

    private void Start()
    {
        GameInitialize();
    }

    public void GameInitialize()
    {
        _cardsRemain[handsign.rock] = _numberOfCards[0];
        _cardsRemain[handsign.paper] = _numberOfCards[1];
        _cardsRemain[handsign.scissors] = _numberOfCards[2];

        _opponentCardsRemain[handsign.rock] = _numberOfCards[0];
        _opponentCardsRemain[handsign.paper] = _numberOfCards[1];
        _opponentCardsRemain[handsign.scissors] = _numberOfCards[2];

        _opponentCardsList.Clear();
        _opponentCardsList.Add(handsign.rock);
        _opponentCardsList.Add(handsign.paper);
        _opponentCardsList.Add(handsign.scissors);

        _results[result.win] = 0;
        _results[result.draw] = 0;
        _results[result.lose] = 0;

        CardsRemainSubject.SendMessage(_cardsRemain);
    }

    public void OnTimelineEnd()
    {
        var IsRemain = false;
        foreach(KeyValuePair<handsign,int> kvp in _cardsRemain)
        {
            if (kvp.Value != 0)
            {
                SelectPhase();
                IsRemain = true;
                break;
            }
        }
        if (IsRemain) return;
        ResultPhase();
    }
    void BattlePhase()
    {
        PhaseSubject.SendMessage(phase.battle);
        _playableDirector.Play();

        switch (_opponentHandSign)
        {
            case handsign.rock:
                _opponentHandController.SetAnimParametor(0);
                break;
            case handsign.paper:
                _opponentHandController.SetAnimParametor(1);
                break;
            case handsign.scissors:
                _opponentHandController.SetAnimParametor(2);
                break;
        }
    }

    public void SelectPhase()
    {
        PhaseSubject.SendMessage(phase.select);
    }
    public void ResultPhase()
    {
        ResultsSubject.SendMessage((_results , EvaluateScore()));
        PhaseSubject.SendMessage(phase.result);
    }

    public void SignChoosed(int choosedSignID)
    {
        _ownHandSign = (handsign)System.Enum.ToObject(typeof(handsign), choosedSignID);
        _opponentHandSign = ChooseOpponentSign();

        _cardsRemain[_ownHandSign]--;
        CardsRemainSubject.SendMessage(_cardsRemain);
        int resultID = JankenJadge(choosedSignID, (int)_opponentHandSign);

        switch (resultID)
        {
            case (0):
                _results[result.draw]++;
                break;
            case (1):
                _results[result.win]++;
                break;
            case (2):
                _results[result.lose]++;
                break;
            default:
                Debug.LogWarning("resultID is an invalid value. | value : " + resultID);
                break;
        }
        BattlePhase();
    }
    handsign ChooseOpponentSign()
    {
        System.Random random = new System.Random();
        var i = random.Next(_opponentCardsList.Count);
        var sign = _opponentCardsList[i];

        _opponentCardsRemain[sign]--;
        if (_opponentCardsRemain[sign] == 0) _opponentCardsList.Remove(sign);

        return sign;
    }
    int JankenJadge(int own, int opponent)
    {
        // ジャンケンのアルゴリズム
        return (own - opponent + 3) % 3;
    }
    score EvaluateScore()
    {
        float _points; //[0,1]
        _points = (_results[result.win] / _resultParameter) + (_results[result.draw] / (2 * _resultParameter));
        return (_points < 1f / 3f) ? score.c : (_points < 2f / 3f) ? score.b : (_points < 1f) ? score.a : score.s;
    }
}
