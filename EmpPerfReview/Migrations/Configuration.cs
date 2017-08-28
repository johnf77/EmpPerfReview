namespace EmpPerfReview.Migrations
{
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<EmpPerfReview.Models.EmpPerfReviewContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(EmpPerfReview.Models.EmpPerfReviewContext context)
        {
            context.Employees.AddOrUpdate(x => x.Id,
                new Employee() { Id = 1, FirstName = "The", LastName = "Boss", Age=40, Gender = "Male", EmpRole = "Admin" },
                new Employee() { Id = 2, FirstName = "Joe", LastName = "Bloggs", Age = 25, Gender = "Male", EmpRole = "Employee" }
        );

            context.Reviews.AddOrUpdate(x => x.Id,
                new Review()
                {
                    Id = 1,
                    Detail = "Offered guidance and support to colleagues/peers by….Displayed a genuine interest in listening and addressing the problems shared by employees",
                    EmployeeId = 1
                },
                new Review()
                {
                    Id = 2,
                    Detail = "Displayed a genuine interest in listening and addressing the problems shared by employees",
                    EmployeeId = 2
                }
                );
        }
    }
}
