using System;

namespace MlaCore
{
   public class Document : IDocument
   {
      private bool published;
      private ILockToken lockToken;

      public ILockToken LockToken
      {
         get { return lockToken; }
         set
         {
            if(this.published)
               throw new InvalidOperationException("Cannot lock published document");
            lockToken = value;
         }
      }

      public string Name { get; set; }

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