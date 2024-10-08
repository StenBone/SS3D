﻿using System.Collections.Generic;

namespace SS3D.Interactions.Interfaces
{
    /// <summary>
    /// Represents a source for an interaction.
	/// A screw driver can be a source of interaction for the opening maintenance panels, building and stabbing interactions.
    /// </summary>
    public interface IInteractionSource : INetworkObjectProvider, IGameObjectProvider
    {
        IInteractionSource Source { get; set; }

        /// <summary>
        /// Allows the source to manipulate existing interactions and add new ones
        /// </summary>
        /// <param name="targets">The interaction targets of this interaction</param>
        /// <param name="entries">The already present interactions</param>
        void CreateSourceInteractions(IInteractionTarget[] targets, List<InteractionEntry> entries);
        /// <summary>
        /// Checks if this source can interact with a certain target
        /// </summary>
        /// <param name="target">The interaction target to check against</param>
        /// <returns>If the interaction target is supported</returns>
        bool CanInteractWithTarget(IInteractionTarget target);
        /// <summary>
        /// Checks if this source can execute a given interaction
        /// </summary>
        /// <param name="interaction">The interaction to check</param>
        /// <returns>If this interaction source can execute the interaction</returns>
        bool CanExecuteInteraction(IInteraction interaction);

        /// <summary>
        /// Executes the interaction (server-side)
        /// </summary>
        /// <param name="interactionEvent">The interaction event</param>
        /// <param name="interaction">The desired interaction</param>
        /// <returns>A reference to the interaction</returns>
        InteractionReference Interact(InteractionEvent interactionEvent, IInteraction interaction);

        /// <summary>
        /// Executes the interaction (client-side)
        /// </summary>
        /// <param name="interactionEvent">The interaction event</param>
        /// <param name="interaction">The desired interaction</param>
        /// <param name="reference">The reference to the interaction (generated on server)</param>
        void ClientInteract(InteractionEvent interactionEvent, IInteraction interaction, InteractionReference reference);
        /// <summary>
        /// Cancels an interaction
        /// </summary>
        /// <param name="reference">The reference to the interaction</param>
        void CancelInteraction(InteractionReference reference);

        InteractionInstance GetInstanceFromReference(InteractionReference reference);
    }
}