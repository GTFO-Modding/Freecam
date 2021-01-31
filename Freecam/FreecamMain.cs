using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BepInEx;
using BepInEx.IL2CPP;
using BepInEx.Logging;
using HarmonyLib;
using UnhollowerRuntimeLib;

namespace Freecam
{
    [BepInPlugin(GUID, MODNAME, VERSION)]
    public class FreecamMain : BasePlugin
    {
        public const string
            MODNAME = "CreativeMode",
            AUTHOR = "Dak",
            GUID = "com." + AUTHOR + "." + MODNAME,
            VERSION = "0.0.0";

        public static ManualLogSource log;

        public override void Load()
        {
            ClassInjector.RegisterTypeInIl2Cpp<FreecamManager>();
            Harmony harmonyPatches = new Harmony(GUID);
            harmonyPatches.PatchAll();
            log = Log;
        }
    }
}
