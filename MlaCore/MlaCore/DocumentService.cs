using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MlaCore
{
   public class DocumentService
   {
      public IDocument CreateDocument(ILockToken token)
      {
         return new Document(token);
      }
   }
}
