using System.Text;

namespace Everyone
{
    /// <summary>
    /// A position within a document.
    /// </summary>
    public class DocumentPosition
    {
        protected DocumentPosition(int characterIndex, int lineIndex, int columnIndex)
        {
            Pre.Condition.AssertGreaterThanOrEqualTo(characterIndex, 0, nameof(characterIndex));
            Pre.Condition.AssertGreaterThanOrEqualTo(lineIndex, 0, nameof(lineIndex));
            Pre.Condition.AssertGreaterThanOrEqualTo(columnIndex, 0, nameof(columnIndex));

            this.CharacterIndex = characterIndex;
            this.LineIndex = lineIndex;
            this.ColumnIndex = columnIndex;
        }

        public static DocumentPosition Create(int characterIndex, int lineIndex, int columnIndex)
        {
            return new DocumentPosition(
                characterIndex: characterIndex,
                lineIndex: lineIndex,
                columnIndex: columnIndex);
        }

        /// <summary>
        /// The character index of this <see cref="DocumentPosition"/>.
        /// </summary>
        public int CharacterIndex { get; }

        /// <summary>
        /// The character number of this <see cref="DocumentPosition"/>.
        /// </summary>
        public int CharacterNumber => CharacterIndex + 1;

        /// <summary>
        /// The line index of this <see cref="DocumentPosition"/>.
        /// </summary>
        public int LineIndex { get; }

        /// <summary>
        /// The line number of this <see cref="DocumentPosition"/>.
        /// </summary>
        public int LineNumber => LineIndex + 1;

        /// <summary>
        /// The column index of this <see cref="DocumentPosition"/>.
        /// </summary>
        public int ColumnIndex { get; }

        /// <summary>
        /// The column number of this <see cref="DocumentPosition"/>.
        /// </summary>
        public int ColumnNumber => ColumnIndex + 1;

        public override bool Equals(object? obj)
        {
            return this.Equals(obj as DocumentPosition);
        }

        public bool Equals(DocumentPosition? rhs)
        {
            return rhs != null &&
                this.CharacterIndex == rhs.CharacterIndex &&
                this.LineIndex == rhs.LineIndex &&
                this.ColumnIndex == rhs.ColumnIndex;
        }

        public override int GetHashCode()
        {
            return HashCode.Get(this.CharacterIndex, this.LineIndex, this.ColumnIndex);
        }

        public override string ToString()
        {
            return $"{{{nameof(CharacterIndex).Quote()}:{this.CharacterIndex},{nameof(LineIndex).Quote()}:{this.LineIndex},{nameof(ColumnIndex).Quote()}:{this.ColumnIndex}}}";
        }
    }
}
