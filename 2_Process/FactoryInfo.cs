namespace Layer.Factory.Process
{
    public class FactoryInfo
    {
        public FactoryInfo(string  name)
        {
            this.Name = name;
        }

        public string Name { get; private set; }

        public bool IsOpened { get; set; }
    }
}