using System;
using System.Text;
using RimWorld;
using UnityEngine;
using Verse;

namespace Toolkit___ChannelPoints
{

    public static class Helper
    {
        public static void LogMessage(string message)
        {
            Verse.Log.Message("<color=#6441A4>[Toolkit ChannelPoints]</color> " + message);
        }

        public static void LogWarning(string message)
        {
            Verse.Log.Warning("<color=#7d6e00>[Toolkit ChannelPoints]</color> " + message);
        }

        public static void LogError(string message)
        {
            Verse.Log.Error("<color=#5c0900>[Toolkit ChannelPoints]</color> " + message);
        }

        public static void Log(string message)
        {
            LogMessage(message);
        }
    }

}