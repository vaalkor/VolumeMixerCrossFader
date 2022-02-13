namespace CrossMixer
{
    public class ListElement
    {
        private readonly string _displayName;

        public ListElement(string displayName, int sessionIndex)
        {
            _displayName = displayName;
            SessionIndex = sessionIndex;
        }

        public int SessionIndex { get; }

        public override string ToString() => _displayName;
    }
}
