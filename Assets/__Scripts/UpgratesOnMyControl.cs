using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SocialPlatforms.Impl;
using Unity.Mathematics;

public class UpgratesOnMyControl : MonoBehaviour
{
    [Header("Set in Inspector")]
    [SerializeField] private float MPUp = 0.1f;
    [SerializeField] private List<Button> buttons = new List<Button>();
    [SerializeField] private List<Upgrates> upgrateInfo = new List<Upgrates>();
    private List<float> count = new List<float>();
    private List<float> costs = new List<float>();
    private List<float> scoreMP = new List<float>();

    void Awake()
    {
        if (buttons != null)
        {
            for (int i = 0; i < buttons.Count; i++)
            {
                costs.Add(upgrateInfo[i].cost);

                scoreMP.Add(upgrateInfo[i].scoreMultiplayer);

                count.Add(0);

                buttons[i].transform.GetChild(0).GetComponent<TMP_Text>().text = "Название: " + upgrateInfo[i].name;

                buttons[i].transform.GetChild(1).GetComponent<TMP_Text>().text = "Описание: " + upgrateInfo[i].description;

                buttons[i].transform.GetChild(2).GetComponent<TMP_Text>().text = "Цена: " + upgrateInfo[i].cost;

                buttons[i].transform.GetChild(3).GetComponent<TMP_Text>().text = "Решения: +" + upgrateInfo[i].scoreMultiplayer;

                buttons[i].GetComponent<Image>().sprite = upgrateInfo[i].icon;
            }
        }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BuyUpdate(int Index)
    {
        int trueI = Index - 1;

        if (costs[trueI] > ClickManager.CM.score)
        {
            return;
        }

        ClickManager.CM.score -= costs[trueI];

        count[trueI]++;

        ClickManager.CM.scoreGainer += scoreMP[trueI];

        costs[trueI] += count[trueI] * Mathf.Clamp(Mathf.Ceil(count[trueI] / 5), 1, Mathf.Infinity);
        buttons[trueI].transform.GetChild(2).GetComponent<TMP_Text>().text = "Цена: " + costs[trueI];

        scoreMP[trueI] += count[trueI] * (MPUp * Index) * (upgrateInfo[trueI].scoreMultiplayer / 2);
        buttons[trueI].transform.GetChild(3).GetComponent<TMP_Text>().text = "Решения: +" + scoreMP[trueI];
    }
}
