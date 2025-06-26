using UnityEngine;
using System.Collections;
using UnityEngine.Playables;

public class GameSymbol : MonoBehaviour
{
    public GameObject sprite2D;
    public PlayableDirector symbolTimeline;
    public float startDelay = 3f;
    public int x, y;
    

    public void SetCordinate(int x, int y)
    {
        this.x = x;
        this.y = y;
    }

    void Awake()
    {
        if (symbolTimeline == null)
            symbolTimeline = GetComponent<PlayableDirector>();
    }

    // This is for Visual representation of Animation in the game. Not for the Gameplay. 
    void Update()
    {
        StartCoroutine(PlayTimelineWithDelay());
    }

    public void PlaySymbolTimeline()
    {
        if (symbolTimeline != null)
            symbolTimeline.Play();
    }

    IEnumerator PlayTimelineWithDelay()
    {
        yield return new WaitForSeconds(startDelay);
        PlaySymbolTimeline();
    }


}
