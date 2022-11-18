namespace FinalProject
{
    public static class IdGenerator
    {
        private static int _currentId = 0;

        public static int GetNextId()
        {
            _currentId = _currentId + 1;
            return _currentId;
        }
    }
}
