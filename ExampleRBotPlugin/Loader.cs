using System;
using System.Collections.Generic;
using System.Windows.Forms;
using RBot;
using RBot.Options;
using RBot.Plugins;

namespace ExampleRBotPlugin
{
	public class Loader : RPlugin
	{
		public override string Name => "Example Plugin";
		public override string Author => "SharpTheNightmare";
		public override string Description => "Gives an example of RPlugin";

		private ToolStripItem menuItem;

		public override List<IOption> Options => new();

		public override void Load()
		{
			// This adds the plugin to the menu strip so it can be toggled on/off
			Bot.Log("Example Loaded.");
			menuItem = Forms.Main.Plugins.DropDownItems.Add("Example");
			menuItem.Click += MenuStripItem_Click;
		}

		public override void Unload()
		{
			// Unloading plugins is buggy in rbot so recommend not unloading but instead removing the plugin from the plugin folder
			// *this may be fixed in the future*
			Bot.Log("Example Unloaded.");
			menuItem.Click -= MenuStripItem_Click;
			Forms.Main.Plugins.DropDownItems.Remove(menuItem);
		}

		private void MenuStripItem_Click(object sender, EventArgs e)
		{
			// This will show/hide the example form when the menu strip button is click
			if (ExampleForm.Instance.Visible)
			{
				ExampleForm.Instance.Hide();
			}
			else
			{
				ExampleForm.Instance.Show();
				ExampleForm.Instance.BringToFront();
			}
		}
	}
}
