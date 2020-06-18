using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

public class AnalyticsController : MonoBehaviour
{

    void Start()
    {
        AnalyticsEvent.Custom("game_start", new Dictionary<string, object> { });
    }

    public void TorchLighted(int level, int torchID) {
        AnalyticsEvent.Custom("torch_lighted", new Dictionary<string, object>
        {
            { "level", level },
            { "torch_id", torchID },
            { "time_elapsed", Time.timeSinceLevelLoad }
        });
    }

    public void LevelComplete(int level) {
        AnalyticsEvent.Custom("level_complete", new Dictionary<string, object>
        {
            { "level", level },
            { "time_elapsed", Time.timeSinceLevelLoad }
        });
    }
}
