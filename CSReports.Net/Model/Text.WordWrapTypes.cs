namespace CSReports.Model
{
    public partial class Text
    {
        public enum WordWrapTypes : byte
        {
            //
            // Summary:
            //     Text wrapping between lines when formatting within a rectangle is disabled.
            None,
            //
            // Summary:
            //     Text is wrapped by words. If there is a word that is longer than bounds' width,
            //     this word is wrapped by characters.
            Word,
            //
            // Summary:
            //     Text is wrapped by words. If there is a word that is longer than bounds' width,
            //     it won't be wrapped at all and the process will be finished.
            WordOnly,
            //
            // Summary:
            //     Text is wrapped by characters. In this case the word at the end of the text line
            //     can be split.
            Character,
            //
            // Summary:
            //     Text is wrapped by soft hyphen. In this case the word has reached its maximum
            //     length, it looks for a soft hyphen within the word and wraps the word accordingly
            //     using the soft hyphen.
            DiscretionaryHyphen
        }
    }
}