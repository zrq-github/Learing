namespace 建议46_显式释放资源
{
    internal class AnotherResource : IDisposable
    {
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}