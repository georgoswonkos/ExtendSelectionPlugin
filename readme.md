# ExtendSelectionPlugin

## Description

ExtendSelection is a Plugin for the Keepass password manager. By default when you double click on a word in the notes section at the bottom of the main window Keepass will select this word with the selection marker. However it will end the selection as soon as it reaches a special character. So it is impossible to select e.g. a whole  email address with a double click. To add insult to injury it will also select a trailing white space. This is the built-in behavior of the RichTextBox from c#. 

This plugin changes the behavior. When the user double clicks a word in the notes section of the main window the selection is expanded on the left and on the right side until a white space or an end-of-line character is reached. The white space is not included in the selection.

## Requirements

- Microsoft Windows with .NET/[Mono](http://www.mono-project.com/download/) 2.0 or newer.
- Unix/Linux with [Mono](http://www.mono-project.com/download/) 2.0 or newer.
- [KeePass](http://keepass.info). This plugin was tested with Keepass version 2.54. The DLL was compiled with .NET 4.8 in VisualStudio 2022.

## Installation

- Download the [latest](https://github.com/georgoswonkos/ExtendSelectionPlugin) release.
- Copy the ExtendSelection.dll into your KeePass Plugins directory and restart the application.

## Usage

Double click any word you like in the notes section and see the selection expand.

## Example
- Before
<p align="center"><img src="https://github.com/georgoswonkos/ExtendSelectionPlugin/blob/main/exampleBefore.png"/></p>
- After
<p align="center"><img src="https://github.com/georgoswonkos/ExtendSelectionPlugin/blob/main/exampleAfter.png"/></p>

## Repository

The main repository is hosted on [GitHub](https://github.com/georgoswonkos/ExtendSelectionPlugin).

## To-Do's:

- A double click would not only select the word but also copy it to the clipboard similar the the login and password information.
- This additional capability of copying to the clipboard could be toggled on and off via toggling a menu item.
- Apply the extend selection behavior not only to the main window but also to the password entry form object (PwEntryForm.cs).

## License
The source code in this repository is released under the Apache License, Version 3.0 license. 
