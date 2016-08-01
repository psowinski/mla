namespace MlaCore
{
   public class Document : IDocument
   {
      public ILockToken LockToken { get; }

      public Document()
      {
      }

      public Document(ILockToken lockToken)
      {
         LockToken = lockToken;
      }

      public string Name { get; set; }
   }
}