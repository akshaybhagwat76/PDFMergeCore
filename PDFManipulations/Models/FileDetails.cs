using System.Collections.Generic;

namespace PDFManipulations.Models
{
    public class FileDetails
    {
        public string FileName { get; internal set; }
        public string FilePath { get; internal set; }
        public List<ParaDetails> ParaDetails { get; internal set; }
    }

    public class ParaDetails
    {
        public string Page { get; internal set; }
        public string ParagraphNumber { get; internal set; }
        public string Details { get; internal set; }
        public string Text { get; internal set; }
    }
}
