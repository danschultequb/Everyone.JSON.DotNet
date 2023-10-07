using System.Collections.Generic;

namespace Everyone
{
    public class DocumentIterator : IteratorDecorator<char, DocumentIterator>
    {
        private int characterIndex;
        private int lineIndex;
        private int columnIndex;

        protected DocumentIterator(Iterator<char> innerIterator)
            : base(innerIterator)
        {
        }

        public static DocumentIterator Create(IEnumerable<char> characters)
        {
            Pre.Condition.AssertNotNull(characters, nameof(characters));

            return new DocumentIterator(characters.Iterate());
        }

        /// <summary>
        /// Get the character index that this <see cref="DocumentIterator"/> is currently on.
        /// </summary>
        public int CharacterIndex
        {
            get { return this.characterIndex; }
        }

        /// <summary>
        /// Get the character number that this <see cref="DocumentIterator"/> is currently on.
        /// </summary>
        public int CharacterNumber => this.CharacterIndex + 1;

        /// <summary>
        /// Get the line index that this <see cref="DocumentIterator"/> is currently on.
        /// </summary>
        public int LineIndex
        {
            get
            {
                Pre.Condition.AssertTrue(this.HasStarted(), "this.HasStarted()");

                return this.lineIndex;
            }
        }

        /// <summary>
        /// Get the line number that this <see cref="DocumentIterator"/> is currently on.
        /// </summary>
        public int LineNumber => LineIndex + 1;

        /// <summary>
        /// Get the column index that this <see cref="DocumentIterator"/> is currently on.
        /// </summary>
        public int ColumnIndex
        {
            get
            {
                Pre.Condition.AssertTrue(this.HasStarted(), "this.HasStarted()");

                return this.columnIndex;
            }
        }

        /// <summary>
        /// Get the column number that this <see cref="DocumentIterator"/> is currently on.
        /// </summary>
        public int ColumnNumber => ColumnIndex + 1;

        /// <summary>
        /// Get the <see cref="DocumentPosition"/> that this <see cref="DocumentIterator"/> is
        /// currently on.
        /// </summary>
        public DocumentPosition Position
        {
            get
            {
                Pre.Condition.AssertTrue(this.HasStarted(), "this.HasStarted()");

                return DocumentPosition.Create(
                    characterIndex: this.CharacterIndex,
                    lineIndex: this.LineIndex,
                    columnIndex: this.ColumnIndex);
            }
        }

        public override bool Next()
        {
            if (!this.HasStarted())
            {
                this.characterIndex = 0;
                this.lineIndex = 0;
                this.columnIndex = 0;
            }
            else if (this.HasCurrent())
            {
                this.characterIndex++;
                if (this.Current != '\n')
                {
                    this.columnIndex++;
                }
                else
                {
                    this.lineIndex++;
                    this.columnIndex = 0;
                }
            }

            return base.Next();
        }

        public override char TakeCurrent()
        {
            return base.TakeCurrent();
        }
    }
}
