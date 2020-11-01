using System;
using AppKit;

namespace BinksDisassembler.UI
{
    public class InstructionRecordTableDelegate : NSTableViewDelegate
    {
        #region Constants 
        private const string CellIdentifier = "InstructionRecordCell";
        #endregion
        
        #region Private Variables
        private InstructionRecordTableDataSource _dataSource;
        #endregion

        #region Constructors
        public InstructionRecordTableDelegate (InstructionRecordTableDataSource datasource)
        {
            _dataSource = datasource;
        }
        #endregion
        
        #region Override Methods
        public override NSView GetViewForItem(NSTableView tableView, NSTableColumn tableColumn, nint row)
        {
            var view = (NSTextField)tableView.MakeView(CellIdentifier, this);
            
            // https://docs.microsoft.com/en-us/xamarin/mac/user-interface/table-view#populating-the-table-view
            if (view == null) {
                view = new NSTextField ();
                view.Identifier = CellIdentifier;
                view.BackgroundColor = NSColor.Clear;
                view.Bordered = false;
                view.Selectable = false;
                view.Editable = false;
            }

            view.StringValue = tableColumn.Title switch
            {
                "Section" => _dataSource.Records[(int) row].Section,
                "Address" => _dataSource.Records[(int) row].Address.ToString("x8"),
                "Instruction" => _dataSource.Records[(int) row].Instruction.ToString(),
                _ => view.StringValue
            };

            return view;
        }
        #endregion
        
    }
}