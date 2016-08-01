using System;
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

      [Fact]
      public void HavePublishedPropertyAsSetButOnlyOneWay()
      {
         var doc = new Document();
         Assert.False(doc.Published);
         doc.Published = true;
         Assert.True(doc.Published);
         Assert.Throws(typeof(InvalidOperationException), () => { doc.Published = false; });
      }

      [Fact]
      public void HaveVerifiedLockTokenProperty()
      {
         var token = new Mock<ILockToken>();
         var doc = new Document();
         Assert.Null(doc.LockToken);
         doc.LockToken = token.Object;
         Assert.Equal(token.Object, doc.LockToken);
      }
   }
}
