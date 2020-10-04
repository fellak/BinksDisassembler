// WARNING
//
// This file has been generated automatically by Visual Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace BinksDisassembler
{
	[Register ("ViewController")]
	partial class ViewController
	{
		[Outlet]
		AppKit.NSTableView InstructionsTableView { get; set; }

		[Outlet]
		AppKit.NSButton LoadButton { get; set; }

		[Outlet]
		AppKit.NSButton SaveButton { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (InstructionsTableView != null) {
				InstructionsTableView.Dispose ();
				InstructionsTableView = null;
			}

			if (LoadButton != null) {
				LoadButton.Dispose ();
				LoadButton = null;
			}

			if (SaveButton != null) {
				SaveButton.Dispose ();
				SaveButton = null;
			}
		}
	}
}
