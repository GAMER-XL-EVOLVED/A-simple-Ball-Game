using UnityEngine;
using UnityEngine.UI;

public class BeatSystem : MonoBehaviour
{
    public float bpm = 120f;
    private float beatInterval;
    private float beatTimer;
    public float hitWindowSeconds = 0.1f;

    public int score = 0;

    public RectTransform beatCircle;
    public RectTransform targetCircle;
    public Text scoreText;

    private Vector2 startPosition;
    private Vector2 endPosition;

    void Start()
    {
        beatInterval = 60f / bpm;
        startPosition = beatCircle.anchoredPosition;
        endPosition = targetCircle.anchoredPosition;
        ResetBeatPosition();
        UpdateScoreDisplay();
    }

    void Update()
    {
        beatTimer += Time.deltaTime;

        // Move beat circle
        float progress = beatTimer / beatInterval;
        Vector2 newPosition = Vector2.Lerp(startPosition, endPosition, progress);
        beatCircle.anchoredPosition = newPosition;

        if (beatTimer >= beatInterval)
        {
            beatTimer -= beatInterval;
            ResetBeatPosition();
        }

        if (Input.GetKeyDown(KeyCode.B))
        {
            CheckBeatTiming();
        }
    }

    void ResetBeatPosition()
    {
        beatCircle.anchoredPosition = startPosition;
    }

    void CheckBeatTiming()
    {
        float timingSinceLastBeat = beatTimer % beatInterval;
        float closestBeat = Mathf.Min(timingSinceLastBeat, beatInterval - timingSinceLastBeat);

        if (closestBeat <= hitWindowSeconds)
        {
            score++;
            Debug.Log("Hit! Score: " + score);
        }
        else
        {
            Debug.Log("Miss!");
        }
        UpdateScoreDisplay();
    }

    void UpdateScoreDisplay()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score;
        }
    }
}