namespace Everyone
{
    public class DocumentSpan
    {
        protected DocumentSpan(DocumentPosition start, DocumentPosition end)
        {
            Pre.Condition.AssertNotNull(start, nameof(start));
            Pre.Condition.AssertNotNull(end, nameof(end));
            Pre.Condition.AssertGreaterThanOrEqualTo(end.CharacterIndex, start.CharacterIndex, $"{nameof(end)}.{nameof(end.CharacterIndex)}");
            Pre.Condition.AssertGreaterThanOrEqualTo(end.LineIndex, start.LineIndex, $"{nameof(end)}.{nameof(end.LineIndex)}");
            Pre.Condition.AssertTrue(end.LineIndex != start.LineIndex || end.ColumnIndex >= start.ColumnIndex, "end.LineIndex != start.LineIndex || end.ColumnIndex >= start.ColumnIndex");

            this.Start = start;
            this.End = end;
        }

        public static DocumentSpan Create(DocumentPosition start, DocumentPosition end)
        {
            return new DocumentSpan(start: start, end: end);
        }

        public DocumentPosition Start { get; }

        public DocumentPosition End { get; }

        public override bool Equals(object? obj)
        {
            return this.Equals(obj as DocumentSpan);
        }

        public bool Equals(DocumentSpan? rhs)
        {
            return rhs != null &&
                this.Start.Equals(rhs.Start) &&
                this.End.Equals(rhs.End);
        }

        public override int GetHashCode()
        {
            return HashCode.Get(this.Start, this.End);
        }

        public override string ToString()
        {
            return $"{{\"Start\":{this.Start.ToString()},\"End\":{this.End.ToString()}}}";
        }
    }
}
