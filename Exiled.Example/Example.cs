// -----------------------------------------------------------------------
// <copyright file="Example.cs" company="Exiled Team">
// Copyright (c) Exiled Team. All rights reserved.
// Licensed under the CC BY-SA 3.0 license.
// </copyright>
// -----------------------------------------------------------------------

namespace Exiled.Example
{
    using Exiled.API.Features;
    using Exiled.API.Interfaces;

    /// <summary>
    /// The example plugin.
    /// </summary>
    public class Example : Plugin
    {
        private Handlers.Server server;
        private Handlers.Player player;

        /// <inheritdoc/>
        public override IConfig Config { get; } = new Config();

        /// <inheritdoc/>
        public override void OnEnabled()
        {
            RegisterEvents();

            Log.Info($"{Name} has been enabled!");
        }

        /// <inheritdoc/>
        public override void OnDisabled()
        {
            UnregisterEvents();

            Log.Info($"{Name} has been disabled!");
        }

        /// <inheritdoc/>
        public override void OnReloaded() => Log.Info($"{Name} has been reloaded!");

        /// <summary>
        /// Registers the plugin events.
        /// </summary>
        private void RegisterEvents()
        {
            server = new Handlers.Server();
            player = new Handlers.Player();

            Events.Handlers.Server.WaitingForPlayers += server.OnWaitingForPlayers;
            Events.Handlers.Server.EndingRound += server.OnEndingRound;

            Events.Handlers.Player.Died += player.OnDied;
            Events.Handlers.Player.ChangingRole += player.OnChangingRole;
        }

        /// <summary>
        /// Unregisters the plugin events.
        /// </summary>
        private void UnregisterEvents()
        {
            Events.Handlers.Server.WaitingForPlayers -= server.OnWaitingForPlayers;
            Events.Handlers.Server.EndingRound -= server.OnEndingRound;

            Events.Handlers.Player.Died -= player.OnDied;
            Events.Handlers.Player.ChangingRole -= player.OnChangingRole;

            server = null;
            player = null;
        }
    }
}
