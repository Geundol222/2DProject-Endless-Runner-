using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreBoardView : MonoBehaviour
{
    [SerializeField] private TMP_Text curText;
    [SerializeField] private TMP_Text bestText;

    private void OnEnable()
    {
        curText.text = GameManager.Data.CurScore.ToString();
        bestText.text = GameManager.Data.BestScore.ToString();
    }
}
