using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MlaCore
{
   public class DocumentService
   {
      private readonly IDocumentRepository repository;

      public DocumentService(IDocumentRepository repository)
      {
         this.repository = repository;
      }

      public IDocument CreateDocument(ILockToken token)
      {
         return this.repository.Create(token);
      }

      public void DeleteDocument(IDocument document)
      {
         if(document.Published)
            throw new InvalidOperationException("Cannot delete published document.");
         this.repository.Delete(document);
      }
   }
}
