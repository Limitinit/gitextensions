﻿using ICSharpCode.TextEditor.Document;

namespace GitUI.Editor
{
    public class SelectedLineEventArgs : EventArgs
    {
        public SelectedLineEventArgs(int selectedLine)
        {
            SelectedLine = selectedLine;
        }

        public int SelectedLine { get; }
    }

    public interface IFileViewer
    {
        event MouseEventHandler MouseMove;
        event EventHandler MouseEnter;
        event EventHandler MouseLeave;
        event EventHandler TextChanged;
        event EventHandler HScrollPositionChanged;
        event EventHandler VScrollPositionChanged;
        event EventHandler<SelectedLineEventArgs> SelectedLineChanged;
        event KeyEventHandler KeyDown;
        event KeyEventHandler KeyUp;
        event EventHandler DoubleClick;

        void EnableScrollBars(bool enable);
        void Find();
        Task FindNextAsync(bool searchForwardOrOpenWithDifftool);

        string GetText();
        void SetText(string text, Action? openWithDifftool);
        void SetHighlighting(string syntax);
        void SetHighlightingForFile(string filename);
        void HighlightLines(int startLine, int endLine, Color color);
        void ClearHighlighting();
        string GetSelectedText();
        int GetSelectionPosition();
        int GetSelectionLength();
        Action? OpenWithDifftool { get; }
        int VScrollPosition { get; set; }

        bool? ShowLineNumbers { get; set; }
        EolMarkerStyle EolMarkerStyle { get; set; }
        bool ShowSpaces { get; set; }
        bool ShowTabs { get; set; }
        int VRulerPosition { get; set; }
        bool IsReadOnly { get; set; }

        int GetLineFromVisualPosY(int visualPosY);
        int TotalNumberOfLines { get; }

        /// <summary>
        /// positions to the given line number.
        /// </summary>
        /// <param name="lineNumber">1..MaxLineNumber.</param>
        void GoToLine(int lineNumber);
        int MaxLineNumber { get; }

        Font Font { get; set; }

        void SetFileLoader(GetNextFileFnc fileLoader);

        /// <summary>
        /// Move the file viewer caret position to the next TextMarker found in the document that matches the AppColor.HighlightAllOccurences.
        /// </summary>
        void GoToNextOccurrence();

        /// <summary>
        /// Move the file viewer caret position to the previous TextMarker found in the document that matches the AppColor.HighlightAllOccurences.
        /// </summary>
        void GoToPreviousOccurrence();
    }
}
