using System;
using System.Collections.Generic;
using AppKit;
using BinksDisassembler.Disassembler;

namespace BinksDisassembler.UI
{
    public class InstructionRecordTableDataSource : NSTableViewDataSource
    {
        #region Public Variables
        public List<InstructionRecord> Records = new List<InstructionRecord>();
        #endregion

        #region Constructors

        #endregion

        #region Override Methods
        public override nint GetRowCount (NSTableView tableView)
        {
            return Records.Count;
        }
        #endregion
    }
}