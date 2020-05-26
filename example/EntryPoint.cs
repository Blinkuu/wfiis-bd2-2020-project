using example.application;

namespace example
{
    public class EntryPoint
    {
        private const string ConnectionString =
            @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=HierarchyDB;Integrated Security=True";

        public static void Main(string[] args)
        {
            var application = new Application();
            application.Run();
            //// Get manager
            //Console.WriteLine("Manager:");
            //Console.WriteLine(employeeDao.GetManagerByEmployeeId("2"));

            //// Get staff
            //Console.WriteLine("Staff:");
            //foreach (var e in employeeDao.GetStaffByEmployeeId("1")) Console.WriteLine(e);
        }
    }
}