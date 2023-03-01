using DiscordRPC;
using DiscordRPC.Logging;
using System.Windows.Forms;
using Button = DiscordRPC.Button;

namespace EmuSak_Revive.Discord
{
    public class RichPresence
    {
        public DiscordRpcClient client;
        private bool initalized = false;

        public void UpdatePresence(
            string details,
            string state,
            string largeImageName,
            string smallImageName,
            string smallImageHoverText)
        {
            Button[] buttons =
            {
                new Button() {Label = "Github", Url = "https://github.com/Glumboi"},
                new Button() { Label = "Participate here", Url = "https://phoebe.feralhosting.com/carltschober/#" }
            };

            if (!initalized)
            {
                return;
            }
            else
            {
                client.SetPresence(new DiscordRPC.RichPresence()
                {
                    Details = details,
                    State = state,
                    Timestamps = Timestamps.Now,
                    //Buttons = buttons,
                    Assets = new Assets()
                    {
                        LargeImageKey = largeImageName,
                        LargeImageText = smallImageHoverText,
                        //SmallImageKey = smallImageName
                    }
                });
            }
        }

        public void Init()
        {
            initalized = true;
            client = new DiscordRpcClient("1041087529778167948");
            client.Initialize();
        }
    }
}