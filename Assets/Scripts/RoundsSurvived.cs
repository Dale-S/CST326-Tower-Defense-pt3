using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class RoundsSurvived : MonoBehaviour
{
    public TextMeshProUGUI roundsText;

    private void OnEnable()
    {
        StartCoroutine(AnimateText());
    }

    IEnumerator AnimateText()
    {
        roundsText.text = "0";
        int round = 0;
        yield return new WaitForSeconds(1f);
        while (round < PlayerStats.Rounds)
        {
            round++;
            roundsText.text = round.ToString();
            yield return new WaitForSeconds(.09f);
        }
    }
}
