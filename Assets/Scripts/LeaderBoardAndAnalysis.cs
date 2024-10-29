using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LeaderBoardAndAnalysis : MonoBehaviour
{
    public Text killCountText;
    KillCountManager killCountManager;
    public int badges;
    public Text badgesText;

    public Text first5Secs;
    public Text first10Secs;
    public Text first15Secs;
    public Text first20Secs;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (KillCountManager.Instance != null)
        {
            killCountText.text = KillCountManager.Instance.killCount + " ";
            Achievements();
            Analysis();
        }
    }

    public void Achievements()
    {
        if(KillCountManager.Instance.killCount >= 5)
        {
            badgesText.text = "You got 1 Badge";
        }
        else if(KillCountManager.Instance.killCount >= 10)
        {
            badgesText.text = "You got 2 Badges";
        }
        else if (KillCountManager.Instance.killCount >= 15)
        {
            badgesText.text = "You got 3 Badges";
        }
        else
        {
            badgesText.text = "You got 0 Badge";
        }
    }

    public void Analysis()
    {

        first5Secs.text = "5secs : " + KillCountManager.Instance.firstKillsCount;
        first10Secs.text = "10secs : " + KillCountManager.Instance.secondKillsCount;
        first15Secs.text = "15sec : " + KillCountManager.Instance.thirdKillsCount;
        first20Secs.text = "20sec : " + KillCountManager.Instance.fourthKillsCount;
    }
}
