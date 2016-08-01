using System;

namespace MlaCore
{
   public class Document : IDocument
   {
      public ILockToken LockToken { get; set; }

      public Document()
      {
      }

      public Document(ILockToken lockToken)
      {
         LockToken = lockToken;
      }

      public string Name { get; set; }

      private bool published;

      /// <summary>
      /// Property can be set to true, but never to false again
      /// </summary>
      public bool Published
      {
         get { return this.published; }
         set
         {
            if(this.published && !value)
               throw new InvalidOperationException("Published property can only be set to true");
            this.published = value;
         }
      }
   }
}