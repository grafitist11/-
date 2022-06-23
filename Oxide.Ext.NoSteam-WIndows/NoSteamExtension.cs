﻿// Author:  Kaidoz
// Filename: NoSteamExtension.cs
// Last update: 2019.10.06 20:41

using Oxide.Core;
using Oxide.Core.Extensions;

namespace Oxide.Ext.NoSteam
{
    public class NoSteamExtension : Extension
    {
        private bool _loaded;

        public NoSteamExtension(ExtensionManager manager) : base(manager)
        {
            Instance = this;
        }

        public override string Name => "NoSteam";

        public override VersionNumber Version => new VersionNumber(1, 0, 7);

        public override string Author => "Kaidoz";

        public static NoSteamExtension Instance { get; private set; }

        public override void Load()
        {
            if (_loaded)
                return;

            _loaded = true;
            Core.NoSteam.InitPlugin();
        }

        public override void OnModLoad()
        {
            Load();
        }
    }
}