﻿using Coimbra;
using System.Collections.Generic;
using UnityEngine;

namespace SS3D.Engine.Chat
{
    [CreateAssetMenu(fileName = "New Chat Channels", menuName = "SS3D/UI/Chat/Channels")]
    [ProjectSettings("SS3D/Assets", "Chat Channels")]
    public class ChatChannels : ScriptableSettings
    {
        public List<ChatChannel> allChannels = new List<ChatChannel>();
        public ChatChannel allSystemMessagesChannel;
        public ChatChannel inGameSystemMessagesChannel;
        public ChatChannel stationAlertsChannel;

        public List<ChatChannel> GetHidableChannels() => allChannels.FindAll(channel => channel.Hidable);
        
        public List<ChatChannel> GetUnhidableChannels() => allChannels.FindAll(channel => !channel.Hidable);
    }
}