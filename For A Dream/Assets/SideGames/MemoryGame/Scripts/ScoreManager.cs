using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager
{
    private int score = 0;
    
    private TextMesh score_label;
    

    public ScoreManager(TextMesh score_label)
    {
        this.score_label = score_label;
        
    }

    public void Add()
    {
        score++;
        score_label.text = score.ToString();
        
    }

    

    public void Reset()
    {
        score = 0;
        score_label.text = score.ToString();
    }
}
