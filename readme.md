# LightsOn 

## The Game 
This is a C# Maui implementation of the [Lights Out](https://en.wikipedia.org/wiki/Lights_Out_(game)) game.

The goal is to make all of the buttons on the board the same color.  Hitting a button toggles the button itself, and each button above, below, and to the left and right.

In this implementation, the board starts from a solved state and the computer randomly toggles buttons to make the game board.  Because each move is reversable, that is hitting a button twice is the same as not hitting it at all, each randomly generated board can be solved.

The first level of difficulty increase comes from increasing the number of starting moves.  The second level of difficulty increase comes from increasing the number of colors that pressing a button will show.  That is, instead of having an on and and off there is an off (dark), a middle on state (medium), and a fully on state (light).  As the colors can be cycled through adding colors does not impact the boards solvability.

## Dependencies

The app is written in C# using Maui.

On a Mac:

* [Visual Studio Code](https://code.visualstudio.com/download)
* [Maui](https://dotnet.microsoft.com/en-us/apps/maui)

To build the iOS app

* [XCode](https://learn.microsoft.com/en-us/dotnet/maui/get-started/first-app?view=net-maui-9.0&tabs=vswin&pivots=devices-ios)

To build the Android app

* [Android](https://learn.microsoft.com/en-us/dotnet/maui/get-started/first-app?view=net-maui-9.0&tabs=vswin&pivots=devices-android)

## TO DO

* Put Reset and Solve behind a Help menu
* Format the starting page
* Add a tutorial
* Add icon and splash screen
* Allow color customization
* Script the repo setup


