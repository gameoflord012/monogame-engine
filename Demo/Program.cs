using System.Reflection;

namespace CruZ.Demos
{
    class Program
    {
        public static void Main(string[] args)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();

            var demoClasses = assembly.GetTypes()
                .Where(type => type.GetCustomAttribute(typeof(DemoNameAttribute), true) != null);

            foreach(var demoClass in demoClasses)
            {
                var attribute = demoClass.GetCustomAttribute(typeof(DemoNameAttribute)) as DemoNameAttribute;
                if(attribute != null && attribute.DemoName == args[0])
                {
                    var demoConstructor = demoClass.GetConstructor(Type.EmptyTypes);

                    if (demoConstructor == null)
                    {
                        throw new Exception("No default constructor found in demo");
                    }

                    demoConstructor.Invoke(new object[] { });
                    break;
                }
            }
        }
    }
}