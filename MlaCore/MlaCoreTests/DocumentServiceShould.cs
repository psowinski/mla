﻿using System;
using MlaCore;
using Moq;
using Xunit;

namespace MlaCoreTests
{
   public class DocumentServiceShould
   {
      private DocumentService docService;
      private Mock<IDocumentRepository> repository;
      private Mock<ILockToken> token;

      public DocumentServiceShould()
      {
         this.repository = new Mock<IDocumentRepository>();
         this.token = new Mock<ILockToken>();
         this.docService = new DocumentService(this.repository.Object);
      }

      [Fact]
      public void CreateDoumentOnRequest()
      {
         this.docService.CreateDocument(this.token.Object);
         this.repository.Verify(x => x.Create(this.token.Object), Times.Once);
      }

      [Fact]
      public void CheckIfDocumentIsLockBeforeDelete()
      {
         var doc = new Mock<IDocument>();
         doc.SetupGet(x => x.LockToken).Returns(this.token.Object);
         this.docService.DeleteDocument(doc.Object);
         this.repository.Verify(x => x.Delete(doc.Object));
         doc.VerifyGet(x => x.LockToken, Times.Once);
      }

      [Fact]
      public void TrowExceptionIfTryingToDeleteUnlockedDocument()
      {
         var doc = new Mock<IDocument>();
         Assert.Throws(typeof(InvalidOperationException), () => this.docService.DeleteDocument(doc.Object));
      }
   }
}
