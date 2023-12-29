namespace CruZ_Engine.Demos
{
    [System.AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
    sealed class DemoNameAttribute : Attribute
    {
        readonly string demoName;
        public DemoNameAttribute(string demoName)
        {
            this.demoName = demoName;
        }

        public string DemoName
        {
            get { return demoName; }
        }
    }
}