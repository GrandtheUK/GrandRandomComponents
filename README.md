# PluginTemplate

This is a template for a Resonite plugin that uses Project Obsidian's custom ProtoFlux binding generator.

The plugin is marked as a Core assembly which means it will always be loaded by default when you start a session. (THIS MEANS OTHER USERS CAN'T JOIN SESSIONS YOU START UNLESS THEY HAVE THE SAME PLUGIN)

If you would like to change it, go to `Properties/AssemblyInfo.cs` and change it to Optional.
If you change it to Optional, you will need a mod to select it when you start a session: https://github.com/Nytra/ResonitePluginSelect
