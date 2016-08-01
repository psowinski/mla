namespace MlaCore
{
   public class Document : IDocument
   {
      public ILockToken LockToken { get; }

      public Document(ILockToken lockToken)
      {
         LockToken = lockToken;
      }
   }
}