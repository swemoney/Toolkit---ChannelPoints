using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TwitchToolkit;
using Verse;

namespace Toolkit___ChannelPoints
{
    public static class ChannelPoints
    {
        public static void AwardCoinsToUser(string username)
        {
            string pointsName = ChannelPoints_Settings.ChannelPointsName;
            int coinsToAward = ChannelPoints_Settings.CoinsToAward;
            string message = $"@{username} Thanks for redeeming your {pointsName} for {coinsToAward} Twitch Toolkit coins!";

            Viewer viewer = Viewers.GetViewer(username);
            viewer.GiveViewerCoins(coinsToAward);

            if (ChannelPoints_Settings.ShowDebugMessages)
            {
                Log.Message($"{username} redeemed their {pointsName} for {coinsToAward} Toolkit coins");
            }

            Toolkit.client.SendMessage(message, true);
        }
    }
}
