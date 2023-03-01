using System;
using System.Runtime.InteropServices;

namespace EmuSak_Revive.Discord.DiscordRpcDemo
{
    public class DiscordRpc
    {
        [DllImport("discord-rpc-w32.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_Initialize")]
        public static extern void Initialize(string applicationId, ref DiscordRpc.EventHandlers handlers, bool autoRegister, string optionalSteamId);


        [DllImport("discord-rpc-w32.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_RunCallbacks")]
        public static extern void RunCallbacks();


        [DllImport("discord-rpc-w32.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_Shutdown")]
        public static extern void Shutdown();


        [DllImport("discord-rpc-w32.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_UpdatePresence")]
        public static extern void UpdatePresence(ref DiscordRpc.RichPresence presence);

        internal static void Initialize(string v1, ref object handlers, bool v2, object p)
        {
            throw new NotImplementedException();
        }

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void DisconnectedCallback(int errorCode, string message);


        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void ErrorCallback(int errorCode, string message);


        public struct EventHandlers
        {

            public DiscordRpc.ReadyCallback readyCallback;


            public DiscordRpc.DisconnectedCallback disconnectedCallback;


            public DiscordRpc.ErrorCallback errorCallback;
        }


        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void ReadyCallback();


        [Serializable]
        public struct RichPresence
        {

            public string state;


            public string details;


            public long startTimestamp;


            public long endTimestamp;


            public string largeImageKey;


            public string largeImageText;


            public string smallImageKey;


            public string smallImageText;


            public string partyId;


            public int partySize;


            public int partyMax;


            public string matchSecret;


            public string joinSecret;


            public string spectateSecret;


            public bool instance;
        }
    }
}
