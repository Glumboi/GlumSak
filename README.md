<div align="center">

# UI Rework in the works, updates may delay
  
<img src="https://i.imgur.com/c7783EU.png" width="312" height="100" />

Since this is an ongoing project I want to gather as much feedback as possible, thus I advise everyone to share their experience with GlumSak

[Click me to write an E-Mail to me that describes your experience!](mailto:glumboi.contact@gmail.com)
  
[Click me to read the GlumSak guide!](https://docs.google.com/document/d/1NTG5DGCiKXF14YSqPk9PfOzY69keQOmrOqjAMg0o_YY)

# News

[![github-readme-twitter](https://github-readme-twitter.gazf.vercel.app/api?id=GlumSak)](https://github.com/gazf/github-readme-twitter)
  
[![Glumboi - GlumSak](https://img.shields.io/static/v1?label=Glumboi&message=GlumSak&color=blue&logo=github)](https://github.com/Glumboi/GlumSak "Go to GitHub repo")
[![stars - GlumSak](https://img.shields.io/github/stars/Glumboi/GlumSak?style=social)](https://github.com/Glumboi/GlumSak)
[![forks - GlumSak](https://img.shields.io/github/forks/Glumboi/GlumSak?style=social)](https://github.com/Glumboi/GlumSak)
[![Twitter URL](https://img.shields.io/twitter/url/https/twitter.com/GlumSak.svg?style=social&label=Follow%20%40GlumSak)](https://twitter.com/GlumSak)


[![GitHub tag](https://img.shields.io/github/tag/Glumboi/GlumSak?include_prereleases=&sort=semver&color=blue)](https://github.com/Glumboi/GlumSak/releases/)
[![License](https://img.shields.io/badge/License-GPL20-blue)](#license)
[![issues - GlumSak](https://img.shields.io/github/issues/Glumboi/GlumSak)](https://github.com/Glumboi/GlumSak/issues)


<div align="center">

# Restart is recommended after install
  
# Changelog
   # 1.0:
     - First complete release of GlumSak
     - Added auto update feature
     - Fixed performance issues
     - Removed beta changelogs from readme
   # 1.1:
     - Added a new tab called "News" which shows you news about Yuzu and GlumSak via Twitter
     - News tab also can be used to update your installed yuzu ea version, you can also download it from there if you don't have it already
     - Source code for this version wont be available due to some cleanup I have to do first
   # 1.1.1.0:
     - Fixed an issue that lead to GlumSak crashing all the time  
   # 1.2.0.0:
     - Overhauled the way sound gets played, this is to reduce issues if the sound files aren't available
     - Removed transparency from the game actions window to improve performance when dragging the window
     - Removed the webviews in the news tab, working on a re work that takes less resources
     - Re worked the game actions window, it now uses a custom layout instead of the standard one
     - Sound files are now baked into the app's resources
   # 1.2.1.0:
     - Baked my modified version of the anon files api (unofficial) into the network part of GlumSak, 
        this is to reduce false postives (Credits to L33tMasta for giving me the idea to do that)
     - Added an ETA to the download bar
     - Changed filter icon size to 15;15
   # 1.3.0.0-Preview1:
     - Added change log to the update window
     - Added new save manager feature which sits in the game actions window
     - Fixed small bugs
     - No source code provided since its a preview and the cleanup isnt quite done yet
   # 1.3.0.2-(1.3 Preview2):
     - Updated the update changelog to be displayed in a webbrowser control, this is to display larger changelogs
     - Fixed an issue that caused GlumSak to launch in ryujinx mode even though yuzu mode was activated with the last session
   #  1.3.1.0:
     - Re made the way game meta info gets loaded (re did the python part in c#) this is to reduce potential errors
     - Lots of small performance improvements
     - Due to the new meta loading, performance may decreased by a small amount, higher ram usage is expected
     - No source code or portable version available for this build!
     - Version 1.3.0.0 got skipped, save manager will remain a somewhat preview feature though
   #  1.3.2.0:
     - Added image compression to the game buttons, this drastically reduces the ram usage and improves the main forms rendering
     - Added mediafire support for shader downloads
     - Minor performance improvements here and there
     - Reduced image button flicker when scrolling with the mouse wheel
   #  2.0.0.0
     - New GUI from the ground up in WPF
     - Fixed many bugs due to the UI being more modern
     - Fixed extreme memory usage (can be reduced furter by using the last session)
     - Fixed a Crash that lead to GlumSak crashing if the default emu Location wasnt detected
     - New color theme throughout the Project
     - This build misses minor features such as disabling the auto updating of GlumSak or the save manager, but don't worry I am on it
     - No source code for this build due to cleanup I have to make, expect the source at version 2.2
          
# I recommend to not install GlumSak in a directory that needs admin rights to acces it, it can cause multiple errors!
    
# What is GlumSak?
This project originally was a joke and I never thought that I'll do this some day.
This project is highly inspired from emusak-ui  by CapitaineJSparrow. With the difference 
that I did all the things from ground up myself. This is probably my biggest and most 
time consuming project, but I really enjoy developing it. 

A special thanks to all the people in Sin's cove that motivated me over the past 1-2 weeks 
making this project happen.

And another special thanks to Sin himself for supporting me and this project
by buying me a server to test around with and for having such a cool community.
  
# What can it do?
  - Install keys, shaders and firmwares to yuzu (shader not supported currently) and ryu with only a few clicks!
  - To select a portable install open the settings with the button on the left and select the folder of the portable Yuzu/Ryujinx make sure you select the folder that contains the filesystem folders and files, for Ryu it would be called "portable" and for Yuzu it's "user" then restart the app 
  
# Create your own paste
  [Click me to learn how to create pastes!](https://github.com/Glumboi/GlumSak-PasteCreator#how-to-use)
  
# Future plans
  [Roadmap](https://trello.com/b/NgcOhYhr/glumsak-road-map)
  
# Current supported shaders
  - All as long as you use a valid shaders file
  
# What is it written in?
  - C# Winforms in .NET Framework 4.8.1
  - A little part is written in Python
  
# UI screenshots (UI could differ from the image depending on how fast I update it)
  ![alt text](https://i.imgur.com/vzyujna.png)
  ![alt text](https://i.imgur.com/eHJjjY9.png)
  ![alt text](https://i.imgur.com/kwvJZdI.png)
  ![alt text](https://i.imgur.com/CgwzBho.png)
  ![alt text](https://i.imgur.com/HxJ6VjU.png)
  ![alt text](https://i.imgur.com/71tTgsZ.png)
  
# This is for education, use at your own risk!
  
## License

Released under [GPL-2.0](/LICENSE) by [@Glumboi](https://github.com/Glumboi).
My biggest and most fun project. 
  
Donate me via crypto (BTC): bc1qrfdct0ryhtf209z9xegqqafylyrv8ssnq5vmyu. 
My Ko-fi: https://ko-fi.com/glumboi
