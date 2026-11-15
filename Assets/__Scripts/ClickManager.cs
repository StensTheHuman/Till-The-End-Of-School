using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SocialPlatforms.Impl;
using static Unity.Collections.AllocatorManager;

public class ClickManager : MonoBehaviour
{
    [Header("Set in Inspector")]
    [SerializeField] private float scoreGain = 1f;
    [SerializeField] private TextMeshProUGUI text;

    private float totalScore = 0f;

    public static ClickManager CM;

    void Awake()
    {
        CM = this;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        text.text = "Нарешено: " + Mathf.Floor(score);
    }

    public void ScoreGain()
    {
        score += scoreGain;
    }

    public float score
    {
        get
        {
            return totalScore;
        }

        set
        {
            totalScore = value;
        }
    }

    public float scoreGainer
    {
        get
        {
            return scoreGain;
        }

        set
        {
            scoreGain = value;
        }
    }
}
