using System;
using System.IO;
using AppKit;
using BinksDisassembler.Disassembler;
using BinksDisassembler.UI;
using ELFSharp.ELF;

namespace BinksDisassembler
{
    public partial class ViewController : NSViewController
    {
        private OpenRiscExecutable _disassemblyFile;
        
        public ViewController(IntPtr handle) : base(handle)
        {
        }
        
        public override void ViewDidDisappear()
        {
            base.ViewDidDisappear();
            NSApplication.SharedApplication.Terminate(this);
        }

        partial void LoadButtonClick(Foundation.NSObject sender)
        {
            var dlg = NSOpenPanel.OpenPanel;
            dlg.CanChooseFiles = true;
            dlg.CanChooseDirectories = false;
            dlg.AllowedFileTypes = new[] { "elf" };
            
            if (dlg.RunModal () == 1) {
                var path = dlg.Urls[0].Path;
                var elf = ELFReader.Load(path);
                _disassemblyFile = new OpenRiscExecutable(elf);

                var dataSource = new InstructionRecordTableDataSource {Records = _disassemblyFile.Records};

                InstructionsTableView.DataSource = dataSource;
                InstructionsTableView.Delegate = new InstructionRecordTableDelegate(dataSource);
            }
        }

        partial void SaveButtonClick(Foundation.NSObject sender)
        {
            var dlg = new NSSavePanel
            {
                Title = "Save Assembly", AllowedFileTypes = new[] {"tsv"}
            };

            if (dlg.RunModal() == 1)
            {
                using var outputFile = new StreamWriter(dlg.Url.Path);
                outputFile.WriteLine("Section\tAddress\tData\tInstruction");
                _disassemblyFile?.Write(outputFile);
            }
        }
    }
}
