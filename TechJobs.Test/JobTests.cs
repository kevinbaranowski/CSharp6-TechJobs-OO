
using System.Text;

namespace TechJobs.Tests
{
	[TestClass]
	public class JobTests
	{
        //Testing Objects
        //initalize your testing objects here
        Job job1;
        Job job2;
        Job job3;
        Job job4;
        [TestInitialize]
        public void CreateJobObjects()
        {
            job1 = new Job();

            job2 = new Job();

            job3 = new Job("Product tester", new Employer("ACME"), new Location("Desert"), new PositionType("Quality control"), new CoreCompetency("Persistence"));

            job4 = new Job("Product tester", new Employer("ACME"), new Location("Desert"), new PositionType("Quality control"), new CoreCompetency("Persistence"));
        }
        

        [TestMethod]
        public void TestSettingJobId()
        {
            Assert.IsFalse(job1.Id == job2.Id);
            Assert.IsTrue(job2.Id - job1.Id == 1);
        }
        [TestMethod]
        public void TestJobConstructorSetsAllFields()
        {
            Assert.AreEqual("Product tester", job3.Name);
            Assert.AreEqual("ACME", job3.EmployerName.Value);
            Assert.AreEqual("Desert", job3.EmployerLocation.Value);
            Assert.AreEqual("Quality control", job3.JobType.Value);
            Assert.AreEqual("Persistence", job3.JobCoreCompetency.Value);
        }
        [TestMethod]
        public void TestJobsForEquality()
        {
            Assert.IsFalse(job1.Equals(job2));
        }
        [TestMethod]
        public void TestToStringStartsAndEndsWithNewLine()
        {
            string jobToString = job1.ToString();
            StringAssert.StartsWith(jobToString, Environment.NewLine);
            StringAssert.EndsWith(jobToString, Environment.NewLine);
        }
        [TestMethod]
        public void TestToStringContainsCorrectLabelsAndData()
        {
            string job3ToString = job3.ToString();
            StringAssert.Contains(job3ToString, "ID: " + job3.Id);
            StringAssert.Contains(job3ToString, "Name: " + job3.Name);
            StringAssert.Contains(job3ToString, "Employer: " + job3.EmployerName.Value);
            StringAssert.Contains(job3ToString, "Location: " + job3.EmployerLocation.Value);
            StringAssert.Contains(job3ToString, "Position Type: " + job3.JobType.Value);
            StringAssert.Contains(job3ToString, "Core Competency: " + job3.JobCoreCompetency.Value);
        }
        [TestMethod]
        public void TestToStringHandlesEmptyField()
        {
            job3.Name = "";
            StringAssert.Contains(job3.ToString(), "Name: Data not available");
            job3.EmployerLocation.Value = null;
            StringAssert.Contains(job3.ToString(), "Location: Data not available");
        }
    }
}

