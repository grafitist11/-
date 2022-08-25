﻿using Newtonsoft.Json;
using Oxide.Core;
using System;
using System.IO;
using System.Reflection;

namespace Oxide.Ext.NoSteam.Utils
{
    internal static class Config
    {

        internal static ConfigData configData;

        internal class ConfigData
        {
            public bool IsEnabledPublicDataBans { get; set; } = true;

            public int? AppId { get; set; } = 252490;

            [JsonProperty("FakePlayers(work only with 480 AppId)")]
            public FakePlayers fakePlayers { get; set; } = new FakePlayers();

            public string Version { get; set; }

            internal ConfigData()
            {
            }

            internal ConfigData(string version)
            {
                Version = version;
            }

            public class FakePlayers
            {
                public bool Enabled { get; set; } = false;
                public int MinCount { get; set; } = 0;

                public int MaxCount { get; set; } = 0;
            }
        }

        internal static void LoadConfig()
        {

            string path = Path.Combine(Interface.Oxide.ConfigDirectory, "NoSteam" + ".json");

            if (File.Exists(path) == false)
            {
                LoadDefaultConfig();
                return;
            }

            try
            {
                string text = File.ReadAllText(path);

                configData = JsonConvert.DeserializeObject<ConfigData>(text);
            }
            catch
            {

            }

            CheckConfig();
        }

        internal static void LoadDefaultConfig()
        {
            string path = Path.Combine(Interface.Oxide.ConfigDirectory, "NoSteam" + ".json");

            configData = new ConfigData(NoSteamExtension.Instance.Version.ToString());

            SaveConfig();
        }

        internal static void CheckConfig()
        {
            if (configData == null || configData.Version != NoSteamExtension.Instance.Version.ToString())
            {
                LoadDefaultConfig();
            }
        }

        internal static void SaveConfig()
        {
            string path = Path.Combine(Interface.Oxide.ConfigDirectory, "NoSteam" + ".json");

            string text = JsonConvert.SerializeObject(configData, Formatting.Indented);

            File.WriteAllText(path, text);
        }
    }
}