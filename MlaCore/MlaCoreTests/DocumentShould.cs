using MlaCore;
using Moq;
using Xunit;

namespace MlaCoreTests
{
   public class DocumentShould
   {
      [Fact]
      public void HaveLockTokenUsedToCreateIt()
      {
         var token = new Mock<ILockToken>();
         var doc = new Document(token.Object);
         Assert.Equal(token.Object, doc.LockToken);
      }

      [Fact]
      public void HaveNamePropertyAsSet()
      {
         const string name = "Doc";
         var doc = new Document();
         Assert.True(string.IsNullOrEmpty(doc.Name));
         doc.Name = name;
         Assert.Equal(name, doc.Name);
      }
   }
}
