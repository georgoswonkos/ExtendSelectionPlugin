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

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;

using KeePass.Forms;
using KeePass.Plugins;
using KeePass.Resources;
using KeePass.UI;

using KeePassLib;
using KeePassLib.Security;
using KeePassLib.Utility;

// The namespace name must be the same as the file name of the
// plugin without its extension.
// For example, if you compile a plugin 'SamplePlugin.dll',
// the namespace must be named 'SamplePlugin'.
namespace ExtendSelection
{
	// Namespace name 'SamplePlugin' + 'Ext' = 'SamplePluginExt'
	public sealed class ExtendSelectionExt : Plugin
	{
		// The plugin remembers its host in this variable
		private IPluginHost m_host = null;

		private CustomRichTextBoxEx mainCustomRichTextBox;

        /// <summary>
        /// The <c>Initialize</c> method is called by KeePass when
        /// you should initialize your plugin.
        /// </summary>
        /// <param name="host">Plugin host interface. Through this
        /// interface you can access the KeePass main window, the
        /// currently opened database, etc.</param>
        /// <returns>You must return <c>true</c> in order to signal
        /// successful initialization. If you return <c>false</c>,
        /// KeePass unloads your plugin (without calling the
        /// <c>Terminate</c> method of your plugin).</returns>
        public override bool Initialize(IPluginHost host)
		{
			if(host == null) return false; // Fail; we need the host
			m_host = host;

            mainCustomRichTextBox = m_host.MainWindow.Controls.Find("m_richEntryView", true)[0] as CustomRichTextBoxEx;
            mainCustomRichTextBox.DoubleClick += this.CustomRichTextBoxEx_DoubleClick;

            return true; // Initialization successful
		}

        private void CustomRichTextBoxEx_DoubleClick(object sender, EventArgs e)
        {
			if (mainCustomRichTextBox.SelectionLength > 0)
			{
				int posStart = mainCustomRichTextBox.SelectionStart;

				// Expand left side of selection
				while (posStart > 0)
				{
					string previousChar = mainCustomRichTextBox.Text.Substring(posStart - 1, 1);
					if (previousChar == "\n" | previousChar == "\r" | previousChar == " ")
						break;

					posStart = --mainCustomRichTextBox.SelectionStart;
                    mainCustomRichTextBox.SelectionLength++;
				}

				// Delete trailing white space
				if (mainCustomRichTextBox.Text.Substring(posStart + mainCustomRichTextBox.SelectionLength - 1, 1) == " ")
				{
                    mainCustomRichTextBox.SelectionLength--;
				}

				// Expand right side of selection
				while (posStart + mainCustomRichTextBox.SelectionLength < mainCustomRichTextBox.Text.Length)
				{
					string nextChar = mainCustomRichTextBox.Text.Substring(posStart + mainCustomRichTextBox.SelectionLength, 1);
					if (nextChar == " " | nextChar == "\n" | nextChar == "\r")
					{
						break;
					}
                    mainCustomRichTextBox.SelectionLength++;
				}
			}

		}

		/// <summary>
		/// The <c>Terminate</c> method is called by KeePass when
		/// you should free all resources, close files/streams,
		/// remove event handlers, etc.
		/// </summary>
		public override void Terminate()
		{
            mainCustomRichTextBox.DoubleClick -= this.CustomRichTextBoxEx_DoubleClick;
		}

        //Keepass update check
        public override string UpdateUrl
        {
            get { return "https://github.com/georgoswonkos/ExtendSelectionPlugin/main/version.txt"; }
        }
    }
}
