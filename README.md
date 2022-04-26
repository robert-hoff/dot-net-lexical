# .NET Lexical Html Editor
.NET WebView2 HTML editor enabled by the [Lexical project](https://github.com/facebook/lexical). the idea is to achieve rich text editing in local applications developed in Visual Studio / C#. This is what the project looks like <a href="https://files.codecreation.dev/net-lexical-demo.mp4" rel=".NET Lexical video"><ins>video</ins></a>

To enable the editing the .NET application needs to connect to a modified version of Lexical which exposes a set Javascript functions on the DOM. Details about this part are in my [Lexical fork](https://github.com/robert-hoff/lexical). You can either build your own or use my  [testserver](https://net-lexical.codecreation.dev/), it has a content field that is editable via Javascript.

## Building

The project will run readily with `Visual Studio 2022` on `.NET 6.0 Runtime` and `NuGet package manager`. Open the project `DotNetLexical.sln` and hit play <kbd>F5</kbd>. [WebView2(1.0.1185.39)](https://docs.microsoft.com/en-us/dotnet/api/microsoft.web.webview2.winforms.webview2?view=webview2-dotnet-1.0.1185.39) is set up to install as a NuGet package.

I set the default server as my test server so that it works without modification. Change the `LEXICAL_WEBSERVER` variable in `Program.cs` to a server of your choice.

## Functionality

The interface offers 12 editing functions (4 buttons and 8 drop-down items). These link to Javascript commands found in `MainForm.cs`. They are recognisable as arguments to the `webView2.ExecuteScriptAsync(..)` function. The current implementation only sends message, more sophisticated interaction is possible by listening for POST messages, through `WebMessageReceived` events.

![image](https://user-images.githubusercontent.com/762237/165338552-b7bf2fe3-6f55-4706-9e33-c87bf483462d.png)

The folder icon and 2 notepad looking icons currently don't offer anything. Their intention is to open local files, and to swap between editing and source views.

## WebView2

The WebView2 control is actually a full-feature browser that renders the same as Microsoft Edge (both using Chromium). Unless disabled, WebView2 shares a similar context menu and keyboard shortcuts as Edge. <kbd>Ctrl</kbd>+<kbd>Shift</kbd>+<kbd>J</kbd> opens up the developer tools and works from within the application.

## Motivation

I've been trying to find solutions that allow work on content locally, with ability to synchonise or distribute remotely, thinking this is a nice way to work content. Probably this isn't a new idea but still I haven't found anything that suits me. I think if this project achieves some form of wiki-like editing, and perhaps could manage distribution with rsync or git, it would be a good start.

Beyond that, bringing the ability to edit structured content into local applications I think offers unique advantages. Such as linking into local folders or structuring files into text-based views, could offer interesting ways to browse or work on ones data.

<p align="left">
  <a href="https://discord.gg/yzbAw4hXr6">
    <img alt="Add yourself to our Discord" src="https://img.shields.io/discord/968141901284925490?color=%237292B6&label=Discord">
  </a>
</p>

If you find the project interesting or have any questions please join my Discord server.
