using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TwitchToolkit.Settings;
using TwitchToolkit.Windows;
using UnityEngine;
using Verse;

namespace Toolkit___ChannelPoints
{
    public class ChannelPoints_RewardSettings : IExposable
    {
        public string RewardName = "";
        public string RewardUUID = "";
        public string CoinsToAward = "300";
        public bool AutomaticallyCaptureUUID = false;
        public bool Enabled = true;

        public ChannelPoints_RewardSettings() 
        {
            RewardName = "";
            RewardUUID = "";
            CoinsToAward = "300";
            AutomaticallyCaptureUUID = false;
            Enabled = true;
        }

        public ChannelPoints_RewardSettings(string rewardName, string rewardUUID, string coinsToAward, bool autoCapture = false, bool enabled = true)
        {
            RewardName = rewardName;
            RewardUUID = rewardUUID;
            CoinsToAward = coinsToAward;
            AutomaticallyCaptureUUID = autoCapture;
            Enabled = enabled;
        }

        public void ExposeData()
        {
            Scribe_Values.Look(ref RewardName, "RewardName", "");
            Scribe_Values.Look(ref RewardUUID, "RewardUUID", "");
            Scribe_Values.Look(ref CoinsToAward, "CoinsToAward", "300");
            Scribe_Values.Look(ref AutomaticallyCaptureUUID, "AutomaticallyCaptureUUID", false);
            Scribe_Values.Look(ref Enabled, "RewardEnabled", true);
        }
    }
}