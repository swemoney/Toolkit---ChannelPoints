using RimWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolkitCore.Interfaces;
using ToolkitCore.Windows;
using Verse;

namespace Toolkit___ChannelPoints
{
    public class AddonMenu : IAddonMenu
    {
        List<FloatMenuOption> IAddonMenu.MenuOptions() => new List<FloatMenuOption>
        {
            new FloatMenuOption("Settings", delegate ()
            {
                Window_ModSettings window = new Window_ModSettings(LoadedModManager.GetMod<ToolkitChannelPoints>());
                Find.WindowStack.TryRemove(window.GetType());
                Find.WindowStack.Add(window);
            }),
        };
    }
}