using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MlaCore;
using Moq;
using Xunit;

namespace MlaCoreTests
{
   public class DocumentServiceShould
   {
      [Fact]
      public void CreateDoumentOnRequest()
      {
         var docService = new DocumentService();
         var token = new Mock<ILockToken>();
         Assert.NotNull(docService.CreateDocument(token.Object));
      }
   }
}
