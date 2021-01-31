using CellMenu;
using HarmonyLib;
using Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Freecam
{
    [HarmonyPatch(typeof(CM_PageIntro), "EXT_PressInject")]
    public static class InjectFreecam
    {
        public static void Postfix()
        {
            GameObject gameObject = new GameObject();
            gameObject.AddComponent<FreecamManager>();
            UnityEngine.Object.DontDestroyOnLoad(gameObject);
        }
    }
}