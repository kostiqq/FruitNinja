using System.Collections;
using TMPro;
using UnityEngine;

public class ScoreText : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI tmpText;
    [SerializeField] private string textExtension;
    [SerializeField] private float animationSpeed;

    private int _currentScore;
    private int _previousScore;
    
    private Coroutine _animation;

    public void Initialize(int score)
    {
        UpdateText(score);
    }
    
    public void SetScore(int value)
    {
        _currentScore = value;

        _animation ??= StartCoroutine(UpdateAnimation(_currentScore));
    }
    
    private IEnumerator UpdateAnimation(int newValue)
    {
        float time = 0f;

        float tempScore = 0;
        while (tempScore < newValue)
        {
            time += Time.deltaTime;

            tempScore = Mathf.Lerp(_previousScore, _currentScore, time / animationSpeed);

            UpdateText((int)tempScore);

            yield return null;
        }

        _previousScore = _currentScore;
        _animation = null;
    }

    private void UpdateText(int tempScore)=>
        tmpText.text = textExtension + tempScore;
}
