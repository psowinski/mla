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
   }
}
