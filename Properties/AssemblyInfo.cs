/*
  SamplePlugin - An Example KeePass Plugin
  Copyright (C) 2003-2019 Dominik Reichl <dominik.reichl@t-online.de>

  This program is free software; you can redistribute it and/or modify
  it under the terms of the GNU General Public License as published by
  the Free Software Foundation; either version 2 of the License, or
  (at your option) any later version.

  This program is distributed in the hope that it will be useful,
  but WITHOUT ANY WARRANTY; without even the implied warranty of
  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
  GNU General Public License for more details.

  You should have received a copy of the GNU General Public License
  along with this program; if not, write to the Free Software
  Foundation, Inc., 51 Franklin St, Fifth Floor, Boston, MA  02110-1301  USA
*/

using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// General assembly properties
[assembly: AssemblyTitle("Extend Selection Plugin")]
[assembly: AssemblyDescription("Extend the selection until you reach a white space when you double click on a word in the notes field")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("Georg Winkel")]
[assembly: AssemblyProduct("KeePass Plugin")]
[assembly: AssemblyCopyright("Copyright © 2025 Georg Winkel")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]

// COM settings
[assembly: ComVisible(false)]

// Assembly GUID
[assembly: Guid("1cb02044-8fc3-40f7-9b0f-29cce2aaa840")]

// Assembly version information
[assembly: AssemblyVersion("1.0.2.0")]
[assembly: AssemblyFileVersion("1.0.2.0")]
