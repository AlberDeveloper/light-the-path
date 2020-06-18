using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

public class AnalyticsController : MonoBehaviour
{
    private int _level;

    public void setLevel(int level) {
        _level = level;
    }

    public void LevelStart()
    {
        AnalyticsEvent.LevelStart(_level);
    }

    public void TorchLighted(int torchID) {
        AnalyticsEvent.Custom("torch_lighted", new Dictionary<string, object>
        {
            { "level", _level },
            { "torch_id", torchID },
            { "time_elapsed", Time.timeSinceLevelLoad }
        });
    }

    public void LevelComplete() {
        AnalyticsEvent.LevelComplete(_level, new Dictionary<string, object>
        {
            { "time_elapsed", Time.timeSinceLevelLoad }
        });
    }
}
