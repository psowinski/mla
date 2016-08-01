namespace MlaCore
{
   public interface IDocumentRepository
   {
      IDocument Create(ILockToken token);
      void Delete(IDocument document);
      bool Lock(ILockToken token, IDocument document);
      void Unlock(IDocument document);
   }
}