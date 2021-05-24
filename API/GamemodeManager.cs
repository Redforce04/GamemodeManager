using Exiled.API.Interfaces;
using System.Collections.Generic;
using static Exiled.Loader.Loader;
using System.Linq;
using System.Reflection;
using System;
using Exiled.API.Features;

namespace GamemodeManager.API
{
    public static class GamemodeManager
    {
        internal static Dictionary<IPlugin<IConfig>, List<CustomGamemode>> GamemodesDict { get; } = new Dictionary<IPlugin<IConfig>, List<CustomGamemode>>();

        public static bool Loaded { get; private set; }

        public static void LoadGamemodes()
        {
            if (Loaded) { return; }

            IPlugin<IConfig>[] plugins = Plugins.ToArray();

            for (int i = 0; i < plugins.Length; i++)
            {
                Type[] pluginTypes = plugins[i].Assembly.GetTypes();

                List<Type> gamemodeTypes = new List<Type>();

                List<CustomGamemode> loadedGamemodes = new List<CustomGamemode>();

                for (int i2 = 0; i2 < pluginTypes.Length; i2++)
                {
                    // Check if derived and not duplicate type.
                    if (pluginTypes[i2].IsSubclassOf(typeof(CustomGamemode)) && !gamemodeTypes.Contains(pluginTypes[i2]))
                    {
                        gamemodeTypes.Add(pluginTypes[i2]);
                    }
                }

                for (int i2 = 0; i2 < gamemodeTypes.Count; i2++)
                {
                    // Get constructor with NO arguments.
                    ConstructorInfo ctor = gamemodeTypes[i2].GetConstructor(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, new Type[0], null);

                    if (ctor != null)
                    {
                        // Call constructor and assign CustomGamemode object.
                        CustomGamemode customGamemode = ctor.Invoke(null) as CustomGamemode;

                        bool allowLoad = true;

                        // Check for duplicates.
                        foreach (List<CustomGamemode> gamemodeList in GamemodesDict.Values)
                        {
                            foreach (CustomGamemode gamemode in gamemodeList)
                            {
                                if (gamemode.Name == customGamemode.Name && gamemode.Author == customGamemode.Author)
                                {
                                    Log.Error($"Found gamemode with duplicate name and author. Will not be loaded!\nName: {customGamemode.Name}\nAuthor: {customGamemode.Author}\nat {gamemodeTypes[i2].FullName} in plugin {plugins[i].Name} by {plugins[i].Author}");
                                    allowLoad = false;
                                    break;
                                }

                                if (gamemode.CommandPrefix == customGamemode.CommandPrefix)
                                {
                                    Log.Error($"Found gamemode with duplicate command prefix. Will not be loaded!\nName: {customGamemode.Name}\nAuthor: {customGamemode.Author}\nat {gamemodeTypes[i2].FullName} in plugin {plugins[i].Name} by {plugins[i].Author}");
                                    allowLoad = false;
                                    break;
                                }
                            }

                            if (!allowLoad) { break; }
                        }


                        // Add to list.
                        if (allowLoad)
                        { 
                            loadedGamemodes.Add(customGamemode);
                            Log.Info($"Loaded custom gamemode {customGamemode.Name} (Author: {customGamemode.Author}) at {gamemodeTypes[i2].FullName} in plugin {plugins[i].Name} by {plugins[i].Author}");
                        }
                    }
                    else
                    {
                        Log.Error($"Error loading gamemode type {gamemodeTypes[i2].FullName} in plugin {plugins[i].Name} by {plugins[i].Author}.\nThe type contained an invalid constructor and could not be generated.");
                    }
                }

                // Add to dictionary.
                GamemodesDict.Add(plugins[i], loadedGamemodes);
            }

            Loaded = true;
        }

        public static void GenerateCommands()
        {

        }
    }
}
