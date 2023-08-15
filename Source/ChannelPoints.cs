using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TwitchToolkit;
using ToolkitCore;
using Verse;

namespace Toolkit___ChannelPoints
{
    public static class ChannelPoints
    {
        public static void AwardCoinsToUser(string username, string coinsToAward)
        {
            string pointsName = ChannelPoints_Settings.ChannelPointsName;
            string message = $"@{username} Thanks for redeeming your {pointsName} for {coinsToAward} Twitch Toolkit coins!";

            Viewer viewer = Viewers.GetViewer(username);
            viewer.GiveViewerCoins(Convert.ToInt32(coinsToAward));

            if (ChannelPoints_Settings.ShowDebugMessages)
            {
                Helper.LogMessage($"{username} redeemed their {pointsName} for {coinsToAward} Toolkit coins");
            }

            ToolkitCore.TwitchWrapper.SendChatMessage(message);
        }
    }
}
