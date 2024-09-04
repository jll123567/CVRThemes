using System;
using System.IO;
using MelonLoader;
using BTKUILib;

namespace CVRThemes
{
    public class Main: MelonMod
    {
        public override void OnInitializeMelon()
        {
            string gameDir = Directory.GetCurrentDirectory();
            string themesDir = gameDir + "\\UserData\\CVRThemes";

            string quickCSS;

            try  // Try and get the custom css and load it.
            {
                
                using (StreamReader stream = new StreamReader(themesDir+"\\quick.css") ?? throw new InvalidOperationException())
                {
                    quickCSS = stream.ReadToEnd();
                }

                QuickMenuAPI.InjectCSSStyle(quickCSS);
                LoggerInstance.Msg("Loaded and applied theme!");
            }
            catch (FileNotFoundException)
            {
                LoggerInstance.Error("Failed to find `quick.css`.\nDid you install the themes correctly to ChilloutVR/UserData/CVRThemes?");
            }
            catch (DirectoryNotFoundException)
            {
                Directory.CreateDirectory(themesDir);
                LoggerInstance.Error("Failed to find CVRThemes folder, so I just made it in <CVR Install>/UserData/CVRThemes.\n Put your themes here and restart the game.");
            }
            catch (InvalidOperationException)
            {
                LoggerInstance.Error("Unknown Error: Tell JillTheSomething to figure out why `StreamReader stream = new StreamReader(gameDir + <CSSPath>)` returned null.\n");
            }

        }
    }
}
