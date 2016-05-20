# CSGO-Localised-String-Replacer

## Description
A simple tool that replaces CSGO's localised strings with strings from a user-created file. Useful for customising colours of chat notifications (e.g. money awarded) for languages other than English.

## Requirements
- Windows operating system
- .NET Framework 4.5.2 or later
- CSGO (probably works with other Source games or any similarily-structured file)

## Instructions
1. Create an INI file and specify the names of the strings to replace and their values in the following format:
  ```
  Name="Value"
  ```
  For example:
  ```
  SFUI_Lobby_StatusRichPresence_competitive_lobby="MM lobby"
  SFUI_Lobby_StatusRichPresence_competitive_game="MM -"
  ```
2. Open a command prompt at the location of `CSGO-Localised-String-Replacer.exe` and run the program, specifying the location of the locale file and the INI file. For example:
  ```
  C:\> CSGO-Localised-String-Replacer.exe "C:\Program Files (x86)\Steam\steamapps\common\Counter-Strike Global Offensive\csgo\csgo_english.txt" "C:\strings.ini"
  ```

## Credits

Mark Kozlov

Nima Shoghi

