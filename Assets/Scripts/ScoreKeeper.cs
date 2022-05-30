using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    [SerializeField] int score = 0;

    public int GetScore() {
        return this.score;
    }

    public void ResetScore() {
        this.score = 0;
    }

    public void AddScore(int add) {
        this.score += add;
        Mathf.Clamp(this.score, 0, int.MaxValue);
    }
}
